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
    public partial class MTabcontrol : TabControl
    {
        public MTabcontrol()
        {
            InitializeComponent();
           

        }
        

        private bool tabsVisible=false;

      
        [Category("MTabcontrol"), Description("是否隐藏Tab标题栏"), DefaultValue(false)]
        public bool TabsVisible
        {
            get { return tabsVisible; }
            set
            {
                if (tabsVisible == value) return;
                tabsVisible = value;
                RecreateHandle();
            }
        }

        protected override void WndProc(ref Message m)
        {
            // 通过捕获TCM_ADJUSTRECT消息来实现Tab标题栏隐藏
            if (m.Msg == 0x1328)
            {
                if (!tabsVisible && !DesignMode)
                {
                    m.Result = (IntPtr)1;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Tab) || keyData == (Keys.Control | Keys.Shift | Keys.Tab) || keyData == (Keys.Left) || keyData == (Keys.Right))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
