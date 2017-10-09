using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TshirtPro
{
    public class Category
    {
        public string Category_id { get; set; }
        public string Category_name { get; set; }
    }

    public class RootObject
    {
        public List<Category> Categories { get; set; }
    }

    public static class Globals
    {
        public static string RemoveSpecialCharacter(string name)
        {
            string result = "";

            result = name.Replace(" ", "-");
            result = Regex.Replace(result, "[^0-9a-zA-Z-]+", "");
            result = Regex.Replace(result, "-+", "-");
            result = result.Trim('-');

            return result;
        }
    }
}
