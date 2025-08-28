using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace project_supermercado.CustomControls
{
    [ToolboxBitmap(typeof(Panel))]
    [Description("Panel decorativo con bordes redondeados personalizables")]
    public class PanelRedondeado : Panel
    {
        private int _radioBordes = 20;
        private Color _colorBorde = Color.Gray;
        private int _grosorBorde = 1;
        private bool _rellenoDegradado = false;
        private Color _colorInicio = Color.LightBlue;
        private Color _colorFin = Color.DarkBlue;

        [Category("Apariencia")]
        [Description("Radio de los bordes redondeados")]
        [DefaultValue(20)]
        public int RadioBordes
        {
            get { return _radioBordes; }
            set
            {
                _radioBordes = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Color del borde")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color ColorBorde
        {
            get { return _colorBorde; }
            set
            {
                _colorBorde = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Grosor del borde")]
        [DefaultValue(1)]
        public int GrosorBorde
        {
            get { return _grosorBorde; }
            set
            {
                _grosorBorde = Math.Max(1, value);
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Indica si se usa relleno degradado")]
        [DefaultValue(false)]
        public bool RellenoDegradado
        {
            get { return _rellenoDegradado; }
            set
            {
                _rellenoDegradado = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Color inicial del degradado")]
        [DefaultValue(typeof(Color), "LightBlue")]
        public Color ColorInicio
        {
            get { return _colorInicio; }
            set
            {
                _colorInicio = value;
                Invalidate();
            }
        }

        [Category("Apariencia")]
        [Description("Color final del degradado")]
        [DefaultValue(typeof(Color), "DarkBlue")]
        public Color ColorFin
        {
            get { return _colorFin; }
            set
            {
                _colorFin = value;
                Invalidate();
            }
        }

        public PanelRedondeado()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Crear camino redondeado
            using (GraphicsPath path = CrearCaminoRedondeado(rect, _radioBordes))
            {
                // Rellenar el fondo
                if (_rellenoDegradado)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect, _colorInicio, _colorFin, LinearGradientMode.Vertical))
                    {
                        graphics.FillPath(brush, path);
                    }
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(BackColor))
                    {
                        graphics.FillPath(brush, path);
                    }
                }

                // Dibujar borde
                if (_grosorBorde > 0)
                {
                    using (Pen pen = new Pen(_colorBorde, _grosorBorde))
                    {
                        graphics.DrawPath(pen, path);
                    }
                }

                // Recortar la región para que los controles hijos no se salgan
                Region = new Region(path);
            }
        }

        private GraphicsPath CrearCaminoRedondeado(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(rect.Location, size);

            // Esquina superior izquierda
            path.AddArc(arc, 180, 90);

            // Esquina superior derecha
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Esquina inferior derecha
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Esquina inferior izquierda
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            Invalidate();
        }
    }
}