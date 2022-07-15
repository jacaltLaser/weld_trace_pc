using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
         [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)] 
*/

namespace CustomControl
{
    [ToolboxBitmap(typeof(HScrollBar))]

    public partial class ScrollBar: UserControl
    {
       
        public ScrollBar()
        {
            InitializeComponent();
        }

        #region   DLL引入
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
       [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        const int EM_GETLINECOUNT = 0x00BA;//获取总行数
        const int EM_GETFIRSTVISIBLELINE = 0x00CE; //当前显示在textbox1中第一行的行号，0开始算
        /*      int totalLineCount = SendMessage(this.textBox1.Handle, EM_GETLINECOUNT, IntPtr.Zero, "");
                int currentLineNo = SendMessage(this.textBox1.Handle, EM_GETFIRSTVISIBLELINE, IntPtr.Zero, ""); */
        #endregion

        #region 私有成员
        private System.Windows.Forms.TextBox STextBox=null;
        private Color data1=System.Drawing.SystemColors.ControlLight;
        private Color data2=System.Drawing.SystemColors.ControlDarkDark;
        private Color data3 = System.Drawing.SystemColors.ControlDark;
        private double  StepHeight=6;
        private System.Timers.Timer TimeDelegate = null;
        private int lines;
        private int TempCursor;
        private bool SlideBarFlag=false ;
        private bool ScrollBarFlag = false ;
        private int SlideBarOpacity = 255;
        private int MinHeight=30;
        private double mSense=0.2;
        #endregion

        #region  滑动灵敏度
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("1到20之间")]
        public double Sense 
        {
            set
            {
                mSense = 1 / value;
                this.StepHeight = this.STextBox.Font.Height * mSense;
            }
            get
            {
                return 1 / mSense;
            }
        }
        #endregion  

        #region  滑动条最短长度
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("滑动条最短长度")]
        public int MinSlideBarLenght
        {
            set
            {
                MinHeight = value;
            }
            get
            {
                return MinHeight;
            }
        }
        #endregion  

