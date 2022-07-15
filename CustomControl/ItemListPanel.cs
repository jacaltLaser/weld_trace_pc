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
    public partial class ItemListPanel : Form
    {
        public ItemListPanel(Control control)
        {
            InitializeComponent();
            controlCombox = control;
            initItemsPanelControl(controlCombox as MTextBox);
        }

        Control controlCombox;
        private void ItemListPanel_Load(object sender, EventArgs e)
        {

            //     this.Size = new Size(getItemMinWidth(controlCombox.Width), this.itemHeight * Items.Count());

        }



        public Color borderColor = Color.Silver;

        TitlePanel comboxItemsPanel = new TitlePanel();
        FlowLayoutPanel itemsLayoutPanel = new FlowLayoutPanel();
        private void initItemsPanelControl(MTextBox control)
        {

            this.Font = control.Font;
            this.borderColor = control.BorderColor;

            this.itemHeight = control.Height;
            //   this.Size = new Size(control.Width , 0);


            this.itemsLayoutPanel.Name = "itemsLayoutPanel";
            this.itemsLayoutPanel.Dock = DockStyle.Top;
            this.itemsLayoutPanel.FlowDirection = FlowDirection.TopDown;


            this.comboxItemsPanel.Name = "comboxItemsPanel";
            this.comboxItemsPanel.BorderRadius = 2;
            this.comboxItemsPanel.BorderThickness = 1;
            this.comboxItemsPanel.IsAutoBackColor = true;
            this.comboxItemsPanel.BackColor = Color.Transparent;
            this.comboxItemsPanel.BorderColor = borderColor;
            this.comboxItemsPanel.Size = new Size(0, 0);
            this.comboxItemsPanel.TitleSize = 0;
            this.comboxItemsPanel.Dock = DockStyle.Fill;
            this.comboxItemsPanel.Controls.Add(this.itemsLayoutPanel);

            this.Controls.Add(comboxItemsPanel);
        }

        private bool mousewheel_flag = false;
        public void MouseWheel_VerticalScroll(int delta)
        {
            if (mousewheel_flag)
            {
                itemsLayoutPanel.Dock = DockStyle.None;

                int locat_Y = itemsLayoutPanel.Location.Y;
                if (delta > 0)
                {
                    locat_Y += itemHeight;
                }
                else
                {
                    locat_Y -= itemHeight;
                }

                if (locat_Y > 0)
                {
                    locat_Y = 0;
                }
                if (locat_Y < (comboxItemsPanel.Height - itemsLayoutPanel.Height))
                {
                    locat_Y = (comboxItemsPanel.Height - itemsLayoutPanel.Height);
                }

                itemsLayoutPanel.Location = new System.Drawing.Point(itemsLayoutPanel.Location.X, locat_Y);
            }
        }
        /// <summary>
        /// 绘制下拉显示框
        /// </summary>
        public void drawItemsPanel()
        {
            itemsLayoutPanel.Controls.Clear();

            if (Items.Count() > 10)
            {
                this.Size = new Size(getItemMinWidth(controlCombox.Width), (this.itemHeight + 3) * 10 + 10);
                mousewheel_flag = true;
            }
            else
            {
                this.Size = new Size(getItemMinWidth(controlCombox.Width), (this.itemHeight + 3) * Items.Count() + 10);
                mousewheel_flag = false;
            }

            itemsLayoutPanel.Height = (this.itemHeight + 3) * Items.Count() + 10;

            foreach (string item in mItems)
            {
                Button btnItem = new Button();
                btnItem.FlatAppearance.BorderSize = 0;
                btnItem.FlatStyle = FlatStyle.Flat;
                btnItem.Cursor = Cursors.Hand;
                btnItem.Font = this.Font;
                btnItem.Name = item;
                btnItem.Text = item;
                btnItem.Size = new Size(itemsLayoutPanel.Size.Width - 5, itemHeight);
                btnItem.TextAlign = itemAlign;
                btnItem.UseVisualStyleBackColor = true;
                btnItem.MouseClick += BtnItem_MouseClick;
                btnItem.Margin = new Padding(3, 3, 0, 0);

                itemsLayoutPanel.Controls.Add(btnItem);
            }

        }

        public void BtnItem_MouseClick(object sender, MouseEventArgs e)
        {
            selectItem = ((Button)sender).Text;

            if (SelectItemEvent != null)
                SelectItemEvent(selectItem, null);
        }

        private void selectItem_Click(object sender, EventArgs e)
        {
            selectItem = ((Button)sender).Text;

            if (SelectItemEvent != null)
                SelectItemEvent(selectItem, null);
        }

        public int itemHeight = 20;
        public ContentAlignment itemAlign = ContentAlignment.MiddleLeft;
        public string selectItem = "";

        public event EventHandler SelectItemEvent;
        /// <summary>
        /// 组合框的项
        /// </summary>
        private string[] mItems = { };
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
        /// 获取下拉显示框的最小宽度
        /// </summary>
        private int getItemMinWidth(float width)
        {
            Graphics g = this.CreateGraphics();  //一个gdi对象
            foreach (string item in Items)
            {
                SizeF sf = g.MeasureString(item, this.Font);
                if (sf.Width > width)
                {
                    width = sf.Width + 10;
                }
            }

            return (int)Math.Ceiling(width);
        }



    }
}
