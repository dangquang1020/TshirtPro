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
        int count = 0;
        bool isPause = false;
        bool isRunning = false;

        List<KeywordCategory> categories;
        DesignCollection dsCollection;
        List<ImageDD> imageDDs;

        public FrmMain()
        {
            InitializeComponent();

            categories = new List<KeywordCategory>();
            dsCollection = new DesignCollection();
            imageDDs = new List<ImageDD>();

            Load += FrmMain_Load;

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
                imageDDs.ForEach(item =>
                {
                    item.Pause(isPause);
                });
            }
            else
            {
                btnPause.Text = "Tạm Dừng";
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = "Đang chạy ...";
                btnPause.ImageIndex = 1;
                imageDDs.ForEach(item =>
                {
                    item.Pause(isPause);
                });
            }
            
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                if (MessageBox.Show("Xóa dữ liệu hiện tại trên lưới và chạy tiếp ?", "Tạo mới", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    lvImage.Items.Clear();
                    categories.Clear();
                    imageDDs.ForEach(item =>
                    {
                        if (item != null)
                        {
                            ((IDisposable)item).Dispose();
                        }
                    });
                } else
                {
                    return;
                }
            }

            if (categories.Count > 0)
            {
                RunDownloadList();
            }
            else
            {
                if (string.IsNullOrEmpty(txtKeyWord.Text))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thiếu thông tin", MessageBoxButtons.OK);
                }
                else
                {
                    string keyword = txtKeyWord.Text.Replace(" ", "+");
                    string category = txtCategory.Text.Trim();
                    KeywordCategory cate = new KeywordCategory(keyword, category, keyword + "; " + category);
                    categories.Add(cate);
                    lvImage.Items.Add(keyword + "; " + category);
                    
                    RunDownloadList();
                }
            }
        }

        private void RunDownloadList()
        {
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Text = "Đang chạy ...";
            isRunning = true;
            count = 0;
            
            string keyWord = txtKeyWord.Text.Replace(" ", "+");
            int maxPage = int.Parse(nuPageNum.Value.ToString());
            string saveTo= txtDirectoryPath.Text;
            int imgPerDir = int.Parse(nuImgPerDir.Value.ToString());

            ProcessControl(true);

            for (int i = 0; i < categories.Count; i++)
            {
                ImageDD imgDD = new ImageDD(lvImage.Items[i], categories[i].Keyword, categories[i].Category, categories[i].OriginText, maxPage, imgPerDir, saveTo, CountSuccess);
                imgDD.StartDownload();
                imageDDs.Add(imgDD);
            }
        }

        public bool CountSuccess()
        {
            count++;
            if (count == categories.Count)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Đã tải xong.";
                ProcessControl(false);
            }
            return true;
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
                        isRunning = false;
                        imageDDs.ForEach(item =>
                        {
                            if (item != null)
                            {
                                ((IDisposable)item).Dispose();
                            }
                        });

                        lvImage.Items.Clear();
                        categories.Clear();
                        string[] lines = File.ReadAllLines(ofd.FileName);
                        foreach(string line in lines)
                        {
                            string[] arr = line.Split(';');
                            if (arr.Length > 1)
                            {
                                KeywordCategory cate = new KeywordCategory(arr[0].Trim(), arr[1].Trim(), line);
                                categories.Add(cate);
                                lvImage.Items.Add(line);
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
                fbd.SelectedPath = txtDirectoryPath.Text;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtDirectoryPath.Text = fbd.SelectedPath;
                }
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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtDirectoryPath.Text = Application.StartupPath;
        }
    }
}
