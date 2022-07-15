using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CustomControl
{

    [ToolboxBitmap(typeof(TextBox))]
    public partial class MTextBox : UserControl
    {


        TextBox textBox = new TextBox();
    
        /// <summary>
        /// 获取或设置文本最大长度
        /// </summary>
        [Browsable(true), Category("MTextBox"), Description("获取或设置文本最大长度")]
        public int MaxLength
        {
            get { return this.textBox.MaxLength; }
            set { this.textBox.MaxLength = value; }
        }
        /// <summary>
        /// 获取或设置只读
        /// </summary>
        [Browsable(true), Category("MTextBox"), Description("获取或设置只读")]
        public bool ReadOnly
        {
            get { return this.textBox.ReadOnly; }
            set
            {
                this.textBox.ReadOnly = value;
                if (value)
                {
                    textBackColor = Color.FromArgb(230 ,230 ,230);
                    
                }
                else
                {
                    textBackColor = Color.White;
                   
                }
                textBox.BackColor = textBackColor;
            }
        }
        /// <summary>
        /// 获取或设置是否使用系统密码
        /// </summary>
        [Browsable(true), Category("MTextBox"), Description("获取或设置是否使用系统密码")]
        public bool UseSystemPasswordChar
        {
            get { return this.textBox.UseSystemPasswordChar; }
            set { this.textBox.UseSystemPasswordChar = value; }
        }

        /// <summary>
        /// 获取或设置密码字符
        /// </summary>
        [Browsable(true), Category("MTextBox"), Description("获取或设置密码字符")]
        public char PasswordChar
        {
            get { return this.textBox.PasswordChar; }
            set { this.textBox.PasswordChar = value; }
        }

        [Browsable(true), Category("MTextBox"), Description("文本输入")]
        public string MText
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                //if(value=="")
                //{
                //    textBox.Text = "0";
                //}
                //else
                //{
                //    if (Convert.ToInt16(value) > 100)
                //    {
                //        textBox.Text = "100";
                //    }
                //    else
                //    {
                //        textBox.Text = value;
                //    }
                //}
                textBox.Text = value;
                textBox.Select(textBox.Text.Length, 0);
                textBox.ScrollToCaret();
                this.Invalidate();

                this.OnTextChanged(EventArgs.Empty);
            }
        }
        /// <summary>
        /// 选择文本框中的文本范围。
        /// </summary>
        /// <param name="start">文本框中当前选定文本的第一个字符的位置</param>
        /// <param name="length">要选择的字符数</param>
        public void Select(int start, int length)
        {
                textBox.Select(start, length);   
                this.Invalidate();          
        }
        /// <summary>
        /// 将控件内容滚动到当前插入符号位置。
        /// </summary>
        public void ScrollToCaret()
        {
            textBox.ScrollToCaret();
            this.Invalidate();

        }
        [Category("MTextBox"), Description("文本的水平对齐方式")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return textBox.TextAlign;
            }
            set
            {
                textBox.TextAlign = value;
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                textBox.Font = value;
                base.Font = value;
            }
        }
        /// <summary>
        /// 文本的边距
        /// </summary>
        Padding textPadding = new Padding(5, 2, 5, 4);
        [Category("MTextBox"), Description("文本的边距")]
        public Padding TextPadding
        {
            get
            {
                return textPadding;
            }
            set
            {
                textPadding = value;
            }
        }
        /// <summary>
        /// 边框的颜色
        /// </summary>
        private Color borderColor = Color.Silver;
        [Category("MTextBox"), Description("边框的颜色")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
            }
        }
        /// <summary>
        /// 边框的焦点颜色
        /// </summary>
        private Color borderFocusColor = Color.Green;
        [Category("MTextBox"), Description("边框的焦点颜色")]
        public Color BorderFocusColor
        {
            get
            {
                return this.borderFocusColor;
            }
            set
            {
                this.borderFocusColor = value;
            }
        }

        /// <summary>
        /// 边框的粗细
        /// </summary>
        private int borderThickness = 1;
        [Category("MTextBox"), Description("边框的粗细")]
        public int BorderThickness
        {
            get
            {
                return this.borderThickness;
            }
            set
            {
                this.borderThickness = value;
            }
        }
        private int borderRadius = 0;
        /// <summary>
        /// 边框的圆角半径
        /// </summary>
        [Category("MTextBox"), Description("边框的圆角半径")]
        public int BorderRadius
        {
            get
            {
                return this.borderRadius;
            }
            set
            {
                this.borderRadius = value;
            }
        }

        /// <summary>
        /// 鼠标指针在控件上的显示样式
        /// </summary>
     
        public override Cursor Cursor
        {
            get
            {
                return this.textBox.Cursor;
            }
            set
            {
                this.textBox.Cursor = value;
            }
        }
        

        public MTextBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.SupportsTransparentBackColor,
               true);
            this.UpdateStyles();
            
            textBox.Margin = new Padding(0);
            textBox.Font = this.Font;
            textBox.BorderStyle = BorderStyle.None;
            textBox.KeyPress += TextBox_KeyPress;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.Click += TextBox_Click;
            textBox.SizeChanged += TextBox_SizeChanged;
            textBox.MouseEnter += new EventHandler(OnMouseEnter);
            textBox.MouseLeave += new EventHandler(OnMouseLeave);
            textBox.MouseDown += new  MouseEventHandler(OnMouseDown);
            textBox.MouseUp += new  MouseEventHandler(OnMouseUp);
            textBox.LostFocus += new EventHandler(OnLostFocus);
           
            this.Controls.Add(textBox);
            
        }

        private void TextBox_SizeChanged(object sender, EventArgs e)
        {
      //      /*int width */this.Width= textBox.Width + borderThickness * 2 + textPadding.Left + textPadding.Right;
            /*int height*/this.Height = textBox.Height + borderThickness * 2 + textPadding.Top + textPadding.Bottom;
        //    base.SetBoundsCore(0, 0, width, height, BoundsSpecified.All);
        }
     
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            height = textBox.Height + borderThickness * 2 + textPadding.Top + textPadding.Bottom;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        //protected override void OnPaintBackground(PaintEventArgs pevent)
        //{
        //    pevent.Graphics.Clear(Parent.BackColor);
        //    if (Color.Transparent.ToArgb() == BackColor.ToArgb())
        //        textBox.BackColor = Color.White;
        //    else
        //        textBox.BackColor = BackColor;
        //    textBox.ForeColor = ForeColor;
        //}


        Color textBackColor = Color.White;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            if (borderThickness <= 0)
                return;
            Pen borderPen = new Pen(borderColor, borderThickness);
            Pen borderFocusPen = new Pen(borderFocusColor, borderThickness);
            Pen borderEnterPen = new Pen(borderFocusColor, borderThickness + 1);
            Pen borderDisabledPen = new Pen(SystemColors.ControlDark, borderThickness);

            if (borderRadius <= 0)
            {
                g.DrawRectangle(borderPen, borderThickness, borderThickness, this.Width - borderThickness*2, this.Height - borderThickness*2);
                g.FillRectangle(new SolidBrush(textBackColor), borderThickness, borderThickness, this.Width - borderThickness*2, this.Height - borderThickness*2);
                return;
            }

            // 要实现 圆角化的 矩形
            Rectangle rect = new Rectangle(borderThickness, borderThickness, this.Width - borderThickness*2, this.Height - borderThickness*3);
            // 指定图形路径， 有一系列 直线/曲线 组成
            GraphicsPath borderPath = new GraphicsPath();
            borderPath.StartFigure();
            borderPath.AddArc(new Rectangle(new Point(rect.X, rect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 180, 90);
            borderPath.AddLine(new Point(rect.X + borderRadius, rect.Y), new Point(rect.Right - borderRadius, rect.Y));
            borderPath.AddArc(new Rectangle(new Point(rect.Right - 2 * borderRadius, rect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 270, 90);
            borderPath.AddLine(new Point(rect.Right, rect.Y + borderRadius), new Point(rect.Right, rect.Bottom - borderRadius));
            borderPath.AddArc(new Rectangle(new Point(rect.Right - 2 * borderRadius, rect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 0, 90);
            borderPath.AddLine(new Point(rect.Right - borderRadius, rect.Bottom), new Point(rect.X + borderRadius, rect.Bottom));
            borderPath.AddArc(new Rectangle(new Point(rect.X, rect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 90, 90);
            borderPath.AddLine(new Point(rect.X, rect.Bottom - borderRadius), new Point(rect.X, rect.Y + borderRadius));
            borderPath.CloseFigure();

            // 填充背景颜色
          
            g.FillPath(new SolidBrush(textBackColor), borderPath);

            // 绘制边框
            switch (ctrlState)
            {
                case ControlState.Normal:
                    g.DrawPath(borderPen, borderPath);
                    break;
                case ControlState.Enter:
                    g.DrawPath(borderEnterPen, borderPath);   
                    break;
                case ControlState.Focus:
                    g.DrawPath(borderFocusPen, borderPath);
                    break;
                case ControlState.Disabled:
                    g.DrawPath(borderDisabledPen, borderPath);
                    break;
                default:
                    break;
            }
          
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int x = borderRadius + borderThickness;
            int y = (Height - textBox.Height - borderThickness * 2) / 2 + textPadding.Top;
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(this.Width - borderThickness * 2 - borderRadius * 2 , this.Height - borderThickness);
        }

        
      
        private ControlState ctrlState = ControlState.Normal;

        protected  void OnMouseEnter(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                ctrlState = ControlState.Enter;
                base.OnMouseEnter(e);
                this.Invalidate();
            }
        }

        protected  void OnMouseLeave(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {

                if (ctrlState == ControlState.Enter && textBox.Focused)
                {
                    ctrlState = ControlState.Focus;
                }
                else if (ctrlState == ControlState.Focus)
                {
                    ctrlState = ControlState.Focus;
                }
                else
                {
                    ctrlState = ControlState.Normal;
                }
                base.OnMouseLeave(e);
                this.Invalidate();
            }
        }

        protected  void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!ReadOnly)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ctrlState = ControlState.Enter;
                }
                base.OnMouseDown(e);
                base.Validate();
            }
        }

        protected void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (!ReadOnly)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (ClientRectangle.Contains(e.Location))
                    {
                        ctrlState = ControlState.Enter;
                    }
                    else
                    {
                        ctrlState = ControlState.Focus;
                    }
                }
                base.OnMouseUp(e);
                this.Invalidate();
            }
        }

        protected void OnLostFocus(object sender, EventArgs e)
        {
            ctrlState = ControlState.Normal;
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
            {
                ctrlState = ControlState.Normal;
            }
            else
            {
                ctrlState = ControlState.Disabled;
            }
            base.OnEnabledChanged(e);
            this.Invalidate();
        }




        public enum TextFormatModel
        {
            /// <summary>
            /// 无输入
            /// </summary>
            none,
            /// <summary>
            /// 文本
            /// </summary>
            Text,
            /// <summary>
            /// 整型数字
            /// </summary>
            Integer,
            /// <summary>
            /// 浮点型数字
            /// </summary>
            Decimal,
            /// <summary>
            /// IP地址
            /// </summary>
            IpAddress
        }
        private TextFormatModel textModel;

        [Category("MTextBox"), Description("文本格式"), DefaultValue(typeof(TextFormatModel), "Text")]
        public TextFormatModel TextModel
        {
            get
            {
                return textModel;
            }
            set
            {
                textModel = value;
            }
        }

        private int digits=10;
        [Category("MTextBox"), Description("小数位数"), DefaultValue(typeof(int), "10")]
        public int Digits
        {
            get
            {
                return digits;
            }
            set
            {
                digits = value;
            }
        }

        private bool allowMinus = false;
        [Category("MTextBox"), Description("是否允许负数"), DefaultValue(typeof(bool), "false")]
        public bool AllowMinus
        {
            get
            {
                return allowMinus;
            }
            set
            {
                allowMinus = value;
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            // 删除和退格，不处理
            if (e.KeyChar == 8 || e.KeyChar == 127)
            {
                return;
            }

            ///48代表0，57代表9，8代表退格，46代表小数点,，45代表 - 号
            if (this.TextModel == TextFormatModel.Integer)
            {
                if (this.AllowMinus)
                {
                    e.Handled = (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45;
                }
                else
                {
                    e.Handled = e.KeyChar < 48 || e.KeyChar > 57;
                }
                             
            }
            else if (this.TextModel == TextFormatModel.Decimal)
            {
                if (this.AllowMinus)
                {
                    e.Handled = (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 45 && e.KeyChar != 46;
                }
                else
                {
                    e.Handled = (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 46;
                }

                // 小数点只能有1个
                if (!e.Handled && e.KeyChar == 46 && this.Text.Contains("."))
                {
                    e.Handled = true;
                }

                // 处理小数位数
                if (!e.Handled && this.Text.Contains("."))
                {
                    e.Handled = this.Text.Split(new string[] { "." }, StringSplitOptions.None)[1].Length >= digits;
                }
            }
            else if (this.TextModel == TextFormatModel.IpAddress)
            {
                // IP地址，只支持输入数字和小数点
                e.Handled = (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 46;
            }
            else
            {
                base.OnKeyPress(e);
            }
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                return;
            }
        }

    }


   
}
