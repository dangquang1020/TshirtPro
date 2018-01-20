using System;

namespace TshirtPro
{
    public class ImgDesign
    {
        string imageUrlTpl = "https://image.spreadshirtmedia.com/image-server/v1/designs/{designId},width=1200,height=1200.png";
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public bool Success { get; set; }
        public int Index { get; set; }

        public ImgDesign(string id, string name, int index)
        {
            Random rd = new Random();
            Id = id;
            Name = name;
            Url = imageUrlTpl.Replace("{designId}", id);
            FileName = string.Format("{0}-{1}.png", id, Globals.GetRandomizeString(3));
            Success = false;
            Index = index;
        }

        public ImgDesign(string id, string url, string name, int index)
        {
            Random rd = new Random();
            Id = id;
            Name = name;
            Url = url;
            FileName = string.Format("{0}.png", Globals.GetRandomizeString(9));
            Success = false;
            Index = index;
        }
    }
}
