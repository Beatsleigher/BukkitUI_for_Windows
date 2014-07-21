using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace BukkitUI {

    public class AntiLabel : Label {

        private TextRenderingHint _textRenderingHint = TextRenderingHint.SystemDefault;

        public TextRenderingHint TextRenderingHint {
            get { return _textRenderingHint; }
            set { _textRenderingHint = value; }
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TextRenderingHint = _textRenderingHint;
            base.OnPaint(e);
        }  

    }
}
