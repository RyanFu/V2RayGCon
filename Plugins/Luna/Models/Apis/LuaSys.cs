﻿using NLua;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VgcApis.Libs.Sys;

namespace Luna.Models.Apis
{
    public class LuaSys :
        VgcApis.BaseClasses.Disposable,
        VgcApis.Interfaces.Lua.ILuaSys
    {
        readonly object procLocker = new object();
        private readonly LuaApis luaApis;
        private readonly Func<List<Type>> getAllAssemblies;

        List<Process> processes = new List<Process>();

        List<VgcApis.Interfaces.Lua.ILuaMailBox>
            mailboxs = new List<VgcApis.Interfaces.Lua.ILuaMailBox>();

        ConcurrentDictionary<string, Tuple<KeyboardHook, VgcApis.Interfaces.Lua.ILuaMailBox>>
            kbHooks = new ConcurrentDictionary<string, Tuple<KeyboardHook, VgcApis.Interfaces.Lua.ILuaMailBox>>();

        static readonly SysCmpos.PostOffice postOffice = new SysCmpos.PostOffice();

        public LuaSys(LuaApis luaApis, Func<List<Type>> getAllAssemblies)
        {
            this.luaApis = luaApis;
            this.getAllAssemblies = getAllAssemblies;
        }

        #region private methods

        void SendLogHandler(object sender, DataReceivedEventArgs args)
        {
            string msg = null;
            try
            {
                msg = args.Data;
            }
            catch { }

            if (msg == null)
            {
                return;
            }

            luaApis.SendLog(msg);
        }

        void TrackdownProcess(Process proc)
        {
            lock (procLocker)
            {
                if (processes.Contains(proc))
                {
                    return;
                }
                processes.Add(proc);
            }
            VgcApis.Libs.Sys.ChildProcessTracker.AddProcess(proc);
        }
        #endregion

        #region ILluaSys.Hotkey
        public string GetAllKeyNames()
        {
            return string.Join(@", ", Enum.GetNames(typeof(Keys)));
        }

        KeyboardHook CreateKeyboardHook(
            string keyName, bool hasCtrl, bool hasShift, bool hasAlt, Action onKeyPressed)
        {
            if (!(hasCtrl || hasShift || hasAlt)
                || !Enum.TryParse(keyName, out Keys hotkey))
            {
                return null;
            }

            ModifierKeys modifier = (hasCtrl ? ModifierKeys.Control : 0)
                | (hasAlt ? ModifierKeys.Alt : 0)
                | (hasShift ? ModifierKeys.Shift : 0);

            var kbHook = new KeyboardHook();
            kbHook.KeyPressed += (s, a) => onKeyPressed();
            try
            {
                kbHook.RegisterHotKey((uint)modifier, (uint)hotkey);
                return kbHook;
            }
            catch { }
            return null;
        }

        public bool UnregisterHotKey(VgcApis.Interfaces.Lua.ILuaMailBox mailbox)
        {
            if (mailbox == null)
            {
                return false;
            }

            if (kbHooks.TryRemove(mailbox.GetAddress(), out var hm))
            {
                hm.Item1.Dispose();
                postOffice.RemoveMailBox(hm.Item2);
                return true;
            }
            return false;
        }

        public VgcApis.Interfaces.Lua.ILuaMailBox RegisterHotKey(
            string keyName, bool hasAlt, bool hasCtrl, bool hasShift)
        {
            var mailbox = postOffice.ApplyRandomMailBox();
            if (mailbox == null)
            {
                return null;
            }

            var addr = mailbox.GetAddress();
            Action onKeyPressed = () => mailbox.SendState(addr, true);
            KeyboardHook kbHook = null;
            try
            {
                kbHook = CreateKeyboardHook(keyName, hasCtrl, hasShift, hasAlt, onKeyPressed);
                if (kbHook != null)
                {
                    var item = new Tuple<KeyboardHook, VgcApis.Interfaces.Lua.ILuaMailBox>(kbHook, mailbox);
                    if (kbHooks.TryAdd(addr, item))
                    {
                        return mailbox;
                    }
                }
            }
            catch { }

            postOffice.RemoveMailBox(mailbox);

            if (kbHooks != null && !kbHooks.Keys.Contains(addr))
            {
                kbHook.Dispose();
            }
            return null;
        }
        #endregion

        #region ILuaSys.Reflection
        public string GetPublicInfosOfType(Type type)
        {
            var pmi = VgcApis.Misc.Utils.GetPublicFieldsInfoOfType(type);
            var pfi = VgcApis.Misc.Utils.GetPublicMethodsInfoOfType(type);
            return $"{pmi}\n\n{pfi}";
        }

        public string GetPublicInfosOfObject(object @object)
        {
            return GetPublicInfosOfType(@object.GetType());
        }

        public string GetPublicInfosOfAssembly(string @namespace, string asm)
        {
            var types = getAllAssemblies();
            foreach (var type in types)
            {
                if (type.Namespace == @namespace && type.Name == asm)
                {
                    return GetPublicInfosOfType(type);
                }
            }
            return null;
        }

        public string GetChildrenInfosOfNamespace(string @namespace)
        {
            List<string> mbs = new List<string>();

            var asms = getAllAssemblies();
            foreach (var asm in asms)
            {
                if (asm.Namespace != @namespace || mbs.Contains(asm.Name))
                {
                    continue;
                }
                mbs.Add(asm.FullName);
            }
            return string.Join("\n", mbs);
        }


        #endregion

        #region ILuaSys.PostOffice
        public VgcApis.Interfaces.Lua.ILuaMailBox CreateMailBox(string name)
        {
            var mailbox = postOffice.CreateMailBox(name);
            if (mailbox == null)
            {
                return null;
            }

            lock (procLocker)
            {
                if (!mailboxs.Contains(mailbox))
                {
                    mailboxs.Add(mailbox);
                    return mailbox;
                }
            }

            return null;
        }

        #endregion

        #region ILuaSys.Process
        public void DoEvents() => Application.DoEvents();

        public void WaitForExit(Process proc) => proc?.WaitForExit();

        public void Cleanup(Process proc) => proc?.Close();

        public void Kill(Process proc)
        {
            try
            {
                if (!HasExited(proc))
                {
                    VgcApis.Misc.Utils.KillProcessAndChildrens(proc.Id);
                }
            }
            catch { }
        }

        public bool CloseMainWindow(Process proc)
        {
            if (proc == null)
            {
                return false;
            }
            return proc.CloseMainWindow();
        }

        public bool HasExited(Process proc)
        {
            if (proc == null)
            {
                return true;
            }

            try
            {
                return proc.HasExited;
            }
            catch { }
            return true;
        }

        public bool SendStopSignal(Process proc) => VgcApis.Misc.Utils.SendStopSignal(proc);

        public Process Run(string exePath) =>
            Run(exePath, null);

        public Process Run(string exePath, string args) =>
            Run(exePath, args, null);

        public Process Run(string exePath, string args, string stdin) =>
            Run(exePath, args, stdin, null, true, false);


        public Process Run(string exePath, string args, string stdin,
            LuaTable envs, bool hasWindow, bool redirectOutput)
        {
            var useStdIn = !string.IsNullOrEmpty(stdin);
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = args,
                    CreateNoWindow = !hasWindow,
                    UseShellExecute = false,
                    RedirectStandardInput = useStdIn,
                    RedirectStandardError = redirectOutput,
                    RedirectStandardOutput = redirectOutput,
                }
            };

