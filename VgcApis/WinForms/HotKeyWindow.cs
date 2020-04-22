﻿using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VgcApis.WinForms
{
    public class HotKeyWindow : NativeWindow, IDisposable
    {
        #region WinAPI
        const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion


        ConcurrentDictionary<uint, Action> handlers = new ConcurrentDictionary<uint, Action>();
        ConcurrentDictionary<string, Tuple<int, uint>> contexts = new ConcurrentDictionary<string, Tuple<int, uint>>();
        int currentEvCode = 0;


        public HotKeyWindow()
        {
            this.CreateHandle(new CreateParams());
        }

        #region private methods


        #endregion

        #region public methods


        public string RegisterHotKey(
            Action hotKeyHandler,
            string keyName, bool hasAlt, bool hasCtrl, bool hasShift)
        {
            var evCode = currentEvCode++;

            if (!Misc.Utils.TryParseKeyMesssage(keyName, hasAlt, hasCtrl, hasShift,
                out uint modifier, out uint key))
            {
                return null;
            }

            var hkMsg = (uint)((key << 16) | modifier);

            if (handlers.Keys.Contains(hkMsg))
            {
                return null;
            }

            if (!RegisterHotKey(Handle, evCode, (uint)modifier, (uint)key))
            {
                return null;
            }

            do
            {
                var hkHandle = Guid.NewGuid().ToString();
                if (!contexts.Keys.Contains(hkHandle))
                {
                    var hkParma = new Tuple<int, uint>(evCode, hkMsg);
                    contexts.TryAdd(hkHandle, hkParma);
                    handlers.TryAdd(hkMsg, hotKeyHandler);
                    return hkHandle;
                }
            } while (true);
        }

        public bool UnregisterHotKey(string hotKeyHandle)
        {
            if (!string.IsNullOrEmpty(hotKeyHandle)
                && contexts.TryRemove(hotKeyHandle, out var context))
            {
                var evCode = context.Item1;
                var keyMsg = context.Item2;
                handlers.TryRemove(keyMsg, out var _);
                return UnregisterHotKey(this.Handle, evCode);
            }

            return false;
        }

        protected override void WndProc(ref Message m)
        {
            // check if we got a hot key pressed.
            if (m.Msg == WM_HOTKEY
                && handlers.TryGetValue((uint)m.LParam, out var handler))
            {
                try
                {
                    handler?.Invoke();
                }
                catch { }
            }

            base.WndProc(ref m);
        }
        #endregion

        #region IDisposable Support
        bool isDisposed = false;
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (isDisposed)
                    {
                        return;
                    }
                    var handles = contexts.Keys;
                    foreach (var handle in handles)
                    {
                        UnregisterHotKey(handle);
                    }
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~MsgWindow()
        // {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}