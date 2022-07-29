using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControl;

namespace 星链激光制管机控制软件
{
    public partial class MainForm : SkinMain
    {
        public MainForm()
        {

            InitializeComponent();
            oldSize = this.Size;
            setTag(this);
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            //   organizeAlignmentControl();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            if (skinForm == null)
            {
                skinForm = new ChangeSkinForm();
                skinForm.SkinEvent += SkinForm_SkinEvent;
                skinForm.TopMost = true;
                skinForm.InitSkinColor();
            }

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread threadA = new Thread(Play_Camera);
            threadA.Start();


            label_AlarmInfo.Text = "";

            InitSendimer();
            InitDataParserTimer();


        }


        #region 界面操作事件

        float ScaleX = 1;
        float ScaleY = 1;

#if false    /// 整理对齐界面控件
        /// <summary>
        /// 整理对齐界面控件
        /// </summary>
        private void organizeAlignmentControl()
        {

            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            ScaleX = graphics.DpiX / 96f;
            ScaleY = graphics.DpiY / 96f;

            if (ScaleX > 1)
            {
                //// 模块标题
                //titlePanel1.Font = new Font(titlePanel1.Font.Name, titlePanel1.Font.Size / ScaleX, titlePanel1.Font.Style, titlePanel1.Font.Unit, titlePanel1.Font.GdiCharSet, titlePanel1.Font.GdiVerticalFont);
                //titlePanel2.Font = new Font(titlePanel2.Font.Name, titlePanel2.Font.Size / ScaleX, titlePanel2.Font.Style, titlePanel2.Font.Unit, titlePanel2.Font.GdiCharSet, titlePanel2.Font.GdiVerticalFont);
                //titlePanel4.Font = new Font(titlePanel4.Font.Name, titlePanel4.Font.Size / ScaleX, titlePanel4.Font.Style, titlePanel4.Font.Unit, titlePanel4.Font.GdiCharSet, titlePanel4.Font.GdiVerticalFont);
                //titlePanel5.Font = new Font(titlePanel5.Font.Name, titlePanel5.Font.Size / ScaleX, titlePanel5.Font.Style, titlePanel5.Font.Unit, titlePanel5.Font.GdiCharSet, titlePanel5.Font.GdiVerticalFont);
                //titlePanel6.Font = new Font(titlePanel6.Font.Name, titlePanel6.Font.Size / ScaleX, titlePanel6.Font.Style, titlePanel6.Font.Unit, titlePanel6.Font.GdiCharSet, titlePanel6.Font.GdiVerticalFont);

                ////  LaserPower.Font = new Font(LaserPower.Font.FontFamily, LaserPower.Font.Size / ScaleX);

                //adjustControlFontSize(this, ScaleX);

                //// 模块1：位置调整               
                //label3.Location = new Point(mTextBox9.Left - label3.Width - 2, mTextBox9.Top + (mTextBox9.Height - label3.Height) / 2);
                //label4.Location = new Point(mTextBox1.Left - label4.Width - 2, mTextBox1.Top + (mTextBox1.Height - label4.Height) / 2);
                //label5.Location = new Point(mTextBox10.Left - label5.Width - 2, mTextBox10.Top + (mTextBox10.Height - label5.Height) / 2);
                //tableLayoutPanel1.Top = label3.Top;
                label8.Top = pictureBox6.Top - label8.Height - 2;

                //// 模块2：焊接控制
                label24.Location = new Point(mTextPipe.Left, mTextPipe.Top - label24.Height - 2);
                label7.Location = new Point(mTextBox2.Left, mTextBox2.Top - label7.Height - 2);

                btnSetting.Location = new Point(mTextPipe.Right + 5, mTextPipe.Top + (mTextPipe.Height - btnSetting.Height) / 2 + 1);
                label6.Location = new Point(mTextBox2.Right + 2, mTextBox2.Top + (mTextBox2.Height - label6.Height) / 2);

                btnGasSwitch.Top = mTextPipe.Top + (mTextPipe.Height - btnGasSwitch.Height) / 2;
                btnRedlightSwitch.Top = mTextBox2.Top + (mTextBox2.Height - btnRedlightSwitch.Height) / 2;
                label26.Location = new Point(btnGasSwitch.Left - label26.Width - 5, btnGasSwitch.Top + (btnGasSwitch.Height - label26.Height) / 2);
                label25.Location = new Point(btnRedlightSwitch.Left - label25.Width - 5, btnRedlightSwitch.Top + (btnRedlightSwitch.Height - label25.Height) / 2);

                //// 模块3：焊接情况
                label9.Top = btnWeldTrackingSwitch.Top + (btnWeldTrackingSwitch.Height - labelCrashStop_Status.Height) / 2;
                label9.Left = btnWeldTrackingSwitch.Left - label9.Width - 5;

                //// 模块4：激光器
                labelPower_Status.Top = picPower_Status.Top + (picPower_Status.Height - labelPower_Status.Height) / 2;
                labelCrashStop_Status.Top = picCrashStop_Status.Top + (picCrashStop_Status.Height - labelCrashStop_Status.Height) / 2;
                labelComm_Status.Top = picComm_Status.Top + (picComm_Status.Height - labelComm_Status.Height) / 2;
                labelAlarm_Status.Top = picAlarm_Status.Top + (picAlarm_Status.Height - labelAlarm_Status.Height) / 2;
                labelLaser_Status.Top = picLaser_Status.Top + (picLaser_Status.Height - labelLaser_Status.Height) / 2;
                labelRedlight_Status.Top = picRedlight_Status.Top + (picRedlight_Status.Height - labelRedlight_Status.Height) / 2;

                //// 模块4：水箱
                labelWaterTank_SwitchStatus.Top = picWaterTank_SwitchStatus.Top + (picWaterTank_SwitchStatus.Height - labelWaterTank_SwitchStatus.Height) / 2;
                labelWaterTank_Temperature.Top = picWaterTank_Temperature.Top + (picWaterTank_Temperature.Height - labelWaterTank_Temperature.Height) / 2;
                //// 模块4：激光器
                labelAirConditione_SwitchStatus.Top = picAirConditione_SwitchStatus.Top + (picAirConditione_SwitchStatus.Height - labelAirConditione_SwitchStatus.Height) / 2;
                labelAirConditione_Humidity.Top = picAirConditione_Humidity.Top + (picAirConditione_Humidity.Height - labelAirConditione_Humidity.Height) / 2;

                //// 底部
                label2.Left = this.Width - label2.Width - 10;

            }
        }

        /// <summary>
        /// 调整字体的文本大小
        /// </summary>
        /// <param name="control"></param>
        /// <param name="scale"></param>
        private void adjustControlFontSize(Control control, float scale)
        {
            foreach (Control con in control.Controls)
            {
                con.Font = new Font(con.Font.FontFamily, con.Font.Size * ((1 + scale) / (2 * scale)), con.Font.Style);

                if (con.Controls.Count > 0)
                {
                    adjustControlFontSize(con, scale);
                }
            }
        }
#endif


