using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public class RoundedControlBase : UserControl
    {
        private int _cornerRadius = 12;
        private int _borderThickness = 1;
        private Color _borderColor = Color.Gray;
        private Color _fillColor = Color.White;

        [Category("Apariencia")]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); UpdateRegion(); }
        }

        [Category("Apariencia")]
        public int BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value; Invalidate(); }
        }

        [Category("Apariencia")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Apariencia")]
        public Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; Invalidate(); }
        }

        public RoundedControlBase()
        {
            this.DoubleBuffered = true;
            this.Resize += delegate { UpdateRegion(); };
            this.BackColor = Color.Transparent;
            UpdateRegion();
        }

        private GraphicsPath BuildRoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0) return;
            using (GraphicsPath path = BuildRoundedRect(ClientRectangle, _cornerRadius))
            {
                this.Region = new Region(path);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;
            rect.Inflate(-_borderThickness, -_borderThickness);

            using (GraphicsPath path = BuildRoundedRect(rect, Math.Max(0, _cornerRadius - _borderThickness)))
            {
                using (SolidBrush fill = new SolidBrush(_fillColor))
                {
                    e.Graphics.FillPath(fill, path);
                }
                if (_borderThickness > 0)
                {
                    using (Pen pen = new Pen(_borderColor, _borderThickness))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}
