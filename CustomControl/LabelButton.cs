using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
   public class LabelButton:Label
    {
        public LabelButton()
            : base()
        {
            this.AutoSize = false;
            this.BorderStyle = BorderStyle.None;
        }
        private Color _backlColor;
        [Category("鼠标"), Description("鼠标在按钮上的颜色")]
        public override Color BackColor
        {
            get
            {
                return this._backlColor;
            }
            set
            {
                if (this._backlColor != value)
                {
                    this._backlColor = value;
                    this.BackColor = value;
                }
            }
        }

        private Color _mouseHoverColor ;
        [Category("鼠标"), Description("鼠标在按钮上的颜色")]
        public Color MouseHoverColor
        {
            get
            {
                return this._mouseHoverColor;
            }
            set
            {
                if(this._mouseHoverColor!=value)
                {
                    this._mouseHoverColor = value;
                }
            }
        }
        

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = _backlColor;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = _mouseHoverColor;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.Invalidate();
            base.OnLostFocus(e);
        }
    }
}