        private bool moving = false;
        private Point oldMousePosition;
        private void panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                return;
            }
            oldMousePosition = e.Location;
            moving = true;
        }

        private void panel_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);
                this.Location += new Size(newPosition);
            }
        }

        private void panel_Top_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }
        private void panel_top_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_max.PerformClick();
        }

        private void btn_windowstool_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn_min": { this.WindowState = FormWindowState.Minimized; } break;
                case "btn_max":
                    {

                        if (this.WindowState == FormWindowState.Maximized)
                        {
                            this.WindowState = FormWindowState.Normal;
                            btn_max.BackgroundImage = Properties.Resources.max;
                        }
                        else
                        {

                            this.WindowState = FormWindowState.Maximized;
                            btn_max.BackgroundImage = Properties.Resources.normal;
                        }

                    }
                    break;

                case "btn_close":
                    {

                        bPlayflag = false;
                        SendTimer.Stop();
                        DataParserTimer.Stop();
                       Common. CloseSerialPort();
                        this.Close();
                        break;
                    }

            }
        }




        #endregion

        #region 模块---位置调整

        private void btnMove_MouseEnter(object sender, EventArgs e)
        {
            TranslucentButton btnmove = sender as TranslucentButton;
            switch (btnmove.Name)
            {
                case "btnMove_Left":
                    btnmove.Image = Properties.Resources.左_down;
                    break;
                case "btnMove_Right":
                    btnmove.Image = Properties.Resources.右_down;
                    break;
                case "btnMove_Up":
                    btnmove.Image = Properties.Resources.上_down;
                    break;
                case "btnMove_Down":
                    btnmove.Image = Properties.Resources.下_down;
                    break;
                case "btnMove_Z_Up":
                    btnmove.Image = Properties.Resources.上_down;
                    break;
                case "btnMove_Z_Down":
                    btnmove.Image = Properties.Resources.下_down;
                    break;
            }
        }

        private void btnMove_MouseLeave(object sender, EventArgs e)
        {
            TranslucentButton btnmove = sender as TranslucentButton;
            switch (btnmove.Name)
            {
                case "btnMove_Left":
                    btnmove.Image = Properties.Resources.左;
                    break;
                case "btnMove_Right":
                    btnmove.Image = Properties.Resources.右;
                    break;
                case "btnMove_Up":
                    btnmove.Image = Properties.Resources.上;
                    break;
                case "btnMove_Down":
                    btnmove.Image = Properties.Resources.下;
                    break;
                case "btnMove_Z_Up":
                    btnmove.Image = Properties.Resources.上;
                    break;
                case "btnMove_Z_Down":
                    btnmove.Image = Properties.Resources.下;
                    break;

            }
        }



        //private void btnMove_Left_Click(object sender, EventArgs e)
        //{
        //    // 减一个单位（左移）命令
        //    byte reduce_Angle = 0x01;
        //    // 移动的单位角度
        //    byte[] move_UnitAngle = { 0x01 };
        //    byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, reduce_Angle, Global.ContrlBoard_Commands.MotorAngle_X, move_UnitAngle);
        //    Common.SendQueue_PC.Enqueue(m_SendAryPC);
        //}

        //private void btnMove_Right_Click(object sender, EventArgs e)
        //{
        //    // 加一个单位（右移）命令
        //    byte add_Angle = 0x00;
        //    // 移动的单位角度
        //    byte[] move_UnitAngle = { 0x01 };
        //    byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, add_Angle, Global.ContrlBoard_Commands.MotorAngle_X, move_UnitAngle);
        //    Common.SendQueue_PC.Enqueue(m_SendAryPC);
        //}

        //private void btnMove_Up_Click(object sender, EventArgs e)
        //{
        //    // 减一个单位（上移）命令
        //    byte reduce_Angle = 0x01;
        //    // 移动的单位角度
        //    byte[] move_UnitAngle = { 0x01 };
        //    byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, reduce_Angle, Global.ContrlBoard_Commands.MotorAngle_Y, move_UnitAngle);
        //    Common.SendQueue_PC.Enqueue(m_SendAryPC);
        //}

        //private void btnMove_Down_Click(object sender, EventArgs e)
        //{
        //    // 加一个单位（下移）命令
        //    byte add_Angle = 0x00;
        //    // 移动的单位角度
        //    byte[] move_UnitAngle = { 0x01 };
        //    byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, add_Angle, Global.ContrlBoard_Commands.MotorAngle_Y, move_UnitAngle);
        //    Common.SendQueue_PC.Enqueue(m_SendAryPC);

        //}



        private void btnMove_Left_MouseDown(object sender, MouseEventArgs e)
        {
            InitMoveTimer();
            // （连续左移）
            moveMode = 0x04;
            move_Direction = Global.ContrlBoard_Commands.MotorAngle_X;
        }
        private void btnMove_Left_MouseUp(object sender, MouseEventArgs e)
        {
            MoveTimer.Enabled = false;
            if (continuityMoveFlag)
            {
                // （停止连续左右移）
                moveMode = 0x05;
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // （左移）减一个单位
                moveMode = 0x01;
                // 移动的单位角度
                byte[] move_UnitAngle = { 0x01 };
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction, move_UnitAngle);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }
        }

        private void btnMove_Right_MouseDown(object sender, MouseEventArgs e)
        {
            InitMoveTimer();
            // （连续右移）
            moveMode = 0x03;
            move_Direction = Global.ContrlBoard_Commands.MotorAngle_X;
        }
        private void btnMove_Right_MouseUp(object sender, MouseEventArgs e)
        {
            MoveTimer.Enabled = false;
            if (continuityMoveFlag)
            {
                // （停止连续左右移）
                moveMode = 0x05;
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // （右移）加一个单位
                moveMode = 0x00;
                // 移动的单位角度
                byte[] move_UnitAngle = { 0x01 };
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction, move_UnitAngle);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }
        }

        private void btnMove_Up_MouseDown(object sender, MouseEventArgs e)
        {
            InitMoveTimer();
            // （连续上移）
            moveMode = 0x04;
            move_Direction = Global.ContrlBoard_Commands.MotorAngle_Y;
        }

        private void btnMove_Up_MouseUp(object sender, MouseEventArgs e)
        {
            MoveTimer.Enabled = false;
            if (continuityMoveFlag)
            {
                // （停止连续上下移）
                moveMode = 0x05;
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // （上移）减一个单位
                moveMode = 0x01;
                // 移动的单位角度
                byte[] move_UnitAngle = { 0x01 };
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction, move_UnitAngle);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }
        }

        private void btnMove_Down_MouseDown(object sender, MouseEventArgs e)
        {
            InitMoveTimer();
            // （连续下移）
            moveMode = 0x03;
            move_Direction = Global.ContrlBoard_Commands.MotorAngle_Y;
        }

        private void btnMove_Down_MouseUp(object sender, MouseEventArgs e)
        {
            MoveTimer.Enabled = false;

            if (continuityMoveFlag)
            {
                // （停止连续上下移）
                moveMode = 0x05;
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // （下移）加一个单位
                moveMode = 0x00;
                // 移动的单位角度
                byte[] move_UnitAngle = { 0x01 };
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction, move_UnitAngle);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }

        }

        /// <summary>
        /// 移动方式
        /// </summary>
        byte moveMode = 0x00;
        /// <summary>
        /// 移动的方向
        /// </summary>
        byte move_Direction = 255;
        /// <summary>
        /// 是否连续移动
        /// </summary>
        bool continuityMoveFlag = false;
        //定义移动MoveTimer 
        System.Timers.Timer MoveTimer = new System.Timers.Timer();
        /// <summary>
        /// 初始化MoveTimer控件
        /// </summary>
        private void InitMoveTimer()
        {
            //设置定时间隔(毫秒为单位)
            MoveTimer.Interval = 500;
            //设置执行一次（false）还是一直执行(true)
            MoveTimer.AutoReset = true;
            //设置是否执行System.Timers.Timer.Elapsed事件
            MoveTimer.Enabled = true;
            //绑定Elapsed事件
            MoveTimer.Elapsed += MoveTimer_Elapsed;
            continuityMoveFlag = false;
        }
        private void MoveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!continuityMoveFlag)
            {
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
                continuityMoveFlag = true;
            }
            else
            {
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, moveMode, move_Direction);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }
        }

        #endregion


        #region 模块---焊接控制

        private void btnSetting_MouseEnter(object sender, EventArgs e)
        {
            btnSetting.Image = Properties.Resources.setting_hover;
        }

        private void btnSetting_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.btnSetting, "配置管材");//设置提示按钮和提示内容
        }

        private void btnSetting_MouseLeave(object sender, EventArgs e)
        {
            btnSetting.Image = Properties.Resources.setting_normal;
        }
        /// <summary>
        /// 配置管材特性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            ManagePipePropertiesForm manageForm = new ManagePipePropertiesForm();
            manageForm.TopMost = true;
            manageForm.Show();
        }

        private void mTextPipe_MouseDown(object sender, MouseEventArgs e)
        {
            drawItemListBorder(sender as MTextBox);
        }

        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (itemListPanel != null)
                itemListPanel.Close();
        }


        /// <summary>
        /// 下拉框
        /// </summary>
        ItemListPanel itemListPanel;
        private void drawItemListBorder(Control control)
        {
            DataTable pipeProPertiesTable = new DataBase().GetdataTable("管材特性");
            string[] Items = pipeProPertiesTable.AsEnumerable().Select(d => d.Field<string>("管材名称")).ToArray();

            if (itemListPanel == null || itemListPanel.IsDisposed || itemListPanel.Visible == false)
            {
                if (Items != null)
                {
                    itemListPanel = new ItemListPanel(control);
                    itemListPanel.Items = Items;
                    itemListPanel.SelectItemEvent += iteMTextBox_SelectItemEvent;
                    itemListPanel.MouseWheel += ItemListPanel_MouseWheel;
                    Point poslocat = control.PointToScreen(new Point(0, 0));
                    poslocat.Offset(0, control.Height);
                    itemListPanel.Location = poslocat;
                    itemListPanel.Show();

                    itemListPanel.BringToFront();
                }
            }
            else
            {
                itemListPanel.Close();
            }
        }

        private void ItemListPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (itemListPanel != null)
            {
                itemListPanel.MouseWheel_VerticalScroll(e.Delta);
            }
        }

        void iteMTextBox_SelectItemEvent(object sender, EventArgs e)
        {
            if (itemListPanel != null && !itemListPanel.IsDisposed && itemListPanel.Visible)
            {
                txtPipe.MText = sender.ToString();
                itemListPanel.Close();
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312; // 热键消息
            if (m.Msg == WM_HOTKEY)
            {
                //最大最小化热键
            }
            //鼠标左键右键中间滑轮事件时，屏保计时器清零 
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_RBUTTONDOWN = 0x0204;
            const int WM_MOUSEDOWN = 0x0210;
            const int WM_MOUSEWHEEL = 0x020A;
            if (m.Msg == WM_MOUSEDOWN || m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN || m.Msg == WM_MOUSEWHEEL)
            {
                if (itemListPanel != null)
                {

                    itemListPanel.Close();

                }
            }
            base.WndProc(ref m);
        }

        private void btnSetPower_MouseEnter(object sender, EventArgs e)
        {
            btnSetPower.BackgroundImage = Properties.Resources.btn_hover;

        }

        private void btnSetPower_MouseLeave(object sender, EventArgs e)
        {
            btnSetPower.BackgroundImage = Properties.Resources.btn_normal;
        }
        /// <summary>
        /// 点击功率设置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetPower_Click(object sender, EventArgs e)
        {

            if (txtPower.MText == "")
            {
                txtPower.MText = "0";
            }
            int temp = Convert.ToInt32(txtPower.MText);
            if (temp > 100)
            {
                temp = 100;
                txtPower.MText = temp.ToString();
            }

            // 设置激光器功率
            byte[] power = new byte[] { (byte)temp };
            byte[] m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.LaserPower, power);
            Common.SendQueue_PC.Enqueue(m_SendAryPC);

        }

        // 定义通信OutLaserTimer
        System.Timers.Timer OutLaserTimer = null;

        /// <summary>
        /// 定时开关激光器出光
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutLaserTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (picLaser_Status.BackgroundImage == Properties.Resources.无)
            {
                // 开始出光
                byte[] open = new byte[] { 0xAA };
                byte[] m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.MCU_Switch, open);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // 结束出光
                byte[] close = new byte[] { 0x55 };
                byte[] m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.MCU_Switch, close);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }

        }

        /// <summary>
        /// 点击焊接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWeldSwitch_Click(object sender, EventArgs e)
        {
            if (laserConnect)
            {
                if (btnWeldSwitch.Checked)
                {
                    if (cbxIntervalTime.Text != "一直持续")
                    {
                        string interval = cbxIntervalTime.Text;
                        interval = interval.Replace("ms", string.Empty).Replace(" ", string.Empty);
                        if (IsNumeric(interval))
                        {
                            if (!interval.Contains("."))
                            {
                                OutLaserTimer = new System.Timers.Timer();
                                //设置定时间隔(毫秒为单位)
                                OutLaserTimer.Interval = Convert.ToInt32(interval);
                                //设置执行一次（false）还是一直执行(true)
                                OutLaserTimer.AutoReset = true;
                                //设置是否执行System.Timers.Timer.Elapsed事件
                                OutLaserTimer.Enabled = true;
                                //绑定Elapsed事件
                                OutLaserTimer.Elapsed += OutLaserTimer_Elapsed;
                            }
                            else
                            {
                                MessageBox.Show("间隔时长不能为小数！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("间隔时长必须为整数！");
                        }
                    }
                    else
                    {
                        // 开始出光
                        byte[] open = new byte[] { 0xAA };
                        byte[] m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.MCU_Switch, open);
                        Common.SendQueue_PC.Enqueue(m_SendAryPC);
                    }
                }
                else
                {
                    if (OutLaserTimer != null)
                    {
                        OutLaserTimer.Enabled = false;
                        OutLaserTimer.Close();
                        OutLaserTimer.Dispose();
                        OutLaserTimer = null;
                    }
                    // 结束出光
                    byte[] close = new byte[] { 0x55 };
                    byte[] m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.MCU_Switch, close);
                    Common.SendQueue_PC.Enqueue(m_SendAryPC);
                }
            }
        }

        /// <summary>
        /// 焊接开关
        /// </summary>      
        private void btnWeldSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (!btnWeldSwitch.Checked)
            {
                btnWeldSwitch.BackgroundImage = Properties.Resources.btnstart_normal;
            }
            else
            {
                btnWeldSwitch.BackgroundImage = Properties.Resources.btnend_normal;
            }
        }
        private void btnWeldSwitch_MouseEnter(object sender, EventArgs e)
        {
            if (!btnWeldSwitch.Checked)
            {
                btnWeldSwitch.BackgroundImage = Properties.Resources.btnstart_hover;
            }
            else
            {
                btnWeldSwitch.BackgroundImage = Properties.Resources.btnend_hover;
            }
        }

        private void btnWeldSwitch_MouseLeave(object sender, EventArgs e)
        {
            if (!btnWeldSwitch.Checked)
            {
                btnWeldSwitch.BackgroundImage = Properties.Resources.btnstart_normal;
            }
            else
            {
                btnWeldSwitch.BackgroundImage = Properties.Resources.btnend_normal;
            }
        }

        /// <summary>
        /// 点击使能按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnableSwitch_Click(object sender, EventArgs e)
        {
            if (isInternalMode)
            {
                sendEnableSwitchCommands(btnEnableSwitch.Checked);
            }
            else
            {
                MessageBox.Show("激光器未设置为内控模式！");
            }
        }

        /// <summary>
        /// 发送使能开关的通信指令
        /// </summary>
        /// <param name="no_off"></param>
        private void sendEnableSwitchCommands(bool no_off)
        {
            byte[] m_SendAryPC;
            if (no_off)
            {
                // 打开激光使能
                byte[] open = new byte[] { 0xAA };
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.SIM_EN, open);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // 关闭激光使能
                byte[] close = new byte[] { 0x55 };
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.SIM_EN, close);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }

            // 读取---使能开关状态
            m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.SIM_EN);
            Common.SendQueue_PC.Enqueue(m_SendAryPC);
        }

        /// <summary>
        /// 使能开关状态
        /// </summary>  
        private void btnEnableSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (isInternalMode)
            {
                if (btnEnableSwitch.Checked)
                {
                    btnEnableSwitch.BackgroundImage = Properties.Resources.on;
                }
                else
                {
                    btnEnableSwitch.BackgroundImage = Properties.Resources.off;
                }

            }

        }

        /// <summary>
        /// 点击红光按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRedlightSwitch_Click(object sender, EventArgs e)
        {
            sendRedlightSwitchCommands(btnRedlightSwitch.Checked);
        }
        /// <summary>
        /// 发送红光开关的通信指令
        /// </summary>
        /// <param name="no_off"></param>
        private void sendRedlightSwitchCommands(bool no_off)
        {
            byte[] m_SendAryPC;
            if (no_off)
            {
                // 打开红光
                byte[] open = new byte[] { 0xAA };
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.RedSwitch, open);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // 关闭红光
                byte[] close = new byte[] { 0x55 };
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.RedSwitch, close);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }

            // 读取---红光开关状态
            m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.RedSwitch);
            Common.SendQueue_PC.Enqueue(m_SendAryPC);
        }
        /// <summary>
        /// 红光开关状态
        /// </summary>
        private void btnRedlightSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRedlightSwitch.Checked)
            {
                btnRedlightSwitch.BackgroundImage = Properties.Resources.on;
            }
            else
            {
                btnRedlightSwitch.BackgroundImage = Properties.Resources.off;
            }

        }

        #endregion


        #region 模块---焊缝跟踪

        /// <summary>
        /// 点击焊接轨迹开关按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWeldTrackingSwitch_Click(object sender, EventArgs e)
        {
            if (btnWeldTrackingSwitch.Checked)
            {
                // 打开焊接轨迹跟踪
                byte[] open = new byte[] { 0x01 };
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataWrite, Global.ContrlBoard_Commands.WeldTrackingSwitch, open);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }
            else
            {
                // 关闭焊接轨迹跟踪
                byte[] close = new byte[] { 0x00 };
                byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataWrite, Global.ContrlBoard_Commands.WeldTrackingSwitch, close);
                Common.SendQueue_PC.Enqueue(m_SendAryPC);
            }
        }
        /// <summary>
        /// 焊接轨迹跟踪开关状态
        /// </summary>       
        private void btnFollowSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (btnWeldTrackingSwitch.Checked)
            {
                btnWeldTrackingSwitch.BackgroundImage = Properties.Resources.on;
            }
            else
            {
                btnWeldTrackingSwitch.BackgroundImage = Properties.Resources.off;
            }
        }
        #endregion

        #region 模块---状态信息

        /// <summary>
        /// 点击水箱开关按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaterTankSwitch_Click(object sender, EventArgs e)
        {
            if (btnWaterTankSwitch.Checked)
            {
                // 打开水箱
                //byte[] open = new byte[] { 0x01 };
                //byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataWrite, Global.ContrlBoard_Commands.WaterTankOpera, open);
                //Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // 关闭水箱
                //byte[] close = new byte[] { 0x00 };
                //byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataWrite, Global.ContrlBoard_Commands.WaterTankOpera, close);
                //Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }

        }
        /// <summary>
        /// 水箱开关状态
        /// </summary>
        private void btnWaterTankSwitch_CheckedChanged(object sender, EventArgs e)
        {

            if (btnWaterTankSwitch.Checked)
            {
                btnWaterTankSwitch.BackgroundImage = Properties.Resources.on;
            }
            else
            {
                btnWaterTankSwitch.BackgroundImage = Properties.Resources.off;
            }

        }

        /// <summary>
        /// 点击空调开关按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAirConditioneSwitch_Click(object sender, EventArgs e)
        {
            if (btnAirConditioneSwitch.Checked)
            {
                // 打开空调
                //byte[] open = new byte[] { 0x01 };
                //byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataWrite, Global.ContrlBoard_Commands.AirConditionerOpera, open);
                //Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
            else
            {
                // 关闭空调
                //byte[] close = new byte[] { 0x00 };
                //byte[] m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataWrite, Global.ContrlBoard_Commands.AirConditionerOpera, close);
                //Common.SendQueue_PC.Enqueue(m_SendAryPC);

            }
        }
        /// <summary>
        /// 空调开关状态
        /// </summary>
        private void btnAirConditioneSwitch_CheckedChanged(object sender, EventArgs e)
        {

            if (btnAirConditioneSwitch.Checked)
            {
                btnAirConditioneSwitch.BackgroundImage = Properties.Resources.on;
            }
            else
            {
                btnAirConditioneSwitch.BackgroundImage = Properties.Resources.off;
            }

        }

        #endregion


        #region 窗口最大化时的控件变化
        private void tableLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            int minSize = Math.Min(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            //   tableLayoutPanel1.Size = new Size(minSize, minSize);

        }

        private void weldingQuality_SizeChanged(object sender, EventArgs e)
        {
            int minSize = Math.Min(weldingQuality.Width, weldingQuality.Height);

            int newSize = 145;
            if (minSize > newSize)
                newSize = minSize;

            weldingQuality.Size = new Size(newSize, newSize);
            weldingQuality.Location = new Point((label10.Right - 7 + weldingQuality.Parent.Width - 240 - newSize) / 2, label10.Top + 5);

            label_CommState.Left = panel1.Left;
            label_AlarmInfo.Left = label_CommState.Right;
        }

        float fontSize = 0;
        private void LaserPower_SizeChanged(object sender, EventArgs e)
        {

            int minSize = Math.Min(Math.Min(LaserPower.Width, LaserPower.Height), label27.Top - 5);

            int newSize = 100;
            if (minSize > newSize)
                newSize = minSize;

            LaserPower.Size = new Size(newSize, newSize);


            LaserPower.ProgressWidth = (int)(8 * (newSize / 100f));
            if (fontSize == 0)
            {
                fontSize = LaserPower.Font.Size;
            }

            LaserPower.Font = new Font(LaserPower.Font.Name, (12F / ScaleX) * (newSize / 100f), LaserPower.Font.Style);

            LaserPower.Location = new Point(label27.Left + label27.Width / 2 - newSize / 2, label27.Top - newSize - 5);
        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {
            cbxIntervalTime.Width = (int)(panel3.Width * (90f / 143f));
        }

        private void panel5_SizeChanged(object sender, EventArgs e)
        {
            btnWeldSwitch.Width = (int)(panel5.Width * (90f / 143f));
            btnWeldSwitch.Height = (int)(btnWeldSwitch.Width * (30f / 90f));

            btnWeldSwitch.Top = btnRedlightSwitch.Top + btnRedlightSwitch.Height / 2 - btnWeldSwitch.Height / 2;

        }



        private void pictureBox6_SizeChanged(object sender, EventArgs e)
        {
            pictureBox6.Height = (int)(pictureBox6.Width * (480f / 640f));
            pictureBox6.Top = panel4.Height - pictureBox6.Height - 3;
            label8.Top = pictureBox6.Top - label8.Height - 3;

        }


        Size oldSize;
        private void MainForm_Resize(object sender, EventArgs e)
        {
            float scale = (float)this.Height / (float)oldSize.Height;
            scale = (scale + 1) / 2;
            changeControlFontSize(this, scale);
            alignmentContrls();
        }

        private void alignmentContrls()
        {

            //// 模块1：位置调整               
            //label3.Location = new Point(mTextBox9.Left - label3.Width - 2, mTextBox9.Top + (mTextBox9.Height - label3.Height) / 2);
            //label4.Location = new Point(mTextBox1.Left - label4.Width - 2, mTextBox1.Top + (mTextBox1.Height - label4.Height) / 2);
            //label5.Location = new Point(mTextBox10.Left - label5.Width - 2, mTextBox10.Top + (mTextBox10.Height - label5.Height) / 2);
            //tableLayoutPanel1.Top = label3.Top;
            label_Angle_X.Font = label3.Font;
            label_Angle_Y.Font = label4.Font;
            label8.Top = pictureBox6.Top - label8.Height - 2;

            //// 模块2：焊接控制
            label24.Location = new Point(txtPipe.Left, txtPipe.Top - label24.Height - 2);
            label7.Location = new Point(txtPower.Left, txtPower.Top - label7.Height - 2);
            label5.Location = new Point(cbxIntervalTime.Left, cbxIntervalTime.Top - label5.Height - 2);

            btnSetting.Location = new Point(txtPipe.Right + 5, txtPipe.Top + (txtPipe.Height - btnSetting.Height) / 2 + 1);
            btnSetPower.Location = new Point(txtPower.Right + 5, txtPower.Top + (txtPower.Height - btnSetPower.Height) / 2 + 1);

            btnEnableSwitch.Top = txtPipe.Top + (txtPipe.Height - btnEnableSwitch.Height) / 2;
            btnRedlightSwitch.Top = txtPower.Top + (txtPower.Height - btnRedlightSwitch.Height) / 2;
            label26.Location = new Point(btnEnableSwitch.Left - label26.Width - 5, btnEnableSwitch.Top + (btnEnableSwitch.Height - label26.Height) / 2);
            label25.Location = new Point(btnRedlightSwitch.Left - label25.Width - 5, btnRedlightSwitch.Top + (btnRedlightSwitch.Height - label25.Height) / 2);

            //// 模块3：焊接情况
            label9.Top = btnWeldTrackingSwitch.Top + (btnWeldTrackingSwitch.Height - labelEnable_Status.Height) / 2;
            label9.Left = btnWeldTrackingSwitch.Left - label9.Width - 5;
            labelCurrMachineTime.Top = label9.Top;

            //// 模块4：激光器
            labelPower_Status.Top = picPower_Status.Top + (picPower_Status.Height - labelPower_Status.Height) / 2;
            labelEnable_Status.Top = picEnable_Status.Top + (picEnable_Status.Height - labelEnable_Status.Height) / 2;
            labelComm_Status.Top = picComm_Status.Top + (picComm_Status.Height - labelComm_Status.Height) / 2;
            labelAlarm_Status.Top = picAlarm_Status.Top + (picAlarm_Status.Height - labelAlarm_Status.Height) / 2;
            labelLaser_Status.Top = picLaser_Status.Top + (picLaser_Status.Height - labelLaser_Status.Height) / 2;
            labelRedlight_Status.Top = picRedlight_Status.Top + (picRedlight_Status.Height - labelRedlight_Status.Height) / 2;

            //// 模块5：水箱

            float leftScale = panel6.Width / 105f;
            btnWaterTankSwitch.Left = (int)((leftScale + 2) / 3 * 50);
            btnWaterTankSwitch.Top = (int)((leftScale - 1) * 3);
            labelWaterTank_SwitchStatus.Top = picWaterTank_SwitchStatus.Top + (picWaterTank_SwitchStatus.Height - labelWaterTank_SwitchStatus.Height) / 2;
            labelWaterTank_Temperature.Top = picWaterTank_Temperature.Top + (picWaterTank_Temperature.Height - labelWaterTank_Temperature.Height) / 2;
            //// 模块6：空调
            leftScale = panel22.Width / 105f;
            btnAirConditioneSwitch.Left = (int)((leftScale + 2) / 3 * 50);
            btnAirConditioneSwitch.Top = (int)((leftScale - 1) * 3);
            labelAirConditione_SwitchStatus.Top = picAirConditione_SwitchStatus.Top + (picAirConditione_SwitchStatus.Height - labelAirConditione_SwitchStatus.Height) / 2;
            labelAirConditione_Humidity.Top = picAirConditione_Humidity.Top + (picAirConditione_Humidity.Height - labelAirConditione_Humidity.Height) / 2;

            //// 底部
            label2.Left = this.Width - label2.Width - 10;

        }

        /// <summary>
        /// 调整字体的文本大小
        /// </summary>
        /// <param name="control"></param>
        /// <param name="scale"></param>
        private void changeControlFontSize(Control control, float scale = 1)
        {
            foreach (Control con in control.Controls)
            {
                try
                {
                    if (con is Label || con is TitlePanel || con is ComboBox)
                    {
                        if (con.Tag != null && IsNumeric(con.Tag.ToString()))
                        {
                            float oldfontSize = Convert.ToSingle(con.Tag);
                            float newfontSize = oldfontSize * scale;

                            con.Font = new Font(con.Font.FontFamily, newfontSize, con.Font.Style);

                        }
                    }
                }
                catch { }

                if (con.Controls.Count > 0)
                {
                    changeControlFontSize(con, scale);
                }
            }
        }


        /// <summary>
        /// 获得控件的字体大小的数据
        /// </summary>
        /// <param name="cons"></param>
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Font.Size;

                if (con.Controls.Count > 0)
                    setTag(con);//递归算法
            }
        }
        #endregion



        #region 与下位机的通信


        //定义通信SendTimer 
        System.Timers.Timer SendTimer = new System.Timers.Timer();
        /// <summary>
        /// 初始化SendTimer控件
        /// </summary>
        private void InitSendimer()
        {
            //设置定时间隔(毫秒为单位)
            SendTimer.Interval = 100;
            //设置执行一次（false）还是一直执行(true)
            SendTimer.AutoReset = true;
            //设置是否执行System.Timers.Timer.Elapsed事件
            SendTimer.Enabled = true;
            //绑定Elapsed事件
            SendTimer.Elapsed += SendTimer_Elapsed;

            InitCommandQueue();

        }

        int queryIndex = 0;
        /// <summary>
        /// 定时向下位机发送命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Common.IsConnect)
            {
                if (Common.Connect_SerialPort != null)
                {
                    lock (Common.ojbSockeSend_PC)
                    {
                        
                        if (Common.SendQueue_PC.Count > 0)
                        {
                            // 动态指令的发送
                            byte[] m_SendAryPC = Common.SendQueue_PC.Dequeue();
                            Common.Connect_SerialPort.Write(m_SendAryPC, 0, m_SendAryPC.Length);
                        }
                        else
                        {
                            // 常态指令的发送
                            if (Common.CommandQueue_PC.Count > 0)
                            {
                                byte[] m_SendAryPC = Common.CommandQueue_PC.ElementAt(queryIndex);
                                Common.Connect_SerialPort.Write(m_SendAryPC, 0, m_SendAryPC.Length);

                                queryIndex++;
                                if (queryIndex >= queryMax)
                                {
                                    queryMax = 3;
                                    queryIndex = 0;
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                Common.Connect_Count++;
                if (Common.Connect_Count > 30)
                {
                    Common.IsConnect = false;
                    Common.Connect_Count = 0;
                    Common.Connect_SerialPort = null;

                    // 通信失联时，3000ms后初始化一次串口
                    Common.CreateSerialPort();
                }

            }
        }

/// <summary>
/// 常态查询最大值
/// </summary>
        int queryMax = 6;

        /// <summary>
        /// 初始化需循环查询的命令队列
        /// </summary>
private void InitCommandQueue()
        {
            lock (Common.ojbSockeSend_PC)
            {
                Common.CommandQueue_PC.Clear();
                byte[] m_SendAryPC = null;

                #region 读取控制板

                /*
                 
                // 读取--所有参数
                m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.AllParameter);
                Common.CommandQueue_PC.Enqueue(m_SendAryPC);

                
                       // 读取---当前机器时间
                       //m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.CurrMachineTime);
                       //Common.CommandQueue_PC.Enqueue(m_SendAryPC);




                       // 读取---电机X角度
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.MotorAngle_X);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---电机Y角度
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.MotorAngle_Y);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---电机Z角度
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.MotorAngle_Z);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);

                       // 读取---保护气状态
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.ShieldGasOpera);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---焊接开关状态
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.WeldingOpera);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---水箱开关状态
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.WaterTankOpera);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---空调开关状态
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.AirConditionerOpera);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---报警信息
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.AlarmInfo);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---当前温度
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.CurrTemper);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---当前湿度
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.CurrHumidity);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---当前焊接长度
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.CurrWeldLength);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---总焊接长度
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.TotaWeldLength);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---当前机器时间
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.CurrMachineTime);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);
                       // 读取---焊接轨迹跟踪开关
                       m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.WeldTrackingSwitch);
                       Common.CommandQueue_PC.Enqueue(m_SendAryPC);

                        */

                #endregion

                #region 读取激光器


                // 读取---报警信息
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.AlarmInfo);
                Common.CommandQueue_PC.Enqueue(m_SendAryPC);

                // 读取---状态信息1
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.StateInfo1);
                Common.CommandQueue_PC.Enqueue(m_SendAryPC);

                // 读取---状态信息2
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.StateInfo2);
                Common.CommandQueue_PC.Enqueue(m_SendAryPC);


                // 读取---使能开关状态
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.SIM_EN);
                Common.CommandQueue_PC.Enqueue(m_SendAryPC);

                // 读取---红光开关状态
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.RedSwitch);
                Common.CommandQueue_PC.Enqueue(m_SendAryPC);

                // 读取---激光输出功率
                m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.LaserPower);
                Common.CommandQueue_PC.Enqueue(m_SendAryPC);

            }

            #endregion

        }

        #endregion


        #region 通信数据的解析和显示

        // 定义通信DataParserTimer
        System.Timers.Timer DataParserTimer = new System.Timers.Timer();
        /// <summary>
        /// 初始化DataParserTimer控件
        /// </summary>
        private void InitDataParserTimer()
        {
            //设置定时间隔(毫秒为单位)
            DataParserTimer.Interval = 200;
            //设置执行一次（false）还是一直执行(true)
            DataParserTimer.AutoReset = true;
            //设置是否执行System.Timers.Timer.Elapsed事件
            DataParserTimer.Enabled = true;
            //绑定Elapsed事件
            DataParserTimer.Elapsed += DataParserTimer_Elapsed;

        }



        /// <summary>
        /// 定时解析数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataParserTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
          
            if (Common.IsConnect)
            {
                lock (Common.ojbSockeRec)
                {
                    if (Common.m_ListRecData.Count > 0)
                    {
                        notCommDataCount = 0;

                        if (Common.m_ListRecData[0] != null)
                        {
                            byte[] m_ReceiveDataAry = Common.m_ListRecData[0].ToArray();

                            int header = m_ReceiveDataAry[0] * 256 + m_ReceiveDataAry[1];
                            int len = m_ReceiveDataAry[2];
                            int Cmd = m_ReceiveDataAry[4];

                         //   MessageBox.Show("测试位置0");

                            if (header == Global.ContrlBoard_Commands.DataHead_receiveContrlBoard)
                            {
                            //    MessageBox.Show("测试位置1");
                                switch (Cmd)
                                {
                                    
                                    case Global.ContrlBoard_Commands.MotorAngle_X:
                                        displayStatusPara_ContrlBoard("电机X角度", m_ReceiveDataAry.Skip(5).Take(4).ToArray());
                                        break;
                                    case Global.ContrlBoard_Commands.MotorAngle_Y:
                                        displayStatusPara_ContrlBoard("电机Y角度", m_ReceiveDataAry.Skip(5).Take(4).ToArray());
                                        break;
                                    case Global.ContrlBoard_Commands.AlarmInfo:
                                        displayStatusPara_ContrlBoard("报警信息", m_ReceiveDataAry.Skip(5).Take(2).ToArray());
                                        break;
                                    //case Global.ContrlBoard_Commands.WaterTankOpera:
                                    //    displayStatusPara_ContrlBoard("水箱", m_ReceiveDataAry[5]);
                                    //    break;
                                    case Global.ContrlBoard_Commands.CurrTemper:
                                        displayStatusPara_ContrlBoard("当前温度", m_ReceiveDataAry.Skip(5).Take(2).ToArray());
                                        break;
                                    //case Global.ContrlBoard_Commands.AirConditionerOpera:
                                    //    displayStatusPara_ContrlBoard("空调", m_ReceiveDataAry[5]);
                                    //    break;
                                    case Global.ContrlBoard_Commands.CurrHumidity:
                                        displayStatusPara_ContrlBoard("当前湿度", m_ReceiveDataAry.Skip(5).Take(2).ToArray());
                                        break;
                                    case Global.ContrlBoard_Commands.CurrWeldLength:
                                        displayStatusPara_ContrlBoard("当前焊接长度", m_ReceiveDataAry.Skip(5).Take(4).ToArray());
                                        break;
                                    case Global.ContrlBoard_Commands.TotaWeldLength:
                                        displayStatusPara_ContrlBoard("总焊接长度", m_ReceiveDataAry.Skip(5).Take(4).ToArray());
                                        break;
                                    case Global.ContrlBoard_Commands.CurrMachineTime:
                                       displayStatusPara_ContrlBoard("当前机器时间", m_ReceiveDataAry.Skip(5).Take(7).ToArray());
                                        break;
                                    case Global.ContrlBoard_Commands.WeldTrackingSwitch:
                                        displayStatusPara_ContrlBoard("焊接轨迹跟踪开关", m_ReceiveDataAry[5]);
                                        break;
                                    case Global.ContrlBoard_Commands.WeldPosition:
                                        displayStatusPara_ContrlBoard("焊接轨迹坐标", m_ReceiveDataAry.Skip(5).Take(2).ToArray());
                                        break;

                                    case Global.ContrlBoard_Commands.AllParameter:
                                        displayAllPara_ContrlBoard(m_ReceiveDataAry);
                                        break;

                                    default:
                                        MessageBox.Show("控制板通信：收到未知的通信命令码 0x" + m_ReceiveDataAry[4].ToString("X2"));
                                        break;
                                }

                                if(!ContrlBoardConnect)
                                {
                                    // 读取--所有参数
                                  byte[]  m_SendAryPC = Common.generateSendData(Global.ContrlBoard_Commands.DataHead_sendContrlBoard, Global.ContrlBoard_Commands.Address_ContrlBoard, Global.DataRead, Global.ContrlBoard_Commands.AllParameter);
                                    Common.SendQueue_PC.Enqueue(m_SendAryPC);
                                }

                                ContrlBoardConnect = true;
                                notContrlBoardCommCount = 0;
                            }
                            else
                            {
                                if (ContrlBoardConnect)
                                {
                                    notContrlBoardCommCount++;
                                    if (notContrlBoardCommCount > 15)
                                    {
                                        ContrlBoardConnect = false;
                                        notContrlBoardCommCount = 0;
                                        MessageBox.Show("与控制板的通信已发生中断！");
                                    }
                                }
                            }


                            if (header == Global.LaserDevice_Commands.DataHead_receiveLaserDevice)
                            {
                                switch (Cmd)
                                {
                                    case Global.LaserDevice_Commands.LaserPower:
                                        displayStatusPara_LaserDevice("激光输出功率", m_ReceiveDataAry[5]);
                                        break;
                                    case Global.LaserDevice_Commands.RedSwitch:
                                        displayStatusPara_LaserDevice("红光开关", m_ReceiveDataAry[5]);
                                        break;
                                    case Global.LaserDevice_Commands.AlarmInfo:
                                        displayStatusPara_LaserDevice("报警信息", m_ReceiveDataAry.Skip(5).Take(4));
                                        break;
                                    case Global.LaserDevice_Commands.StateInfo1:
                                        displayStatusPara_LaserDevice("状态信息1", m_ReceiveDataAry.Skip(5).Take(2));
                                        break;
                                    case Global.LaserDevice_Commands.StateInfo2:
                                        displayStatusPara_LaserDevice("状态信息2", m_ReceiveDataAry.Skip(5).Take(2));
                                        break;


                                    default:
                                        MessageBox.Show("激光器通信：收到未知的通信命令码 0x" + m_ReceiveDataAry[4].ToString("X2"));
                                        break;
                                }

                                laserConnect = true;
                                notLaserCommCount = 0;

                            }
                            else
                            {
                                if (laserConnect)
                                {
                                    notLaserCommCount++;
                                    if (notLaserCommCount > 15)
                                    {
                                        laserConnect = false;
                                        notLaserCommCount = 0;
                                        MessageBox.Show("与激光器的通信已发生中断！");
                                    }
                                }

                            }

                        }
                        if (Common.m_ListRecData.Count > 0)
                            Common.m_ListRecData.RemoveAt(0);

                        notCommDataCount = 0;


                    }
                    else
                    {
                        notCommDataCount++;
                        if (notCommDataCount >= 20)
                        {
                            Common.IsConnect = false;
                            label_CommState.Text = "通信已断开";
                        }
                    }
                }
            }

            InitializeAfterDisconnect();
        }



        /// <summary>
        /// 串口通信数据为空的计数
        /// </summary>
        int notCommDataCount = 0;
        /// <summary>
        /// 控制板通信的计数
        /// </summary>
        int notContrlBoardCommCount = 0;
        /// <summary>
        /// 控制板的通信连接
        /// </summary>
        bool ContrlBoardConnect = false;
        /// <summary>
        /// 激光器通信的计数
        /// </summary>
        int notLaserCommCount = 0;
        /// <summary>
        /// 激光器的通信连接
        /// </summary>
        bool laserConnect = false;

        /// <summary>
        /// 通信断开连接后进行初始化处理
        /// </summary>
        private void InitializeAfterDisconnect()
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke((EventHandler)delegate
                    {
                        if (!Common.IsConnect)
                        {
                            laserConnect = false;
                            ContrlBoardConnect = false;
                        }

                        if (ContrlBoardConnect)
                        {
                            label_CommState.ForeColor = Color.Aqua;
                            label_CommState.Text = "通信连接正常";
                        }
                        else
                        {
                            label_CommState.ForeColor = Color.Red;
                            label_CommState.Text = "通信已断开";

                            //  "电机X角度":
                            label_Angle_X.Text = "0.0 °";
                            label_Angle_X.Tag = "0.0 °";

                            //    "电机Y角度":
                            label_Angle_Y.Text = "0.0 °";
                            label_Angle_Y.Tag = "0.0 °";



                            //   "报警信息":
                            label_AlarmInfo.Text = "";

                            //  "当前温度":
                            labelWaterTank_Temperature.Text = "0.0℃";
                            labelWaterTank_Temperature.ForeColor = ThemeTextColor;
                            picWaterTank_Temperature.BackgroundImage = Properties.Resources.温度_nothing;


                            //   "当前湿度":
                            labelAirConditione_Humidity.ForeColor = ThemeTextColor;
                            picAirConditione_Humidity.BackgroundImage = Properties.Resources.湿度_nothing;
                            labelAirConditione_Humidity.Text = "0.0%RH";


                            //   "当前焊接长度":
                            labelCurrWeldLength.Text = "0.0";

                            //   "总焊接长度":
                            labelTotalWeldLength.Text = "0.0";

                            //  设备时间
                            //  labelCurrMachineTime.Text = s_value;

                            //  "焊接轨迹跟踪开关":
                            btnWeldTrackingSwitch.Checked = false;

                            //  显示焊接轨迹
                            //    this.chart1.Series[0].Points.Clear();

                        }

                        if (laserConnect)
                        {
                            picComm_Status.BackgroundImage = Properties.Resources.有;
                            labelComm_Status.ForeColor = Color.Aqua;
                        }
                        else
                        {
                            queryMax = 6;

                            isInternalMode = false;
                            btnSetPower.Enabled = false;
                            btnEnableSwitch.Enabled = false;
                            btnRedlightSwitch.Enabled = false;
                            btnWeldSwitch.Enabled = false;

                            btnEnableSwitch.Checked = false;
                            btnRedlightSwitch.Checked = false;
                            btnWeldSwitch.Checked = false;

                            LaserPower.Text = "0%";
                            LaserPower.Value = 0;

                            picComm_Status.BackgroundImage = Properties.Resources.无;
                            labelComm_Status.ForeColor = ThemeTextColor;

                            labelRedlight_Status.ForeColor = ThemeTextColor;
                            picRedlight_Status.BackgroundImage = Properties.Resources.无;

                            labelPower_Status.ForeColor = ThemeTextColor;
                            picPower_Status.BackgroundImage = Properties.Resources.无;

                            labelLaser_Status.ForeColor = ThemeTextColor;
                            picLaser_Status.BackgroundImage = Properties.Resources.无;

                            labelEnable_Status.ForeColor = ThemeTextColor;
                            picEnable_Status.BackgroundImage = Properties.Resources.无;

                            labelAlarm_Status.ForeColor = ThemeTextColor;
                            picAlarm_Status.BackgroundImage = Properties.Resources.无;
                        }

                    });
                }
            }
            catch { }
        }


        DisplayDetailForm displayState = new DisplayDetailForm("激光器---状态信息");
        DisplayDetailForm displayAlarm = new DisplayDetailForm("激光器---报警信息");

        /// <summary>
        /// 界面显示所有状态参数(控制板)
        /// </summary>
        /// <param name="value"></param>
        private void displayAllPara_ContrlBoard(byte[] bParas)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((EventHandler)delegate
                {

                    //if (bParas.Length != 33)
                    //{
                    //    MessageBox.Show("全部参数数据长度=" + bParas.Length + "[错误]");
                    //    return;
                    //}
                    byte b_value = 0;
                    float f_value = 0.0f;
                    string s_value = "";

                    //  "电机X角度":

                    f_value = (bParas[5] | (bParas[6] << 8) | (bParas[7] << 16) | (bParas[8] << 24)) * 1.8f;
                    label_Angle_X.Text = f_value.ToString("0.0 °");
                    label_Angle_X.Tag = f_value;


                    //    "电机Y角度":
                    f_value = (bParas[9] | (bParas[10] << 8) | (bParas[11] << 16) | (bParas[12] << 24)) * 1.8f;
                    label_Angle_Y.Text = f_value.ToString("0.0 °");
                    label_Angle_Y.Tag = f_value;

                    //   "焊接开关":
                    //b_value = bParas[13];
                    //if (b_value == 0x00)
                    //{
                    //    btnWeldSwitch.Checked = false;
                    //}
                    //else if (b_value == 0x01)
                    //{
                    //    btnWeldSwitch.Checked = true;
                    //}

                    //   "报警信息":
                    string strAlarm = "";
                    byte W1 = bParas[14];
                    byte W2 = bParas[15];

                    byte[] W1_bitArray = getBooleanArray(W1);
                    if (W1_bitArray[0] == 1)
                    {
                        strAlarm += "电机X错误";
                    }
                    if (W1_bitArray[1] == 1)
                    {
                        strAlarm += "电机Y错误";
                    }
                    if (W1_bitArray[2] == 1)
                    {
                        strAlarm += "电机Z错误";
                    }
                    if (W1_bitArray[3] == 1)
                    {
                        strAlarm += "水冷机错误";
                    }
                    if (W1_bitArray[4] == 1)
                    {
                        if (W2 == 0x01)
                            strAlarm += "温湿度模块初始化错误";
                        else if (W2 == 0x01)
                            strAlarm += "内存24512 初始化错误";
                        else
                            strAlarm += "其他错误";

                    }


                    label_AlarmInfo.Text = strAlarm;



                    //  "当前温度":
                    f_value = (bParas[16] | (bParas[17] << 8)) * 0.1f;
                    if (f_value > 1)
                    {
                        btnWaterTankSwitch.Checked = true;
                        if (f_value > 80)
                        {
                            labelWaterTank_Temperature.ForeColor = Color.Red;
                            picWaterTank_Temperature.BackgroundImage = Properties.Resources.温度_alarm;

                        }
                        else
                        {
                            labelWaterTank_Temperature.ForeColor = Color.Aqua;
                            picWaterTank_Temperature.BackgroundImage = Properties.Resources.温度_normal;
                        }
                        labelWaterTank_Temperature.Text = f_value.ToString("0.0℃");
                    }
                    else
                    {
                        btnWaterTankSwitch.Checked = false;
                    }

                    //   "当前湿度":
                    f_value = (bParas[18] | (bParas[19] << 8)) * 0.1f;
                    if (f_value > 1)
                    {
                        btnAirConditioneSwitch.Checked = true;
                        if (f_value > 45)
                        {
                            labelAirConditione_Humidity.ForeColor = Color.Red;
                            picAirConditione_Humidity.BackgroundImage = Properties.Resources.湿度_alarm;

                        }
                        else
                        {
                            labelAirConditione_Humidity.ForeColor = Color.Aqua;
                            picAirConditione_Humidity.BackgroundImage = Properties.Resources.湿度_normal;
                        }

                        labelAirConditione_Humidity.Text = f_value.ToString("0.0") + "%RH";
                    }
                    else
                    {
                        btnAirConditioneSwitch.Checked = false;
                    }



                    //   "当前焊接长度":
                    f_value = ((bParas[20] | (bParas[21] << 8) | (bParas[22] << 16) | (bParas[23] << 24)) * 0.01f);
                    labelCurrWeldLength.Text = f_value.ToString("0.0");

                    //   "总焊接长度":
                    f_value = ((bParas[24] | (bParas[25] << 8) | (bParas[26] << 16) | (bParas[27] << 24)) * 0.01f);
                    labelTotalWeldLength.Text = f_value.ToString("0.0");

                    //  设备时间
                    s_value = (bParas[28] | (bParas[29] << 8)) + "年"
                    + (bParas[30]).ToString("00") + "月"
                    + bParas[31].ToString("00") + "日 "
                    + bParas[32].ToString("00") + ":"
                    + bParas[33].ToString("00") + ":"
                    + bParas[34].ToString("00");

                    labelCurrMachineTime.Text = s_value;

                    //  "焊接轨迹跟踪开关":
                    b_value = bParas[35];
                    if (b_value == 0x00)
                    {
                        if (btnWeldTrackingSwitch.Checked != false)
                        {
                            btnWeldTrackingSwitch.Checked = false;
                        }
                    }
                    else if (b_value == 0x01)
                    {
                        if (btnWeldTrackingSwitch.Checked != true)
                            btnWeldTrackingSwitch.Checked = true;
                    }

                    //  显示焊接轨迹
                    f_value = (bParas[36] | (bParas[37] << 8)) * 0.01f;
                    if (btnWeldTrackingSwitch.Checked)
                    {
                        this.chart1.Series[0].Points.AddY(f_value);

                        resetChartAreaAxisX_MaxMin();
                        resetChartAreaAxisY_MaxMin(f_value);

                    }
                    else
                    {
                        this.chart1.Series[0].Points.Clear();
                    }




                });
            }
        }

        /// <summary>
        /// 界面显示状态参数(控制板)
        /// </summary>
        /// <param name="displayname"></param>
        /// <param name="value"></param>
        private void displayStatusPara_ContrlBoard(string displayname, object value)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((EventHandler)delegate
                {
                    switch (displayname)
                    {
                        case "电机X角度":
                            {
                                byte[] bParas = (byte[])value;
                                double f_value = (bParas[0] | (bParas[1] << 8) | (bParas[2] << 16) | (bParas[3] << 24)) * 1.8f;
                                label_Angle_X.Text = f_value.ToString("0.0 °");
                                label_Angle_X.Tag = f_value;
                           //     MessageBox.Show("测试位置2");
                            }
                            break;
                        case "电机Y角度":
                            {
                                byte[] bParas = (byte[])value;
                                double f_value = (bParas[0] | (bParas[1] << 8) | (bParas[2] << 16) | (bParas[3] << 24)) * 1.8f;
                                label_Angle_Y.Text = f_value.ToString("0.0 °");
                                label_Angle_Y.Tag = f_value;
                            }
                            break;
                        //case "水箱":
                        //    {

                        //        if (((byte)value) == 0x00)
                        //        {
                        //            labelWaterTank_SwitchStatus.ForeColor = ThemeTextColor;
                        //            picWaterTank_SwitchStatus.BackgroundImage = Properties.Resources.无;
                        //            btnWaterTankSwitch.Checked = false;
                        //        }
                        //        else if (((byte)value) == 0x01)
                        //        {
                        //            labelWaterTank_SwitchStatus.ForeColor = Color.Aqua;
                        //            picWaterTank_SwitchStatus.BackgroundImage = Properties.Resources.有;
                        //            btnWaterTankSwitch.Checked = true;
                        //        }
                        //    }
                        //    break;
                        case "当前温度":
                            {
                                byte[] bParas = (byte[])value;
                                double f_value = (bParas[0] | (bParas[1] << 8)) * 0.1f;
                                if (f_value > 1)
                                {
                                    btnWaterTankSwitch.Checked = true;
                                    if (f_value > 80)
                                    {
                                        labelWaterTank_Temperature.ForeColor = Color.Red;
                                        picWaterTank_Temperature.BackgroundImage = Properties.Resources.温度_alarm;

                                    }
                                    else
                                    {
                                        labelWaterTank_Temperature.ForeColor = Color.Aqua;
                                        picWaterTank_Temperature.BackgroundImage = Properties.Resources.温度_normal;
                                    }
                                    labelWaterTank_Temperature.Text = f_value.ToString("0.0℃");
                                }
                                else
                                {
                                    btnWaterTankSwitch.Checked = false;
                                }
                            }
                            break;
                        case "报警信息":
                            {
                                byte[] bParas = (byte[])value;
                                string strAlarm = "";
                                byte W1 = bParas[0];
                                byte W2 = bParas[1];

                                byte[] W1_bitArray = getBooleanArray(W1);
                                if (W1_bitArray[0] == 1)
                                {
                                    strAlarm += "电机X错误";
                                }
                                if (W1_bitArray[1] == 1)
                                {
                                    strAlarm += "电机Y错误";
                                }
                                if (W1_bitArray[2] == 1)
                                {
                                    strAlarm += "电机Z错误";
                                }
                                if (W1_bitArray[3] == 1)
                                {
                                    strAlarm += "水冷机错误";
                                }
                                if (W1_bitArray[4] == 1)
                                {
                                    if (W2 == 0x01)
                                        strAlarm += "温湿度模块初始化错误";
                                    else if (W2 == 0x01)
                                        strAlarm += "内存24512 初始化错误";
                                    else
                                        strAlarm += "其他错误";

                                }


                                label_AlarmInfo.Text = strAlarm;
                            }
                            break;
                        //case "空调":
                        //    {
                        //        if (((byte)value) == 0x00)
                        //        {
                        //            labelAirConditione_SwitchStatus.ForeColor = ThemeTextColor;
                        //            picAirConditione_SwitchStatus.BackgroundImage = Properties.Resources.无;
                        //            btnAirConditioneSwitch.Checked = false;
                        //        }
                        //        else if (((byte)value) == 0x01)
                        //        {
                        //            labelAirConditione_SwitchStatus.ForeColor = Color.Aqua;
                        //            picAirConditione_SwitchStatus.BackgroundImage = Properties.Resources.有;
                        //            btnAirConditioneSwitch.Checked = true;
                        //        }
                        //    }
                        //    break;
                        case "当前湿度":
                            {
                                byte[] bParas = (byte[])value;
                                double f_value = (bParas[0] | (bParas[1] << 8)) * 0.1f;
                                if (f_value > 1)
                                {
                                    btnAirConditioneSwitch.Checked = true;
                                    if (f_value > 45)
                                    {
                                        labelAirConditione_Humidity.ForeColor = Color.Red;
                                        picAirConditione_Humidity.BackgroundImage = Properties.Resources.湿度_alarm;

                                    }
                                    else
                                    {
                                        labelAirConditione_Humidity.ForeColor = Color.Aqua;
                                        picAirConditione_Humidity.BackgroundImage = Properties.Resources.湿度_normal;
                                    }

                                    labelAirConditione_Humidity.Text = f_value.ToString("0.0") + "%RH";
                                }
                                else
                                {
                                    btnAirConditioneSwitch.Checked = false;
                                }
                            }
                            break;
                        case "当前焊接长度":
                            {
                                byte[] bParas = (byte[])value;
                                double f_value = ((bParas[0] | (bParas[1] << 8) | (bParas[2] << 16) | (bParas[3] << 24)) * 0.01f);
                                labelCurrWeldLength.Text = f_value.ToString("0.0");

                                //   "总焊接长度":

                            }
                            break;
                        case "总焊接长度":
                            {
                                byte[] bParas = (byte[])value;
                                double f_value = ((bParas[0] | (bParas[1] << 8) | (bParas[2] << 16) | (bParas[3] << 24)) * 0.01f);
                                labelTotalWeldLength.Text = f_value.ToString("0.0");
                            }
                            break;
                        case "当前机器时间":
                            {
                                byte[] bParas = (byte[])value;
                                string datetime = (bParas[0] | (bParas[1] << 8)) + "年" + ((int)bParas[2]).ToString("00") + "月" + bParas[3].ToString("00") + "日 " + bParas[4].ToString("00") + ":" + bParas[5].ToString("00") + ":" + bParas[6].ToString("00");
                                labelCurrMachineTime.Text = datetime;
                            }
                            break;
                        //case "焊接轨迹跟踪开关":
                        //    {
                        //        if (((byte)value) == 0x00)
                        //        {
                        //            btnWeldTrackingSwitch.Checked = false;
                        //        }
                        //        else if (((byte)value) == 0x01)
                        //        {
                        //            btnWeldTrackingSwitch.Checked = true;
                        //        }
                        //    }
                        //    break;                       
                        case "焊接轨迹跟踪开关":
                            {
                                if (((byte)value) == 0x00)
                                {
                                    if (btnWeldTrackingSwitch.Checked != false)
                                    {
                                        btnWeldTrackingSwitch.Checked = false;
                                    }
                                }
                                else if (((byte)value) == 0x01)
                                {
                                    if (btnWeldTrackingSwitch.Checked != true)
                                        btnWeldTrackingSwitch.Checked = true;
                                }
                            }
                            break;
                        case "焊接轨迹坐标":
                            {
                                byte[] bParas = (byte[])value;
                               double f_value = (bParas[0] | (bParas[1] << 8)) * 0.01f;
                                if (btnWeldTrackingSwitch.Checked)
                                {
                                    this.chart1.Series[0].Points.AddY(f_value);

                                    resetChartAreaAxisX_MaxMin();
                                    resetChartAreaAxisY_MaxMin(f_value);

                                }
                                else
                                {
                                    this.chart1.Series[0].Points.Clear();
                                }
                            }
                            break;

                        default:
                            MessageBox.Show("控制板通信：收到未知的显示内容：" + displayname);
                            break;
                    }
                });
            }
        }



        /// <summary>
        /// 界面显示状态参数(激光器)
        /// </summary>
        /// <param name="displayname"></param>
        /// <param name="value"></param>
        private void displayStatusPara_LaserDevice(string displayname, object value)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((EventHandler)delegate
                {
                    switch (displayname)
                    {
                        case "激光输出功率":
                            {
                                LaserPower.Text = value + "%";
                                LaserPower.Value = (int)value;
                            }
                            break;
                        case "内控使能":
                            {
                                if (((byte)value) == 0x55)
                                {
                                    labelEnable_Status.ForeColor = ThemeTextColor;
                                    picEnable_Status.BackgroundImage = Properties.Resources.无;
                                    btnEnableSwitch.Checked = false;
                                }
                                else if (((byte)value) == 0xAA)
                                {
                                    labelEnable_Status.ForeColor = Color.Aqua;
                                    picEnable_Status.BackgroundImage = Properties.Resources.有;
                                    btnEnableSwitch.Checked = true;
                                    if (btnRedlightSwitch.Checked)
                                        sendRedlightSwitchCommands(false);
                                }
                            }
                            break;
                        case "红光开关":
                            {
                                if (((byte)value) == 0x55)
                                {
                                    labelRedlight_Status.ForeColor = ThemeTextColor;
                                    picRedlight_Status.BackgroundImage = Properties.Resources.无;
                                    btnRedlightSwitch.Checked = false;
                                }
                                else if (((byte)value) == 0xAA)
                                {
                                    labelRedlight_Status.ForeColor = Color.Aqua;
                                    picRedlight_Status.BackgroundImage = Properties.Resources.有;
                                    btnRedlightSwitch.Checked = true;
                                    if (btnEnableSwitch.Checked)
                                        sendEnableSwitchCommands(false);
                                }
                            }
                            break;
                        case "报警信息":
                            {
                                string strAlarm = "";
                                byte W1 = ((byte[])value)[0];
                                byte W2 = ((byte[])value)[1];
                                byte W3 = ((byte[])value)[2];
                                byte W4 = ((byte[])value)[3];

                                byte[] W1_bitArray = getBooleanArray(W1);
                                byte[] W2_bitArray = getBooleanArray(W2);
                                byte[] W3_bitArray = getBooleanArray(W3);
                                byte[] W4_bitArray = getBooleanArray(W4);

                                displayAlarm.clearItem();
                                if (W1_bitArray[0] == 1)
                                {
                                    displayAlarm.display("过压告警", StateColor.AlarmColor);
                                }
                                if (W1_bitArray[1] == 1)
                                {
                                    displayAlarm.display("欠压告警", StateColor.AlarmColor);
                                }
                                if (W1_bitArray[2] == 1)
                                {
                                    displayAlarm.display("水流量告警", StateColor.AlarmColor);
                                }
                                if (W1_bitArray[3] == 1)
                                {
                                    displayAlarm.display("急停告警", StateColor.AlarmColor);
                                }

                                if (W1_bitArray[4] == 1)
                                {
                                    displayAlarm.display("QBH 安装告警", StateColor.AlarmColor);
                                }
                                if (W1_bitArray[5] == 1)
                                {
                                    displayAlarm.display("QBH 温度告警", StateColor.AlarmColor);
                                }
                                if (W1_bitArray[6] == 1)
                                {
                                    displayAlarm.display("电水冷板温度告警", StateColor.AlarmColor);
                                }
                                if (W1_bitArray[7] == 1)
                                {
                                    displayAlarm.display("异常断电报警", StateColor.AlarmColor);
                                }

                                if (W2_bitArray[0] == 1)
                                {
                                    displayAlarm.display("泵源电流告警", StateColor.AlarmColor);
                                }
                                if (W2_bitArray[1] == 1)
                                {
                                    displayAlarm.display("泵源温度告警", StateColor.AlarmColor);
                                }
                                if (W2_bitArray[2] == 1)
                                {
                                    displayAlarm.display("PD_SD1 告警", StateColor.AlarmColor);
                                }
                                if (W2_bitArray[3] == 1)
                                {
                                    displayAlarm.display("PD1 告警", StateColor.AlarmColor);
                                }
                                if (W2_bitArray[4] == 1)
                                {
                                    displayAlarm.display("光模块温度告警(非致命)", StateColor.WarnColor);
                                }
                                if (W2_bitArray[5] == 1)
                                {
                                    displayAlarm.display("光模块湿度告警(非致命)", StateColor.WarnColor);
                                }
                                if (W2_bitArray[6] == 1)
                                {
                                    displayAlarm.display("红光电流告警(非致命)", StateColor.WarnColor);
                                }
                                if (W2_bitArray[7] == 1)
                                {
                                    displayAlarm.display("剥模器1 温度告警", StateColor.AlarmColor);
                                }

                                if (W3_bitArray[0] == 1)
                                {
                                    displayAlarm.display("剥模器2 温度告警", StateColor.AlarmColor);
                                }
                                if (W3_bitArray[1] == 1)
                                {
                                    displayAlarm.display("光水冷板温度1 告警", StateColor.AlarmColor);
                                }
                                if (W3_bitArray[2] == 1)
                                {
                                    displayAlarm.display("光水冷板温度2 告警", StateColor.AlarmColor);
                                }
                                if (W3_bitArray[3] == 1)
                                {
                                    displayAlarm.display("电模块温度告警(非致命)", StateColor.WarnColor);
                                }
                                if (W3_bitArray[4] == 1)
                                {
                                    displayAlarm.display("电模块湿度告警(非致命)", StateColor.WarnColor);
                                }
                                if (W3_bitArray[5] == 1)
                                {
                                    displayAlarm.display("Power AC Alarm", StateColor.AlarmColor);
                                }
                                if (W3_bitArray[6] == 1)
                                {
                                    displayAlarm.display("Power DC Alarm", StateColor.AlarmColor);
                                }
                                if (W3_bitArray[7] == 1)
                                {
                                    displayAlarm.display("PD2 告警", StateColor.AlarmColor);
                                }

                                if (W4_bitArray[0] == 1)
                                {
                                    displayAlarm.display("超强回光告警", StateColor.AlarmColor);
                                }
                                if (W4_bitArray[1] == 1)
                                {
                                    displayAlarm.display("普通回光告警", StateColor.AlarmColor);
                                }
                                if (W4_bitArray[2] == 1)
                                {
                                    displayAlarm.display("回光预警(非致命)", StateColor.WarnColor);
                                }
                                if (W4_bitArray[3] == 1)
                                {
                                    displayAlarm.display("合束器温度告警", StateColor.AlarmColor);
                                }
                                if (W4_bitArray[4] == 1)
                                {
                                    displayAlarm.display("FPGA 加载失败告警", StateColor.AlarmColor);
                                }
                                if (W4_bitArray[5] == 1)
                                {
                                    displayAlarm.display("FPGA 握手失败告警", StateColor.AlarmColor);
                                }
                                if (W4_bitArray[6] == 1)
                                {
                                    displayAlarm.display("系统时钟失效(非致命)", StateColor.WarnColor);
                                }
                                if (W4_bitArray[7] == 1)
                                {
                                    displayAlarm.display("水冷板低温告警", StateColor.AlarmColor);
                                }

                                if (strAlarm != "")
                                {
                                    labelAlarm_Status.ForeColor = Color.Red;
                                    picAlarm_Status.BackgroundImage = Properties.Resources.激光器_alarm;
                                }
                                else
                                {
                                    labelAlarm_Status.ForeColor = ThemeTextColor;
                                    picAlarm_Status.BackgroundImage = Properties.Resources.无;
                                }


                            }
                            break;
                        case "状态信息1":
                            {

                                byte S1 = ((byte[])value)[0];
                                byte S2 = ((byte[])value)[1];

                                byte[] S1_bitArray = getBooleanArray(S1);
                                byte[] S2_bitArray = getBooleanArray(S2);

                                displayState.clearItem();
                                // 内外控指示，0 - 外控，1 - 内控
                                if (S1_bitArray[0] == 1)
                                {
                                    displayState.display("控制模式：内控", StateColor.normalColor);
                                    isInternalMode = true;
                                    btnSetPower.Enabled = true;
                                    btnEnableSwitch.Enabled = true;
                                    btnRedlightSwitch.Enabled = true;
                                    if (btnEnableSwitch.Checked)
                                        btnWeldSwitch.Enabled = true;
                                }
                                else
                                {
                                    displayState.display("控制模式：外控", StateColor.WarnColor);
                                    isInternalMode = false;
                                    btnSetPower.Enabled = false;
                                    btnEnableSwitch.Enabled = false;
                                    btnRedlightSwitch.Enabled = false;
                                    btnWeldSwitch.Enabled = false;

                                    setInternalMode();
                                }
                                // 激光器出光指示，0 - 没出光，1 - 出光
                                if (S1_bitArray[1] == 1)
                                {
                                    displayState.display("激光器出光：出光", StateColor.normalColor);
                                    labelLaser_Status.ForeColor = Color.Aqua;
                                    picLaser_Status.BackgroundImage = Properties.Resources.有;
                                    btnWeldSwitch.Checked = true;
                                }
                                else
                                {
                                    displayState.display("激光器出光：没出光", StateColor.ShutColor);
                                    labelLaser_Status.ForeColor = ThemeTextColor;
                                    picLaser_Status.BackgroundImage = Properties.Resources.无;
                                    btnWeldSwitch.Checked = false;
                                }
                                // 主电源启动指示，0 - 关闭，1 - 启动
                                if (S1_bitArray[2] == 1)
                                {
                                    displayState.display("主电源：启动", StateColor.normalColor);
                                    labelPower_Status.ForeColor = Color.Aqua;
                                    picPower_Status.BackgroundImage = Properties.Resources.有;
                                }
                                else
                                {
                                    displayState.display("主电源：关闭", StateColor.ShutColor);
                                    labelPower_Status.ForeColor = ThemeTextColor;
                                    picPower_Status.BackgroundImage = Properties.Resources.无;
                                }

                                if (S1_bitArray[3] == 1)
                                {

                                }
                                if (S1_bitArray[4] == 1)
                                {

                                }
                                // 结露指示，0 - 正常，1 - 报警
                                if (S1_bitArray[5] == 1)
                                {
                                    displayState.display("结露：报警", StateColor.AlarmColor);
                                }
                                else
                                {
                                    displayState.display("结露：正常", StateColor.normalColor);
                                }

                                if (S1_bitArray[6] == 1)
                                {

                                }
                                if (S1_bitArray[7] == 1)
                                {

                                }

                                // 连续前向光锁机标志，0 - 未锁机，1 – 已锁机
                                if (S2_bitArray[0] == 1)
                                {
                                    displayState.display("连续前向光锁机标志：已锁机", StateColor.WarnColor);
                                }
                                else
                                {
                                    displayState.display("连续前向光锁机标志：未锁机", StateColor.normalColor);
                                }
                                // 外控线EN，0 - 低电平，1 - 高电平
                                if (S2_bitArray[1] == 1)
                                {
                                    displayState.display("外控线EN：高电平", StateColor.normalColor);
                                }
                                else
                                {
                                    displayState.display("外控线EN：低电平", StateColor.normalColor);
                                }
                                // 外控线调制PWM，0 - 低电平，1 - 高电平
                                if (S2_bitArray[2] == 1)
                                {
                                    displayState.display("外控线调制PWM：高电平", StateColor.normalColor);
                                }
                                else
                                {
                                    displayState.display("外控线调制PWM：低电平", StateColor.normalColor);
                                }
                                // 外控线0～10V，0 - 低电平，1 - 高电平
                                if (S2_bitArray[3] == 1)
                                {
                                    displayState.display("外控线0～10V：高电平", StateColor.normalColor);
                                }
                                else
                                {
                                    displayState.display("外控线0～10V：低电平", StateColor.normalColor);
                                }
                                // 外控线Control，0 - 低电平，1 - 高电平
                                if (S2_bitArray[4] == 1)
                                {
                                    displayState.display("外控线Control：高电平", StateColor.normalColor);
                                }
                                else
                                {
                                    displayState.display("外控线Control：低电平", StateColor.normalColor);
                                }
                                // 连续QBH 温度锁机标志，0 - 未锁机，1 – 已锁机
                                if (S2_bitArray[5] == 1)
                                {
                                    displayState.display("连续QBH 温度锁机标志：已锁机", StateColor.WarnColor);
                                }
                                else
                                {
                                    displayState.display("连续QBH 温度锁机标志：未锁机", StateColor.normalColor);
                                }
                                // 连续回光锁机标志，0 - 未锁机，1 – 已锁机
                                if (S2_bitArray[6] == 1)
                                {
                                    displayState.display("连续回光锁机标志：已锁机", StateColor.WarnColor);
                                }
                                else
                                {
                                    displayState.display("连续回光锁机标志：未锁机", StateColor.normalColor);
                                }

                                if (S2_bitArray[7] == 1)
                                {

                                }
                            }
                            break;
                        case "状态信息2":
                            {

                                byte S1 = ((byte[])value)[0];
                                byte S2 = ((byte[])value)[1];

                                byte[] S1_bitArray = getBooleanArray(S1);
                                byte[] S2_bitArray = getBooleanArray(S2);

                                displayState.clearItem();
                              
                                if (S1_bitArray[0] == 1)
                                {
                                    
                                }
                                // 激光器SD卡状态，0 未连接，1 已连接
                                if (S1_bitArray[1] == 1)
                                {
                                    displayState.display("激光器SD卡状态：已连接", StateColor.normalColor);
                                }
                                else
                                {
                                    displayState.display("激光器SD卡状态：未连接", StateColor.WarnColor);
                                }
                               
                                if (S1_bitArray[2] == 1)
                                {
                               
                                }
                                // 激光器RTC状态，1 锁机，0 正常 （有加密数据，RTC 时间不正确）
                                if (S1_bitArray[3] == 1)
                                {
                                    displayState.display("激光器RTC状态：锁机", StateColor.AlarmColor);
                                }
                                else
                                {
                                    displayState.display("激光器RTC状态：正常", StateColor.normalColor);
                                }
                                // 激光器互锁状态，0 未连接，1 已连接
                                if (S1_bitArray[4] == 1)
                                {
                                    displayState.display("激光器互锁状态：已连接", StateColor.normalColor);
                                }
                                else
                                {
                                    displayState.display("激光器互锁状态：未连接", StateColor.ShutColor);
                                }
                                // 激光器后气动门/互锁 2 状态，0 未连接，1 已连接
                                if (S1_bitArray[5] == 1)
                                {
                                    displayState.display("激光器后气动门/互锁：已连接", StateColor.normalColor);
                                }
                                else
                                {
                                    displayState.display("激光器后气动门/互锁：未连接", StateColor.normalColor);
                                }

                                if (S1_bitArray[6] == 1)
                                {

                                }
                                if (S1_bitArray[7] == 1)
                                {

                                }


                            }
                            break;

                    }


                });
            }
        }

        /// <summary>
        /// 内控模式
        /// </summary>
        bool isInternalMode = false;
        /// <summary>
        /// 将激光器切换为内控模式
        /// </summary>
        private void setInternalMode()
        {
            byte[] mode = new byte[] { 0xAA };
            byte[] m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataWrite, Global.LaserDevice_Commands.ModeSwitch, mode);
            Common.SendQueue_PC.Enqueue(m_SendAryPC);

            // 读取---状态信息
            m_SendAryPC = Common.generateSendData(Global.LaserDevice_Commands.DataHead_sendLaserDevice, Global.LaserDevice_Commands.Address_LaserDevice, Global.DataRead, Global.LaserDevice_Commands.StateInfo1);
            Common.SendQueue_PC.Enqueue(m_SendAryPC);
        }


        /// <summary>
        /// 显示报警信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel17_MouseEnter(object sender, EventArgs e)
        {
            if (!displayAlarm.isEmpty())
            {
                Point loctPoint = picAlarm_Status.FindForm().PointToClient(picAlarm_Status.PointToScreen(new Point(0, 0)));
                int height = this.Height - loctPoint.Y - picAlarm_Status.Height;
                displayAlarm.resize(titlePanel4.Width, height);

                Point screenMouse = picAlarm_Status.PointToScreen(new Point(0, 0));
                displayAlarm.Location = new Point(titlePanel4.PointToScreen(new Point(0, 0)).X + titlePanel4.Width - displayAlarm.Width, screenMouse.Y + picAlarm_Status.Height + 5);

                displayAlarm.Show();
            }
        }
        /// <summary>
        /// 隐藏报警信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel17_MouseLeave(object sender, EventArgs e)
        {
            if (!panel17.RectangleToScreen(panel17.ClientRectangle).Contains(Control.MousePosition))
            {
                displayAlarm.Hide();
            }
        }

        /// <summary>
        /// 显示状态信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel14_MouseEnter(object sender, EventArgs e)
        {
            if (!displayState.isEmpty())
            {
                Point loctPoint = picAlarm_Status.FindForm().PointToClient(picAlarm_Status.PointToScreen(new Point(0, 0)));
                int height = this.Height - loctPoint.Y - picAlarm_Status.Height;
                displayState.resize(titlePanel4.Width, height);

                Point screenMouse = picAlarm_Status.PointToScreen(new Point(0, 0));
                displayState.Location = new Point(titlePanel4.PointToScreen(new Point(0, 0)).X, screenMouse.Y + picAlarm_Status.Height + 5);

                if (this.RectangleToScreen(this.ClientRectangle).Contains(displayState.Location))
                {
                    displayState.Show();
                }

            }
        }

        /// <summary>
        /// 隐藏状态信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel14_MouseLeave(object sender, EventArgs e)
        {
            if (!panel14.RectangleToScreen(panel14.ClientRectangle).Contains(Control.MousePosition))
            {
                displayState.Hide();
            }
        }





        #endregion



        #region 焊接监控
        bool bPlayflag = true;

        /// <summary>
        /// 播放摄像头
        /// </summary>
        private void Play_Camera()
        {

            var m_vCapture = new OpenCvSharp.VideoCapture(1);

            if (!m_vCapture.IsOpened())
            {
                m_vCapture.Open(0);// try to open the default camera if USB camera failed
                if (!m_vCapture.IsOpened())
                {
                    //  return;
                }
            }
            //此处参考网上的读取方法
            int sleepTime = (int)Math.Round(1000 / m_vCapture.Fps);

            // 进入读取视频每帧的循环
            while (bPlayflag)
            {
                // 声明实例 Mat类
                OpenCvSharp.Mat image1 = new OpenCvSharp.Mat();
                m_vCapture.Read(image1);

                //判断是否还有没有视频图像 
                if (image1.Empty())
                    break;

                //图像缩放适应PictureBox的尺寸
                OpenCvSharp.Mat image2 = new OpenCvSharp.Mat();
                float scale = Math.Min(pictureBox6.Width / (float)image1.Width, pictureBox6.Height / (float)image1.Height);
                OpenCvSharp.Cv2.Resize(image1, image2, new OpenCvSharp.Size(image1.Width * scale, image1.Height * scale), 0, 0, OpenCvSharp.InterpolationFlags.Area);

                // 在PictureBox中播放视频， 需要先转换成bitmap格式
                pictureBox6.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image2);

                // 在Window窗口中播放视频
                //  window.ShowImage(image);

                OpenCvSharp.Cv2.WaitKey(sleepTime);

                image1.Release();
                image2.Release();
            }
        }
        #endregion


        #region 背景主题

        ChangeSkinForm skinForm;
        private void btn_skin_Click(object sender, EventArgs e)
        {
            Point screenMouse = btn_skin.PointToScreen(new Point(-300, 30));
            skinForm.Location = screenMouse;
            if (skinForm.Visible)
                skinForm.Hide();
            else
                skinForm.Show();
        }
        private void changeTextColor(Control control, Color newcolor)
        {
            foreach (Control con in control.Controls)
            {

                if (con is Label || con is Button)
                {
                    Color textColor = con.ForeColor;
                    if (textColor.ToArgb() == Color.White.ToArgb() || textColor.ToArgb() == Color.Black.ToArgb())
                        con.ForeColor = newcolor;

                }
                if (con is TranslucentButton)
                {
                    TranslucentButton tsbutton = con as TranslucentButton;
                    Color textColor = tsbutton.FontColor;
                    if (textColor.ToArgb() == Color.White.ToArgb() || textColor.ToArgb() == Color.Black.ToArgb())
                        tsbutton.FontColor = newcolor;
                }
                if (con is TitlePanel)
                {
                    TitlePanel tpanel = con as TitlePanel;
                    Color titleColor = tpanel.TitleColor;
                    if (titleColor.ToArgb() == Color.White.ToArgb() || titleColor.ToArgb() == Color.Black.ToArgb())
                        tpanel.TitleColor = newcolor;
                }


                if (con is CircularProgressBar.CircularProgressBar)
                {
                    continue;
                }


                if (con.Controls.Count > 0)
                {
                    changeTextColor(con, newcolor);
                }
            }
        }
        /// <summary>
        /// 主题的字体颜色
        /// </summary>
        Color ThemeTextColor = Color.White;



        private void SkinForm_SkinEvent(object sender, ChangeSkinForm.SkinEventArgs e)
        {
            this.BackColor = e.mainColor;
            if (e.textColor.ToArgb() == Color.Black.ToArgb())
            {
                this.titlePanel1.PanelBackColor = PublicFunc.ChangeColor(BackColor, -2);
                this.titlePanel2.PanelBackColor = PublicFunc.ChangeColor(BackColor, -2);
                this.titlePanel4.PanelBackColor = PublicFunc.ChangeColor(BackColor, -2);
                this.titlePanel5.PanelBackColor = PublicFunc.ChangeColor(BackColor, -2);
                this.titlePanel6.PanelBackColor = PublicFunc.ChangeColor(BackColor, -2);
                this.chart1.ChartAreas[0].BackColor = PublicFunc.ChangeColor(BackColor, -2);
                this.LaserPower.BackColor = PublicFunc.ChangeColor(BackColor, -2);

                this.displayState.changeBackColor(PublicFunc.ChangeColor(BackColor, -4));
                this.displayAlarm.changeBackColor(PublicFunc.ChangeColor(BackColor, -4));

                btn_skin.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, -3);
                btn_min.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, -3);
                btn_max.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, -3);
                btn_close.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, -3);
            }
            else
            {
                this.titlePanel1.PanelBackColor = PublicFunc.ChangeColor(BackColor, 2);
                this.titlePanel2.PanelBackColor = PublicFunc.ChangeColor(BackColor, 2);
                this.titlePanel4.PanelBackColor = PublicFunc.ChangeColor(BackColor, 2);
                this.titlePanel5.PanelBackColor = PublicFunc.ChangeColor(BackColor, 2);
                this.titlePanel6.PanelBackColor = PublicFunc.ChangeColor(BackColor, 2);
                this.chart1.ChartAreas[0].BackColor = PublicFunc.ChangeColor(BackColor, 2);
                this.LaserPower.BackColor = PublicFunc.ChangeColor(BackColor, 2);

                this.displayState.changeBackColor(PublicFunc.ChangeColor(BackColor, 4));
                this.displayAlarm.changeBackColor(PublicFunc.ChangeColor(BackColor, 4));


                btn_skin.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, 3);
                btn_min.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, 3);
                btn_max.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, 3);
                btn_close.FlatAppearance.MouseOverBackColor = PublicFunc.ChangeColor(BackColor, 3);
            }
            ThemeTextColor = e.textColor;
            changeTextColor(this, ThemeTextColor);



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //chart1.Series[0].Points.AddY(-9);
            //resetChartAreaAxisX_MaxMin();
            //resetChartAreaAxisY_MaxMin(-9);

            Random rd = new Random();
            double val = rd.NextDouble() * 10;
            chart1.Series[0].Points.AddY(val);
            resetChartAreaAxisX_MaxMin();
            resetChartAreaAxisY_MaxMin(val);

            //chart1.Series[0].Points.AddY(-1999);
            //resetChartAreaAxisX_MaxMin();
            //resetChartAreaAxisY_MaxMin(-1999);
        }

        double chartAreasAxisYShowIntervalRange = 200;
        /// <summary>
        /// 重新设置chart图表的X轴最大最小值
        /// </summary>
        private void resetChartAreaAxisX_MaxMin()
        {
            if (chart1.Series[0].Points.Count > chartAreasAxisYShowIntervalRange - 10)
            {
                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points.Count - chartAreasAxisYShowIntervalRange + 10;
                chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[0].Points.Count + 10;
            }
        }
        double axisY_Min = 0;
        double axisY_Max = 10;
        private void resetChartAreaAxisY_MaxMin(double value)
        {
            double interValue = 10;
            if (Math.Abs(value) > 1)
            {
                interValue = 10;
            }
            if (Math.Abs(value / 10) > 1)
            {
                interValue = 10;
            }
            if (Math.Abs(value / 100) > 1)
            {
                interValue = 100;
            }
            if (Math.Abs(value / 1000) > 1)
            {
                interValue = 1000;
            }

            if (value < axisY_Min + interValue)
            {
                axisY_Min = value - interValue;
                chart1.ChartAreas[0].AxisY.Minimum = axisY_Min;//设置Y轴最小值
            }
            if (value > axisY_Max - interValue)
            {
                axisY_Max = value + interValue;
                chart1.ChartAreas[0].AxisY.Maximum = axisY_Max;//设置Y轴最大值
            }
        }



        #endregion


        /// <summary>
        /// 将byte转换为一个长度为8的byte数组，数组每个值代表bit
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static byte[] getBooleanArray(byte b)
        {
            byte[] array = new byte[8];
            for (int i = 7; i >= 0; i--)
            {
                array[i] = (byte)(b & 1);
                b = (byte)(b >> 1);
            }
            return array;
        }


        /// <summary>
        /// 判断是否是数字 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

      
    }

}
    

