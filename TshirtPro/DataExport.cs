using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Threading;

namespace TshirtPro
{
    public class DataExport
    {
        public DataTable dtExport = new DataTable();
        public string CategoryIds { get; set; }
        public string ItemProducts { get; set; }
        public string ItemPrices { get; set; }
        public string ItemColors { get; set; }
        public string Sides { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string SaleGoal { get; set; }
        public string DayLimit { get; set; }

        public DataExport()
        {
            dtExport.Columns.Add("Filenames", typeof(string));
            dtExport.Columns.Add("Sides", typeof(string));
            dtExport.Columns.Add("Position", typeof(string));
            dtExport.Columns.Add("Name", typeof(string));
            dtExport.Columns.Add("Description", typeof(string));
            dtExport.Columns.Add("Draft", typeof(string));
            dtExport.Columns.Add("Slug", typeof(string));
            dtExport.Columns.Add("SaleGoal", typeof(string));
            dtExport.Columns.Add("HideGoal", typeof(string));
            dtExport.Columns.Add("DaysLimit", typeof(string));
            dtExport.Columns.Add("InMarketplace", typeof(string));
            dtExport.Columns.Add("AutoRelaunch", typeof(string));
            dtExport.Columns.Add("CategoryIds", typeof(string));
            dtExport.Columns.Add("ItemsPrices", typeof(string));
            dtExport.Columns.Add("ItemsProduct", typeof(string));
            dtExport.Columns.Add("ItemsColors", typeof(string));
            dtExport.Columns.Add("UpsellCategory", typeof(string));
            dtExport.Columns.Add("UpsellAmount", typeof(string));
            dtExport.Columns.Add("UpsellCurrency", typeof(string));
        }

        public void ClearData()
        {
            dtExport.Rows.Clear();
        }

        public void AddItem(string fileName, string name)
        {
            DataRow dr = dtExport.NewRow();
            dr["Filenames"] = fileName;
            dr["Sides"] = Sides;
            dr["Position"] = Position;
            dr["Name"] = name;
            dr["Description"] = Description;
            dr["Draft"] = "false";
            dr["Slug"] = GenerateSlug(name);
            dr["SaleGoal"] = SaleGoal;
            dr["HideGoal"] = "false";
            dr["DaysLimit"] = DayLimit;
            dr["InMarketplace"] = "true";
            dr["AutoRelaunch"] = "true";
            dr["CategoryIds"] = CategoryIds;
            dr["ItemsPrices"] = ItemPrices;
            dr["ItemsProduct"] = ItemProducts;
            dr["ItemsColors"] = ItemColors;
            dr["UpsellCategory"] = "";
            dr["UpsellAmount"] = "";
            dr["UpsellCurrency"] = "";

            dtExport.Rows.Add(dr);
        }

        private string GenerateSlug(string name)
        {
            string slug = Globals.RemoveSpecialCharacter(name);
            int maxIndex = slug.Length > 40 ? 40 : slug.Length;
            slug = slug.Substring(0, maxIndex);
            slug += GetRandomizeString(9);

            return slug.ToLower();
        }

        private string GetRandomizeString(int length)
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
            result = result.PadRight(9);
            return result;
        }

        public void ExportToExcel(string directory, int rowCount, string dirName)
        {
            Random rd = new Random();
            DataTable dtTemp = dtExport.Copy();
            dtTemp.Columns[0].ColumnName = "Filenames*";
            dtTemp.Columns[1].ColumnName = "Sides*";
            dtTemp.Columns[3].ColumnName = "Name*";
            dtTemp.Columns[4].ColumnName = "Description*";
            dtTemp.Columns[5].ColumnName = "Draft*";
            dtTemp.Columns[6].ColumnName = "Slug*";
            dtTemp.Columns[7].ColumnName = "Sales goal*";
            dtTemp.Columns[8].ColumnName = "Hide goal*";
            dtTemp.Columns[9].ColumnName = "Days limit*";
            dtTemp.Columns[10].ColumnName = "In marketplace*";
            dtTemp.Columns[11].ColumnName = "Auto relaunch*";
            dtTemp.Columns[12].ColumnName = "Category ids";
            dtTemp.Columns[13].ColumnName = "Items prices*";
            dtTemp.Columns[14].ColumnName = "Items product references*";
            dtTemp.Columns[15].ColumnName = "Items colors*";
            dtTemp.Columns[16].ColumnName = "Upsell category";
            dtTemp.Columns[17].ColumnName = "Upsell amount";
            dtTemp.Columns[18].ColumnName = "Upsell currency";

            string filePath = string.Format(@"{0}\{1}.xlsx", directory, dirName);

            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Import");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(dtTemp, true);
                for(int i = 1; i <= 18; i++)
                {
                    ws.Column(i).AutoFit();
                }

                string range = "E1:E" + (rowCount + 1).ToString();
                //Format the header for column 1-3
                using (ExcelRange rng = ws.Cells[range])
                {
                    //rng.Style.Font.Bold = true;
                    //rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    //rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    //rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.WrapText = true;
                }

                Stream stream = File.Create(filePath);
                pck.SaveAs(stream);
                stream.Position = 0;
                stream.Close();
            }

            dtExport.Rows.Clear();
        }
    }
}
