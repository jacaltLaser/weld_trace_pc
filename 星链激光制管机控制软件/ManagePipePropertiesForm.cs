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
    public partial class ManagePipePropertiesForm : SkinMain
    {
        public ManagePipePropertiesForm()
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
                label7.Left = queryText.Left - label7.Width - 2;
                label7.Top = queryText.Top + (queryText.Height - label7.Height) / 2;
                
                btnQuery.Top = queryText.Top + (queryText.Height - btnQuery.Height) / 2;
                btnRecovery.Top = queryText.Top + (queryText.Height - btnRecovery.Height) / 2;
                btnAdd.Top = queryText.Top + (queryText.Height - btnAdd.Height) / 2;
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
            if(editPipeForm!=null)
            {
                editPipeForm.Close();
            }
            this.Close();
        }

        #endregion
        EditPipePropertiesForm editPipeForm = null;
        DataBase dataBase = new DataBase();
        DataTable originalTable = null;
        DataTable showPipeTable = null;
        private void ManagePipePropertiesForm_Load(object sender, EventArgs e)
        {
            showPipeTable = originalTable = dataBase.GetdataTable("管材特性");
            
            refreshTable(tableToPageDataRow(1));
            deplayPageButton();
        }

        #region 材料特性的数据表
        private void refreshTable(DataTable showTable)
        {
            if (showTable != null)
            {
                if (showTable.Rows.Count > 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                    foreach (DataRow row in showTable.Rows)
                    {
                        TableLayoutPanel tableRow = new TableLayoutPanel();
                        tableRow.BackColor = Color.White;
                        tableRow.Width = tableColumns.Width;
                        tableRow.Height = tableColumns.Height + 7;
                        tableRow.ColumnCount = tableColumns.ColumnCount;
                        for (int i = 0; i < tableColumns.ColumnCount; i++)
                        {
                            tableRow.ColumnStyles.Add(new ColumnStyle(tableColumns.ColumnStyles[i].SizeType, tableColumns.ColumnStyles[i].Width));

                            if (i != tableColumns.ColumnCount - 1)
                            {
                                Label lblCell = new Label();
                                lblCell.BackColor = Color.Transparent;
                                lblCell.Dock = DockStyle.Fill;
                                lblCell.AutoSize = false;
                                lblCell.Font = tableColumns.Font;
                                lblCell.Name = row[i + 1].ToString();
                                lblCell.Text = row[i + 1].ToString();
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
                            
                                operaCell.RowCustomEvent += OperaCell_RowCustomEvent;
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
                    lblTips.Height = tableColumns.Height*2;
                    lblTips.TextAlign = ContentAlignment.MiddleCenter;
                    lblTips.BackColor = Color.Transparent;
                    lblTips.Font = tableColumns.Font;
                    lblTips.Text = "没有找到材料特性！";
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

        #region 新增 材料特性
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.add_hover;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.add_normal;
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            editPipeForm = new EditPipePropertiesForm();
            editPipeForm.PipePropertiesChangeEvent += EditPipeForm_PipePropertiesChangeEvent;
            editPipeForm.TopMost = true;
            editPipeForm.showContentEditForm( showPipeTable.NewRow(),"新增");
            editPipeForm.Show();
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
            DataTable pagedt = showPipeTable.Clone();

            if (showPipeTable != null)
            {
                int pageCount = (int)Math.Ceiling(showPipeTable.Rows.Count / 10f);
                if (pageCount < num)
                {
                    num = pageCount;
                }

                var query = showPipeTable.AsEnumerable().Skip((num - 1) * 10).Take(10);
                foreach (DataRow item in query)
                {
                    pagedt.Rows.Add(item.ItemArray);
                }

                pageNum.MText = num.ToString();

            }

            return pagedt;

        }

        private void deplayPageButton()
        {
            if (showPipeTable != null)
            {
                int pageCount = (int)Math.Ceiling(showPipeTable.Rows.Count / 10f);

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
            switch(button.Text)
            {
                case "首页":
                    refreshTable(tableToPageDataRow(1));
                    deplayPageButton();
                    break;

                case "上一页": 
                    refreshTable(tableToPageDataRow(Convert.ToInt32(pageNum.MText)-1));
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
        
        private void btnPagebackColorChange( int num)
        {
            if(btnPage1.Text== num.ToString())
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

        #region 特性的查询和重置
        private void btnQuery_Click(object sender, EventArgs e)
        {
            showPipeTable = originalTable.Clone();
            DataRow[] queryRows = originalTable.Select("管材名称 like '%" + queryText.MText + "%'");
            if (queryRows.Count() > 0)
            {
                foreach (DataRow row in queryRows)
                    showPipeTable.ImportRow(row);
            }

            refreshTable(tableToPageDataRow(1));
            deplayPageButton();

        }
        private void btnRecovery_Click(object sender, EventArgs e)
        {
            showPipeTable = originalTable;
            refreshTable(tableToPageDataRow(1));
            deplayPageButton();
        }

        #endregion

        /// <summary>
        /// 新增或修改材料特性的处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPipeForm_PipePropertiesChangeEvent(object sender, EditPipePropertiesForm.DataRowEventArgs e)
        {
            if (e.EventName == "新增")
            {
                DataRow addRow =  e.Data;
                addRow[0]= originalTable.Rows.Count+1;
                originalTable.Rows.Add(addRow);

            }
            else
            {
                DataRow changeRow = originalTable.Rows.Find(e.Data[0]);
                changeRow.BeginEdit();
                changeRow[1] = e.Data[1];
                changeRow[2] = e.Data[2];
                changeRow[3] = e.Data[3];
                changeRow[4] = e.Data[4];
                changeRow[5] = e.Data[5];
                changeRow.EndEdit();
            }

            updatePipePropertiesTable();
        }

        /// <summary>
        /// 接收到修改或删除的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperaCell_RowCustomEvent(object sender, TableOperationCell.DataGridViewRowCustomEventArgs e)
        {
            if(e.EventName=="修改")
            {
                editPipeForm = new EditPipePropertiesForm();
                editPipeForm.PipePropertiesChangeEvent += EditPipeForm_PipePropertiesChangeEvent;
                editPipeForm.TopMost = true;
                editPipeForm.showContentEditForm ( e.Data,e.EventName);
                editPipeForm.Show();
            }
            else
            {
                // DataRow deleteRow = originalTable.Rows.Find(e.Data[0]);
                //// deleteRow.Delete();
                // originalTable.Rows.Remove(deleteRow);
                // originalTable.AcceptChanges();
                // updatePipePropertiesTable();

                dataBase.sqlCmd("delete from 管材特性 where ID=" + e.Data[0].ToString());
                updatePipePropertiesTable();
            }
        }

        /// <summary>
        /// 将更新到数据表
        /// </summary>
        private void updatePipePropertiesTable()
        {
            dataBase.UpdatedataTable("管材特性", originalTable);

            showPipeTable = originalTable = dataBase.GetdataTable("管材特性");
            refreshTable(tableToPageDataRow(1));
            deplayPageButton();
        }
    }
}

