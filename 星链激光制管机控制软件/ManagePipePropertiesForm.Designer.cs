namespace 星链激光制管机控制软件
{
    partial class ManagePipePropertiesForm
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.label_Tilte = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_close = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableColumns = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.queryText = new CustomControl.MTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pagesPanel = new System.Windows.Forms.Panel();
            this.btnPage7 = new CustomControl.TranslucentButton();
            this.btnPage6 = new CustomControl.TranslucentButton();
            this.btnPage5 = new CustomControl.TranslucentButton();
            this.pageNum = new CustomControl.MTextBox();
            this.btnPage4 = new CustomControl.TranslucentButton();
            this.btnPage3 = new CustomControl.TranslucentButton();
            this.btnPage2 = new CustomControl.TranslucentButton();
            this.btnPageJump = new CustomControl.TranslucentButton();
            this.btnPageNext = new CustomControl.TranslucentButton();
            this.btnPagePrev = new CustomControl.TranslucentButton();
            this.btnPageFirst = new CustomControl.TranslucentButton();
            this.btnPage1 = new CustomControl.TranslucentButton();
            this.btnAdd = new CustomControl.TranslucentButton();
            this.btnRecovery = new CustomControl.TranslucentButton();
            this.btnQuery = new CustomControl.TranslucentButton();
            this.panel_top.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableColumns.SuspendLayout();
            this.pagesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageJump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPagePrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecovery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.panel_top.Controls.Add(this.label_Tilte);
            this.panel_top.Controls.Add(this.flowLayoutPanel2);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(700, 30);
            this.panel_top.TabIndex = 3;
            this.panel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // label_Tilte
            // 
            this.label_Tilte.AutoSize = true;
            this.label_Tilte.BackColor = System.Drawing.Color.Transparent;
            this.label_Tilte.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Tilte.ForeColor = System.Drawing.Color.White;
            this.label_Tilte.Location = new System.Drawing.Point(5, 5);
            this.label_Tilte.Name = "label_Tilte";
            this.label_Tilte.Size = new System.Drawing.Size(93, 19);
            this.label_Tilte.TabIndex = 15;
            this.label_Tilte.Text = "配置管材特性";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.btn_close);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(561, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(135, 30);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImage = global::星链激光制管机控制软件.Properties.Resources.close;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(100, 3);
            this.btn_close.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 25);
            this.btn_close.TabIndex = 3;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(5, 99);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.tableColumns);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.White;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(690, 445);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableColumns
            // 
            this.tableColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.tableColumns.ColumnCount = 6;
            this.tableColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableColumns.Controls.Add(this.label6, 5, 0);
            this.tableColumns.Controls.Add(this.label5, 4, 0);
            this.tableColumns.Controls.Add(this.label4, 3, 0);
            this.tableColumns.Controls.Add(this.label3, 2, 0);
            this.tableColumns.Controls.Add(this.label2, 1, 0);
            this.tableColumns.Controls.Add(this.label1, 0, 0);
            this.tableColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableColumns.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableColumns.Location = new System.Drawing.Point(0, 0);
            this.tableColumns.Name = "tableColumns";
            this.tableColumns.RowCount = 1;
            this.tableColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableColumns.Size = new System.Drawing.Size(690, 28);
            this.tableColumns.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(553, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 28);
            this.label6.TabIndex = 4;
            this.label6.Text = "操 作";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(450, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "移动速度";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(347, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "厚 度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(244, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "材 料";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(141, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "直 径";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "管材名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(690, 413);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // queryText
            // 
            this.queryText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.queryText.BackColor = System.Drawing.Color.Transparent;
            this.queryText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.queryText.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.queryText.BorderRadius = 2;
            this.queryText.BorderThickness = 1;
            this.queryText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.queryText.Location = new System.Drawing.Point(82, 58);
            this.queryText.Margin = new System.Windows.Forms.Padding(0);
            this.queryText.MaxLength = 32767;
            this.queryText.MText = "";
            this.queryText.Name = "queryText";
            this.queryText.PasswordChar = '\0';
            this.queryText.ReadOnly = false;
            this.queryText.Size = new System.Drawing.Size(114, 28);
            this.queryText.TabIndex = 15;
            this.queryText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.queryText.TextModel = CustomControl.MTextBox.TextFormatModel.none;
            this.queryText.TextPadding = new System.Windows.Forms.Padding(5, 2, 5, 8);
            this.queryText.UseSystemPasswordChar = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(17, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "管材名称 :";
            // 
            // pagesPanel
            // 
            this.pagesPanel.Controls.Add(this.btnPage7);
            this.pagesPanel.Controls.Add(this.btnPage6);
            this.pagesPanel.Controls.Add(this.btnPage5);
            this.pagesPanel.Controls.Add(this.pageNum);
            this.pagesPanel.Controls.Add(this.btnPage4);
            this.pagesPanel.Controls.Add(this.btnPage3);
            this.pagesPanel.Controls.Add(this.btnPage2);
            this.pagesPanel.Controls.Add(this.btnPageJump);
            this.pagesPanel.Controls.Add(this.btnPageNext);
            this.pagesPanel.Controls.Add(this.btnPagePrev);
            this.pagesPanel.Controls.Add(this.btnPageFirst);
            this.pagesPanel.Controls.Add(this.btnPage1);
            this.pagesPanel.Location = new System.Drawing.Point(158, 553);
            this.pagesPanel.Name = "pagesPanel";
            this.pagesPanel.Size = new System.Drawing.Size(537, 35);
            this.pagesPanel.TabIndex = 18;
            // 
            // btnPage7
            // 
            this.btnPage7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage7.BackColor = System.Drawing.Color.Transparent;
            this.btnPage7.BorderColor = System.Drawing.Color.Empty;
            this.btnPage7.BorderWidth = 0;
            this.btnPage7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage7.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPage7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage7.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage7.IsBorder = false;
            this.btnPage7.IsTranslucent = true;
            this.btnPage7.Location = new System.Drawing.Point(346, 6);
            this.btnPage7.Margin = new System.Windows.Forms.Padding(0);
            this.btnPage7.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPage7.Name = "btnPage7";
            this.btnPage7.Size = new System.Drawing.Size(30, 25);
            this.btnPage7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPage7.TabIndex = 16;
            this.btnPage7.TabStop = false;
            this.btnPage7.Text = "7";
            this.btnPage7.ToolTipText = null;
            this.btnPage7.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPage6
            // 
            this.btnPage6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage6.BackColor = System.Drawing.Color.Transparent;
            this.btnPage6.BorderColor = System.Drawing.Color.Empty;
            this.btnPage6.BorderWidth = 0;
            this.btnPage6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPage6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage6.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage6.IsBorder = false;
            this.btnPage6.IsTranslucent = true;
            this.btnPage6.Location = new System.Drawing.Point(314, 6);
            this.btnPage6.Margin = new System.Windows.Forms.Padding(0);
            this.btnPage6.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPage6.Name = "btnPage6";
            this.btnPage6.Size = new System.Drawing.Size(30, 25);
            this.btnPage6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPage6.TabIndex = 16;
            this.btnPage6.TabStop = false;
            this.btnPage6.Text = "6";
            this.btnPage6.ToolTipText = null;
            this.btnPage6.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPage5
            // 
            this.btnPage5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage5.BackColor = System.Drawing.Color.Transparent;
            this.btnPage5.BorderColor = System.Drawing.Color.Empty;
            this.btnPage5.BorderWidth = 0;
            this.btnPage5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPage5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage5.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage5.IsBorder = false;
            this.btnPage5.IsTranslucent = true;
            this.btnPage5.Location = new System.Drawing.Point(282, 6);
            this.btnPage5.Margin = new System.Windows.Forms.Padding(0);
            this.btnPage5.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPage5.Name = "btnPage5";
            this.btnPage5.Size = new System.Drawing.Size(30, 25);
            this.btnPage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPage5.TabIndex = 16;
            this.btnPage5.TabStop = false;
            this.btnPage5.Text = "5";
            this.btnPage5.ToolTipText = null;
            this.btnPage5.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // pageNum
            // 
            this.pageNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageNum.BackColor = System.Drawing.Color.Transparent;
            this.pageNum.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.pageNum.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.pageNum.BorderRadius = 2;
            this.pageNum.BorderThickness = 1;
            this.pageNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageNum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pageNum.Location = new System.Drawing.Point(439, 7);
            this.pageNum.Margin = new System.Windows.Forms.Padding(0);
            this.pageNum.MaxLength = 32767;
            this.pageNum.MText = "1";
            this.pageNum.Name = "pageNum";
            this.pageNum.PasswordChar = '\0';
            this.pageNum.ReadOnly = false;
            this.pageNum.Size = new System.Drawing.Size(40, 23);
            this.pageNum.TabIndex = 1;
            this.pageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pageNum.TextModel = CustomControl.MTextBox.TextFormatModel.Integer;
            this.pageNum.TextPadding = new System.Windows.Forms.Padding(5, 1, 5, 4);
            this.pageNum.UseSystemPasswordChar = false;
            // 
            // btnPage4
            // 
            this.btnPage4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage4.BackColor = System.Drawing.Color.Transparent;
            this.btnPage4.BorderColor = System.Drawing.Color.Empty;
            this.btnPage4.BorderWidth = 0;
            this.btnPage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPage4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage4.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage4.IsBorder = false;
            this.btnPage4.IsTranslucent = true;
            this.btnPage4.Location = new System.Drawing.Point(250, 6);
            this.btnPage4.Margin = new System.Windows.Forms.Padding(0);
            this.btnPage4.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPage4.Name = "btnPage4";
            this.btnPage4.Size = new System.Drawing.Size(30, 25);
            this.btnPage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPage4.TabIndex = 16;
            this.btnPage4.TabStop = false;
            this.btnPage4.Text = "4";
            this.btnPage4.ToolTipText = null;
            this.btnPage4.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPage3
            // 
            this.btnPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage3.BackColor = System.Drawing.Color.Transparent;
            this.btnPage3.BorderColor = System.Drawing.Color.Empty;
            this.btnPage3.BorderWidth = 0;
            this.btnPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPage3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage3.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage3.IsBorder = false;
            this.btnPage3.IsTranslucent = true;
            this.btnPage3.Location = new System.Drawing.Point(218, 6);
            this.btnPage3.Margin = new System.Windows.Forms.Padding(0);
            this.btnPage3.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(30, 25);
            this.btnPage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPage3.TabIndex = 16;
            this.btnPage3.TabStop = false;
            this.btnPage3.Text = "3";
            this.btnPage3.ToolTipText = null;
            this.btnPage3.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPage2
            // 
            this.btnPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage2.BackColor = System.Drawing.Color.Transparent;
            this.btnPage2.BorderColor = System.Drawing.Color.Empty;
            this.btnPage2.BorderWidth = 0;
            this.btnPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPage2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage2.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPage2.IsBorder = false;
            this.btnPage2.IsTranslucent = true;
            this.btnPage2.Location = new System.Drawing.Point(186, 6);
            this.btnPage2.Margin = new System.Windows.Forms.Padding(0);
            this.btnPage2.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(30, 25);
            this.btnPage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPage2.TabIndex = 16;
            this.btnPage2.TabStop = false;
            this.btnPage2.Text = "2";
            this.btnPage2.ToolTipText = null;
            this.btnPage2.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPageJump
            // 
            this.btnPageJump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageJump.BackColor = System.Drawing.Color.Transparent;
            this.btnPageJump.BorderColor = System.Drawing.Color.Empty;
            this.btnPageJump.BorderWidth = 0;
            this.btnPageJump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPageJump.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPageJump.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPageJump.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPageJump.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPageJump.IsBorder = false;
            this.btnPageJump.IsTranslucent = true;
            this.btnPageJump.Location = new System.Drawing.Point(480, 6);
            this.btnPageJump.Margin = new System.Windows.Forms.Padding(0);
            this.btnPageJump.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPageJump.Name = "btnPageJump";
            this.btnPageJump.Size = new System.Drawing.Size(42, 25);
            this.btnPageJump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPageJump.TabIndex = 16;
            this.btnPageJump.TabStop = false;
            this.btnPageJump.Text = "跳转";
            this.btnPageJump.ToolTipText = null;
            this.btnPageJump.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPageNext
            // 
            this.btnPageNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageNext.BackColor = System.Drawing.Color.Transparent;
            this.btnPageNext.BorderColor = System.Drawing.Color.Empty;
            this.btnPageNext.BorderWidth = 0;
            this.btnPageNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPageNext.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPageNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPageNext.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPageNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPageNext.IsBorder = false;
            this.btnPageNext.IsTranslucent = true;
            this.btnPageNext.Location = new System.Drawing.Point(378, 6);
            this.btnPageNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnPageNext.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Size = new System.Drawing.Size(54, 25);
            this.btnPageNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPageNext.TabIndex = 16;
            this.btnPageNext.TabStop = false;
            this.btnPageNext.Text = "下一页";
            this.btnPageNext.ToolTipText = null;
            this.btnPageNext.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPagePrev
            // 
            this.btnPagePrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagePrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPagePrev.BorderColor = System.Drawing.Color.Empty;
            this.btnPagePrev.BorderWidth = 0;
            this.btnPagePrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagePrev.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPagePrev.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPagePrev.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPagePrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPagePrev.IsBorder = false;
            this.btnPagePrev.IsTranslucent = true;
            this.btnPagePrev.Location = new System.Drawing.Point(98, 6);
            this.btnPagePrev.Margin = new System.Windows.Forms.Padding(0);
            this.btnPagePrev.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPagePrev.Name = "btnPagePrev";
            this.btnPagePrev.Size = new System.Drawing.Size(54, 25);
            this.btnPagePrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPagePrev.TabIndex = 16;
            this.btnPagePrev.TabStop = false;
            this.btnPagePrev.Text = "上一页";
            this.btnPagePrev.ToolTipText = null;
            this.btnPagePrev.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPageFirst
            // 
            this.btnPageFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnPageFirst.BorderColor = System.Drawing.Color.Empty;
            this.btnPageFirst.BorderWidth = 0;
            this.btnPageFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPageFirst.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPageFirst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPageFirst.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPageFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnPageFirst.IsBorder = false;
            this.btnPageFirst.IsTranslucent = true;
            this.btnPageFirst.Location = new System.Drawing.Point(54, 6);
            this.btnPageFirst.Margin = new System.Windows.Forms.Padding(0);
            this.btnPageFirst.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPageFirst.Name = "btnPageFirst";
            this.btnPageFirst.Size = new System.Drawing.Size(42, 25);
            this.btnPageFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPageFirst.TabIndex = 16;
            this.btnPageFirst.TabStop = false;
            this.btnPageFirst.Text = "首页";
            this.btnPageFirst.ToolTipText = null;
            this.btnPageFirst.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage1.BackColor = System.Drawing.Color.Aqua;
            this.btnPage1.BorderColor = System.Drawing.Color.Empty;
            this.btnPage1.BorderWidth = 0;
            this.btnPage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPage1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPage1.FontColor = System.Drawing.Color.Black;
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.IsBorder = false;
            this.btnPage1.IsTranslucent = true;
            this.btnPage1.Location = new System.Drawing.Point(154, 6);
            this.btnPage1.Margin = new System.Windows.Forms.Padding(0);
            this.btnPage1.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(30, 25);
            this.btnPage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPage1.TabIndex = 16;
            this.btnPage1.TabStop = false;
            this.btnPage1.Text = "1";
            this.btnPage1.ToolTipText = null;
            this.btnPage1.Click += new System.EventHandler(this.btnPageJump_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderColor = System.Drawing.Color.Empty;
            this.btnAdd.BorderWidth = 0;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnAdd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Image = global::星链激光制管机控制软件.Properties.Resources.add_normal;
            this.btnAdd.IsBorder = false;
            this.btnAdd.IsTranslucent = true;
            this.btnAdd.Location = new System.Drawing.Point(631, 64);
            this.btnAdd.MouseHoverColor = System.Drawing.Color.Empty;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 22);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.TabStop = false;
            this.btnAdd.Tag = "normal";
            this.btnAdd.Text = "新增";
            this.btnAdd.ToolTipText = null;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnAdd_MouseLeave);
            // 
            // btnRecovery
            // 
            this.btnRecovery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecovery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnRecovery.BorderColor = System.Drawing.Color.Empty;
            this.btnRecovery.BorderWidth = 0;
            this.btnRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecovery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRecovery.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecovery.FontColor = System.Drawing.Color.White;
            this.btnRecovery.ForeColor = System.Drawing.Color.White;
            this.btnRecovery.IsBorder = false;
            this.btnRecovery.IsTranslucent = false;
            this.btnRecovery.Location = new System.Drawing.Point(268, 60);
            this.btnRecovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnRecovery.MouseHoverColor = System.Drawing.Color.Aqua;
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(50, 25);
            this.btnRecovery.TabIndex = 16;
            this.btnRecovery.TabStop = false;
            this.btnRecovery.Text = "重置";
            this.btnRecovery.ToolTipText = null;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnQuery.BorderColor = System.Drawing.Color.Empty;
            this.btnQuery.BorderWidth = 0;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.FontColor = System.Drawing.Color.White;
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.IsBorder = false;
            this.btnQuery.IsTranslucent = false;
            this.btnQuery.Location = new System.Drawing.Point(207, 60);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuery.MouseHoverColor = System.Drawing.Color.Aqua;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(50, 25);
            this.btnQuery.TabIndex = 16;
            this.btnQuery.TabStop = false;
            this.btnQuery.Text = "查询";
            this.btnQuery.ToolTipText = null;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // ManagePipePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pagesPanel);
            this.Controls.Add(this.btnRecovery);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.queryText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ManagePipePropertiesForm";
            this.ShowInTaskbar = false;
            this.Text = "ManagePipePropertiesForm";
            this.Load += new System.EventHandler(this.ManagePipePropertiesForm_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableColumns.ResumeLayout(false);
            this.pagesPanel.ResumeLayout(false);
            this.pagesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageJump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPagePrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecovery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableColumns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private CustomControl.MTextBox queryText;
        private System.Windows.Forms.Label label7;
        private CustomControl.TranslucentButton btnQuery;
        private CustomControl.TranslucentButton btnAdd;
        private CustomControl.TranslucentButton btnPage1;
        private System.Windows.Forms.Panel pagesPanel;
        private CustomControl.TranslucentButton btnPage7;
        private CustomControl.TranslucentButton btnPage6;
        private CustomControl.TranslucentButton btnPage5;
        private CustomControl.MTextBox pageNum;
        private CustomControl.TranslucentButton btnPage4;
        private CustomControl.TranslucentButton btnPage3;
        private CustomControl.TranslucentButton btnPage2;
        private CustomControl.TranslucentButton btnPageJump;
        private CustomControl.TranslucentButton btnPageNext;
        private CustomControl.TranslucentButton btnPagePrev;
        private CustomControl.TranslucentButton btnPageFirst;
        private CustomControl.TranslucentButton btnRecovery;
        private System.Windows.Forms.Label label_Tilte;
    }
}