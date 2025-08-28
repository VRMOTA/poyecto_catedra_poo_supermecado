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

        public card_producto_menu()
        {
            InitializeComponent();
            // estado inicial seguro si el diseñador aún no creó los controles
            if (lblPrecioDescuento != null) lblPrecioDescuento.Visible = false;
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
            // seguridad si el diseñador no ha inicializado los controles aún
            if (lblPrecio == null || lblPrecioDescuento == null) return;

            // muestra precio con formato de moneda según cultura
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
    }
}
