﻿using AutocompleteMenuNS;
using ScintillaNET;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Luna.Libs.LuaSnippet
{
    internal sealed class BestMatchSnippets :
        IEnumerable<AutocompleteItem>
    {
        Scintilla editor;
        string searchPattern = @"";

        List<ApiFunctionSnippets> apiFunctions;
        List<LuaFuncSnippets> luaFunctions;
        List<LuaKeywordSnippets> luaKeywords;
        List<LuaSubFuncSnippets> luaSubFunctions;
        private readonly List<LuaImportClrSnippets> luaImportClrs;

        public BestMatchSnippets(
            Scintilla editor,
            string searchPattern,
            List<ApiFunctionSnippets> apiFunctions,
            List<LuaFuncSnippets> luaFunctions,
            List<LuaKeywordSnippets> luaKeywords,
            List<LuaSubFuncSnippets> luaSubFunctions,
            List<LuaImportClrSnippets> luaImportClrs)
        {
            this.searchPattern = searchPattern;
            this.editor = editor;
            this.apiFunctions = apiFunctions;
            this.luaFunctions = luaFunctions;
            this.luaKeywords = luaKeywords;
            this.luaSubFunctions = luaSubFunctions;
            this.luaImportClrs = luaImportClrs;
        }

        #region private methods
        private IEnumerable<AutocompleteItem> BuildList()
        {
            var fragment = VgcApis.Misc.Utils.GetFragment(
                editor, searchPattern);

            List<MatchItemBase> items = GenMatchItemList(fragment);

            var table = new Dictionary<MatchItemBase, long>();
            foreach (var item in items)
            {
                var marks = item.MeasureSimilarityCi(fragment);
                if (marks > 0)
                {
                    table.Add(item, marks);
                }
            }

            var sorted = table
                .OrderBy(kv => kv.Value)
                .ThenBy(kv => kv.Key.GetLowerText())
                .Select(kv => kv.Key as AutocompleteItem)
                .ToList();

            //return autocomplete items
            foreach (var item in sorted)
                yield return item;
        }

        #endregion

        #region private methods
        List<MatchItemBase> GenMatchItemList(string fragment)
        {
            var items = new List<MatchItemBase>();
            if (fragment.Contains(":"))
            {
                items.AddRange(apiFunctions);
            }
            else if (fragment.Contains("."))
            {
                if (fragment.Contains("("))
                {
                    items.AddRange(luaImportClrs);
                }
                items.AddRange(luaSubFunctions);
            }
            else if (fragment.Contains("("))
            {
                items.AddRange(luaImportClrs);
                items.AddRange(luaFunctions);
            }
            else
            {
                items.AddRange(luaKeywords);
            }

            return items;
        }
        #endregion

        #region IEnumerable thinggy
        public IEnumerator<AutocompleteItem> GetEnumerator() =>
            BuildList().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
