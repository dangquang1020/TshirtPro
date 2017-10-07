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
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDayLimit = new System.Windows.Forms.TextBox();
            this.txtSaleGoal = new System.Windows.Forms.TextBox();
            this.txtProsition = new System.Windows.Forms.TextBox();
            this.txtSlide = new System.Windows.Forms.TextBox();
            this.txtItemColor = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtProductRef = new System.Windows.Forms.TextBox();
            this.txtCategoryIds = new System.Windows.Forms.TextBox();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.lvImage = new System.Windows.Forms.ListView();
            this.colImageUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPagePercent = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.Label();
            this.txtSuccess = new System.Windows.Forms.Label();
            this.txtImageCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuImgPerDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPageNum)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(398, 69);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Enabled = false;
            this.txtDirectoryPath.Location = new System.Drawing.Point(163, 71);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.Size = new System.Drawing.Size(229, 20);
            this.txtDirectoryPath.TabIndex = 0;
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(163, 19);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(229, 20);
            this.txtKeyWord.TabIndex = 0;
            // 
            // nuImgPerDir
            // 
            this.nuImgPerDir.Location = new System.Drawing.Point(163, 97);
            this.nuImgPerDir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuImgPerDir.Name = "nuImgPerDir";
            this.nuImgPerDir.Size = new System.Drawing.Size(120, 20);
            this.nuImgPerDir.TabIndex = 2;
            this.nuImgPerDir.Value = new decimal(new int[] {
            50,
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
            this.nuPageNum.Size = new System.Drawing.Size(120, 20);
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
            this.label7.Location = new System.Drawing.Point(12, 99);
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
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.Location = new System.Drawing.Point(519, 533);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(300, 15);
            this.pbProgress.Step = 1;
            this.pbProgress.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSetting);
            this.tabMain.Controls.Add(this.tabSearch);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(837, 529);
            this.tabMain.TabIndex = 5;
            // 
            // tabSetting
            // 
            this.tabSetting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabSetting.Controls.Add(this.groupBox2);
            this.tabSetting.Controls.Add(this.groupBox1);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(829, 503);
            this.tabSetting.TabIndex = 0;
            this.tabSetting.Text = "Cài Đặt";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDayLimit);
            this.groupBox2.Controls.Add(this.txtSaleGoal);
            this.groupBox2.Controls.Add(this.txtProsition);
            this.groupBox2.Controls.Add(this.txtSlide);
            this.groupBox2.Controls.Add(this.txtItemColor);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.txtProductRef);
            this.groupBox2.Controls.Add(this.txtCategoryIds);
            this.groupBox2.Location = new System.Drawing.Point(8, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(813, 360);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội dung file";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(163, 173);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(587, 107);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = resources.GetString("txtDescription.Text");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(395, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "(*Tối đa 3 mã)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 315);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Day Limit:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 289);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Sale Goal:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Description:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Position:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Slides:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Item Color:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Item Price:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Item Product reference:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Category Ids:";
            // 
            // txtDayLimit
            // 
            this.txtDayLimit.Location = new System.Drawing.Point(163, 312);
            this.txtDayLimit.Name = "txtDayLimit";
            this.txtDayLimit.Size = new System.Drawing.Size(229, 20);
            this.txtDayLimit.TabIndex = 0;
            this.txtDayLimit.Text = "1";
            // 
            // txtSaleGoal
            // 
            this.txtSaleGoal.Location = new System.Drawing.Point(163, 286);
            this.txtSaleGoal.Name = "txtSaleGoal";
            this.txtSaleGoal.Size = new System.Drawing.Size(229, 20);
            this.txtSaleGoal.TabIndex = 0;
            this.txtSaleGoal.Text = "1";
            // 
            // txtProsition
            // 
            this.txtProsition.Location = new System.Drawing.Point(163, 147);
            this.txtProsition.Name = "txtProsition";
            this.txtProsition.Size = new System.Drawing.Size(229, 20);
            this.txtProsition.TabIndex = 0;
            this.txtProsition.Text = "N";
            // 
            // txtSlide
            // 
            this.txtSlide.Location = new System.Drawing.Point(163, 121);
            this.txtSlide.Name = "txtSlide";
            this.txtSlide.Size = new System.Drawing.Size(229, 20);
            this.txtSlide.TabIndex = 0;
            this.txtSlide.Text = "front";
            // 
            // txtItemColor
            // 
            this.txtItemColor.Location = new System.Drawing.Point(163, 95);
            this.txtItemColor.Name = "txtItemColor";
            this.txtItemColor.Size = new System.Drawing.Size(587, 20);
            this.txtItemColor.TabIndex = 0;
            this.txtItemColor.Text = "BLACK, NAVY, RED, WHITE, SPORT_GREY";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(163, 69);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(587, 20);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.Text = "18.95, 30.95, 23.95, 25.95, 19.95, 18.95, 21.95, 19.95";
            // 
            // txtProductRef
            // 
            this.txtProductRef.Location = new System.Drawing.Point(163, 43);
            this.txtProductRef.Name = "txtProductRef";
            this.txtProductRef.Size = new System.Drawing.Size(587, 20);
            this.txtProductRef.TabIndex = 0;
            this.txtProductRef.Text = "TSRN_U, HOOD_U, TSLS_U, SWTR_U, TSVN_U, TSRN_W, TKTP_W, TSVN_W";
            // 
            // txtCategoryIds
            // 
            this.txtCategoryIds.Location = new System.Drawing.Point(163, 17);
            this.txtCategoryIds.Name = "txtCategoryIds";
            this.txtCategoryIds.Size = new System.Drawing.Size(229, 20);
            this.txtCategoryIds.TabIndex = 0;
            this.txtCategoryIds.Text = "41, 96, 69";
            // 
            // tabSearch
            // 
            this.tabSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabSearch.Controls.Add(this.lvImage);
            this.tabSearch.Controls.Add(this.panel2);
            this.tabSearch.Controls.Add(this.panel1);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(829, 503);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Tìm Kiếm";
            // 
            // lvImage
            // 
            this.lvImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImageUrl});
            this.lvImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImage.FullRowSelect = true;
            this.lvImage.GridLines = true;
            this.lvImage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvImage.Location = new System.Drawing.Point(0, 60);
            this.lvImage.Name = "lvImage";
            this.lvImage.Size = new System.Drawing.Size(829, 383);
            this.lvImage.TabIndex = 7;
            this.lvImage.UseCompatibleStateImageBehavior = false;
            this.lvImage.View = System.Windows.Forms.View.Details;
            // 
            // colImageUrl
            // 
            this.colImageUrl.Text = "Đường dẫn hình ảnh";
            this.colImageUrl.Width = 833;
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
            this.panel2.Location = new System.Drawing.Point(0, 443);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 60);
            this.panel2.TabIndex = 6;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 60);
            this.panel1.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpen.ImageIndex = 3;
            this.btnOpen.ImageList = this.imglist;
            this.btnOpen.Location = new System.Drawing.Point(228, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(90, 51);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Mở Thư Mục";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPause.ImageIndex = 1;
            this.btnPause.ImageList = this.imglist;
            this.btnPause.Location = new System.Drawing.Point(116, 3);
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
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 51);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Tìm Kiếm";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 551);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "FrmMain";
            this.Text = "Image Downloader";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuImgPerDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuPageNum)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabSearch.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.NumericUpDown nuPageNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.ListView lvImage;
        private System.Windows.Forms.ColumnHeader colImageUrl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtPagePercent;
        private System.Windows.Forms.Label txtError;
        private System.Windows.Forms.Label txtSuccess;
        private System.Windows.Forms.Label txtImageCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nuImgPerDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProductRef;
        private System.Windows.Forms.TextBox txtCategoryIds;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDayLimit;
        private System.Windows.Forms.TextBox txtSaleGoal;
        private System.Windows.Forms.TextBox txtProsition;
        private System.Windows.Forms.TextBox txtSlide;
        private System.Windows.Forms.TextBox txtItemColor;
        private System.Windows.Forms.TextBox txtPrice;
    }
}