        #region  要滑动的TextBox
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("要滚动的TextBox")]
        public TextBox TextBox
        {
            set {
                STextBox = value;
            }
            get {
                return STextBox;
            }
        }
        #endregion  

        #region 滑动条被唤醒颜色
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)] 
        public Color WakedColor
        {
            set {
                data1 = value;
            }
            get {
                return data1;
            }
        }
        #endregion

        #region 滑动条被按下颜色
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("滑动条被按下的颜色")]
        public Color PressedColor
        {
            set
            {
                data2 = value;
            }
            get
            {
                return data2;
            }
        }
        #endregion

        #region 鼠标进入滑动条颜色
        [System.ComponentModel.Browsable(true)]
        [Localizable(true)]
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Description("鼠标进入滑动条的颜色")]
        public Color EnterColor
        {
            set
            {
                data3 = value;
            }
            get
            {
                return data3;
            }
    }
        #endregion



        private void This_Created(object sender, EventArgs e)
        {
            this.SlideBar.Size = new Size(this.Width,40);
            this.SlideBar.BackColor = this.BackColor;
            this.StepHeight = this.STextBox.Font.Height * mSense;
            this.lines = STextBox.Height / this.STextBox.Font.Height;
            STextBox.MouseWheel += new MouseEventHandler(This_STextBox_MouseWheel);
        }


        private void Wake()
        {
            if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
            SlideBar.Size = new Size(SlideBar.Width, this.Height - (int)((SendMessage(this.STextBox.Handle, EM_GETLINECOUNT, IntPtr.Zero, "") - lines) * StepHeight));
            SlideBar.Location = new Point(SlideBar.Location.X,(int) Math.Ceiling(SendMessage(this.STextBox.Handle, EM_GETFIRSTVISIBLELINE, IntPtr.Zero, "") * StepHeight));
            SlideBarOpacity = 255;
            this.SlideBar.BackColor = this.WakedColor;
        }

        private void ScrollBar_MouseEnter(object sender, EventArgs e)
        {
            SlideBarFlag = true;
            Wake();
        }

        private void ScrollBar_MouseLeave(object sender, EventArgs e)
        {

            ScrollBarFlag=false ;
            if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
            TimeDelegate = new System.Timers.Timer(10);
            TimeDelegate.AutoReset = true ;
            TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(ScrollBar_Leave_Delegate);
            TimeDelegate.Enabled = true;

        }

        private void ScrollBar_Leave_Delegate(object sender,System .Timers.ElapsedEventArgs e)
        {
            TimeDelegate.Close();
            TimeDelegate = null;
            if (!ScrollBarFlag) this.SlideBar_Sleep();
        }

        private void SlideBar_Sleep()
        {
            if (TimeDelegate != null) TimeDelegate.Close();
            TimeDelegate = new System.Timers.Timer(150);
            TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(SlideBar_Sleep_Delegate);
            TimeDelegate.AutoReset = true;
            TimeDelegate.Enabled = true;
        }

        private void SlideBar_Sleep_Delegate(object sender, System.Timers.ElapsedEventArgs e)
        {

            this.SlideBarOpacity -= (256 - this.SlideBarOpacity);
            if (SlideBarOpacity <= 0)
            {
                TimeDelegate.Close();
                TimeDelegate = null;
                SlideBarOpacity = 0;
            }
            this.SlideBar.BackColor = System.Drawing.Color.FromArgb(SlideBarOpacity, this.WakedColor.R, this.WakedColor.G, this.WakedColor.B);
        }

        private void SlideBar_MouseEnter(object sender, EventArgs e)
        {
            this.ScrollBarFlag = true;
            Wake();
            this.SlideBar.BackColor = EnterColor;
        }

        private void SlideBar_MouseLeave(object sender, EventArgs e)
        {
            SlideBarFlag = false;
            if (TimeDelegate != null) TimeDelegate.Close();
            TimeDelegate = new System.Timers.Timer(10);
            TimeDelegate.AutoReset = true;
            TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(SlideBar_Leave_Delegate);
            TimeDelegate.Enabled = true;

        }

        private void SlideBar_Leave_Delegate(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimeDelegate.Close();
            TimeDelegate = null;
            if (!SlideBarFlag) this.SlideBar_Sleep();
            else this.SlideBar.BackColor = this.WakedColor;
        }

        private void SlideBar_MouseDown(object sender, MouseEventArgs e)
        {
            this.SlideBar.BackColor = PressedColor;
            TempCursor = Cursor.Position.Y;
             if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
            TimeDelegate = new System.Timers.Timer(1);
            TimeDelegate.AutoReset = true ;
            TimeDelegate.Elapsed += new System.Timers.ElapsedEventHandler(Sliding_Delegate);
            TimeDelegate.Enabled = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Sliding_Delegate(object sender,System.Timers.ElapsedEventArgs e)
        {
            if (Cursor.Position.Y > TempCursor)
            {
                if (Cursor.Position.Y >= TempCursor + StepHeight)
                {
                    TempCursor += (int)StepHeight;
                    SendMessage(this.STextBox.Handle, 0xb6, 0, 1);
                    if (this.SlideBar.Location.Y + (int)StepHeight <= this.Height - SlideBar.Height)
                        this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y + (int)StepHeight);
                }
            }
            if (Cursor.Position.Y < TempCursor)
            {
                if (Cursor.Position.Y <= TempCursor - StepHeight)
                {
                    TempCursor -= (int)StepHeight;
                    SendMessage(this.STextBox.Handle, 0xb6, 0, -1);
                    if (this.SlideBar.Location.Y - (int)StepHeight >= 0)
                        this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y - (int)StepHeight);
                }
            }
        }

        private void SlideBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.SlideBar.BackColor = WakedColor;
            if (TimeDelegate != null) { TimeDelegate.Close(); TimeDelegate = null; }
        }

        private void This_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                SendMessage(this.STextBox.Handle, 0xb6, 0, -1);
                if (this.SlideBar.Location.Y - (int)StepHeight>=0)
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y - (int)StepHeight);
            }
            else
            {
                SendMessage(this.STextBox.Handle, 0xb6, 0, 1);
                if (this.SlideBar.Location.Y + (int)StepHeight <= this.Height-SlideBar.Height)
                this.SlideBar.Location = new Point(this.SlideBar.Location.X, this.SlideBar.Location.Y + (int)StepHeight);
            }
        }

        private void This_STextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            Wake();
            this.OnMouseWheel(e);
            SlideBar_Sleep();
        }

    }

}
