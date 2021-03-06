﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Luna.Models.Apis.Components
{
    public sealed class Misc :
        VgcApis.BaseClasses.ComponentOf<LuaApis>,
        VgcApis.Interfaces.Lua.ILuaMisc
    {
        Services.Settings settings;
        VgcApis.Interfaces.Services.IUtilsService vgcUtils;
        VgcApis.Interfaces.Services.IShareLinkMgrService vgcSlinkMgr;
        VgcApis.Interfaces.Services.INotifierService vgcNotifier;
        VgcApis.Interfaces.Services.IServersService vgcServer;
        VgcApis.Interfaces.Services.ISettingsService vgcSettings;

        public Misc(
            Services.Settings settings,
            VgcApis.Interfaces.Services.IApiService api)
        {
            this.settings = settings;
            vgcNotifier = api.GetNotifierService();
            vgcUtils = api.GetUtilsService();
            vgcSlinkMgr = api.GetShareLinkMgrService();
            vgcServer = api.GetServersService();
            vgcSettings = api.GetSettingService();
        }


        #region ILuaMisc.WinForms
        public void ShowFormMain() => vgcNotifier.ShowFormMain();

        public void ShowFormLog() => vgcNotifier.ShowFormLog();

        public void ShowFormQrcode() => vgcNotifier.ShowFormQrcode();

        #endregion

        #region ILuaMisc.Json
        public bool TrySetDoubleValue(JToken json, string path, double value) =>
            vgcUtils.TrySetValue(json, path, value);

        public bool TrySetIntValue(JToken json, string path, int value) =>
            vgcUtils.TrySetValue(json, path, value);

        public bool TrySetBoolValue(JToken json, string path, bool value) =>
            vgcUtils.TrySetValue(json, path, value);

        public bool TrySetStringValue(JToken json, string path, string value) =>
            vgcUtils.TrySetValue(json, path, value);

        public string GetString(JToken json, string path) =>
            vgcUtils.GetValue<string>(json, path);

        public bool GetBool(JToken json, string path) =>
            vgcUtils.GetValue<bool>(json, path);

        public int GetInt(JToken json, string path) =>
            vgcUtils.GetValue<int>(json, path);

        public double GetDouble(JToken json, string path) =>
            vgcUtils.GetValue<double>(json, path);

        public JToken GetKey(JToken json, string path) =>
           vgcUtils.GetKey(json, path);

        public string GetProtocol(JObject config) =>
            vgcUtils.GetProtocol(config);

        public void CombineWithRoutingInFront(JObject body, JObject mixin) =>
            vgcUtils.CombineWithRoutingInFront(body, mixin);

        public void CombineWithRoutingInTheEnd(JObject body, JObject mixin) =>
            vgcUtils.CombineWithRoutingInTheEnd(body, mixin);

        public void Merge(JObject body, JObject mixin) =>
            vgcUtils.Merge(body, mixin);

        public JArray ParseJArray(string json) =>
            vgcUtils.ParseJArray(json);

        public JObject ParseJObject(string json) =>
            vgcUtils.ParseJObject(json);

        public JToken ParseJToken(string json) =>
            vgcUtils.ParseJToken(json);

        public void Replace(JToken node, JToken value) =>
            vgcUtils.Replace(node, value);

        public JArray ToJArray(JToken jtoken) =>
            vgcUtils.ToJArray(jtoken);

        public JObject ToJObject(JToken jtoken) =>
            vgcUtils.ToJObject(jtoken);

        public void Union(JObject body, JObject mixin) =>
            vgcUtils.Union(body, mixin);

        public string JTokenToString(JToken jtoken) =>
            vgcUtils.JTokenToString(jtoken);
        #endregion

        #region ILuaMisc.ImportLinks     
        public int ImportLinks(string links, string mark)
        {
            var pair = new string[] { links, mark ?? "" };
            var linkList = new List<string[]> { pair };
            var decoders = vgcSlinkMgr.GenDecoderList(false);
            var results = vgcSlinkMgr.ImportLinksBatchMode(linkList, decoders);

            GetSibling<VgcApis.Interfaces.Lua.ILuaServer>()
                .UpdateAllSummary();

            var count = 0;
            foreach (var result in results)
            {
                if (VgcApis.Misc.Utils.IsImportResultSuccess(result))
                {
                    count++;
                }
            }
            return count;
        }
        #endregion

        #region ILuaMisc.Forms

        public string ShowData(string title, NLua.LuaTable columns, NLua.LuaTable rows, int defColumn)
        {
            var dt = LuaTableToDataTable(columns, rows);
            return ShowDataGridDialog(title, dt, defColumn);
        }

        public string ShowData(string title, NLua.LuaTable columns, NLua.LuaTable rows) =>
            ShowData(title, columns, rows, -1);

        public string BrowseFolder() => VgcApis.Misc.UI.ShowSelectFolderDialog();

        public string BrowseFile() =>
            VgcApis.Misc.UI.ShowSelectFileDialog(
                VgcApis.Models.Consts.Files.AllExt);

        public string BrowseFile(string filter) =>
                VgcApis.Misc.UI.ShowSelectFileDialog(filter);

        public string Input(string title) => Input(title, 3);

        public string Input(string title, int lines) => Input(title, string.Empty, lines);

        public string Input(string title, string content, int lines)
        {
            DialogResult ok = DialogResult.Cancel;
            string r = null;
            using (var form = Views.WinForms.FormInput.CreateForm(title, content, lines))
            {
                VgcApis.Misc.UI.Invoke(() =>
                {
                    ok = form.ShowDialog();
                    r = form.result;
                });
            }
            return ok == DialogResult.OK ? r : null;
        }

        public List<int> Choices(string title, NLua.LuaTable choices) =>
            Choices(title, choices, false);

        public List<int> Choices(string title, NLua.LuaTable choices, bool isShowKey)
        {
            var list = global::Luna.Misc.Utils.LuaTableToList(choices, isShowKey);
            return GetResultFromChoicesDialog(title, list.ToArray());
        }

        public List<int> Choices(string title, params string[] choices) =>
            GetResultFromChoicesDialog(title, choices);

        public int Choice(string title, NLua.LuaTable choices) =>
            Choice(title, choices, false, -1);

        public int Choice(string title, NLua.LuaTable choices, bool isShowKey) =>
            Choice(title, choices, isShowKey, -1);

        public int Choice(string title, NLua.LuaTable choices, bool isShowKey, int selected)
        {
            var list = global::Luna.Misc.Utils.LuaTableToList(choices, isShowKey);
            return GetResultFromChoiceDialog(title, list.ToArray(), selected);
        }

        public int Choice(string title, params string[] choices) =>
            GetResultFromChoiceDialog(title, choices, -1);

        public bool Confirm(string content) =>
            VgcApis.Misc.UI.Confirm(content);

        public void Alert(string content) =>
            MessageBox.Show(content, VgcApis.Misc.Utils.GetAppName());

        #endregion

        #region other ILuaMisc thinggy

        public string Replace(string text, string oldStr, string newStr) =>
            text?.Replace(oldStr, newStr);

        public string RandomHex(int len) => VgcApis.Misc.Utils.RandomHex(len);

        public string NewGuid() => Guid.NewGuid().ToString();

        public string GetSubscriptionConfig() => vgcSettings.GetSubscriptionConfig();

        public long GetTimeoutValue() => VgcApis.Models.Consts.Core.SpeedtestTimeout;

        public void RefreshFormMain() => vgcServer.RequireFormMainReload();

        public void WriteLocalStorage(string key, string value) =>
          settings.SetLuaShareMemory(key, value);

        public string ReadLocalStorage(string key) =>
            settings.GetLuaShareMemory(key);

        public bool RemoveLocalStorage(string key) =>
            settings.RemoveShareMemory(key);

        public List<string> LocalStorageKeys() =>
            settings.ShareMemoryKeys();

        public string Config2VeeLink(string config)
        {
            try
            {
                return vgcSlinkMgr.EncodeConfigToShareLink(
                config, VgcApis.Models.Datas.Enums.LinkTypes.v);
            }
            catch { }
            return null;
        }

        public string Config2VmessLink(string config)
        {
            try
            {
                return vgcSlinkMgr.EncodeConfigToShareLink(
                config, VgcApis.Models.Datas.Enums.LinkTypes.vmess);
            }
            catch { }
            return null;
        }

        public string Config2V2cfg(string config)
        {
            try
            {
                return vgcSlinkMgr.EncodeConfigToShareLink(
                config, VgcApis.Models.Datas.Enums.LinkTypes.v2cfg);
            }
            catch { }
            return null;
        }

        public string ShareLink2ConfigString(string shareLink)
        {
            try
            {
                return vgcSlinkMgr.DecodeShareLinkToConfig(shareLink) ?? @"";
            }
            catch { }
            return null;
        }

        public string AddVeePrefix(string b64Str) =>
           vgcUtils.AddLinkPrefix(b64Str, VgcApis.Models.Datas.Enums.LinkTypes.v);

        public string AddVmessPrefix(string b64Str) =>
           vgcUtils.AddLinkPrefix(b64Str, VgcApis.Models.Datas.Enums.LinkTypes.vmess);

        public string AddV2cfgPrefix(string b64Str) =>
           vgcUtils.AddLinkPrefix(b64Str, VgcApis.Models.Datas.Enums.LinkTypes.v2cfg);

        /// <summary>
        /// null: failed
        /// </summary>
        public string Base64Encode(string text) =>
            vgcUtils.Base64Encode(text);

        /// <summary>
        /// null: failed
        /// </summary>
        public string Base64Decode(string b64Str) =>
            vgcUtils.Base64Decode(b64Str);

        public string GetLinkBody(string link) =>
            vgcUtils.GetLinkBody(link);

        public string PredefinedFunctions() =>
            Resources.Files.Datas.LuaPredefinedFunctions;

        public string ScanQrcode() =>
            vgcUtils.ScanQrcode();

        public string GetAppDir() => VgcApis.Misc.Utils.GetAppDir();

        public void Sleep(int milSec) => VgcApis.Misc.Utils.Sleep(milSec);

        public void Print(params object[] contents)
        {
            var text = "";
            foreach (var content in contents)
            {
                if (content == null)
                {
                    text += @"nil";
                }
                else
                {
                    text += content.ToString();
                }
            }
            GetParent().SendLog(text);
        }
        #endregion

        #region private methods
        List<Type> GetTypesFromRows(NLua.LuaTable rows)
        {
            if (rows == null)
            {
                return null;
            }

            var ts = new List<Type>();
            foreach (var row in rows.Values)
            {
                foreach (var cell in (row as NLua.LuaTable).Values)
                {
                    ts.Add(cell.GetType());
                }
                return ts;
            }
            return null;
        }

        DataTable LuaTableToDataTable(NLua.LuaTable columns, NLua.LuaTable rows)
        {
            var d = new DataTable();

            if (columns == null)
            {
                return d;
            }

            var ts = GetTypesFromRows(rows);

            var idx = 0;
            foreach (var column in columns.Values)
            {
                var name = column.ToString();
                if (ts == null)
                {
                    d.Columns.Add(name);
                }
                else
                {
                    d.Columns.Add(name, ts[idx++]);
                }
            }

            if (rows == null)
            {
                return d;
            }
            var rowsKey = rows.Keys;
            foreach (var rowkey in rowsKey)
            {
                var row = rows[rowkey] as NLua.LuaTable;
                var items = new List<object>();
                foreach (var item in row.Values)
                {
                    items.Add(item);
                }

                d.Rows.Add(items.ToArray());
            }
            return d;
        }

        string ShowDataGridDialog(string title, DataTable dataSource, int defColumn)
        {
            DialogResult result = DialogResult.Cancel;
            string r = null;
            using (var form = Views.WinForms.FormDataGrid.CreateForm(title, dataSource, defColumn))
            {
                VgcApis.Misc.UI.Invoke(() =>
                {
                    result = form.ShowDialog();
                    r = form.jsonResult;
                });
            }
            return result == DialogResult.OK ? r : null;
        }

        private static List<int> GetResultFromChoicesDialog(string title, string[] choices)
        {
            DialogResult ok = DialogResult.Cancel;
            List<int> r = null;
            using (var form = Views.WinForms.FormChoices.CreateForm(title, choices))
            {
                VgcApis.Misc.UI.Invoke(() =>
                {
                    ok = form.ShowDialog();
                    r = form.results;
                });
            }
            return ok == DialogResult.OK ? r : new List<int>();
        }

        private static int GetResultFromChoiceDialog(string title, string[] choices, int selected)
        {
            DialogResult ok = DialogResult.Cancel;
            int idx = 0;
            using (var form = Views.WinForms.FormChoice.CreateForm(title, choices, selected))
            {
                VgcApis.Misc.UI.Invoke(() =>
                {
                    ok = form.ShowDialog();
                    idx = form.result;
                });
            }
            return ok == DialogResult.OK ? idx : -1;
        }

        #endregion
    }
}
