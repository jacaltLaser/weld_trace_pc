using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 星链激光制管机控制软件
{
    public partial class DisplayDetailForm : Form
    {
        public DisplayDetailForm(string tilte)
        {
            InitializeComponent();
            label1.Text = tilte;
        }



        private void DisplayDetailForm_Load(object sender, EventArgs e)
        {

        }

        public void changeBackColor(Color back)
        {
            label1.BackColor = ChangeColor(back, -3);
            this.BackColor = back;
        }
        public static Color ChangeColor(Color color, float factor)
        {

            float red = (float)color.R + (10 * (factor));
            float green = (float)color.G + 12 * factor;
            float blue = (float)color.B + factor * 14;

            if (red < 0)
                red = 0;
            if (red > 255)
                red = 255;

            if (green < 0)
                green = 0;
            if (green > 255)
                green = 255;

            if (blue < 0)
                blue = 0;
            if (blue > 255)
                blue = 255;


            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }
        /// <summary>
        /// 清除所以内容
        /// </summary>
        public void clearItem()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        /// <summary>
        /// 显示内容是否为空
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 显示该信息
        /// </summary>
        /// <param name="item"></param>
        /// <param name="color"></param>
        public void display(string item, Color color)
        {
            string name = item.Split('：')[0];

            foreach (Control con in flowLayoutPanel1.Controls)
            {
                if (con.Name.Equals(name))
                {
                    con.Text = item;
                    con.ForeColor = color;
                    return;
                }
            }

            Label lbl = new Label();
            lbl.Name = name;
            lbl.ForeColor = color;
            lbl.Text = item;
            lbl.AutoSize = false;
            lbl.Size = new Size(175, 25);
            lbl.Font = new Font("微软雅黑", 9);
            flowLayoutPanel1.Controls.Add(lbl);

        }


        /// <summary>
        /// 删除该信息
        /// </summary>
        /// <param name="item"></param>
        public void delete(string item)
        {
            string name = item.Split('：')[0];

            foreach (Control con in flowLayoutPanel1.Controls)
            {
                if (con.Name.Equals(name))
                {
                    flowLayoutPanel1.Controls.Remove(con);
                    return;
                }
            }
        }

        public void resize(int width, int height)
        {
            if (width > 370)
            {
                this.Width = 370;
                this.Height = (int)Math.Ceiling(flowLayoutPanel1.Controls.Count / 2f) * 25 + label1.Height + 10;
            }
            else
            {
                this.Width = 180;
                this.Height = flowLayoutPanel1.Controls.Count * 25 + label1.Height + 10;
            }

        }
    }
    /// <summary>
    /// 状态颜色
    /// </summary>
    public static class StateColor
    {
        /// <summary>
        /// 正常
        /// </summary>
        public static Color normalColor = Color.Aqua;
        /// <summary>
        /// 关闭
        /// </summary>
        public static Color ShutColor = Color.Silver;
        /// <summary>
        /// 告警
        /// </summary>
        public static Color AlarmColor = Color.Red;
        /// <summary>
        /// 警示
        /// </summary>
        public static Color WarnColor = Color.Yellow;
    }
}
