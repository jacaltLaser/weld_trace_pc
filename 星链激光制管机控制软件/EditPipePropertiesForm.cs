using CustomControl;
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
    public partial class EditPipePropertiesForm : SkinMain
    {
        public EditPipePropertiesForm()
        {
            InitializeComponent();
            organizeAlignmentControl();
        }
        #region 界面操作事件

        float ScaleX = 1;
        float ScaleY = 1;
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
                //// 窗口界面标题
                label_Tilte.Font = new Font(label_Tilte.Font.Name, label_Tilte.Font.Size / ScaleX, label_Tilte.Font.Style, label_Tilte.Font.Unit, label_Tilte.Font.GdiCharSet, label_Tilte.Font.GdiVerticalFont);
                adjustControlFontSize(this, ScaleX);

                //// 界面区
                label1.Left = mTextBox1.Left - label1.Width - 2;
                label1.Top = mTextBox1.Top + (mTextBox1.Height - label1.Height) / 2;

                label2.Left = mTextBox2.Left - label2.Width - 2;
                label2.Top = mTextBox2.Top + (mTextBox2.Height - label2.Height) / 2;

                label3.Left = mTextBox3.Left - label3.Width - 2;
                label3.Top = mTextBox3.Top + (mTextBox3.Height - label3.Height) / 2;

                label4.Left = mTextBox4.Left - label4.Width - 2;
                label4.Top = mTextBox4.Top + (mTextBox4.Height - label4.Height) / 2;

                label5.Left = mTextBox5.Left - label5.Width - 2;
                label5.Top = mTextBox5.Top + (mTextBox5.Height - label5.Height) / 2;
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
                con.Font = new Font(con.Font.FontFamily, con.Font.Size * ((1 + scale) / (2 * scale)));

                if (con.Controls.Count > 0)
                {
                    adjustControlFontSize(con, scale);
                }
            }
        }
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
            base.OnMouseDown(e);
        }

        private void panel_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);
                this.Location += new Size(newPosition);
            }
            base.OnMouseMove(e);
        }

        private void panel_Top_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            base.OnMouseUp(e);
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        public event PipePropertieChangeEventHandler PipePropertiesChangeEvent;

        private DataRow dataRow = null;

        public void showContentEditForm(DataRow row, string action)
        {
            dataRow = row;
            btnOK.Text = action;
        }

        private void EditPipePropertiesForm_Load(object sender, EventArgs e)
        {
            if (dataRow != null)
            {
                mTextBox1.MText = dataRow[1].ToString();
                mTextBox2.MText = dataRow[2].ToString();
                mTextBox3.MText = dataRow[3].ToString();
                mTextBox4.MText = dataRow[4].ToString();
                mTextBox5.MText = dataRow[5].ToString();
            }
        }

    
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mTextBox1.MText==""||
                   mTextBox2.MText == "" ||
                   mTextBox3.MText == "" ||
                   mTextBox4.MText == "" ||
                   mTextBox5.MText == "")
            {
                MessageBox.Show("特性的参数不能他有空！");
                return;
            }
                if (dataRow != null)
            {
                if (mTextBox1.MText != dataRow[1].ToString() ||
                    mTextBox2.MText != dataRow[2].ToString() ||
                    mTextBox3.MText != dataRow[3].ToString() ||
                    mTextBox4.MText != dataRow[4].ToString() ||
                    mTextBox5.MText != dataRow[5].ToString() )
                {
                    dataRow.BeginEdit();
                    dataRow[1] = mTextBox1.MText;
                    dataRow[2] = mTextBox2.MText;
                    dataRow[3] = mTextBox3.MText;
                    dataRow[4] = mTextBox4.MText;
                    dataRow[5] = mTextBox5.MText;
                    dataRow.EndEdit();
                }
                
            }


            if (PipePropertiesChangeEvent != null)
                PipePropertiesChangeEvent(this, new DataRowEventArgs() { EventName = btnOK.Text, Data = dataRow });

            this.Close();
        }
        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.FontColor = Color.White;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public class DataRowEventArgs : EventArgs
        {
            public string EventName { get; set; }
            public DataRow Data { get; set; }

        }
        [Serializable]
        [ComVisible(true)]
        public delegate void PipePropertieChangeEventHandler(object sender, DataRowEventArgs e);

       
    }
}

