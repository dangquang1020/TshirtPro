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

namespace TshirtPro
{
    public partial class FrmMain : Form
    {
        string itemXPath = "//*[@id='articleTileList']/div";
        string domain = "https://www.spreadshirt.com/";
        
        string saveToDirectory;
        string keyWord = string.Empty;
        int maxPage = 10;
        int imgPerDir = 100;
        bool isPause = false;
        int currentIndex = 0;

        List<KeywordCategory> categories;
        DataExportJson dataExportJson;
        DesignCollection dsCollection;
        HtmlWeb web;
        BackgroundWorker bwCollectImage;
        BackgroundWorker bwDownloadImage;
        ManualResetEvent pause;

        public FrmMain()
        {
            InitializeComponent();

            categories = new List<KeywordCategory>();
            web = new HtmlWeb();
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
            bwCollectImage.DoWork += BwCollectImage_DoWork;
            bwDownloadImage.RunWorkerCompleted += BwDownloadImage_RunWorkerCompleted;
            bwDownloadImage.ProgressChanged += BwDownloadImage_ProgressChanged;
            bwDownloadImage.DoWork += BwDownloadImage_DoWork;

            btnBrowse.Click += BtnBrowse_Click;
            btnOpen.Click += BtnOpen_Click;
            btnStart.Click += BtnStart_Click;
            btnPause.Click += BtnPause_Click;
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
                        maxPage = int.Parse(nuPageNum.Value.ToString());
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
            maxPage = int.Parse(nuPageNum.Value.ToString());
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
            nuPageNum.Enabled = !isRunning;
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
                        foreach(string line in lines)
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

                if(dsCollection.TotalImage <= imgPerDir)
                {
                    SaveImageAndExportExcel(saveToDirectory, 0, dsCollection.TotalImage, keyWordFormat);
                }
                else
                {
                    int totalDirectory = 0;
                    if(dsCollection.TotalImage % imgPerDir == 0)
                    {
                        totalDirectory = (dsCollection.TotalImage / imgPerDir);
                    }
                    else
                    {
                        totalDirectory = (dsCollection.TotalImage / imgPerDir) + 1;
                    }

                    for(int i = 0; i < totalDirectory; i++)
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
                            SaveImageAndExportExcel(dirPath, start, end, dirName);
                        }
                        catch (Exception ex)
                        {
                            ShowError(ex.Message);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void SaveImageAndExportExcel(string directory, int start, int end, string dirName)
        {
            if(start >= dsCollection.TotalImage)
            {
                return;
            }

            if(end > dsCollection.TotalImage)
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
                        item.FileName = string.Format("{1}-{2}.png", item.Id, rd.Next(1, 100));
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
            } else
            {
                ListViewItem item = lvImage.Items[index];
                item.ForeColor = Color.Red;
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

        private void BwCollectImage_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for(int i = 1; i <= maxPage; i++)
                {
                    string url = domain + keyWord + "+gifts?page=" + i.ToString();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(itemXPath);

                    if (nodes != null)
                    {
                        foreach (HtmlNode node in nodes)
                        {
                            pause.WaitOne();

                            string designId = node.GetAttributeValue("data-designid", "");
                            if(!dsCollection.ListIds.ContainsKey(designId))
                            {
                                string name = node.ChildNodes.ElementAt(1).InnerText.Trim();
                                if (!string.IsNullOrEmpty(designId))
                                {
                                    ImgDesign img = dsCollection.AddNewImage(designId, name);
                                    bwCollectImage.ReportProgress(i, img);
                                    dsCollection.ListIds.Add(designId, name);
                                }
                            }
                        }
                    }
                    
                    bwCollectImage.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void BwCollectImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtPagePercent.Text = string.Format("{0}/{1}", e.ProgressPercentage.ToString(), maxPage);
            txtImageCount.Text = dsCollection.TotalImage.ToString();
            
            if (lvKeyword.Items.Count > 0)
            {
                lvKeyword.Items[currentIndex].Text = string.Format("{0} === 0/{1}", categories[currentIndex].OriginText, dsCollection.TotalImage);
            }
            
            pbProgress.Value = CalculatePercent(e.ProgressPercentage, maxPage);

            if (e.UserState != null)
            {
                ImgDesign img = (ImgDesign)e.UserState;
                lvImage.Items.Add((img.Index + 1).ToString() + " : " + img.Name);
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
        }

        private int CalculatePercent(int current, int total)
        {
            int percent = 0;

            float fCurrent = float.Parse(current.ToString());
            float fTotal = float.Parse(total.ToString());
            float fPercent = (fCurrent / fTotal) * 100;
            percent = int.Parse(fPercent.ToString("0"));

            return percent;
        }
    }
}
