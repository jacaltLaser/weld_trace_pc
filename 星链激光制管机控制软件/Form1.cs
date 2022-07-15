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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            string interval = comboBox1.Text;
            interval = interval.Replace("ms", string.Empty).Replace(" ", string.Empty);
            if(!IsNumeric(interval))
                MessageBox.Show(interval+"不是纯数字");
            else
            MessageBox.Show(interval);
            if (interval.Contains("."))
                MessageBox.Show(interval + "是小数");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
