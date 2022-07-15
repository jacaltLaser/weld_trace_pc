namespace CustomControl
{
    partial class ScrollBar
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SlideBar = new System.Windows.Forms.PictureBox();
            this.STextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SlideBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SlideBar
            // 
            this.SlideBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SlideBar.Location = this.Location;
            this.SlideBar.Name = "SlideBar";
            this.SlideBar.Size = new System.Drawing.Size(12, 74);
            this.SlideBar.TabIndex = 0;
            this.SlideBar.TabStop = false;
            this.SlideBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SlideBar_MouseDown);
            this.SlideBar.MouseEnter += new System.EventHandler(this.SlideBar_MouseEnter);
            this.SlideBar.MouseLeave += new System.EventHandler(this.SlideBar_MouseLeave);
            this.SlideBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SlideBar_MouseUp);
            // 
            // STextBox
            // 
            this.STextBox.Location = new System.Drawing.Point(0, 0);
            this.STextBox.Name = "STextBox";
            this.STextBox.Size = new System.Drawing.Size(100, 20);
            this.STextBox.TabIndex = 0;
            // 
            // ScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.SlideBar);
            this.Name = "ScrollBar";
            this.Size = new System.Drawing.Size(12, 313);
            this.HandleCreated += new System.EventHandler(this.This_Created);
            this.MouseEnter += new System.EventHandler(this.ScrollBar_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ScrollBar_MouseLeave);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.This_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.SlideBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SlideBar;
    }
}