            if (redirectOutput)
            {
                p.Exited += (s, a) =>
                {
                    p.ErrorDataReceived -= SendLogHandler;
                    p.OutputDataReceived -= SendLogHandler;
                };

                p.ErrorDataReceived += SendLogHandler;
                p.OutputDataReceived += SendLogHandler;
            }

            if (envs != null)
            {
                VgcApis.Misc.Utils.SetProcessEnvs(p, Misc.Utils.LuaTableToDictionary(envs));
            }

            p.Start();
            TrackdownProcess(p);

            if (redirectOutput)
            {
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
            }

            if (useStdIn)
            {
                var input = p.StandardInput;
                var buff = Encoding.UTF8.GetBytes(stdin);
                input.BaseStream.Write(buff, 0, buff.Length);
                input.WriteLine();
                input.Close();
            }

            return p;
        }
        #endregion

        #region ILuaSys.System
        static string osReleaseId;
        public string GetOsReleaseInfo()
        {
            if (string.IsNullOrEmpty(osReleaseId))
            {
                // https://stackoverflow.com/questions/39778525/how-to-get-windows-version-as-in-windows-10-version-1607/39778770
                var root = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                var name = Microsoft.Win32.Registry.GetValue(root, @"ProductName", @"")?.ToString();
                var arch = Environment.Is64BitOperatingSystem ? @"x64" : @"x86";
                var id = Microsoft.Win32.Registry.GetValue(root, @"ReleaseId", "")?.ToString();
                var build = Microsoft.Win32.Registry.GetValue(root, @"CurrentBuildNumber", @"")?.ToString();

                osReleaseId = $"{name} {arch} {id} build {build}";
            }
            return osReleaseId;
        }

        public string GetOsVersion() => Environment.OSVersion.VersionString;

        public int SetWallpaper(string filename) => Libs.Sys.WinApis.SetWallpaper(filename);
        #endregion

        #region ILuaSys.File
        public string GetImageResolution(string filename) =>
           VgcApis.Misc.Utils.GetImageResolution(filename);

        public string PickRandomLine(string filename) =>
            VgcApis.Misc.Utils.PickRandomLine(filename);

        public bool IsFileExists(string path) => File.Exists(path);
        public bool IsDirExists(string path) => Directory.Exists(path);

        public bool CreateFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch { }
            return false;
        }
        #endregion

        #region public methods

        public void OnSignalStop()
        {
            RemoveAllKeyboardHooks();
            CloseAllMailBox();
        }

        #endregion

        #region private methods

        private void KillAllProcesses()
        {
            List<Process> ps;
            lock (procLocker)
            {
                ps = processes.ToList();
                processes.Clear();
            }
            foreach (var p in ps)
            {
                try
                {
                    if (!p.HasExited)
                    {
                        VgcApis.Misc.Utils.KillProcessAndChildrens(p.Id);
                    }
                }
                catch { }
            }
        }

        void CloseAllMailBox()
        {
            List<VgcApis.Interfaces.Lua.ILuaMailBox> boxes;
            lock (procLocker)
            {
                boxes = mailboxs.ToList();
                mailboxs.Clear();
            }

            foreach (var box in boxes)
            {
                postOffice.RemoveMailBox(box);
            }
        }

        void RemoveAllKeyboardHooks()
        {
            var keys = kbHooks.Keys;
            foreach (var key in keys)
            {
                if (!kbHooks.TryRemove(key, out var kbHook))
                {
                    continue;
                }
                kbHook.Item1.Dispose();
                postOffice.RemoveMailBox(kbHook.Item2);
            }
        }
        #endregion

        #region protected methods
        protected override void Cleanup()
        {
            RemoveAllKeyboardHooks();
            CloseAllMailBox();
            KillAllProcesses();
        }

        #endregion
    }
}