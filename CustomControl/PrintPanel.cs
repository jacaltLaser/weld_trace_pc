
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.ComponentModel;
    using System.Drawing.Imaging;
    using System.Drawing.Printing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Text;

namespace CustomControl
{

    /// <summary>
    /// GetPanel函数为传入控件实现打印；GetThumbnail函数为图像缩放成指定大小
    /// </summary>
    public class PrintPanel
    {
        #region API
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        public enum ScrollBarInfoFlags
        {
            SIF_RANGE = 0x0001,
            SIF_PAGE = 0x0002,
            SIF_POS = 0x0004,
            SIF_DISABLENOSCROLL = 0x0008,
            SIF_TRACKPOS = 0x0010,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS)
        }
        public enum ScrollBarRequests
        {
            SB_LINEUP = 0,
            SB_LINELEFT = 0,
            SB_LINEDOWN = 1,
            SB_LINERIGHT = 1,
            SB_PAGEUP = 2,
            SB_PAGELEFT = 2,
            SB_PAGEDOWN = 3,
            SB_PAGERIGHT = 3,
            SB_THUMBPOSITION = 4,
            SB_THUMBTRACK = 5,
            SB_TOP = 6,
            SB_LEFT = 6,
            SB_BOTTOM = 7,
            SB_RIGHT = 7,
            SB_ENDSCROLL = 8
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si);
        [DllImport("user32")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool Rush);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        #endregion
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr HDest, int nXDest, int nYDest, int nWidth, int hHeight, IntPtr HSrc, int nXSrc, int nYSrc, int DwRop);

        private static Bitmap bitMap = null;  //实例化一个位图
        private static System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();  //实例化一个打印的对象

        private static bool Landscape = false;
        private static bool Center = false;
        /// <summary>
        /// 打印控件
        /// </summary>
        /// <param name="con">控件</param>
        /// <param name="landscape">横向</param>
        /// <param name="center">居中</param>
        public static void Print(System.Windows.Forms.Control con,bool landscape = false,bool center=false )
        {
            Landscape = landscape;
            Center = center;
            GetPanel(con);
        }
        private static void GetPanel(System.Windows.Forms.Control p)
        {
            MoveBar(0, 0, p);  //移动滚动条
            MoveBar(1, 0, p);   //移动滚动条
            Point pit = GetScrollPoint(p); //获得滚动条的长度
            bitMap = new Bitmap(p.Width + pit.X, p.Height + pit.Y);         //根据画布的宽和高赋值给位图
            p.DrawToBitmap(bitMap, new Rectangle(0, 0, p.Width + pit.X, p.Height + pit.Y));
            PrintPreviewDialog ppvw = new PrintPreviewDialog();  //初始化一个打印预览
            ppvw.StartPosition = FormStartPosition.CenterScreen;
            ppvw.WindowState = FormWindowState.Maximized;
            ppvw.Document = printDoc;                            // 预览的文档赋值发送给打印机
            PaperSize pp = new PaperSize("自定义", p.Width, p.Height);
            foreach (PaperSize ps in ppvw.Document.PrinterSettings.PaperSizes)  //获取该打印机支持的纸张大小
            {
                //设置纸张的大小为A4  
                if (ps.PaperName.Equals("A4"))//这里设置纸张大小,但必须是定义好的
                {
                    pp = ps;
                    break;
                }
            }
            if(Landscape)
            bitMap = GetThumbnail(bitMap,  pp.Width ,pp.Height);
            else
                bitMap = GetThumbnail(bitMap, pp.Height, pp.Width);

            printDoc.DefaultPageSettings.Landscape = false; //是否为横向打印
            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);  //打印之前发生的事
            ppvw.Document.DefaultPageSettings.PaperSize = pp;
            if (ppvw.ShowDialog() != DialogResult.OK)                          //如果不打印的话，返回
            {
                printDoc.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
                return;
            }
            printDoc.Print();                                                  //开始打印
        }

        /// <summary>
        /// 图像缩放成指定大小：
        /// </summary>
        /// <param name="b"></param>
        /// <param name="destHeight"></param>
        /// <param name="destWidth"></param>
        /// <returns></returns>
        public static Bitmap GetThumbnail(Bitmap b, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放           
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth; sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            { sW = sWidth; sH = sHeight; }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量           
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if(Center)
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            else
                g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, 25, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);

            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量      
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1]; quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam; imgSource.Dispose();
            return outBmp;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitMap, 0, 0);   //绘制一幅图片
        }

        /// <summary> 
        /// 获取滚动条数据 
        /// </summary> 
        /// <param name="MyControl"></param> 
        /// <param name="ScrollSize"></param> 
        /// <returns></returns> 
        private static Point GetScrollPoint(System.Windows.Forms.Control MyControl)
        {
            Point MaxScroll = new Point();

            SCROLLINFO ScrollInfo = new SCROLLINFO();
            ScrollInfo.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(ScrollInfo);
            ScrollInfo.fMask = (uint)ScrollBarInfoFlags.SIF_ALL;

            GetScrollInfo(MyControl.Handle, 1, ref ScrollInfo);
            MaxScroll.Y = ScrollInfo.nMax - (int)ScrollInfo.nPage;
            //if ((int)ScrollInfo.nPage == 0) MaxScroll.Y = 0;
            GetScrollInfo(MyControl.Handle, 0, ref ScrollInfo);
            MaxScroll.X = ScrollInfo.nMax - (int)ScrollInfo.nPage;
            //if ((int)ScrollInfo.nPage == 0) MaxScroll.X = 0;
            return MaxScroll;
        }
        /// <summary> 
        /// 移动控件滚动条位置 
        /// </summary> 
        /// <param name="Bar"></param> 
        /// <param name="Point"></param> 
        /// <param name="MyControl"></param> 
        private static void MoveBar(int Bar, int Point, System.Windows.Forms.Control MyControl)
        {
            if (Bar == 0)
            {
                SetScrollPos(MyControl.Handle, 0, Point, true);
                SendMessage(MyControl.Handle, (int)0x0114, (int)ScrollBarRequests.SB_THUMBPOSITION, 0);
            }
            else
            {
                SetScrollPos(MyControl.Handle, 1, Point, true);
                SendMessage(MyControl.Handle, (int)0x0115, (int)ScrollBarRequests.SB_THUMBPOSITION, 0);
            }
        }
    }
}





