using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_producto_carrito : RoundedControlBase // Cambié el nombre para diferenciarlo
    {
        private decimal precioBase;
        private int descuento;
        private int cantidad;

        private decimal totalProducto;
        public decimal TotalProducto
        {
            get => totalProducto;
            set
            {
                totalProducto = value;
                lblPrecioTotal.Text = totalProducto.ToString("C2");
            }
        }

        private decimal ahorroProducto;
        public decimal AhorroProducto
        {
            get => ahorroProducto;
            set
            {
                ahorroProducto = value;
                if (ahorroProducto > 0)
                {
                    lblPrecioDescuento.Visible = true;
                    lblPrecioDescuento.Text = $"{ahorroProducto.ToString("C2")}";
                }
                else
                {
                    lblPrecioDescuento.Visible = false;
                }
            }
        }

        [Category("Producto"), Description("Stock disponible del producto")]
        public int StockDisponible { get; set; }
        [Category("Acciones"), Description("Evento cuando se actualiza la cantidad")]
        public event EventHandler<int> CantidadActualizada;
        [Category("Producto"), Description("ID del producto")]
        public int IDProducto { get; set; }
        public card_producto_carrito()
        {
            InitializeComponent();
            // estado inicial seguro si el diseñador aún no creó los controles
            if (lblPrecioDescuento != null) lblPrecioDescuento.Visible = false;
        }

        [Category("Producto"), Description("Nombre del producto")]
        public string NombreProducto
        {
            get => lblNombreProducto?.Text ?? string.Empty;
            set { if (lblNombreProducto != null) lblNombreProducto.Text = value; }
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


        [Category("Cantidad"), Description("Cantidad del producto")]
        public int Cantidad
        {
            get => cantidad;
            set
            {
                cantidad = Math.Max(value, 0);
                ActualizarPrecios();
            }
        }

        [Category("Producto"), Description("Imagen del producto")]
        public Image ImagenProducto
        {
            get => pbProducto?.Image;
            set { if (pbProducto != null) pbProducto.Image = value; }
        }

        [Category("Acciones"), Description("Evento al hacer clic en Eliminar")]
        public event EventHandler EliminarClick
        {
            add { btnEliminar.Click += value; }
            remove { btnEliminar.Click -= value; }
        }

        [Category("Acciones"), Description("Evento al hacer clic en Actualizar")]
        public event EventHandler ActualizarClick
        {
            add { btnActualizar.Click += value; }
            remove { btnActualizar.Click -= value; }
        }

        private void ActualizarPrecios()
        {
            // seguridad si el diseñador no ha inicializado los controles aún
            if (lblPrecio == null || lblPrecioDescuento == null || lblCantidad == null || lblPrecioTotal == null) return;

            // muestra precio con formato de moneda según cultura
            lblPrecio.Text = precioBase.ToString("C2");
            lblCantidad.Text = cantidad.ToString();

            lblPrecioTotal.Text = totalProducto.ToString("C2");
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

        private void card_producto_carrito_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using (var modal = new CustomModals.md_actualizar_carrito(this.Cantidad, this.StockDisponible))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    int nuevaCantidad = modal.NuevaCantidad;
                    this.Cantidad = nuevaCantidad;
                    //MessageBox.Show(nuevaCantidad.ToString());
                    CantidadActualizada?.Invoke(this, nuevaCantidad);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}