namespace CustomControl
{
    partial class MComboBox
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
            this.titlePanel1 = new CustomControl.TitlePanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mTextBox1 = new CustomControl.MTextBox();
            this.titlePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel1
            // 
            this.titlePanel1.BackColor = System.Drawing.Color.Transparent;
            this.titlePanel1.BorderColor = System.Drawing.Color.DarkGreen;
            this.titlePanel1.BorderRadius = 2;
            this.titlePanel1.BorderThickness = 1;
           
            this.titlePanel1.Controls.Add(this.flowLayoutPanel1);
            this.titlePanel1.Controls.Add(this.mTextBox1);
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titlePanel1.IsAutoBackColor = true;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Margin = new System.Windows.Forms.Padding(5);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.PanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(229)))));
            this.titlePanel1.Size = new System.Drawing.Size(90, 111);
            this.titlePanel1.TabIndex = 1;
            this.titlePanel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.titlePanel1.TitleAlign = CustomControl.TitlePanel.TitleAlignment.top;
            this.titlePanel1.TitleColor = System.Drawing.Color.Black;
            this.titlePanel1.TitlePadding = new System.Windows.Forms.Padding(0);
            this.titlePanel1.TitleSize = 0;
            this.titlePanel1.TitleText = "";
            this.titlePanel1.TitleTextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 88);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // mTextBox1
            // 
            this.mTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.mTextBox1.BorderColor = System.Drawing.Color.DarkGreen;
            this.mTextBox1.BorderFocusColor = System.Drawing.Color.Green;
            this.mTextBox1.BorderRadius = 2;
            this.mTextBox1.BorderThickness = 1;
            this.mTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mTextBox1.Location = new System.Drawing.Point(0, 0);
            this.mTextBox1.MaxLength = 32767;
            this.mTextBox1.MText = "";
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.PasswordChar = '\0';
            this.mTextBox1.ReadOnly = false;
            this.mTextBox1.Size = new System.Drawing.Size(90, 23);
            this.mTextBox1.TabIndex = 0;
            this.mTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mTextBox1.TextPadding = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.mTextBox1.UseSystemPasswordChar = false;
            this.mTextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mTextBox1_MouseDown);
            // 
            // MComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titlePanel1);
          
            this.Name = "MComboBox";
            this.Size = new System.Drawing.Size(90, 111);
            this.Load += new System.EventHandler(this.MComboBox_Load);
            this.SizeChanged += new System.EventHandler(this.MComboBox_SizeChanged);
            this.Leave += new System.EventHandler(this.MComboBox_Leave);
            this.titlePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTextBox mTextBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private TitlePanel titlePanel1;
    }
}
