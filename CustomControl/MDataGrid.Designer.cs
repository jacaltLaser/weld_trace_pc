namespace CustomControl
{
    partial class MDataGrid
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableColumns = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            this.tablePanel = new System.Windows.Forms.Panel();
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
            this.tablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(700, 565);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.Resize += new System.EventHandler(this.splitContainer1_Resize);
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
            this.tableColumns.Size = new System.Drawing.Size(700, 28);
            this.tableColumns.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(563, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 28);
            this.label6.TabIndex = 4;
            this.label6.Text = "Column5";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(458, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Column4";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(353, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Column3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(248, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Column2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(143, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Column1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Column0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(700, 533);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
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
            this.pagesPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagesPanel.Location = new System.Drawing.Point(0, 565);
            this.pagesPanel.Name = "pagesPanel";
            this.pagesPanel.Size = new System.Drawing.Size(700, 35);
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
            this.btnPage7.Location = new System.Drawing.Point(509, 6);
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
            this.btnPage6.Location = new System.Drawing.Point(477, 6);
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
            this.btnPage5.Location = new System.Drawing.Point(445, 6);
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
            this.pageNum.Location = new System.Drawing.Point(602, 7);
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
            this.btnPage4.Location = new System.Drawing.Point(413, 6);
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
            this.btnPage3.Location = new System.Drawing.Point(381, 6);
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
            this.btnPage2.Location = new System.Drawing.Point(349, 6);
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
            this.btnPageJump.Location = new System.Drawing.Point(643, 6);
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
            this.btnPageNext.Location = new System.Drawing.Point(541, 6);
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
            this.btnPagePrev.Location = new System.Drawing.Point(261, 6);
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
            this.btnPageFirst.Location = new System.Drawing.Point(217, 6);
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
            this.btnPage1.Location = new System.Drawing.Point(317, 6);
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
            // tablePanel
            // 
            this.tablePanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tablePanel.Controls.Add(this.splitContainer1);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(700, 565);
            this.tablePanel.TabIndex = 19;
            // 
            // manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.pagesPanel);
            this.Name = "manage";
            this.Size = new System.Drawing.Size(700, 600);
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
            this.tablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableColumns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
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
        private System.Windows.Forms.Panel tablePanel;
    }
}
