namespace TshirtPro
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPagePercent = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.Label();
            this.txtSuccess = new System.Windows.Forms.Label();
            this.txtImageCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTZLCategory3 = new System.Windows.Forms.TextBox();
            this.txtTZLCategory2 = new System.Windows.Forms.TextBox();
            this.txtTZLCategory1 = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.nuImgPerDir = new System.Windows.Forms.NumericUpDown();
            this.nuPageNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lvImage = new System.Windows.Forms.ListView();
            this.colImageUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lvKeyword = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuImgPerDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPageNum)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 529);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(837, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 17);
            this.lblStatus.Text = "Sẵn sàng";
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "download.png");
            this.imglist.Images.SetKeyName(1, "pause.png");
            this.imglist.Images.SetKeyName(2, "more.png");
            this.imglist.Images.SetKeyName(3, "folder-open.png");
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(519, 533);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(300, 15);
            this.pbProgress.Step = 1;
            this.pbProgress.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPagePercent);
            this.panel2.Controls.Add(this.txtError);
            this.panel2.Controls.Add(this.txtSuccess);
            this.panel2.Controls.Add(this.txtImageCount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 60);
            this.panel2.TabIndex = 7;
            // 
            // txtPagePercent
            // 
            this.txtPagePercent.AutoSize = true;
            this.txtPagePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagePercent.ForeColor = System.Drawing.Color.Blue;
            this.txtPagePercent.Location = new System.Drawing.Point(74, 12);
            this.txtPagePercent.Name = "txtPagePercent";
            this.txtPagePercent.Size = new System.Drawing.Size(27, 13);
            this.txtPagePercent.TabIndex = 0;
            this.txtPagePercent.Text = "0/0";
            // 
            // txtError
            // 
            this.txtError.AutoSize = true;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.ForeColor = System.Drawing.Color.Red;
            this.txtError.Location = new System.Drawing.Point(340, 34);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(14, 13);
            this.txtError.TabIndex = 0;
            this.txtError.Text = "0";
            // 
            // txtSuccess
            // 
            this.txtSuccess.AutoSize = true;
            this.txtSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuccess.ForeColor = System.Drawing.Color.Green;
            this.txtSuccess.Location = new System.Drawing.Point(233, 34);
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.Size = new System.Drawing.Size(14, 13);
            this.txtSuccess.TabIndex = 0;
            this.txtSuccess.Text = "0";
            // 
            // txtImageCount
            // 
            this.txtImageCount.AutoSize = true;
            this.txtImageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageCount.ForeColor = System.Drawing.Color.Blue;
            this.txtImageCount.Location = new System.Drawing.Point(74, 34);
            this.txtImageCount.Name = "txtImageCount";
            this.txtImageCount.Size = new System.Drawing.Size(14, 13);
            this.txtImageCount.TabIndex = 0;
            this.txtImageCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trang:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Lỗi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thành công:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hình ảnh:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(396, 469);
            this.panel3.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvKeyword);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTZLCategory3);
            this.groupBox2.Controls.Add(this.txtTZLCategory2);
            this.groupBox2.Controls.Add(this.txtTZLCategory1);
            this.groupBox2.Controls.Add(this.txtCategory);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 307);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội dung file";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "TZL Category ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 1;
            this.label9.Tag = "";
            this.label9.Text = "Category";
            // 
            // txtTZLCategory3
            // 
            this.txtTZLCategory3.Location = new System.Drawing.Point(163, 95);
            this.txtTZLCategory3.Name = "txtTZLCategory3";
            this.txtTZLCategory3.Size = new System.Drawing.Size(217, 20);
            this.txtTZLCategory3.TabIndex = 0;
            // 
            // txtTZLCategory2
            // 
            this.txtTZLCategory2.Location = new System.Drawing.Point(163, 69);
            this.txtTZLCategory2.Name = "txtTZLCategory2";
            this.txtTZLCategory2.Size = new System.Drawing.Size(217, 20);
            this.txtTZLCategory2.TabIndex = 0;
            // 
            // txtTZLCategory1
            // 
            this.txtTZLCategory1.Location = new System.Drawing.Point(163, 43);
            this.txtTZLCategory1.Name = "txtTZLCategory1";
            this.txtTZLCategory1.Size = new System.Drawing.Size(217, 20);
            this.txtTZLCategory1.TabIndex = 0;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(163, 17);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(217, 20);
            this.txtCategory.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtDirectoryPath);
            this.groupBox1.Controls.Add(this.txtKeyWord);
            this.groupBox1.Controls.Add(this.nuImgPerDir);
            this.groupBox1.Controls.Add(this.nuPageNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 152);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(305, 87);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Enabled = false;
            this.txtDirectoryPath.Location = new System.Drawing.Point(15, 90);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.Size = new System.Drawing.Size(284, 20);
            this.txtDirectoryPath.TabIndex = 0;
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(163, 19);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(136, 20);
            this.txtKeyWord.TabIndex = 0;
            // 
            // nuImgPerDir
            // 
            this.nuImgPerDir.Location = new System.Drawing.Point(163, 116);
            this.nuImgPerDir.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuImgPerDir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuImgPerDir.Name = "nuImgPerDir";
            this.nuImgPerDir.Size = new System.Drawing.Size(136, 20);
            this.nuImgPerDir.TabIndex = 2;
            this.nuImgPerDir.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nuPageNum
            // 
            this.nuPageNum.Location = new System.Drawing.Point(163, 45);
            this.nuPageNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuPageNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuPageNum.Name = "nuPageNum";
            this.nuPageNum.Size = new System.Drawing.Size(136, 20);
            this.nuPageNum.TabIndex = 2;
            this.nuPageNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ khóa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Số hình trong 1 thư mục:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Thư mục lưu hình ảnh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số trang tìm (1 - 10):";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lvImage);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(396, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(441, 469);
            this.panel4.TabIndex = 10;
            // 
            // lvImage
            // 
            this.lvImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImageUrl});
            this.lvImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImage.FullRowSelect = true;
            this.lvImage.GridLines = true;
            this.lvImage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvImage.Location = new System.Drawing.Point(0, 66);
            this.lvImage.Name = "lvImage";
            this.lvImage.Size = new System.Drawing.Size(441, 403);
            this.lvImage.TabIndex = 8;
            this.lvImage.UseCompatibleStateImageBehavior = false;
            this.lvImage.View = System.Windows.Forms.View.Details;
            // 
            // colImageUrl
            // 
            this.colImageUrl.Text = "Đường dẫn hình ảnh";
            this.colImageUrl.Width = 833;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(441, 66);
            this.panel1.TabIndex = 3;
            // 
            // btnOpen
            // 
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpen.ImageIndex = 3;
            this.btnOpen.ImageList = this.imglist;
            this.btnOpen.Location = new System.Drawing.Point(15, 69);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(83, 46);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Đọc File";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPause.ImageIndex = 1;
            this.btnPause.ImageList = this.imglist;
            this.btnPause.Location = new System.Drawing.Point(123, 9);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(90, 51);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Tạm Dừng";
            this.btnPause.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStart.Location = new System.Drawing.Point(8, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 51);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Tìm Kiếm";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // lvKeyword
            // 
            this.lvKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvKeyword.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvKeyword.FullRowSelect = true;
            this.lvKeyword.GridLines = true;
            this.lvKeyword.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvKeyword.Location = new System.Drawing.Point(6, 121);
            this.lvKeyword.MultiSelect = false;
            this.lvKeyword.Name = "lvKeyword";
            this.lvKeyword.Size = new System.Drawing.Size(374, 180);
            this.lvKeyword.TabIndex = 9;
            this.lvKeyword.UseCompatibleStateImageBehavior = false;
            this.lvKeyword.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Đường dẫn hình ảnh";
            this.columnHeader1.Width = 370;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 551);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "FrmMain";
            this.Text = "Image Downloader";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuImgPerDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPageNum)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtPagePercent;
        private System.Windows.Forms.Label txtError;
        private System.Windows.Forms.Label txtSuccess;
        private System.Windows.Forms.Label txtImageCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTZLCategory1;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.NumericUpDown nuImgPerDir;
        private System.Windows.Forms.NumericUpDown nuPageNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lvImage;
        private System.Windows.Forms.ColumnHeader colImageUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtTZLCategory3;
        private System.Windows.Forms.TextBox txtTZLCategory2;
        private System.Windows.Forms.ListView lvKeyword;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

