using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    [ToolboxBitmap(typeof(ComboBox))]
    public partial class MComboBox : UserControl
    {
        public MComboBox()
        {
            InitializeComponent();
            mTextBox1.Font = this.Font;
            this.Height = mTextBox1.Height;
        }
        private void MComboBox_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 组合框的项
        /// </summary>
        public string[] mItems= { };
        [TypeConverter(typeof(string))]//指定类型装换器
        [Browsable(true), Category("MComboBox"), Description("组合框的项")]
        public string[] Items
        {
            get
            {
                return mItems;
            }
            set
            {
                if (mItems != value)
                {
                    mItems = value;
                    drawItemsPanel();
                }
            }
            }

            /// <summary>
            /// 组合框的下拉框中的对齐方式
            /// </summary>
            ContentAlignment itemAlign = ContentAlignment.MiddleLeft;
        [Browsable(true), Category("MComboBox"), Description("组合框的下拉框中的对齐方式")]
        public ContentAlignment ItemAlign
        {
            get
            {
                return itemAlign;
            }
            set
            {
                if (itemAlign != value)
                {
                    itemAlign = value;
                    
                }
            }
        }
        /// <summary>
        /// 绘制下拉显示框
        /// </summary>
        private void drawItemsPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (string item in mItems)
            {
              
                Button btnItem = new Button();                   
                btnItem.FlatAppearance.BorderSize = 0;
                btnItem.FlatStyle = FlatStyle.Flat;
                btnItem.Font = this.Font;
                btnItem.Name = item;
                btnItem.Text = item;
                btnItem.Size = new Size(flowLayoutPanel1.Size.Width-5, mTextBox1.Height+5);
                btnItem.TextAlign = itemAlign;
                btnItem.UseVisualStyleBackColor = true;
                btnItem.Click += new EventHandler(this.selectItem_Click);

                flowLayoutPanel1.Controls.Add(btnItem);
            }

            
        }

        private void MComboBox_SizeChanged(object sender, EventArgs e)
        {
           
            drawItemsPanel();
        }

        private void mTextBox1_MouseDown(object sender, MouseEventArgs e)
        {       
            this.Height = mTextBox1.Height * (mItems.Count()+2);
            this.BringToFront();

        } 
     
        private void selectItem_Click(object sender, EventArgs e)
        {
            mTextBox1.MText =  ((Button)sender).Text;
            this.Height = mTextBox1.Height;
        }

      

        private void MComboBox_Leave(object sender, EventArgs e)
        {
            this.Height = mTextBox1.Height;
        }

       

    }
}
 