using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_producto_menu : RoundedControlBase
    {
        private decimal precioBase;
        private int descuento;
        private int idProducto;

        // Evento personalizado que se disparará cuando se presione el botón
        public event EventHandler<int> BotonVisualizarClick;

        public card_producto_menu()
        {
            InitializeComponent();
            if (lblPrecioDescuento != null) lblPrecioDescuento.Visible = false;

            // Suscribir el evento del botón (si existe en el diseñador)
            if (btnVisualizar != null)
            {
                btnVisualizar.Click += BtnVisualizar_Click;
            }
        }

        [Category("Producto"), Description("ID único del producto")]
        public int IDProducto
        {
            get => idProducto;
            set => idProducto = value;
        }

        [Category("Producto"), Description("Nombre del producto")]
        public string Producto
        {
            get => lblProducto?.Text ?? string.Empty;
            set { if (lblProducto != null) lblProducto.Text = value; }
        }

        [Category("Precio"), Description("Precio base del producto")]
        public decimal Precio
        {
            get => precioBase;
            set { precioBase = value; ActualizarPrecios(); }
        }

        [Category("Precio"), Description("Descuento en porcentaje (0-100)")]
        public int Descuento
        {
            get => descuento;
            set
            {
                descuento = Math.Min(Math.Max(value, 0), 100);
                ActualizarPrecios();
            }
        }

        [Category("Producto"), Description("Imagen del producto")]
        public Image ImagenProducto
        {
            get => pbProducto?.Image;
            set { if (pbProducto != null) pbProducto.Image = value; }
        }

        private void ActualizarPrecios()
        {
            if (lblPrecio == null || lblPrecioDescuento == null) return;

            lblPrecio.Text = precioBase.ToString("C2");

            if (descuento > 0)
            {
                decimal precioConDescuento = precioBase * (1 - (descuento / 100m));
                lblPrecioDescuento.Text = precioConDescuento.ToString("C2");
                lblPrecioDescuento.Visible = true;
                SetStrikeout(lblPrecio, true);
            }
            else
            {
                lblPrecioDescuento.Visible = false;
                SetStrikeout(lblPrecio, false);
            }
        }

        private void SetStrikeout(Label lbl, bool strike)
        {
            if (lbl == null) return;
            var family = lbl.Font.FontFamily;
            var size = lbl.Font.Size;
            var style = lbl.Font.Style;
            style = strike ? (style | FontStyle.Strikeout) : (style & ~FontStyle.Strikeout);
            lbl.Font = new Font(family, size, style);
        }

        // Método que se ejecuta cuando se presiona el botón
        private void BtnVisualizar_Click(object sender, EventArgs e)
        {
            // Disparar el evento pasando el ID del producto
            BotonVisualizarClick?.Invoke(this, idProducto);
        }
    }
}