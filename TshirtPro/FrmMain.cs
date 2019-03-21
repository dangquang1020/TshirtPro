using HtmlAgilityPack;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace TshirtPro
{
    public partial class FrmMain : Form
    {
        string Sdomain = "https://www.spreadshirt.com/";
        string Tdomain = "https://www.threadless.com/search/?q=";

        string saveToDirectory;
        string keyWord = string.Empty;
        int maxPage = 0;
        int currentPage = 0;
        int imgPerDir = 100;
        bool isPause = false;
        int currentIndex = 0;
        int dlSource = 2;
        int maxPageThreadless = 200;
        string browserContent = string.Empty;

        List<KeywordCategory> categories;
        DataExportJson dataExportJson;
        DesignCollection dsCollection;
        HtmlWeb web;
        BackgroundWorker bwCollectImage;
        BackgroundWorker bwDownloadImage;
        ManualResetEvent pause;
        List<SourcePage> sourcePages;
        WebBrowser browser;
        List<string> tmKeys;

        public FrmMain()
        {
            InitializeComponent();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12
        | SecurityProtocolType.Ssl3;

            browser = new WebBrowser();
            categories = new List<KeywordCategory>();
            tmKeys = new List<string>();
            web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36";
            web.UseCookies = true;
            pause = new ManualResetEvent(true);
            dsCollection = new DesignCollection();
            dataExportJson = new DataExportJson();
            bwCollectImage = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            bwDownloadImage = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            Load += FrmMain_Load;
            bwCollectImage.RunWorkerCompleted += BwCollectImage_RunWorkerCompleted;
            bwCollectImage.ProgressChanged += BwCollectImage_ProgressChanged;
            bwCollectImage.DoWork += BwCollectImage_DoWorkAsync;
            bwDownloadImage.RunWorkerCompleted += BwDownloadImage_RunWorkerCompleted;
            bwDownloadImage.ProgressChanged += BwDownloadImage_ProgressChanged;
            bwDownloadImage.DoWork += BwDownloadImage_DoWork;
            btnBrowse.Click += BtnBrowse_Click;
            btnOpen.Click += BtnOpen_Click;
            btnStart.Click += BtnStart_Click;
            btnPause.Click += BtnPause_Click;

            SetSourcePageDataSource();
        }

        private void SetSourcePageDataSource()
        {
            sourcePages = new List<SourcePage>();
            for (int i = 0; i < 3; i++)
            {
                string name = "";
                switch (i)
                {
                    case 0:
                        name = "SpreadShirt";
                        break;
                    case 1:
                        name = "ThreadLess";
                        break;
                    case 2:
                        name = "All";
                        break;
                }
                SourcePage s = new SourcePage(name, i);
                sourcePages.Add(s);
            }

            cbSourcePage.DataSource = sourcePages;
            cbSourcePage.DisplayMember = "Name";
            cbSourcePage.ValueMember = "Value";
            cbSourcePage.SelectedValue = 1;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            isPause = !isPause;
            if (isPause)
            {
                btnPause.Text = "Tiếp Tục";
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = "Tạm dừng";
                btnPause.ImageIndex = 2;
                pause.Reset();
            }
            else
            {
                btnPause.Text = "Tạm Dừng";
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = "Đang chạy ...";
                btnPause.ImageIndex = 1;
                pause.Set();
            }

        }

        private void InitNewSearch()
        {
            txtPagePercent.Text = "0/0";
            txtSuccess.Text = "0";
            txtError.Text = "0";
            txtImageCount.Text = "0";

            isPause = false;
            pause.Set();
            lvImage.Items.Clear();
            dsCollection.RefreshData();
            maxPage = 0;
            currentPage = 0;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (categories.Count > 0)
            {
                RunDownloadList(0);
            }
            else
            {
                if (string.IsNullOrEmpty(txtKeyWord.Text))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thiếu thông tin", MessageBoxButtons.OK);
                }
                else
                {
                    bool isContinue = true;
                    if (lvImage.Items.Count > 0)
                    {
                        if (MessageBox.Show("Xóa dữ liệu trên danh sách và tiếp tục ?", "Xóa danh sách", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            isContinue = false;
                        }
                    }

                    if (isContinue)
                    {
                        InitDataExport();
                        InitNewSearch();
                        keyWord = txtKeyWord.Text.Replace(" ", "+");
                        dlSource = int.Parse(cbSourcePage.SelectedValue.ToString());
                        saveToDirectory = txtDirectoryPath.Text;
                        imgPerDir = int.Parse(nuImgPerDir.Value.ToString());
                        lblStatus.ForeColor = Color.Blue;
                        lblStatus.Text = "Đang chạy ...";

                        ProcessControl(true);
                        bwCollectImage.RunWorkerAsync();
                    }
                }
            }
        }

        private void RunDownloadList(int index)
        {
            bool isContinue = true;
            currentIndex = index;
            if (currentIndex == 0 && lvImage.Items.Count > 0)
            {
                if (MessageBox.Show("Xóa dữ liệu trên danh sách và tiếp tục ?", "Xóa danh sách", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    isContinue = false;
                }
            }

            if (!isContinue)
            {
                return;
            }

            txtCategory.Text = categories[currentIndex].Category;
            txtKeyWord.Text = categories[currentIndex].Keyword;
            string dirPath = Application.StartupPath + Path.DirectorySeparatorChar + categories[currentIndex].Keyword;
            txtDirectoryPath.Text = dirPath;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            InitDataExport();
            InitNewSearch();
            keyWord = txtKeyWord.Text.Replace(" ", "+");
            dlSource = int.Parse(cbSourcePage.SelectedValue.ToString());
            saveToDirectory = txtDirectoryPath.Text;
            imgPerDir = int.Parse(nuImgPerDir.Value.ToString());
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Text = "Đang chạy ...";
            lvKeyword.Items[currentIndex].ForeColor = Color.Blue;
            lvKeyword.Items[currentIndex].Selected = true;

            ProcessControl(true);
            bwCollectImage.RunWorkerAsync();
        }

        private void InitDataExport()
        {
            dataExportJson.Category = txtCategory.Text;
        }

        private void ProcessControl(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnPause.Enabled = isRunning;
            btnBrowse.Enabled = !isRunning;
            btnOpen.Enabled = !isRunning;
            txtKeyWord.Enabled = !isRunning;
            cbSourcePage.Enabled = !isRunning;
            pbProgress.Enabled = !isRunning;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Application.StartupPath;
                ofd.Filter = "txt files (*.txt)|*.txt";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        lvKeyword.Items.Clear();
                        categories.Clear();
                        string[] lines = File.ReadAllLines(ofd.FileName);
                        foreach (string line in lines)
                        {
                            string[] arr = line.Split(';');
                            if (arr.Length > 1)
                            {
                                KeywordCategory cate = new KeywordCategory(arr[0].Trim(), arr[1].Trim(), line);
                                categories.Add(cate);
                                lvKeyword.Items.Add(line);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = saveToDirectory;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    saveToDirectory = fbd.SelectedPath;
                    txtDirectoryPath.Text = saveToDirectory;
                }
            }
        }

        private void BwDownloadImage_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                lblStatus.Text = "Bắt đầu tải hình ảnh ...";
                Random rd = new Random();
                string keyWordFormat = Globals.RemoveSpecialCharacter(keyWord);

                if (dsCollection.TotalImage <= imgPerDir)
                {
                    SaveImageAndExportJson(saveToDirectory, 0, dsCollection.TotalImage, keyWordFormat);
                }
                else
                {
                    int totalDirectory = 0;
                    if (dsCollection.TotalImage % imgPerDir == 0)
                    {
                        totalDirectory = (dsCollection.TotalImage / imgPerDir);
                    }
                    else
                    {
                        totalDirectory = (dsCollection.TotalImage / imgPerDir) + 1;
                    }

                    for (int i = 0; i < totalDirectory; i++)
                    {
                        try
                        {
                            string dirName = string.Format("{0}-{1}", keyWordFormat, i.ToString());
                            if (Directory.Exists(dirName))
                            {
                                dirName += rd.Next(1, 100);
                            }

                            string dirPath = string.Format(@"{0}\{1}", saveToDirectory, dirName);
                            Directory.CreateDirectory(dirPath);
                            int start = i * imgPerDir;
                            int end = start + imgPerDir;
                            SaveImageAndExportJson(dirPath, start, end, dirName);
                        }
                        catch (Exception ex)
                        {
                            ShowError(ex.Message);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void SaveImageAndExportJson(string directory, int start, int end, string dirName)
        {
            if (start >= dsCollection.TotalImage)
            {
                return;
            }

            if (end > dsCollection.TotalImage)
            {
                end = dsCollection.TotalImage;
            }

            using (WebClient client = new WebClient())
            {
                for (; start < end; start++)
                {
                    pause.WaitOne();

                    bool downloadSuccess = true;
                    ImgDesign item = dsCollection.ListUrl.ElementAt(start);
                    string fullPath = string.Format("{0}\\{1}", directory, item.FileName);
                    if (File.Exists(fullPath))
                    {
                        Random rd = new Random();
                        if (!string.IsNullOrEmpty(item.Id))
                        {
                            item.FileName = string.Format("{0}-{1}.png", item.Id, rd.Next(1, 100));
                        }
                        else
                        {
                            item.FileName = string.Format("{0}-{1}.png", item.FileName, rd.Next(1, 100));
                        }

                        fullPath = string.Format("{0}\\{1}", directory, item.FileName);
                    }

                    try
                    {
                        client.Headers.Add("user-agent", "Only a test!");
                        client.DownloadFile(item.Url, fullPath);
                        dataExportJson.AddItem(item);
                        dsCollection.SuccessCount++;
                        item.Success = true;
                    }
                    catch (Exception ex)
                    {
                        dsCollection.ErrorCount++;
                        downloadSuccess = false;
                        ShowError(ex.Message);
                    }

                    bwDownloadImage.ReportProgress(start + 1, downloadSuccess);
                }
            }

            dataExportJson.ExportToJson(directory, imgPerDir, dirName);
        }

        private void BwDownloadImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                pbProgress.Value = CalculatePercent(e.ProgressPercentage, dsCollection.TotalImage);
                txtSuccess.Text = dsCollection.SuccessCount.ToString();
                txtError.Text = dsCollection.ErrorCount.ToString();

                if (lvKeyword.Items.Count > 0)
                {
                    lvKeyword.Items[currentIndex].Text = string.Format("{0} === {1}/{2}", categories[currentIndex].OriginText, dsCollection.SuccessCount + dsCollection.ErrorCount, dsCollection.TotalImage);
                }

                int index = e.ProgressPercentage - 1;
                lvImage.EnsureVisible(index);
                if (bool.Parse(e.UserState.ToString()))
                {
                    ListViewItem item = lvImage.Items[index];
                    item.ForeColor = Color.Green;
                }
                else
                {
                    ListViewItem item = lvImage.Items[index];
                    item.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void BwDownloadImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Đã tải xong.";
            ProcessControl(false);

            currentIndex++;
            if (currentIndex < categories.Count)
            {
                RunDownloadList(currentIndex);
            }
        }

        private void ShowError(string message)
        {
            Invoke(new MethodInvoker(delegate
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = message;
            }));
        }

        private void BwCollectImage_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (dlSource == 2 || dlSource == 1)
                {
                    DownloadFromThreadLess();
                }

                if (dlSource == 2 || dlSource == 0)
                {
                    DownloadFromSpreadShirtAsync();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void DownloadFromThreadLess()
        {
            string url = Tdomain + keyWord;
            int totalPage = 1;
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            //url = "https://www.teezily.com/en-gb/marketplace?utf8=%E2%9C%93&query=dog";
            //HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            HtmlNode container = doc.DocumentNode.SelectSingleNode("//*[@id='hits-container']");
            //Get total page
            HtmlNode nav = doc.DocumentNode.SelectSingleNode("//*[@id='search-results-grid']/div[2]/nav/ul/li[8]/a");
            if (nav != null)
            {
                if (!string.IsNullOrEmpty(nav.InnerText))
                {
                    int.TryParse(nav.InnerText, out totalPage);
                    totalPage = totalPage > maxPageThreadless ? maxPageThreadless : totalPage;
                }
            }

            maxPage += totalPage;
            //totalPage = 1;

            for (int i = 1; i <= totalPage; i++)
            {
                currentPage++;
                if (i != 1)
                {
                    url = Tdomain + keyWord + "&page=" + i.ToString();
                    doc = web.Load(url);
                }

                IEnumerable<HtmlNode> nodes = doc.DocumentNode.Descendants("div").Where(div => div.HasClass("media-card")).ToArray();
                if (nodes != null)
                {
                    foreach (HtmlNode child in nodes)
                    {
                        pause.WaitOne();

                        HtmlNode node = child.SelectSingleNode("./div[1]/a/img");
                        string name = node.GetAttributeValue("alt", "");
                        string[] src = node.GetAttributeValue("src", "").Split('?');
                        string imgUrl = src.Length > 0 ? src[0] : "";

                        HtmlNode ownerNode = child.SelectSingleNode("./div[2]/div/div/p[1]/a");
                        string owner = ownerNode != null ? ownerNode.InnerText.Trim() : "";

                        if (!dsCollection.ListIds.ContainsKey(imgUrl))
                        {
                            if (!string.IsNullOrEmpty(imgUrl) && imgUrl.EndsWith(".png") && !owner.Contains("@"))
                            {
                                if (!ContainTradeMarkKey(name))
                                {
                                    ImgDesign img = dsCollection.AddNewImageThreadLess($"{imgUrl}?v=4", name);
                                    bwCollectImage.ReportProgress(i, img);
                                    dsCollection.ListIds.Add(imgUrl, name);
                                }
                            }
                        }
                    }
                }

                bwCollectImage.ReportProgress(i);
            }
        }

        private bool ContainTradeMarkKey(string title)
        {
            bool isContain = false;

            isContain = tmKeys.Any(title.ToLower().Contains);

            return isContain;
        }

        private async void DownloadFromSpreadShirtAsync()
        {
            for (int i = 1; i <= 10; i++)
            {
                currentPage++;
                string url = Sdomain + keyWord + "+gifts?page=" + i.ToString();

                string getResp = await GetStringFromUrl(url);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                //Convert the Raw HTML into an HTML Object
                doc.LoadHtml(getResp);

                HtmlNode parent = doc.DocumentNode.SelectSingleNode("//*[@id='articleTileList']");
                if (parent == null)
                {
                    continue;
                }
                IEnumerable<HtmlNode> nodes = parent.SelectNodes("./div").ToArray();

                if (nodes != null)
                {
                    foreach (HtmlNode child in nodes)
                    {
                        pause.WaitOne();

                        HtmlNode node = child.FirstChild;
                        IEnumerable<HtmlNode> imgList = node.Descendants("img");
                        HtmlNode imgNode = imgList.ElementAtOrDefault(0);
                        string link = imgNode.GetAttributeValue("src", "");

                        string designId = GetDesignIdOfSpreadShirt(link);
                        if (!dsCollection.ListIds.ContainsKey(designId))
                        {
                            string name = node.ChildNodes.ElementAt(1).InnerText.Trim();
                            if (!string.IsNullOrEmpty(designId))
                            {
                                ImgDesign img = dsCollection.AddNewImage(designId, name);
                                //bwCollectImage.ReportProgress(i, img);
                                dsCollection.ListIds.Add(designId, name);
                            }
                        }
                    }
                }

                bwCollectImage.ReportProgress(i);
            }
        }

        private async Task<string> GetStringFromUrl(string url)
        {
            var getResp = await url
                .WithHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36")
                .GetStringAsync();
            return getResp;
        }

        private string GetDesignIdOfSpreadShirt(string imgSrc)
        {
            string designId = string.Empty;

            try
            {
                int sIndex = imgSrc.IndexOf("products/");
                int eIndex = imgSrc.IndexOf("/views");
                if (sIndex == -1 || eIndex == -1) return designId;

                imgSrc = imgSrc.Substring(sIndex + 9, eIndex - sIndex - 9);

                bool beginId = false;
                for (int i = imgSrc.Length - 1; i >= 0; i--)
                {
                    if (imgSrc[i] == 'S')
                    {
                        beginId = true;
                    }
                    else if (beginId && imgSrc[i] == 'D')
                    {
                        beginId = false;
                        break;
                    }
                    else if (beginId)
                    {
                        if (Char.IsDigit(imgSrc[i]))
                        {
                            designId = imgSrc[i] + designId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

            return designId;
        }

        private void BwCollectImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                txtPagePercent.Text = string.Format("{0}/{1}", currentPage, maxPage);
                txtImageCount.Text = dsCollection.TotalImage.ToString();

                if (lvKeyword.Items.Count > 0)
                {
                    lvKeyword.Items[currentIndex].Text = string.Format("{0} === 0/{1}", categories[currentIndex].OriginText, dsCollection.TotalImage);
                }

                pbProgress.Value = CalculatePercent(currentPage, maxPage);

                if (e.UserState != null)
                {
                    ImgDesign img = (ImgDesign)e.UserState;
                    lvImage.Items.Add((img.Index + 1).ToString() + " : " + img.Name);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void BwCollectImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Lấy danh sách đường dẫn hình ảnh hoàn thành";
            pbProgress.Value = 0;
            bwDownloadImage.RunWorkerAsync();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            saveToDirectory = Application.StartupPath;
            txtDirectoryPath.Text = saveToDirectory;
            LoadTradeMarkKeys();
        }

        private int CalculatePercent(int current, int total)
        {
            int percent = 0;

            float fCurrent = float.Parse(current.ToString());
            float fTotal = float.Parse(total.ToString());
            float fPercent = (fCurrent / fTotal) * 100;
            percent = int.Parse(fPercent.ToString("0"));

            return percent >= 100 ? 100 : percent;
        }

        private void LoadTradeMarkKeys()
        {
            try
            {
                if (File.Exists("TM-key.txt"))
                {
                    string[] lines = File.ReadAllLines("TM-key.txt");
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            tmKeys.Add(line.ToLower());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read trade mark keys file. " + ex.Message);
            }
        }
    }
}
