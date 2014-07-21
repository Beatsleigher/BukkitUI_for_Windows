using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace BukkitUI {
    class TextProgressBar : ProgressBar {

        [DllImportAttribute("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);


        public enum ProgressBarDisplayText {
            Percentage,
            CustomText
        }

        public ProgressBarDisplayText displayStyle { get; set; }

        public String customText { get; set; }

        public TextProgressBar() {
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnHandleCreated(EventArgs e) {
            SetWindowTheme(this.Handle, "", "");
            base.OnHandleCreated(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent) { }

        protected override void OnPaint(PaintEventArgs e) {
            const int inSet = 1;

            using (Image offScreenImage = new Bitmap(Width, Height)) {
                using (Graphics offScreen = Graphics.FromImage(offScreenImage)) {
                    Rectangle rectangle = new Rectangle(0, 0, Width, Height);

                    if (ProgressBarRenderer.IsSupported)
                        ProgressBarRenderer.DrawHorizontalBar(offScreen, rectangle);

                    rectangle.Inflate(new Size(-inSet, -inSet));
                    rectangle.Width = (int)(rectangle.Width * ((double)Value / Maximum));
                    if (rectangle.Width == 0)
                        rectangle.Width = 1;

                    LinearGradientBrush brush = new LinearGradientBrush(rectangle, BackColor, ForeColor, LinearGradientMode.Vertical);
                    offScreen.FillRectangle(brush, inSet, inSet, rectangle.Width, rectangle.Height);

                    e.Graphics.DrawImage(offScreenImage, 0, 0);
                    offScreenImage.Dispose();

                    String text = displayStyle == ProgressBarDisplayText.Percentage ? Value.ToString() + "%" : customText;

                    using (Font font = new Font(FontFamily.GenericSerif, 10)) {
                        SizeF len = e.Graphics.MeasureString(text, font);
                        Point location = new Point(Convert.ToInt32((Width / 2) - len.Width / 2), Convert.ToInt32((Height / 2) - len.Height / 2));
                        e.Graphics.DrawString(text, font, Brushes.Blue, location);
                    }

                }
            }

        } // Convert.ToInt32((rectangle.Width / 2) - (len.Width / 2)), Convert.ToInt32((rectangle.Height / 2) - (len.Height / 2))

    }
}
