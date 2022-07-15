﻿using System;
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
    public partial class MComboBox2 : UserControl
    {
        public MComboBox2()
        {
            InitializeComponent();
           
        }
        private void MComboBox_Load(object sender, EventArgs e)
        {
           

        }
        ///// <summary>
        ///// 组合框的项
        ///// </summary>
        //public Font mfont = new System.Drawing.Font("宋体", 9F);
        //[Browsable(true), Category("MComboBox"), Description("组合框的项")]
        //public override Font Font
        //{
        //    get
        //    {
        //        return mfont;
        //    }
        //    set
        //    {
        //        if (mfont != value)
        //        {
        //            mfont = value;
        //            mTextBox1.Font = mfont;            
        //            mTextBox1.Location = new Point(0);
        //            mTextBox1.Invalidate();
        //            this.Height = mTextBox1.Height;
        //        }
        //    }
        //}
        /// <summary>
        /// 组合框的项
        /// </summary>
        public string[] mItems = { };
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
                    getItemMinWidth();
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
                btnItem.Size = new Size(flowLayoutPanel1.Size.Width - 5, mTextBox1.Height + 5);
                btnItem.TextAlign = itemAlign;
                btnItem.UseVisualStyleBackColor = true;
                btnItem.Click += new EventHandler(this.selectItem_Click);

                flowLayoutPanel1.Controls.Add(btnItem);
            }
        }

        float itemMinWidth = 0;
        /// <summary>
        /// 获取下拉显示框的最小宽度
        /// </summary>
        private void getItemMinWidth()
        {
            itemMinWidth = this.Width;
            Graphics g = this.CreateGraphics();  //一个gdi对象
            foreach (string item in mItems)
            {
                SizeF sf = g.MeasureString(item, this.Font);
                if (sf.Width > itemMinWidth)
                {
                    itemMinWidth = sf.Width;
                }
            }


        }

        private void MComboBox_SizeChanged(object sender, EventArgs e)
        {

        }

        private void mTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            oldSize = mTextBox1.Size;

            mTextBox1.Dock = DockStyle.None;
            titlePanel1.Dock = DockStyle.None;
            mTextBox1.Location = new Point(0);
            titlePanel1.Location = new Point(mTextBox1.Location.X, mTextBox1.Location.Y + mTextBox1.Height);
            titlePanel1.Size = new Size((int)itemMinWidth, mTextBox1.Height * (mItems.Count() + 2));
            this.Size = new Size(titlePanel1.Size.Width, mTextBox1.Height + titlePanel1.Size.Height);

            drawItemsPanel();
        }
        Size oldSize;

        private void selectItem_Click(object sender, EventArgs e)
        {
            mTextBox1.MText =  ((Button)sender).Text;

            mTextBox1.Size = oldSize;


            this.Size = mTextBox1.Size;
            
        }

     

        private void MComboBox_Leave(object sender, EventArgs e)
        {
            this.Size = mTextBox1.Size;
            
        }

       

    }
}
 