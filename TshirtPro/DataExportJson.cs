using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace TshirtPro
{
    public class DataExportJson
    {
        public List<JsonItem> ListItem;
        public string Category { get; set; }
        public DataExportJson()
        {
            ListItem = new List<JsonItem>();
        }

        public void ClearData()
        {
            ListItem.Clear();
        }

        public void AddItem(ImgDesign img)
        {
            string slug = GenerateSlug(Category, img.Name);
            ListItem.Add(new JsonItem(img.FileName, img.Name, slug, Category));
        }

        private string GenerateSlug(string category, string name)
        {
            string slug = string.Format("{0}-{1}", category, name);
            slug = Globals.RemoveSpecialCharacter(slug);
            int maxIndex = slug.Length > 40 ? 40 : slug.Length;
            slug = slug.Substring(0, maxIndex);
            slug += "-" + Globals.GetRandomizeString(9);

            return slug.ToLower();
        }

        public void ExportToJson(string directory, int rowCount, string dirName)
        {
            string filePath = string.Format(@"{0}\{1}.json", directory, dirName);
            //open file stream
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, ListItem);
            }

            ListItem.Clear();
        }
    }

    public class JsonItem
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Category { get; set; }
        public bool Uploaded { get; set; }

        public JsonItem(string fileName, string title, string slug, string category)
        {
            FileName = fileName;
            Title = title;
            Slug = slug;
            Category = category;
            Uploaded = false;
        }
    }
}
