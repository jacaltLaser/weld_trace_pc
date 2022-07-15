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
    public partial class TitlePanel : Panel
    {
        public TitlePanel()
        {
            InitializeComponent();


        }

        /// <summary>
        /// 边框的颜色
        /// </summary>
        private Color borderColor = Color.Silver;
        [Browsable(true), Category("外观"), Description("边框的颜色")]
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

        /// <summary>
        /// 边框的圆角
        /// </summary>
        private int borderRadius = 5;
        [Browsable(true), Category("外观"), Description("边框的圆角度数")]
        public int BorderRadius
        {
            get
            {
                return this.borderRadius;
            }
            set
            {
                if (this.borderRadius != value)
                {
                    this.borderRadius = value;

                }
            }
        }
        /// <summary>
        /// 边框的粗细
        /// </summary>
        private int borderThickness = 1;
        [Browsable(true), Category("外观"), Description("边框的粗细")]
        public int BorderThickness
        {
            get
            {
                return this.borderThickness;
            }
            set
            {

                if (this.borderThickness != value)
                {
                    this.borderThickness = value;
                }
            }
        }

        /// <summary>
        /// 背景颜色
        /// </summary>
        private Color panelBackColor;
        [Browsable(true), Category("外观"), Description("背景的颜色")]
        public Color PanelBackColor
        {
            get
            {
                return this.panelBackColor;
            }
            set
            {
                if (this.panelBackColor != value)
                {
                    this.panelBackColor = value;
                   /// this.BackColor = Color.Transparent;
                }
            }
        }

        /// <summary>
        /// 标题栏的高度
        /// </summary>
        private int titleSize = 35;
        [Browsable(true), Category("外观"), Description("标题栏的高度")]
        public int TitleSize
        {
            get
            {
                return this.titleSize;
            }
            set
            {
                if (this.titleSize != value)
                {
                    this.titleSize = value;
                }
            }
        }
        /// <summary>
        /// 标题文本的边距
        /// </summary>
        Padding titlePadding = new Padding(0);
        [Browsable(true), Category("外观"), Description("标题文本的边距")]
        public Padding TitlePadding
        {
            get
            {
                return titlePadding;
            }
            set
            {
                titlePadding = value;
            }
        }

        /// <summary>
        /// 文本
        /// </summary>
        string text = "";
        [Browsable(true), Category("外观"), Description("文本")]
        public override string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                }
            }
        }
        StringFormat textStringFormat = new StringFormat();
        /// <summary>
        /// 文本位置
        /// </summary>
        private ContentAlignment textAlign = ContentAlignment.TopLeft;
        [Browsable(true), Category("外观"), Description("文本位置")]
        public ContentAlignment TextAlign
        {
            get
            {
                return this.textAlign;
            }
            set
            {
                if (this.textAlign != value)
                {
                    this.textAlign = value;
                    switch (textAlign)
                    {
                        case ContentAlignment.TopLeft:
                            textStringFormat.Alignment = StringAlignment.Near;
                            textStringFormat.LineAlignment = StringAlignment.Near;
                            break;
                        case ContentAlignment.TopCenter:
                            textStringFormat.Alignment = StringAlignment.Center;
                            textStringFormat.LineAlignment = StringAlignment.Near;
                            break;
                        case ContentAlignment.TopRight:
                            textStringFormat.Alignment = StringAlignment.Far;
                            textStringFormat.LineAlignment = StringAlignment.Near;
                            break;
                        case ContentAlignment.MiddleLeft:
                            textStringFormat.Alignment = StringAlignment.Near;
                            textStringFormat.LineAlignment = StringAlignment.Center;
                            break;
                        case ContentAlignment.MiddleCenter:
                            textStringFormat.Alignment = StringAlignment.Center;
                            textStringFormat.LineAlignment = StringAlignment.Center;
                            break;
                        case ContentAlignment.MiddleRight:
                            textStringFormat.Alignment = StringAlignment.Far;
                            textStringFormat.LineAlignment = StringAlignment.Center;
                            break;
                        case ContentAlignment.BottomLeft:
                            textStringFormat.Alignment = StringAlignment.Near;
                            textStringFormat.LineAlignment = StringAlignment.Far;
                            break;
                        case ContentAlignment.BottomCenter:
                            textStringFormat.Alignment = StringAlignment.Center;
                            textStringFormat.LineAlignment = StringAlignment.Far;
                            break;
                        case ContentAlignment.BottomRight:
                            textStringFormat.Alignment = StringAlignment.Far;
                            textStringFormat.LineAlignment = StringAlignment.Far;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 标题文本
        /// </summary>
        private string titleText = "标题";
        [Browsable(true), Category("外观"), Description("标题文本")]
        public string TitleText
        {
            get
            {
                return this.titleText;
            }
            set
            {
                if (this.titleText != value)
                {
                    this.titleText = value;
                }
            }
        }

        /// <summary>
        /// 文本字体
        /// </summary>
        private Font textFont = new Font("微软雅黑", 9F);
        [Browsable(true), Category("外观"), Description("文本的字体")]
        public Font TextFont
        {
            get
            {
                return this.textFont;
            }
            set
            {
                if (this.textFont != value)
                {
                    this.textFont = value;
                }
            }
        }
        /// <summary>
        /// 标题颜色
        /// </summary>
        private Color titleColor = Color.Black;
        [Browsable(true), Category("外观"), Description("标题的颜色")]
        public Color TitleColor
        {
            get
            {
                return this.titleColor;
            }
            set
            {
                if (this.titleColor != value)
                {
                    this.titleColor = value;
                }
            }
        }
        public enum TitleAlignment { left, top, right, bottom };
        /// <summary>
        /// 标题栏位置
        /// </summary>
        private TitleAlignment titleAlign = TitleAlignment.top;
        [Browsable(true), Category("外观"), Description("标题栏的位置")]
        public TitleAlignment TitleAlign
        {
            get
            {
                return this.titleAlign;
            }
            set
            {
                if (this.titleAlign != value)
                {
                    this.titleAlign = value;  
                }
            }
        }

        StringFormat titleStringFormat = new StringFormat();
        /// <summary>
        /// 标题文本位置
        /// </summary>
        private ContentAlignment titleTextAlign = ContentAlignment.TopLeft;
        [Browsable(true), Category("外观"), Description("标题的文本位置")]
        public ContentAlignment TitleTextAlign
        {
            get
            {
                return this.titleTextAlign;
            }
            set
            {
                if (this.titleTextAlign != value)
                {
                    this.titleTextAlign = value;
                    switch (titleTextAlign)
                    {
                        case ContentAlignment.TopLeft:
                            titleStringFormat.Alignment = StringAlignment.Near;
                            titleStringFormat.LineAlignment = StringAlignment.Near;
                            break;
                        case ContentAlignment.TopCenter:
                            titleStringFormat.Alignment = StringAlignment.Center;
                            titleStringFormat.LineAlignment = StringAlignment.Near;
                            break;
                        case ContentAlignment.TopRight:
                            titleStringFormat.Alignment = StringAlignment.Far;
                            titleStringFormat.LineAlignment = StringAlignment.Near;
                            break;
                        case ContentAlignment.MiddleLeft:
                            titleStringFormat.Alignment = StringAlignment.Near;
                            titleStringFormat.LineAlignment = StringAlignment.Center;
                            break;
                        case ContentAlignment.MiddleCenter:
                            titleStringFormat.Alignment = StringAlignment.Center;
                            titleStringFormat.LineAlignment = StringAlignment.Center;
                            break;
                        case ContentAlignment.MiddleRight:
                            titleStringFormat.Alignment = StringAlignment.Far;
                            titleStringFormat.LineAlignment = StringAlignment.Center;
                            break;
                        case ContentAlignment.BottomLeft:
                            titleStringFormat.Alignment = StringAlignment.Near;
                            titleStringFormat.LineAlignment = StringAlignment.Far;
                            break;
                        case ContentAlignment.BottomCenter:
                            titleStringFormat.Alignment = StringAlignment.Center;
                            titleStringFormat.LineAlignment = StringAlignment.Far;
                            break;
                        case ContentAlignment.BottomRight:
                            titleStringFormat.Alignment = StringAlignment.Far;
                            titleStringFormat.LineAlignment = StringAlignment.Far;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 是否根据边框颜色自动生成控件的背景颜色
        /// </summary>
        private bool isAutoBackColor = true;
        [Browsable(true), Category("外观"), Description("是否根据边框颜色自动生成控件的背景颜色")]
        public bool IsAutoBackColor
        {

            get
            {
                return isAutoBackColor;
            }

            set
            {
                this.isAutoBackColor = value;
            }

        }

        /// <summary>
        /// 是否启用标题背景渐变效果
        /// </summary>
        private bool isGradientChange = true;
        [Browsable(true), Category("外观"), Description("是否启用标题背景渐变效果")]
        public bool TitleBackColorGradientChange
        {

            get
            {
                return isGradientChange;
            }

            set
            {
                this.isGradientChange = value;
            }

        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            drawTitleBorder(pe.Graphics);

        }

        /// <summary>
        /// 绘制标题栏和边框
        /// </summary>
        /// <param name="g"></param>
        private void drawTitleBorder(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

            if (borderThickness <= 0)
                return;
            
            this.borderColor=    this.panelBackColor ;
   
            Brush backbrush = new SolidBrush(this.panelBackColor);

            Brush titlebrush = new SolidBrush(this.borderColor);
            if (isGradientChange)
            {
                LinearGradientBrush gradientBrush = new LinearGradientBrush(this.ClientRectangle, this.borderColor, this.panelBackColor, LinearGradientMode.Horizontal);
                Blend myBlend = new Blend();
                myBlend.Factors = new float[] { 0.0F, 0.2F, 0.5F, 0.8F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F };
                myBlend.Positions = new float[] { 0.0F, 0.1F, 0.3F, 0.4F, 0.5F, 0.6F, 0.7F, 0.8F, 1.0F };
                gradientBrush.Blend = myBlend;

                titlebrush = gradientBrush;
            }
            
            
            Pen borderPen = new Pen(borderColor, borderThickness);

            if (borderRadius <= 0)
            {
                // 绘制背景颜色
                Rectangle borderRect = new Rectangle(borderThickness, borderThickness, this.Width - borderThickness * 2, this.Height - borderThickness * 2);
                g.FillRectangle(backbrush, borderRect);
                // 绘制文本
                g.DrawString(text, this.TextFont, new SolidBrush(this.ForeColor), GetStringRectangle(borderRect,this.Padding), textStringFormat);

                if (titleSize > 2)
                {
                    // 绘制标题栏
                    Rectangle titleRect = new Rectangle(borderThickness, borderThickness, this.Width - borderThickness * 2, titleSize);
                    g.FillRectangle(titlebrush, titleRect);

                    // 绘制标题文本
                    g.DrawString(titleText, Font, new SolidBrush(this.TitleColor), GetStringRectangle(titleRect, this.titlePadding) , titleStringFormat);
                }
                // 绘制边框
                g.DrawRectangle(borderPen, borderThickness, borderThickness, this.Width - borderThickness * 2, this.Height - borderThickness * 2);

            }
            else
            {
                // 要实现 圆角化的 矩形
                Rectangle borderRect = new Rectangle(borderThickness, borderThickness, this.Width - borderThickness * 2, this.Height - borderThickness * 2);
                //// 指定图形路径， 有一系列 直线/曲线 组成---边框
                GraphicsPath borderPath = new GraphicsPath();
                borderPath.StartFigure();
                borderPath.AddArc(new Rectangle(new Point(borderRect.X, borderRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 180, 90);
                borderPath.AddLine(new Point(borderRect.X + borderRadius, borderRect.Y), new Point(borderRect.Right - borderRadius, borderRect.Y));
                borderPath.AddArc(new Rectangle(new Point(borderRect.Right - 2 * borderRadius, borderRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 270, 90);
                borderPath.AddLine(new Point(borderRect.Right, borderRect.Y + borderRadius), new Point(borderRect.Right, borderRect.Bottom - borderRadius));
                borderPath.AddArc(new Rectangle(new Point(borderRect.Right - 2 * borderRadius, borderRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 0, 90);
                borderPath.AddLine(new Point(borderRect.Right - borderRadius, borderRect.Bottom), new Point(borderRect.X + borderRadius, borderRect.Bottom));
                borderPath.AddArc(new Rectangle(new Point(borderRect.X, borderRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 90, 90);
                borderPath.AddLine(new Point(borderRect.X, borderRect.Bottom - borderRadius), new Point(borderRect.X, borderRect.Y + borderRadius));
                borderPath.CloseFigure();

                // 填充背景颜色
                g.FillPath(backbrush, borderPath);
                // 绘制文本
                g.DrawString(text, this.TextFont, new SolidBrush(this.ForeColor), GetStringRectangle(borderRect,this.Padding), textStringFormat);


                if (titleSize > 2)
                {

                    Rectangle titleRect = new Rectangle();
                    GraphicsPath titlePath = GetTitleGraphicsPath(out titleRect);
                    // 绘制标题栏
                    g.FillPath(titlebrush, titlePath);
                    // 绘制标题文本
                    g.DrawString(titleText, Font, new SolidBrush(this.titleColor), new Rectangle(titleRect.X + titlePadding.Left, titleRect.Y + titlePadding.Top, titleRect.Width - titlePadding.Left - titlePadding.Right, titleRect.Height - titlePadding.Top - titlePadding.Bottom), titleStringFormat);
                }

                // 绘制边框
                g.DrawPath(borderPen, borderPath);


            }
        }


        private Rectangle GetStringRectangle(Rectangle drawRect, Padding padding)
        {
            //// 指定图形路径， 有一系列 直线/曲线 组成---标题栏
            Rectangle  rect = new Rectangle();

            switch (titleAlign)
            {
                case TitleAlignment.top:
                    rect = new Rectangle(drawRect.X + padding.Left, drawRect.Y  + padding.Top, drawRect.Width - padding.Left - padding.Right, drawRect.Height - titleSize - padding.Top - padding.Bottom);
                    break;

                case TitleAlignment.bottom:
                    rect = new Rectangle(drawRect.X + padding.Left, drawRect.Y + titleSize + padding.Top, drawRect.Width - padding.Left - padding.Right, drawRect.Height  - padding.Top - padding.Bottom);
                    break;

                case TitleAlignment.left:
                    rect = new Rectangle(drawRect.X + titleSize + padding.Left, drawRect.Y + padding.Top, drawRect.Width - titleSize - padding.Left - padding.Right, drawRect.Height - padding.Top - padding.Bottom);
                    break;

                case TitleAlignment.right:
                    rect = new Rectangle(drawRect.X + padding.Left, drawRect.Y + padding.Top, drawRect.Width - titleSize - padding.Left - padding.Right, drawRect.Height - padding.Top - padding.Bottom);
                    break; 

                default:
                    rect = new Rectangle();
                    break;
            }


            return rect;
        }
        /// <summary>
        /// 根据标题的位置生成指定图形路径
        /// </summary>
        /// <param name="titleRect"></param>
        /// <returns></returns>
        private GraphicsPath GetTitleGraphicsPath(out Rectangle textRect)
        {

            Rectangle titleRect = new Rectangle(0,0,0,0);
            //// 指定图形路径， 有一系列 直线/曲线 组成---标题栏
            GraphicsPath titlePath = new GraphicsPath();

            switch (titleAlign)
            {
                case TitleAlignment.top:
                    // 要实现 圆角化的 矩形
                    titleRect = new Rectangle(borderThickness, borderThickness, this.Width - borderThickness * 2 , titleSize);
                    
                        titlePath.StartFigure();
                        titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 180, 90);
                        titlePath.AddLine(new Point(titleRect.X + borderRadius, titleRect.Y), new Point(titleRect.Right - borderRadius, titleRect.Y));//上
                        titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 270, 90);
                        titlePath.AddLine(new Point(titleRect.Right, titleRect.Y + borderRadius), new Point(titleRect.Right, titleRect.Bottom));//右
                                                                                                                                                //     titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 0, 90);
                        titlePath.AddLine(new Point(titleRect.Right, titleRect.Bottom), new Point(titleRect.X, titleRect.Bottom));//下
                                                                                                                                  //  titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 90, 90);
                        titlePath.AddLine(new Point(titleRect.X, titleRect.Bottom), new Point(titleRect.X, titleRect.Y + borderRadius));//左
                        titlePath.CloseFigure();

                    
                    
                    break;

                case TitleAlignment.bottom:
                    // 要实现 圆角化的 矩形
                    titleRect = new Rectangle(borderThickness, this.Height - borderThickness - titleSize, this.Width - borderThickness * 2, titleSize);
                    titlePath.StartFigure();
                    //  titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 180, 90);
                    titlePath.AddLine(new Point(titleRect.X /*+ borderRadius*/, titleRect.Y), new Point(titleRect.Right/* - borderRadius*/, titleRect.Y));//上
                                                                                                                                                          //  titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 270, 90);
                    titlePath.AddLine(new Point(titleRect.Right, titleRect.Y), new Point(titleRect.Right, titleRect.Bottom - borderRadius));//右
                    titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 0, 90);
                    titlePath.AddLine(new Point(titleRect.Right - borderRadius, titleRect.Bottom), new Point(titleRect.X - borderRadius, titleRect.Bottom));//下
                    titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 90, 90);
                    titlePath.AddLine(new Point(titleRect.X, titleRect.Bottom - borderRadius), new Point(titleRect.X, titleRect.Y));//左
                    titlePath.CloseFigure();

                  
                    break;

                case TitleAlignment.left:
                    titleRect = new Rectangle(borderThickness, borderThickness, titleSize, this.Height);
                    titlePath.StartFigure();
                    titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 180, 90);
                    titlePath.AddLine(new Point(titleRect.X + borderRadius, titleRect.Y), new Point(titleRect.Right, titleRect.Y));//上
                                                                                                                                   //  titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 270, 90);
                    titlePath.AddLine(new Point(titleRect.Right, titleRect.Y), new Point(titleRect.Right, titleRect.Bottom - borderRadius));//右
                                                                                                                                            //   titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 0, 90);
                    titlePath.AddLine(new Point(titleRect.Right, titleRect.Bottom), new Point(titleRect.X - borderRadius, titleRect.Bottom - borderRadius));//下
                    titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 90, 90);
                    titlePath.AddLine(new Point(titleRect.X, titleRect.Bottom - borderRadius), new Point(titleRect.X, titleRect.Y + borderRadius));//左
                    titlePath.CloseFigure();
                    
                    break;

                case TitleAlignment.right:
                    titleRect = new Rectangle(this.Width - borderThickness - titleSize, borderThickness, titleSize, this.Height);
                    titlePath.StartFigure();
                    //  titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 180, 90);
                    titlePath.AddLine(new Point(titleRect.X, titleRect.Y), new Point(titleRect.Right - borderRadius, titleRect.Y));//上
                    titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Y), new Size(2 * borderRadius, 2 * borderRadius)), 270, 90);
                    titlePath.AddLine(new Point(titleRect.Right, titleRect.Y + borderRadius), new Point(titleRect.Right, titleRect.Bottom));//右
                    titlePath.AddArc(new Rectangle(new Point(titleRect.Right - 2 * borderRadius, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 0, 90);
                    titlePath.AddLine(new Point(titleRect.Right - borderRadius, titleRect.Bottom), new Point(titleRect.X, titleRect.Bottom));//下
                                                                                                                                             //  titlePath.AddArc(new Rectangle(new Point(titleRect.X, titleRect.Bottom - 2 * borderRadius), new Size(2 * borderRadius, 2 * borderRadius)), 90, 90);
                    titlePath.AddLine(new Point(titleRect.X, titleRect.Bottom), new Point(titleRect.X, titleRect.Y));//左
                    titlePath.CloseFigure();

                    
                    break;

                default:
                    titleRect = new Rectangle(0,0,0,0);
                    break;
            }

            textRect = titleRect;
            return titlePath;
        }

       





    }


}
