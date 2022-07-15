using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CustomControl
{
    public partial class MTreeView : TreeView
    {
        Color rootbackColor = Color.FromArgb(41, 57, 85);
        Color roothoverColor = Color.FromArgb(77, 96, 120);

        Color twobackColor = Color.FromArgb(66, 85, 110);
        Color twohoverColor = Color.FromArgb(80, 100, 140);

        Color threebackColor = Color.FromArgb(94, 120, 155);
        Color threehoverColor = Color.FromArgb(115, 138, 170);
        Color threeselectColor = Color.FromArgb(240, 240, 240); //选中的背景颜色


        Font nodeForeFont = new Font("微软雅黑", 10F ,FontStyle.Bold);
        Color nodeForeColor = Color.White; //选中字体颜色
        Brush nodeForeBrush = new SolidBrush(Color.White);//字体颜色
        Color nodeForeSelectColor = Color.DodgerBlue; //选中字体颜色

        Pen linePen = new Pen(Color.DeepSkyBlue, 2);//父子项间的连线
        bool blnHasVBar = false;

        public MTreeView()
        {
            InitializeComponent();

            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.ItemHeight = 30;//节点行高          
        //    this.BackColor = rootbackColor;
            this.ShowLines = true;
            this.HotTracking = true;
            this.Indent = 20;//节点X值缩进量
            this.Scrollable = true;
            this.BorderStyle = BorderStyle.None;
            this.Font = nodeForeFont;
        }

        bool _isAutoChangeNodeColor=false;
        [Category("自定义属性"), Description("是否设置自动子节点背景色随父节点背景色逐级变淡")]
        public bool IsAutoChangeNodeColor

        {
            get
            {
                return this._isAutoChangeNodeColor;
            }
            set
            {
                this._isAutoChangeNodeColor = value;
            }
        }
        [Category("自定义属性"), Description("节点高度")]
        public int NodeHeight
        {
            get
            {
                return base.ItemHeight;
            }
            set
            {
                base.ItemHeight = value;
            }
        }
       Image _nodeDownPic = Properties.Resources.node_down;

        [Category("自定义属性"), Description("下翻图标")]
        public Image NodeDownPic
        {
            get
            {
                return this._nodeDownPic;
            }
            set
            {
                this._nodeDownPic = value;
            }
        }
       Image _nodeUpPic = Properties.Resources.node_up;
        [Category("自定义属性"), Description("上翻图标")]
        public Image NodeUpPic
        {
            get
            {
                return this._nodeUpPic;
            }
            set
            {
                this._nodeUpPic = value;
            }
        }

        bool _nodeIsShowSplitLine = false;
        [Category("自定义属性"), Description("是否显示节点分隔线")]
        public bool IsShowSplitLine

        {
            get
            {
                return this._nodeIsShowSplitLine;
            }
            set
            {
                this._nodeIsShowSplitLine = value;
            }
        }
        Color _nodeSplitLineColor = Color.Silver;
        [Category("自定义属性"), Description("节点分隔线颜色")]
        public Color SplitLineColor

        {
            get
            {
                return this._nodeSplitLineColor;
            }
            set
            {
                this._nodeSplitLineColor = value;
            }
        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {           
            try
            {
                if (e.Node == null || (e.Node.Bounds.Width <= 0 && e.Node.Bounds.Height <= 0 && e.Node.Bounds.X <= 0 && e.Node.Bounds.Y <= 0))
                {
                    e.DrawDefault = true;
                }
                else
                {
                    if (base.Nodes.IndexOf(e.Node) == 0)
                    {
                        this.blnHasVBar = this.IsVerticalScrollBarVisible();
                    }
                    Font font = nodeForeFont; // e.Node.NodeFont;
                    if (font == null)
                    {
                        font = this.Font;
                    }
                    SizeF fontSize = this.GetFontSize(font, e.Graphics);

                    bool flag = false;
                    int num = 0;
                    if (base.ImageList != null && base.ImageList.Images.Count > 0 && e.Node.ImageIndex >= 0 && e.Node.ImageIndex < base.ImageList.Images.Count)
                    {
                        flag = true;
                        num = (e.Bounds.Height - base.ImageList.ImageSize.Height) / 2;
                    }
                    int nodeleft = (e.Node.Level + 1) * 10+30;

                    Color nodeNormalcolor = Color.Black;
                    Color nodeFocuscolor = Color.White;
                    Color nodeSelectedColor = threeselectColor;
                    if (_isAutoChangeNodeColor)
                    {
                        nodeNormalcolor = ChangeColor(this.BackColor, e.Node.Level * 0.15f);
                        nodeFocuscolor = ChangeColor(nodeNormalcolor, 0.1f);

                    }
                    else
                    {
                        switch (e.Node.Level)
                        {
                            case 0:
                                nodeNormalcolor = this.rootbackColor;
                                nodeFocuscolor = this.roothoverColor;
                                break;
                            case 1:
                                nodeNormalcolor = this.twobackColor;
                                nodeFocuscolor = this.twohoverColor;
                                break;
                            case 2:
                                nodeNormalcolor = this.threebackColor;
                                nodeFocuscolor = this.threehoverColor;
                                break;

                        }
                    }

                    if (e.Node.IsSelected && e.Node.Nodes.Count <= 0)
                    {
                        // 节点被选中
                        e.Graphics.FillRectangle(new SolidBrush(nodeSelectedColor), new Rectangle(new Point(0, e.Node.Bounds.Y), new Size(base.Width - (this.blnHasVBar ? 20 : 0), e.Node.Bounds.Height)));
                        e.Graphics.DrawString(e.Node.Text, font, new SolidBrush(nodeForeSelectColor), (float)e.Bounds.X + nodeleft, (float)e.Bounds.Y + ((float)this.ItemHeight - fontSize.Height) / 2f);
                    }
                    else
                    {
                        if ((e.State & TreeNodeStates.Hot) != 0)
                        {
                            // 鼠标在节点
                            e.Graphics.FillRectangle(new SolidBrush(nodeFocuscolor), new Rectangle(new Point(0, e.Node.Bounds.Y), new Size(base.Width - (this.blnHasVBar ? 20 : 0), e.Node.Bounds.Height)));
                            e.Graphics.DrawString(e.Node.Text, font, new SolidBrush(nodeForeColor), (float)e.Bounds.X + nodeleft, (float)e.Bounds.Y + ((float)this.ItemHeight - fontSize.Height) / 2f);

                        }
                        else
                        {
                            e.Graphics.FillRectangle(new SolidBrush(nodeNormalcolor), new Rectangle(new Point(0, e.Node.Bounds.Y), new Size(base.Width - (this.blnHasVBar ? 20 : 0), e.Node.Bounds.Height)));
                            e.Graphics.DrawString(e.Node.Text, font, new SolidBrush(this.nodeForeColor), (float)e.Bounds.X + nodeleft, (float)e.Bounds.Y + ((float)this.ItemHeight - fontSize.Height) / 2f);
                        }
                    }
                    if (flag)
                    {
                        int num2 = e.Bounds.X - num - base.ImageList.ImageSize.Width;
                        if (num2 < 0)
                        {
                            num2 = 3;
                        }
                        e.Graphics.DrawImage(base.ImageList.Images[e.Node.ImageIndex], new Rectangle(new Point(num2, e.Bounds.Y + num), base.ImageList.ImageSize));
                    }
                    if (this._nodeIsShowSplitLine)
                    {
                        e.Graphics.DrawLine(new Pen(this._nodeSplitLineColor, 1f), new Point(0, e.Bounds.Y + this.ItemHeight - 1), new Point(base.Width, e.Bounds.Y + this.ItemHeight - 1));
                    }

                    if (e.Node.Nodes.Count > 0)
                    {
                        if (e.Node.IsExpanded && this._nodeDownPic != null)
                        {
                            e.Graphics.DrawImage(this._nodeDownPic, e.Node.Bounds.X - 10, e.Node.Bounds.Y + 10);//显示在前端
                                                                                                              // e.Graphics.DrawImage(this._nodeUpPic, base.Width - (this.blnHasVBar ? 50 : 30), e.Node.Bounds.Y + 10);//显示在后端
                        }
                        else if (this._nodeUpPic != null)
                        {
                            e.Graphics.DrawImage(this._nodeUpPic, e.Node.Bounds.X - 10, e.Node.Bounds.Y + 10);//显示在前端
                                                                                                                // e.Graphics.DrawImage(this._nodeDownPic, base.Width - (this.blnHasVBar ? 50 : 30), e.Node.Bounds.Y + 10);//显示在后端
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);
        private bool IsVerticalScrollBarVisible()
        {
            return base.IsHandleCreated && (MTreeView.GetWindowLong(base.Handle, -16) & 2097152) != 0;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            TreeNode tn = this.GetNodeAt(e.Location);
            Graphics g = this.CreateGraphics();
            if (tn.Level > 1)//点击一、二级节点不使三级节点的选中效果消失
            {
                this.SelectedNode = tn;
            }
            
            if (null != SelectedNode)
            {
                OnDrawNode(new DrawTreeNodeEventArgs(g, SelectedNode, new Rectangle(0, SelectedNode.Bounds.Y, this.Width - 4, SelectedNode.Bounds.Height), TreeNodeStates.Checked));
            }

        }

        TreeNode currentNode = null;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            TreeNode tn = this.GetNodeAt(e.Location);
            Graphics g = this.CreateGraphics();
            if (currentNode != tn) 
            {
                //绘制当前节点的hover背景
                if (null != tn)
                {
                    OnDrawNode(new DrawTreeNodeEventArgs(g, tn, new Rectangle(0, tn.Bounds.Y, this.Width - 4, tn.Bounds.Height), TreeNodeStates.Hot));
                }

                //取消之前hover的节点背景
                if (null != currentNode)
                {
                    OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width - 4, currentNode.Bounds.Height), TreeNodeStates.Default));
                }
            }
            currentNode = tn;
            g.Dispose();//释放Graphics资源
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //移出控件时取消Hover背景
            if (currentNode != null)
            {
                Graphics g = this.CreateGraphics();
                OnDrawNode(new DrawTreeNodeEventArgs(g, currentNode, new Rectangle(0, currentNode.Bounds.Y, this.Width - 4, currentNode.Bounds.Height), TreeNodeStates.Default));

                currentNode = null;//同一个节点Leave后Move有Hover效果            
            }
        }
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            TreeNode tn = this.GetNodeAt(e.Location);
        
                if (tn.IsExpanded == false)
                    tn.Expand();
                else
                    tn.Collapse();
            
        }

        /// <summary>
        /// 获取字体的尺寸大小
        /// </summary>
        /// <param name="font"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        private SizeF GetFontSize(Font font, Graphics g = null)
        {
            SizeF result;
            try
            {
                bool flag = false;
                if (g == null)
                {
                    g = base.CreateGraphics();
                    flag = true;
                }
                SizeF sizeF = g.MeasureString("a", font, 100, StringFormat.GenericTypographic);
                if (flag)
                {
                    g.Dispose();
                }
                result = sizeF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 改变颜色的深浅
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="correctionFactor">加深 :大于-1且小于0； 变亮 :大于0且小于1</param>
        /// <returns></returns>
        public static Color ChangeColor(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            if (red < 0) red = 0;

            if (red > 255) red = 255;

            if (green < 0) green = 0;

            if (green > 255) green = 255;

            if (blue < 0) blue = 0;

            if (blue > 255) blue = 255;



            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }
    }
}
