using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControl
{
   public class AutoSizeFormClass
    {
        //1.声明一个结构体，记录窗体和控件的基本属性
        public struct controlRect
        {
            public string Name;
            public int Left;
            public int Top;
            public int Width;
            public int Height;
            public float FontSize;
            public FontFamily FontFamily;
        }
        //2.声明一个集合记录所有控件的属性
        //使用控件的Name作为key
        Dictionary<string, controlRect> dic = new Dictionary<string, controlRect>();
        int ctrNo = 0;
        //这里是你开发环境下的分辨率
        private int ScW = 1920;
        private int ScH = 1080;
        //记录窗体是不是第一次加载的标记 0：第一次加载  1：重复加载
        private int IsFirstLoad = 0;
        //窗体的名称
        private string FrmName = string.Empty;
        //3.创建两个函数
        //采用递归的方法将控件包含的所有控件属性记录下来（结构体的每一个属性都需要赋值）
        private void AddControl(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                GetCtrParameter(c);
                //使用递归函数先记录控件本身，后记录控件包含的子控件
                if (c.Controls.Count > 0)
                {
                    AddControl(c);
                }
            }
        }
        //获取控件的所有属性
        private void GetCtrParameter(Control mForm)
        {
            controlRect cr;
            cr.Name = mForm.Name;
            cr.Left = mForm.Left;
            cr.Top = mForm.Top;
            cr.Width = mForm.Width;
            cr.Height = mForm.Height;
            cr.FontSize = mForm.Font.Size;
            cr.FontFamily = mForm.Font.FontFamily;
            dic.Add(cr.Name, cr);
        }

        //4.控件自适应大小
        public void controlAutoSize(Control mForm)
        {
            FrmName = mForm.Name;
            float wScale = 0;
            float hScale = 0;
            //因为有些控件和DataGridView的子空间加载时间较长，所以在Form1_SizeChanged中，
            //记录控件的原始大小和位置，第一次加载的时候先根据和开发环境的像素比例绘制窗体                
            if (IsFirstLoad == 0 && ctrNo == 0)
            {
                //获取当前的像素
                int SH = Screen.PrimaryScreen.Bounds.Height;
                int SW = Screen.PrimaryScreen.Bounds.Width;
                //和开发环境的像素相比获取对应的比值
                wScale = (float)SH / (float)ScH;
                hScale = (float)SW / (float)ScW;
                controlRect cR;
                cR.Name = mForm.Name;
                cR.Left = mForm.Left;
                cR.Top = mForm.Top;
                cR.Width = mForm.Width;
                cR.Height = mForm.Height;
                cR.FontSize = mForm.Font.Size;
                cR.FontFamily = mForm.Font.FontFamily;
                dic.Add(cR.Name, cR);//第一个为窗体本身
                AddControl(mForm);//递归获取所有窗体基础信息
                AutoScaleControl(mForm, wScale, hScale);//这里其实是第一次构造窗体
                IsFirstLoad = 1;
            }
            //这里是改变窗体大小时重新设置窗体的属性
            else
            {
                //新旧窗体之间的高和长的比例，与第一次加载的信息比较
                wScale = (float)mForm.Width / dic[FrmName].Width;
                hScale = (float)mForm.Height / dic[FrmName].Height;
                //将ctrNo设为1，代表为控件而非窗体
                ctrNo = 1;
                //设置控件以及其嵌套的控件的比例大小，使用递归调用
                AutoScaleControl(mForm, wScale, hScale);
            }
        }
        //递归进行自适应调整
        private void AutoScaleControl(Control ctl, float wScale, float hScale)
        {
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            float fontSize;
            FontFamily fontFamily;
            foreach (Control c in ctl.Controls)
            {
                bool isAuto = true;
                foreach (Control notctrl in notAutoControl)
                {
                    if (c == notctrl)
                    {
                        isAuto = false;
                        break;
                    }
                }

                if (isAuto)
                {
                    string ctrName = c.Name;
                    ctrLeft0 = dic[ctrName].Left;
                    ctrTop0 = dic[ctrName].Top;
                    ctrWidth0 = dic[ctrName].Width;
                    ctrHeight0 = dic[ctrName].Height;
                    fontSize = dic[ctrName].FontSize;
                    fontFamily = dic[ctrName].FontFamily;
                    //新旧控件之间的线性比例，字体大小依据高度转换
                    c.Left = (int)(ctrLeft0 * wScale);
                    c.Top = (int)(ctrTop0 * hScale);
                    c.Width = (int)(ctrWidth0 * wScale);
                    c.Height = (int)(ctrHeight0 * hScale);
                    c.Font = new Font(fontFamily, fontSize * hScale);
                    ctrNo++;
                    //先缩放控件本身，后缩放控件的子控件
                    if (c.Controls.Count > 0)
                    {
                        AutoScaleControl(c, wScale, hScale);
                    }
                    //dataGridview特殊处理
                    if (c is DataGridView)
                    {
                        DataGridView dgv = c as DataGridView;
                        Cursor.Current = Cursors.WaitCursor;
                        int widths = 0;
                        for (int i = 0; i < dgv.Columns.Count - 1; i++)
                        {
                            //自动调整列宽
                            dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                            widths += dgv.Columns[i].Width;
                        }
                        //如果调整列的宽度大于设定宽度
                        if (widths > ctl.Size.Width)
                        {
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;//调整列的模式

                        }
                        else
                        {
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//如果小于则填充

                        }
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }
        /// <summary>
        /// 不参与自适应变化的控件名
        /// </summary>
        public List<Control> notAutoControl = new List<Control>();
    }
    public static class PublicClass
    {
        /// <summary>
        /// 改变颜色的深浅
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="correctionFactor">加深 :大于-1且小于0； 变亮 :大于0且小于1</param>
        /// <returns></returns>
        public static Color ChangeColor(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

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
    }

    public enum ControlState
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 鼠标进入
        /// </summary>
        Enter = 1,
        /// <summary>
        /// 鼠标按下
        /// </summary>
        Down = 2,
        /// <summary>
        /// 获得焦点
        /// </summary>
        Focus = 3,
        /// <summary>
        /// 控件禁止
        /// </summary>
        Disabled = 4
    }
}
