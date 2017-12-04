using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TshirtPro
{
    public class ImageDD : IDisposable
    {
        string itemXPath = "//*[@id='articleTileList']/div";
        string domain = "https://www.spreadshirt.com/";

        string saveToDirectory = string.Empty;
        string keyWord = string.Empty;
        string category = string.Empty;
        string originText = string.Empty;
        string fileName = string.Empty;
        int maxPage = 10;
        int imgPerDir = 100;
        ListViewItem lvItem;
        Func<bool> funcFinish;

        DataExportJson dataExportJson;
        DesignCollection dsCollection;
        HtmlWeb web;
        BackgroundWorker bwCollectImage;
        BackgroundWorker bwDownloadImage;
        ManualResetEvent pause;

        public ImageDD(ListViewItem item, string key, string cate, string origin, int maxP, int imgPer, string saveTo, Func<bool> func)
        {
            lvItem = item;
            keyWord = key;
            fileName = Globals.RemoveSpecialCharacter(key);

            category = cate;
            originText = origin;
            maxPage = maxP;
            imgPerDir = imgPer;
            saveToDirectory = saveTo + Path.DirectorySeparatorChar + fileName;
            funcFinish = func;

            web = new HtmlWeb();
            pause = new ManualResetEvent(true);
            dsCollection = new DesignCollection();
            dataExportJson = new DataExportJson(category);
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

            bwCollectImage.RunWorkerCompleted += BwCollectImage_RunWorkerCompleted;
            bwCollectImage.ProgressChanged += BwCollectImage_ProgressChanged;
            bwCollectImage.DoWork += BwCollectImage_DoWork;

            bwDownloadImage.RunWorkerCompleted += BwDownloadImage_RunWorkerCompleted;
            bwDownloadImage.ProgressChanged += BwDownloadImage_ProgressChanged;
            bwDownloadImage.DoWork += BwDownloadImage_DoWork;
        }

        public void StartDownload()
        {
            InitDownload();
        }

        private void InitDownload()
        {
            //Create directory
            string dirPath = saveToDirectory;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            bwCollectImage.RunWorkerAsync();
        }

        public void Pause(bool isPause)
        {
            if (isPause)
            {
                pause.Reset();
            }
            else
            {
                pause.Set();
            }
        }

        private void BwCollectImage_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                lvItem.ForeColor = Color.Blue;
                for (int i = 1; i <= maxPage; i++)
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
                            if (!dsCollection.ListIds.ContainsKey(designId))
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
                
            }
        }

        private void BwCollectImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lvItem.Text = string.Format("{0} === 0/{1}", originText, dsCollection.TotalImage);
        }

        private void BwCollectImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwDownloadImage.RunWorkerAsync();
        }

        private void BwDownloadImage_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Random rd = new Random();

                if (dsCollection.TotalImage <= imgPerDir)
                {
                    SaveImageAndExportJson(saveToDirectory, 0, dsCollection.TotalImage, fileName);
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
                            string dirName = string.Format("{0}-{1}", fileName, i.ToString());
                            string dirPath = string.Format(@"{0}\{1}", saveToDirectory, dirName);
                            if (Directory.Exists(dirPath))
                            {
                                dirName += rd.Next(1, 100);
                                dirPath = string.Format(@"{0}\{1}", saveToDirectory, dirName);
                            }
                            
                            Directory.CreateDirectory(dirPath);
                            int start = i * imgPerDir;
                            int end = start + imgPerDir;
                            SaveImageAndExportJson(dirPath, start, end, dirName);
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                
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
                    }

                    bwDownloadImage.ReportProgress(start + 1, downloadSuccess);
                }
            }

            dataExportJson.ExportToJson(directory, imgPerDir, dirName);
        }

        private void BwDownloadImage_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lvItem.Text = string.Format("{0} === {1}/{2}", originText, dsCollection.SuccessCount + dsCollection.ErrorCount, dsCollection.TotalImage);
        }

        private void BwDownloadImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lvItem.ForeColor = Color.Green;
            funcFinish();
        }

        public void Dispose()
        {
            bwCollectImage.Dispose();
            bwDownloadImage.Dispose();
            pause.Dispose();
        }
    }
}
