using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CustomControl
{
    public partial class MDataGrid : UserControl
    {
        public MDataGrid()
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
                adjustControlFontSize(this, ScaleX);
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





        #endregion
        
        DataTable showDataTable = null;

        #region 数据表


        public DataTable DataSource
        {
            get
            {
                return showDataTable;
            }
            set
            {
                if (value != null)
                {
                    showDataTable = value;
                    refreshTable(tableToPageDataRow(1));
                    deplayPageButton();
                }
            }
        }

        public void clearColumn()
        {
            tableColumns.ColumnStyles.Clear();
            tableColumns.Controls.Clear();
            tableColumns.ColumnCount = 0;
        }
        public void addColumnCell(string text, ColumnStyle columnStyle)
        {
            Label lblcolum = new Label();
            lblcolum.Name = text;
            lblcolum.Text = text;
            lblcolum.Dock = DockStyle.Fill;
            lblcolum.Font = new Font("微软雅黑", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
            lblcolum.TextAlign = ContentAlignment.MiddleCenter;
        //    lblcolum.BackColor = Color.Aqua;
            tableColumns.ColumnStyles.Add(columnStyle);    
            tableColumns.Controls.Add(lblcolum, tableColumns.ColumnCount, 0);
            tableColumns.ColumnCount++;
        }

        private void refreshTable(DataTable showTable)
        {
            if (showTable != null)
            {
                if (showTable.Rows.Count > 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                 //   flowLayoutPanel1.Width= tableColumns.Width - 3;
                    foreach (DataRow row in showTable.Rows)
                    {   
                        TableLayoutPanel tableRow = new TableLayoutPanel();
                        tableRow.BackColor = Color.White;
                        tableRow.Width = tableColumns.Width-20;
                        tableRow.Height = tableColumns.Height+3;
                        tableRow.Margin = new Padding(1);
                       // tableRow.Dock = DockStyle.Fill;
                        tableRow.ColumnCount = tableColumns.ColumnCount;
                        for (int i = 0; i < tableColumns.ColumnCount; i++)
                        {
                            tableRow.ColumnStyles.Add(new ColumnStyle(tableColumns.ColumnStyles[i].SizeType, tableColumns.ColumnStyles[i].Width));

                            if (i != tableColumns.ColumnCount)
                            {
                                Label lblCell = new Label();
                                lblCell.BackColor = Color.Transparent;
                                lblCell.Dock = DockStyle.Fill;
                                lblCell.AutoSize = false;
                                lblCell.Font = tableColumns.Font;
                                lblCell.Name = row[i].ToString();
                                lblCell.Text = row[i].ToString();
                                lblCell.TextAlign = ContentAlignment.MiddleCenter;
                                lblCell.MouseEnter += TableRow_MouseEnter;
                                lblCell.MouseLeave += Cell_MouseLeave;
                                tableRow.Controls.Add(lblCell, i, 0);
                            }
                            else
                            {
                                TableOperationCell operaCell = new TableOperationCell();
                                operaCell.BackColor = Color.Transparent;
                                operaCell.Dock = DockStyle.Fill;
                                operaCell.SetBindSource(row);
                                operaCell.Font = new Font(operaCell.Font.FontFamily, operaCell.Font.Size / ScaleX, operaCell.Font.Style, operaCell.Font.Unit, operaCell.Font.GdiCharSet, operaCell.Font.GdiVerticalFont);
                                
                                operaCell.MouseEnter += TableRow_MouseEnter;
                                operaCell.MouseLeave += Cell_MouseLeave;
                                tableRow.Controls.Add(operaCell, i, 0);
                            }
                        }

                        tableRow.Name = row[0].ToString();
                        tableRow.MouseEnter += TableRow_MouseEnter;
                        tableRow.MouseLeave += TableRow_MouseLeave;

                        flowLayoutPanel1.Controls.Add(tableRow);
                    }
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    Label lblTips = new Label();
                    lblTips.AutoSize = false;
                    lblTips.Width = tableColumns.Width;
                    lblTips.Height = tableColumns.Height * 2;
                    lblTips.TextAlign = ContentAlignment.MiddleCenter;
                    lblTips.BackColor = Color.Transparent;
                    lblTips.Font = tableColumns.Font;
                    lblTips.Text = "没有内容！";
                    flowLayoutPanel1.Controls.Add(lblTips);
                }
            }
        }

        private void TableRow_MouseEnter(object sender, EventArgs e)
        {
            TableLayoutPanel tableRow = null;
            if (sender is TableLayoutPanel)
                tableRow = sender as TableLayoutPanel;
            else
                tableRow = (TableLayoutPanel)((Control)sender).Parent;

            if (tableRow.RectangleToScreen(tableRow.ClientRectangle).Contains(MousePosition))
            {
                tableRow.BackColor = Color.AntiqueWhite;
                base.OnMouseEnter(e);
            }

        }
        private void TableRow_MouseLeave(object sender, EventArgs e)
        {
            TableLayoutPanel tableRow = tableRow = sender as TableLayoutPanel;

            if (!tableRow.RectangleToScreen(tableRow.ClientRectangle).Contains(Control.MousePosition))
            {
                tableRow.BackColor = Color.White; //tableRow.Parent.BackColor;
                base.OnMouseLeave(e);
            }
        }

        /// <summary>
        /// 子控件鼠标离开时也要做相应的判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cell_MouseLeave(Object sender, EventArgs e)
        {
            TableLayoutPanel tableRow = (TableLayoutPanel)((Control)sender).Parent;
            //判断鼠标是否还在本控件的矩形区域内
            if (!tableRow.RectangleToScreen(tableRow.ClientRectangle).Contains(Control.MousePosition))
            {
                tableRow.BackColor = Color.White; //tableRow.Parent.BackColor;
                base.OnMouseLeave(e);
            }
        }

        #endregion



        #region 表的页码

   

        /// <summary>
        /// 获取页码下的数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private DataTable tableToPageDataRow(int num)
        {
            
            DataTable pagedt = null;

            if (showDataTable != null)
            {
                if (IsPaging)
                {
                    pagedt = showDataTable.Clone();

                    if (pageCount < num)
                    {
                        num = pageCount;
                    }

                    var query = showDataTable.AsEnumerable().Skip((num - 1) * _maxRowNum).Take(_maxRowNum);
                    foreach (DataRow item in query)
                    {
                        pagedt.Rows.Add(item.ItemArray);
                    }

                    pageNum.MText = num.ToString();
                }
                else
                {
                    pagedt = showDataTable.Copy();
                }

            }

            return pagedt;

        }

        private void deplayPageButton()
        {
            if (showDataTable != null)
            {
                 pageCount = (int)Math.Ceiling(showDataTable.Rows.Count / 10f);

                if (pageCount <= 1)
                {
                    btnPageFirst.Enabled = false;
                    btnPagePrev.Enabled = false;
                    btnPage1.Visible = true;
                    btnPageNext.Enabled = false;
                    pageNum.Enabled = false;
                    btnPageJump.Enabled = false;

                    btnPage2.Visible = false;
                    btnPage3.Visible = false;
                    btnPage4.Visible = false;
                    btnPage5.Visible = false;
                    btnPage6.Visible = false;
                    btnPage7.Visible = false;

                }

                if (pageCount == 2)
                {
                    btnPageFirst.Enabled = true;
                    btnPagePrev.Enabled = true;
                    btnPage1.Visible = true;
                    btnPage2.Visible = true;
                    btnPageNext.Enabled = true;
                    pageNum.Enabled = true;
                    btnPageJump.Enabled = true;

                    btnPage3.Visible = false;
                    btnPage4.Visible = false;
                    btnPage5.Visible = false;
                    btnPage6.Visible = false;
                    btnPage7.Visible = false;
                }

                if (pageCount == 3)
                {
                    btnPageFirst.Enabled = true;
                    btnPagePrev.Enabled = true;
                    btnPage1.Visible = true;
                    btnPage2.Visible = true;
                    btnPage3.Visible = true;
                    btnPageNext.Enabled = true;
                    pageNum.Enabled = true;
                    btnPageJump.Enabled = true;

                    btnPage4.Visible = false;
                    btnPage5.Visible = false;
                    btnPage6.Visible = false;
                    btnPage7.Visible = false;
                }

                if (pageCount == 4)
                {
                    btnPageFirst.Enabled = true;
                    btnPagePrev.Enabled = true;
                    btnPage1.Visible = true;
                    btnPage2.Visible = true;
                    btnPage3.Visible = true;
                    btnPage4.Visible = true;
                    btnPageNext.Enabled = true;
                    pageNum.Enabled = true;
                    btnPageJump.Enabled = true;

                    btnPage5.Visible = false;
                    btnPage6.Visible = false;
                    btnPage7.Visible = false;
                }

                if (pageCount == 5)
                {
                    btnPageFirst.Enabled = true;
                    btnPagePrev.Enabled = true;
                    btnPage1.Visible = true;
                    btnPage2.Visible = true;
                    btnPage3.Visible = true;
                    btnPage4.Visible = true;
                    btnPage5.Visible = true;
                    btnPageNext.Enabled = true;
                    pageNum.Enabled = true;
                    btnPageJump.Enabled = true;

                    btnPage6.Visible = false;
                    btnPage7.Visible = false;
                }

                if (pageCount == 6)
                {
                    btnPageFirst.Enabled = true;
                    btnPagePrev.Enabled = true;
                    btnPage1.Visible = true;
                    btnPage2.Visible = true;
                    btnPage3.Visible = true;
                    btnPage4.Visible = true;
                    btnPage5.Visible = true;
                    btnPage6.Visible = true;
                    btnPageNext.Enabled = true;
                    pageNum.Enabled = true;
                    btnPageJump.Enabled = true;

                    btnPage7.Visible = false;
                }

                if (pageCount >= 7)
                {
                    btnPageFirst.Enabled = true;
                    btnPagePrev.Enabled = true;
                    btnPage1.Visible = true;
                    btnPage2.Visible = true;
                    btnPage3.Visible = true;
                    btnPage4.Visible = true;
                    btnPage5.Visible = true;
                    btnPage6.Visible = true;
                    btnPage7.Visible = true;
                    btnPageNext.Enabled = true;
                    pageNum.Enabled = true;
                    btnPageJump.Enabled = true;

                }

                int pageIndex = Convert.ToInt32(pageNum.MText);

                if (pageCount >= 8)
                {
                    btnPage7.Text = pageCount.ToString();
                    if (pageIndex >= 4)
                    {
                        btnPage2.Text = "...";
                        btnPage2.Enabled = false;
                    }
                    else
                    {
                        btnPage2.Enabled = true;
                        btnPage2.Text = "2";
                        btnPage3.Text = "3";
                        btnPage4.Text = "4";
                        btnPage5.Text = "5";
                    }
                    if (pageCount - pageIndex >= 4)
                    {
                        btnPage6.Text = "...";
                        btnPage6.Enabled = false;
                    }
                    else
                    {
                        btnPage6.Enabled = true;
                        btnPage3.Text = (pageCount - 4).ToString();
                        btnPage4.Text = (pageCount - 3).ToString();
                        btnPage5.Text = (pageCount - 2).ToString();
                        btnPage6.Text = (pageCount - 1).ToString();

                    }

                    if (btnPage2.Text == "..." && btnPage6.Text == "...")
                    {
                        btnPage3.Text = (pageIndex - 1).ToString();
                        btnPage4.Text = pageIndex.ToString();
                        btnPage5.Text = (pageIndex + 1).ToString();
                    }

                }
                else
                {
                    btnPage2.Enabled = true;
                    btnPage6.Enabled = true;
                    btnPage2.Text = "2";
                    btnPage3.Text = "3";
                    btnPage4.Text = "4";
                    btnPage5.Text = "5";
                    btnPage6.Text = "6";
                    btnPage7.Text = "7";
                }

                if (pageIndex <= 1)
                {
                    btnPageFirst.Enabled = false;
                    btnPagePrev.Enabled = false;
                }
                else
                {
                    btnPageFirst.Enabled = true;
                    btnPagePrev.Enabled = true;
                }

                if (pageIndex == pageCount)
                {
                    btnPageNext.Enabled = false;
                }
                else
                {
                    btnPageNext.Enabled = true;
                }


                btnPagebackColorChange(pageIndex);
            }
        }

        private void btnPageJump_Click(object sender, EventArgs e)
        {
            TranslucentButton button = sender as TranslucentButton;
            switch (button.Text)
            {
                case "首页":
                    refreshTable(tableToPageDataRow(1));
                    deplayPageButton();
                    break;

                case "上一页":
                    refreshTable(tableToPageDataRow(Convert.ToInt32(pageNum.MText) - 1));
                    deplayPageButton();
                    break;

                case "下一页":
                    refreshTable(tableToPageDataRow(Convert.ToInt32(pageNum.MText) + 1));
                    deplayPageButton();
                    break;
                case "跳转":
                    refreshTable(tableToPageDataRow(Convert.ToInt32(pageNum.MText)));
                    deplayPageButton();
                    break;
                case "...":
                    break;

                default:
                    refreshTable(tableToPageDataRow(Convert.ToInt32(button.Text)));
                    deplayPageButton();
                    break;

            }
        }

        private void btnPagebackColorChange(int num)
        {
            if (btnPage1.Text == num.ToString())
            {
                btnPage1.BackColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage1.FontColor = Color.Black;
                btnPage1.IsTranslucent = false;
            }
            else
            {
                btnPage1.BackColor = Color.Transparent;
                btnPage1.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage1.IsTranslucent = true;
            }

            if (btnPage2.Text == num.ToString())
            {
                btnPage2.BackColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage2.FontColor = Color.Black;
                btnPage2.IsTranslucent = false;
            }
            else
            {
                btnPage2.BackColor = Color.Transparent;
                btnPage2.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage2.IsTranslucent = true;
            }

            if (btnPage3.Text == num.ToString())
            {
                btnPage3.BackColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage3.FontColor = Color.Black;
                btnPage3.IsTranslucent = false;
            }
            else
            {
                btnPage3.BackColor = Color.Transparent;
                btnPage3.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage3.IsTranslucent = true;
            }

            if (btnPage4.Text == num.ToString())
            {
                btnPage4.BackColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage4.FontColor = Color.Black;
                btnPage4.IsTranslucent = false;
            }
            else
            {
                btnPage4.BackColor = Color.Transparent;
                btnPage4.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage4.IsTranslucent = true;
            }

            if (btnPage5.Text == num.ToString())
            {
                btnPage5.BackColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage5.FontColor = Color.Black;
                btnPage5.IsTranslucent = false;
            }
            else
            {
                btnPage5.BackColor = Color.Transparent;
                btnPage5.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage5.IsTranslucent = true;
            }

            if (btnPage6.Text == num.ToString())
            {
                btnPage6.BackColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage6.FontColor = Color.Black;
                btnPage6.IsTranslucent = false;
            }
            else
            {
                btnPage6.BackColor = Color.Transparent;
                btnPage6.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage6.IsTranslucent = true;
            }

            if (btnPage7.Text == num.ToString())
            {
                btnPage7.BackColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage7.FontColor = Color.Black;
                btnPage7.IsTranslucent = false;
            }
            else
            {
                btnPage7.BackColor = Color.Transparent;
                btnPage7.FontColor = Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(178)))), ((int)(((byte)(255)))));
                btnPage7.IsTranslucent = true;
            }
        }
        #endregion

        //protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        //{
        //    width = splitContainer1.Width;
        //    base.SetBoundsCore(x, y, width, height, specified);
        //}

        int pageCount = 1;

        int _maxRowNum = 10;
        /// <summary>
        /// 每页最大行数
        /// </summary>
        [Browsable(true), Category("外观"), Description("每页最大行数")]
        public int MaxRowNum
        {
            get
            {
                return _maxRowNum;
            }
            set
            {
                _maxRowNum = value;
            }
        }

        private bool _autoRowNum = false;
        /// <summary>
        /// 自适应每页显示的行数
        /// </summary>
        [Browsable(true), Category("外观"), Description("自适应每页显示的行数")]
        public bool AutoRowNum
        {
            get
            {
                return _autoRowNum;
            }
            set
            {
                _autoRowNum = value;
            }
        }


        
        /// <summary>
        /// 是否分页显示
        /// </summary>
          [Browsable(true), Category("外观"), Description("是否分页显示")]
        public bool IsPaging
        {
            get
            {
                return pagesPanel.Visible;
            }
            set
            {
                pagesPanel.Visible = value;
            }
        }

        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            if (IsPaging)
            {
                if (AutoRowNum)
                {
                    _maxRowNum =( splitContainer1.Panel2.Height) / (tableColumns.Height + 5);
                    if (showDataTable != null)
                        pageCount = (int)Math.Ceiling(showDataTable.Rows.Count / (float)_maxRowNum);
                   
                }
            }
            //      tableColumns.Width = splitContainer1.Width;
            refreshTable(tableToPageDataRow(Convert.ToInt32(pageNum.MText)));
            deplayPageButton();
        }

    

        public void print()
        {
            PrintPanel.Print(flowLayoutPanel1);
        }

    }

}
