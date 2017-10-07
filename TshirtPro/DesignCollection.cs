using System.Collections.Generic;

namespace TshirtPro
{
    public class DesignCollection
    {
        public int TotalImage = 0;
        public int SuccessCount = 0;
        public int ErrorCount = 0;
        public List<ImgDesign> ListUrl = new List<ImgDesign>();
        public Dictionary<string, string> ListIds = new Dictionary<string, string>(); 

        public void RefreshData()
        {
            TotalImage = 0;
            SuccessCount = 0;
            ErrorCount = 0;
            ListUrl.Clear();
            ListIds.Clear();
        }

        public ImgDesign AddNewImage(string id, string name)
        {
            ImgDesign img = new ImgDesign(id, name, ListUrl.Count);
            ListUrl.Add(img);
            TotalImage++;

            return img;
        }
    }
}
