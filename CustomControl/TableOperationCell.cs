using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class TableOperationCell : UserControl
    {
        public event DataGridViewRowCustomEventHandler RowCustomEvent;
        private DataRow m_object = null;
        public object DataSource
        {
            get
            {
                return m_object;
            }
        }
        Font m_font =new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        public override Font Font
        {
            get
            {
                return m_font;
            }
            set
            {
                m_font = value;
                btnEdit.Font = value;
                btnDelete.Font = value;
            }
        }
        public TableOperationCell()
        {
            InitializeComponent();
        }

        public void SetBindSource(object obj)
        {
            if (obj is DataRow)
                m_object = (DataRow)obj;
        }

        /// <summary>
        /// 激活操作
        /// </summary>
        public bool performAction = false;
        private void ucBtnEdit_BtnClick(object sender, EventArgs e)
        {
            if (RowCustomEvent != null)
            {
                performAction = true;
                RowCustomEvent(this, new DataGridViewRowCustomEventArgs() { EventName = btnEdit.Text, Data = m_object });
            }

        }

        
        private void ucBtnDelete_BtnClick(object sender, EventArgs e)
        {
            if (RowCustomEvent != null)
            { 
                performAction = true;
                RowCustomEvent(this, new DataGridViewRowCustomEventArgs() { EventName = btnDelete.Text, Data = m_object });
            }

        }

        /// <summary>
        /// Class DataGridViewRowCustomEventArgs.
        /// Implements the <see cref="System.EventArgs" />
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class DataGridViewRowCustomEventArgs : EventArgs
        {
            /// <summary>
            /// Gets or sets the name of the event.
            /// </summary>
            /// <value>The name of the event.</value>
            public string EventName { get; set; }

            public DataRow Data { get; set; }

        }
        ///// <summary>
        ///// Delegate DataGridViewEventHandler
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="DataGridViewEventArgs" /> instance containing the event data.</param>
        //[Serializable]
        //[ComVisible(true)]
        //public delegate void DataGridViewEventHandler(object sender, DataGridViewEventArgs e);

        /// <summary>
        /// 委托 DataGridViewRowCustomEventHandler
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewRowCustomEventArgs" /> instance containing the event data.</param>
        [Serializable]
        [ComVisible(true)]
        public delegate void DataGridViewRowCustomEventHandler(object sender, DataGridViewRowCustomEventArgs e);

    }
}
