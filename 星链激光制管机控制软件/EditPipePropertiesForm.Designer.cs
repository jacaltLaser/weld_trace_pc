namespace 星链激光制管机控制软件
{
    partial class EditPipePropertiesForm
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_close = new System.Windows.Forms.Button();
            this.label_Tilte = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mTextBox1 = new CustomControl.MTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mTextBox2 = new CustomControl.MTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mTextBox3 = new CustomControl.MTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mTextBox4 = new CustomControl.MTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mTextBox5 = new CustomControl.MTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOK = new CustomControl.TranslucentButton();
            this.btnCancel = new CustomControl.TranslucentButton();
            this.panel_top.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.panel_top.Controls.Add(this.flowLayoutPanel2);
            this.panel_top.Controls.Add(this.label_Tilte);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(330, 30);
            this.panel_top.TabIndex = 3;
            this.panel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.btn_close);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(191, 0);
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
            // label_Tilte
            // 
            this.label_Tilte.AutoSize = true;
            this.label_Tilte.BackColor = System.Drawing.Color.Transparent;
            this.label_Tilte.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Tilte.ForeColor = System.Drawing.Color.White;
            this.label_Tilte.Location = new System.Drawing.Point(5, 5);
            this.label_Tilte.Name = "label_Tilte";
            this.label_Tilte.Size = new System.Drawing.Size(41, 19);
            this.label_Tilte.TabIndex = 14;
            this.label_Tilte.Text = "编 辑";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(44, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "管材名称 :";
            // 
            // mTextBox1
            // 
            this.mTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.mTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox1.BorderRadius = 2;
            this.mTextBox1.BorderThickness = 1;
            this.mTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mTextBox1.Location = new System.Drawing.Point(109, 72);
            this.mTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.mTextBox1.MaxLength = 32767;
            this.mTextBox1.MText = "";
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.PasswordChar = '\0';
            this.mTextBox1.ReadOnly = false;
            this.mTextBox1.Size = new System.Drawing.Size(150, 28);
            this.mTextBox1.TabIndex = 15;
            this.mTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mTextBox1.TextPadding = new System.Windows.Forms.Padding(5, 2, 5, 8);
            this.mTextBox1.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(64, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "直 径 :";
            // 
            // mTextBox2
            // 
            this.mTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.mTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox2.BorderRadius = 2;
            this.mTextBox2.BorderThickness = 1;
            this.mTextBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mTextBox2.Location = new System.Drawing.Point(109, 116);
            this.mTextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.mTextBox2.MaxLength = 32767;
            this.mTextBox2.MText = "";
            this.mTextBox2.Name = "mTextBox2";
            this.mTextBox2.PasswordChar = '\0';
            this.mTextBox2.ReadOnly = false;
            this.mTextBox2.Size = new System.Drawing.Size(150, 28);
            this.mTextBox2.TabIndex = 15;
            this.mTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mTextBox2.TextModel = CustomControl.MTextBox.TextFormatModel.Decimal;
            this.mTextBox2.TextPadding = new System.Windows.Forms.Padding(5, 2, 5, 8);
            this.mTextBox2.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(64, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "材 料 :";
            // 
            // mTextBox3
            // 
            this.mTextBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.mTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox3.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox3.BorderRadius = 2;
            this.mTextBox3.BorderThickness = 1;
            this.mTextBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mTextBox3.Location = new System.Drawing.Point(109, 160);
            this.mTextBox3.Margin = new System.Windows.Forms.Padding(5);
            this.mTextBox3.MaxLength = 32767;
            this.mTextBox3.MText = "";
            this.mTextBox3.Name = "mTextBox3";
            this.mTextBox3.PasswordChar = '\0';
            this.mTextBox3.ReadOnly = false;
            this.mTextBox3.Size = new System.Drawing.Size(150, 28);
            this.mTextBox3.TabIndex = 15;
            this.mTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mTextBox3.TextPadding = new System.Windows.Forms.Padding(5, 2, 5, 8);
            this.mTextBox3.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(64, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "厚 度 :";
            // 
            // mTextBox4
            // 
            this.mTextBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.mTextBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox4.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox4.BorderRadius = 2;
            this.mTextBox4.BorderThickness = 1;
            this.mTextBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mTextBox4.Location = new System.Drawing.Point(109, 204);
            this.mTextBox4.Margin = new System.Windows.Forms.Padding(0);
            this.mTextBox4.MaxLength = 32767;
            this.mTextBox4.MText = "";
            this.mTextBox4.Name = "mTextBox4";
            this.mTextBox4.PasswordChar = '\0';
            this.mTextBox4.ReadOnly = false;
            this.mTextBox4.Size = new System.Drawing.Size(150, 28);
            this.mTextBox4.TabIndex = 15;
            this.mTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mTextBox4.TextModel = CustomControl.MTextBox.TextFormatModel.Decimal;
            this.mTextBox4.TextPadding = new System.Windows.Forms.Padding(5, 2, 5, 8);
            this.mTextBox4.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(44, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "移动速度 :";
            // 
            // mTextBox5
            // 
            this.mTextBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mTextBox5.BackColor = System.Drawing.Color.Transparent;
            this.mTextBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox5.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.mTextBox5.BorderRadius = 2;
            this.mTextBox5.BorderThickness = 1;
            this.mTextBox5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mTextBox5.Location = new System.Drawing.Point(109, 248);
            this.mTextBox5.Margin = new System.Windows.Forms.Padding(0);
            this.mTextBox5.MaxLength = 32767;
            this.mTextBox5.MText = "";
            this.mTextBox5.Name = "mTextBox5";
            this.mTextBox5.PasswordChar = '\0';
            this.mTextBox5.ReadOnly = false;
            this.mTextBox5.Size = new System.Drawing.Size(150, 28);
            this.mTextBox5.TabIndex = 15;
            this.mTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mTextBox5.TextModel = CustomControl.MTextBox.TextFormatModel.Decimal;
            this.mTextBox5.TextPadding = new System.Windows.Forms.Padding(5, 2, 5, 8);
            this.mTextBox5.UseSystemPasswordChar = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(262, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(262, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(262, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "m/s";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnOK.BorderColor = System.Drawing.Color.Empty;
            this.btnOK.BorderWidth = 0;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.FontColor = System.Drawing.Color.White;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.IsBorder = true;
            this.btnOK.IsTranslucent = false;
            this.btnOK.Location = new System.Drawing.Point(191, 316);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.MouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 16;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "确 定";
            this.btnOK.ToolTipText = null;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnCancel.BorderWidth = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.FontColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBorder = true;
            this.btnCancel.IsTranslucent = false;
            this.btnCancel.Location = new System.Drawing.Point(47, 316);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取 消";
            this.btnCancel.ToolTipText = null;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            // 
            // EditPipePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(330, 370);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.mTextBox5);
            this.Controls.Add(this.mTextBox4);
            this.Controls.Add(this.mTextBox3);
            this.Controls.Add(this.mTextBox2);
            this.Controls.Add(this.mTextBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_top);
            this.Name = "EditPipePropertiesForm";
            this.ShowInTaskbar = false;
            this.Text = "EditPipePropertiesForm";
            this.Load += new System.EventHandler(this.EditPipePropertiesForm_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private CustomControl.TranslucentButton btnCancel;
        private System.Windows.Forms.Label label_Tilte;
        private System.Windows.Forms.Label label1;
        private CustomControl.MTextBox mTextBox1;
        private System.Windows.Forms.Label label2;
        private CustomControl.MTextBox mTextBox2;
        private System.Windows.Forms.Label label3;
        private CustomControl.MTextBox mTextBox3;
        private System.Windows.Forms.Label label4;
        private CustomControl.MTextBox mTextBox4;
        private CustomControl.TranslucentButton btnOK;
        private System.Windows.Forms.Label label5;
        private CustomControl.MTextBox mTextBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}