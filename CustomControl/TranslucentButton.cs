using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using CustomControl;

namespace CustomControl
{



    public class TranslucentButton : PictureBox, IButtonControl
    {
        #region  Fileds

        private DialogResult _DialogResult;
        private bool _isDefault = false;
        private bool _holdingSpace = false;

        private ControlState _state = ControlState.Normal;
        private Font _defaultFont = new Font("微软雅黑", 9);

        private Image _glassHotImg = Properties.Resources.glassbtn_hot;
        private Image _glassDownImg = Properties.Resources.glassbtn_down;

        private ToolTip _toolTip = new ToolTip();

        #endregion

        #region Constructor

        public TranslucentButton()
            : base()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(75, 23);
            this.BorderStyle = BorderStyle.None;
            this.Font = _defaultFont;
        }

        #endregion

        #region IButtonControl Members

        public DialogResult DialogResult
        {
            get
            {
                return _DialogResult;
            }
            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                {
                    _DialogResult = value;
                }
            }
        }

        public void NotifyDefault(bool value)
        {
            if (_isDefault != value)
            {
                _isDefault = value;
            }
        }

        public void PerformClick()
        {
            base.OnClick(EventArgs.Empty);
        }

        #endregion

        #region  Properties

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The text associated with the control.")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The font used to display text in the control.")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Description("当鼠标放在控件可见处的提示文本")]
        public string ToolTipText { get; set; }

        #endregion

        #region Description Changes
        [Description("Controls how the ImageButton will handle image placement and control sizing.")]
        public new PictureBoxSizeMode SizeMode { get { return base.SizeMode; } set { base.SizeMode = value; } }

        [Description("Controls what type of border the ImageButton should have.")]
        public new BorderStyle BorderStyle { get { return base.BorderStyle; } set { base.BorderStyle = value; } }
        #endregion

        #region Hiding

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { base.BackgroundImageLayout = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage { get { return base.BackgroundImage; } set { base.BackgroundImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String ImageLocation { get { return base.ImageLocation; } set { base.ImageLocation = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image ErrorImage { get { return base.ErrorImage; } set { base.ErrorImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image InitialImage { get { return base.InitialImage; } set { base.InitialImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool WaitOnLoad { get { return base.WaitOnLoad; } set { base.WaitOnLoad = value; } }
        #endregion

        #region override

        private bool isTranslucent=true;
        [Category("外观"), Description("是否半透明效果")]
        public bool IsTranslucent
        {
            get
            {
                return this.isTranslucent;
            }
            set
            {
                if (this.isTranslucent != value)
                {
                    this.isTranslucent = value;
                   
                }
            }
        }

        private Color fontColor = Color.Black;
        [Category("外观"), Description("是否半透明效果")]
        public Color FontColor
        {
            get
            {
                return this.fontColor;
            }
            set
            {
                if (this.fontColor != value)
                {
                    this.fontColor = value;
                }
            }
        }

        //private Color _backlColor;
        //[Category("外观"), Description("按钮背景色")]
        //public Color ButtonBackColor
        //{
        //    get
        //    {
        //        return this._backlColor;
        //    }
        //    set
        //    {
        //        if (this._backlColor != value)
        //        {
        //            this._backlColor = value;
        //            this.BackColor = value;
        //        }
        //    }
        //}

        private Color _mouseHoverColor;
        [Category("外观"), Description("鼠标在按钮上的颜色")]
        public Color MouseHoverColor
        {
            get
            {
                return this._mouseHoverColor;
            }
            set
            {
                if (this._mouseHoverColor != value)
                {
                    this._mouseHoverColor = value;
                }
            }
        }

        private bool isBorder;
        [Category("外观"), Description("按钮是否有边框")]
        public bool IsBorder
        {
            get
            {
                return this.isBorder;
            }
            set
            {
                if (this.isBorder != value)
                {
                    this.isBorder = value;

                    this.BorderStyle = BorderStyle.None;
                }
            }
        }
        private Color borderColor;
        [Category("外观"), Description("边框的颜色")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor != value)
                {
                    this.borderColor = value;
                }
            }
        }
        private int borderWidth;
        [Category("外观"), Description("边框的宽度")]
        public int BorderWidth
        {
            get
            {
                return this.borderWidth;
            }
            set
            {
                if (this.borderWidth != value)
                {
                    this.borderWidth = value;
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //show tool tip 
            if (ToolTipText != string.Empty)
            {
                HideToolTip();
                ShowTooTip(ToolTipText);
            }

            _state = ControlState.Enter;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _state = ControlState.Normal;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _state = ControlState.Down;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(e.Location))
                    _state = ControlState.Enter;
                else
                    _state = ControlState.Normal;
            }
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {

            _state = ControlState.Normal;
            Invalidate();
            _holdingSpace = false;
            base.OnLostFocus(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle imageRect, textRect;
            CalculateRect(out imageRect, out textRect);
            switch (_state)
            {
                case ControlState.Enter:
                    if (isTranslucent)
                    {
                        DrawImageWithNineRect(
                           pe.Graphics,
                         _glassHotImg,
                          ClientRectangle,
                          new Rectangle(0, 0, _glassDownImg.Width, _glassDownImg.Height));
                    }
                    else
                    {
                        pe.Graphics.FillRectangle(new SolidBrush(_mouseHoverColor), new Rectangle(0, 0, this.Width, this.Height));
                    }
                        break;
                case ControlState.Down:
                    if (isTranslucent)
                    {
                        DrawImageWithNineRect(
                         pe.Graphics,
                        _glassDownImg,
                        ClientRectangle,
                        new Rectangle(0, 0, _glassDownImg.Width, _glassDownImg.Height));
                    }
                    else
                    {

                    }
                    break;
                case ControlState.Normal:
                    if (!isTranslucent)
                    {
                        pe.Graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, 0, this.Width, this.Height));

                        if (isBorder)
                        {
                            pe.Graphics.DrawRectangle(new Pen(this.borderColor, this.borderWidth), new Rectangle(0, 0, this.Width - borderWidth * 2, this.Height - borderWidth * 2));
                        }
                    }
                    break;
                default:
                    break;
            }
            


            if (Image != null)
            {

                pe.Graphics.DrawImage(Image, imageRect);
            }

            if (Text.Trim().Length != 0)
            {
                Graphics graphics = pe.Graphics;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                TextRenderer.DrawText(
                    graphics,
                    Text,
                    Font,
                    textRect,
                    fontColor);
            }
        }

        /// <summary>
        /// 利用九宫图绘制图像
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="img">所需绘制的图片</param>
        /// <param name="targetRect">目标矩形</param>
        /// <param name="srcRect">来源矩形</param>
        public static void DrawImageWithNineRect(Graphics g, Image img, Rectangle targetRect, Rectangle srcRect)
        {
            int offset = 5;
            Rectangle NineRect = new Rectangle(img.Width / 2 - offset, img.Height / 2 - offset, 2 * offset, 2 * offset);
            int x = 0, y = 0, nWidth, nHeight;
            int xSrc = 0, ySrc = 0, nSrcWidth, nSrcHeight;
            int nDestWidth, nDestHeight;
            nDestWidth = targetRect.Width;
            nDestHeight = targetRect.Height;
            // 左上-------------------------------------;
            x = targetRect.Left;
            y = targetRect.Top;
            nWidth = NineRect.Left - srcRect.Left;
            nHeight = NineRect.Top - srcRect.Top;
            xSrc = srcRect.Left;
            ySrc = srcRect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 上-------------------------------------;
            x = targetRect.Left + NineRect.Left - srcRect.Left;
            nWidth = nDestWidth - nWidth - (srcRect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            nSrcHeight = NineRect.Top - srcRect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 右上-------------------------------------;
            x = targetRect.Right - (srcRect.Right - NineRect.Right);
            nWidth = srcRect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 左-------------------------------------;
            x = targetRect.Left;
            y = targetRect.Top + NineRect.Top - srcRect.Top;
            nWidth = NineRect.Left - srcRect.Left;
            nHeight = targetRect.Bottom - y - (srcRect.Bottom - NineRect.Bottom);
            xSrc = srcRect.Left;
            ySrc = NineRect.Top;
            nSrcWidth = NineRect.Left - srcRect.Left;
            nSrcHeight = NineRect.Bottom - NineRect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 中-------------------------------------;
            x = targetRect.Left + NineRect.Left - srcRect.Left;
            nWidth = nDestWidth - nWidth - (srcRect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);

            // 右-------------------------------------;
            x = targetRect.Right - (srcRect.Right - NineRect.Right);
            nWidth = srcRect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            nSrcWidth = srcRect.Right - NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);

            // 左下-------------------------------------;
            x = targetRect.Left;
            y = targetRect.Bottom - (srcRect.Bottom - NineRect.Bottom);
            nWidth = NineRect.Left - srcRect.Left;
            nHeight = srcRect.Bottom - NineRect.Bottom;
            xSrc = srcRect.Left;
            ySrc = NineRect.Bottom;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 下-------------------------------------;
            x = targetRect.Left + NineRect.Left - srcRect.Left;
            nWidth = nDestWidth - nWidth - (srcRect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            nSrcHeight = srcRect.Bottom - NineRect.Bottom;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 右下-------------------------------------;
            x = targetRect.Right - (srcRect.Right - NineRect.Right);
            nWidth = srcRect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == Win32.WM_KEYUP)
            {
                if (_holdingSpace)
                {
                    if ((int)msg.WParam == (int)Keys.Space)
                    {
                        OnMouseUp(null);
                        PerformClick();
                    }
                    else if ((int)msg.WParam == (int)Keys.Escape
                        || (int)msg.WParam == (int)Keys.Tab)
                    {
                        _holdingSpace = false;
                        OnMouseUp(null);
                    }
                }
                return true;
            }
            else if (msg.Msg == Win32.WM_KEYDOWN)
            {
                if ((int)msg.WParam == (int)Keys.Space)
                {
                    _holdingSpace = true;
                    OnMouseDown(null);
                }
                else if ((int)msg.WParam == (int)Keys.Enter)
                {
                    PerformClick();
                }
                return true;
            }
            else
                return base.PreProcessMessage(ref msg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_defaultFont != null)
                    _defaultFont.Dispose();
                if (_glassDownImg != null)
                    _glassDownImg.Dispose();
                if (_glassHotImg != null)
                    _glassHotImg.Dispose();
                if (_toolTip != null)
                    _toolTip.Dispose();
            }
            _defaultFont = null;
            _glassDownImg = null;
            _glassHotImg = null;
            _toolTip = null;
            base.Dispose(disposing);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Refresh();
            base.OnTextChanged(e);
        }

        #endregion

        #region Private

        private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
        {
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            if (Image == null && !string.IsNullOrEmpty(Text))
            {
                textRect = new Rectangle(3, 0, Width - 6, Height);
            }
            else if (Image != null && string.IsNullOrEmpty(Text))
            {
                //  imageRect = new Rectangle((Width - Image.Width) / 2, (Height - Image.Height) / 2, Image.Width, Image.Height);
                imageRect = new Rectangle(0, 0, this.Width, this.Height);
            }
            else if (Image != null && !string.IsNullOrEmpty(Text))
            {
                int imageSize = Math.Min(this.Width, this.Height);
                imageRect = new Rectangle(0, 0, imageSize, imageSize);
                textRect = new Rectangle(imageRect.Right + 2, 0, Width - 2 * 2 - imageRect.Width - 1, Height);
            }
        }

        private void ShowTooTip(string toolTipText)
        {
            _toolTip.Active = true;
            _toolTip.SetToolTip(this, toolTipText);
        }

        private void HideToolTip()
        {
            _toolTip.Active = false;
        }

        #endregion
    }
}

