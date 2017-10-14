using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace TshirtPro
{
    public class KeywordCategory
    {
        public string Keyword { get; set; }
        public string Category { get; set; }
        public string OriginText { get; set; }
        public KeywordCategory(string key, string cate, string full)
        {
            Keyword = key;
            Category = cate;
            OriginText = full;
        }
    }

    public static class Globals
    {
        public static string RemoveSpecialCharacter(string name)
        {
            string result = "";

            result = name.Replace(" ", "-");
            result = result.Replace(">", "-");
            result = Regex.Replace(result, "[^0-9a-zA-Z-]+", "");
            result = Regex.Replace(result, "-+", "-");
            result = result.Trim('-');

            return result;
        }

        public static string GetRandomizeString(int length)
        {
            long lastTimeStamp = DateTime.UtcNow.Ticks;
            long original, newValue;
            do
            {
                original = lastTimeStamp;
                long now = DateTime.UtcNow.Ticks;
                newValue = Math.Max(now, original + 1);
            } while (Interlocked.CompareExchange
                         (ref lastTimeStamp, newValue, original) != original);

            string result = newValue.ToString();
            result = result.Substring(result.Length > length ? result.Length - length : 0);
            return result;
        }
    }
}
