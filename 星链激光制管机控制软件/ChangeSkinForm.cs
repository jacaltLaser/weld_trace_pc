using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 星链激光制管机控制软件
{
    public partial class ChangeSkinForm : Form
    {
        public ChangeSkinForm()
        {
            InitializeComponent();
        }

        #region  窗口操作
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        private void ChangeSkinForm_Load(object sender, EventArgs e)
        {

        }


        public event SkinEventHandler SkinEvent;
        /// <summary>
        /// 皮肤颜色类
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class SkinEventArgs : EventArgs
        {
            public Color mainColor { get; set; }
            public Color textColor { get; set; }

        }
        /// <summary>
        /// 委托 皮肤事件
        /// </summary>
        [Serializable]
        [ComVisible(true)]
        public delegate void SkinEventHandler(object sender, SkinEventArgs e);

        private void ChangeSkinBtn_MouseEnter(object sender, EventArgs e)
        {
            Button skinBtn = sender as Button;
            skinBtn.FlatAppearance.BorderColor = Color.DeepSkyBlue;
        }

        private void ChangeSkinBtn_MouseLeave(object sender, EventArgs e)
        {
            Button skinBtn = sender as Button;
            if (skinBtn.FlatAppearance.BorderSize == 2)
            {
                skinBtn.FlatAppearance.BorderColor = Color.White;
            }
        }
        private void ChangeSkinBtn_Click(object sender, EventArgs e)
        {
            Button skinBtn = sender as Button;
            if (skinBtn != btnSkin_0)
            {
                btnSkin_0.FlatAppearance.BorderColor = Color.White;
                btnSkin_0.FlatAppearance.BorderSize = 2;
            }
            if (skinBtn != btnSkin_1)
            {
                btnSkin_1.FlatAppearance.BorderColor = Color.White;
                btnSkin_1.FlatAppearance.BorderSize = 2;
            }
            if (skinBtn != btnSkin_2)
            {
                btnSkin_2.FlatAppearance.BorderColor = Color.White;
                btnSkin_2.FlatAppearance.BorderSize = 2;
            }
            if (skinBtn != btnSkin_3)
            {
                btnSkin_3.FlatAppearance.BorderColor = Color.White;
                btnSkin_3.FlatAppearance.BorderSize = 2;
            }
            if (skinBtn != btnSkin_4)
            {
                btnSkin_4.FlatAppearance.BorderColor = Color.White;
                btnSkin_4.FlatAppearance.BorderSize = 2;
            }
            if (skinBtn != btnSkin_5)
            {
                btnSkin_5.FlatAppearance.BorderColor = Color.White;
                btnSkin_5.FlatAppearance.BorderSize = 2;
            }
            skinBtn.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            skinBtn.FlatAppearance.BorderSize = 5;

            this.panel_top.BackColor = PublicFunc.ChangeColor(skinBtn.BackColor, -2.5f);
            this.BackColor = PublicFunc.ChangeColor(skinBtn.BackColor, 5);
            this.label1.ForeColor = skinBtn.ForeColor;

            Properties.Settings.Default.SkinName = skinBtn.Name;
            Properties.Settings.Default.Save();

            SkinEvent(this, new SkinEventArgs() { mainColor = skinBtn.BackColor, textColor = skinBtn.ForeColor });
        }

        public void InitSkinColor()
        {
            Button btnskin = (Button)this.Controls.Find(Properties.Settings.Default.SkinName, false)[0];
            ChangeSkinBtn_Click(btnskin, new EventArgs());
        }


    }

}
