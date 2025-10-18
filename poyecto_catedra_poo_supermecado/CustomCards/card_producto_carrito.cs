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
        public decimal TotalProducto // Propiedad para el total del producto
        {
            get => totalProducto;
            set
            {
                totalProducto = value;
                lblPrecioTotal.Text = totalProducto.ToString("C2");
            }
        }

        private decimal ahorroProducto;
        public decimal AhorroProducto // Propiedad para el ahorro del producto
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

        [Category("Producto"), Description("Stock disponible del producto")] // Propiedad para el stock disponible del producto
        public int StockDisponible { get; set; }
        [Category("Acciones"), Description("Evento cuando se actualiza la cantidad")] // Evento cuando se actualiza la cantidad
        public event EventHandler<int> CantidadActualizada;
        [Category("Producto"), Description("ID del producto")] // Propiedad para el ID del producto
        public int IDProducto { get; set; }
        public card_producto_carrito()
        {
            InitializeComponent();
            // estado inicial seguro si el diseñador aún no creó los controles
            if (lblPrecioDescuento != null) lblPrecioDescuento.Visible = false;
        }

        [Category("Producto"), Description("Nombre del producto")] // Propiedad para el nombre del producto
        public string NombreProducto // Propiedad para el nombre del producto 
        {
            get => lblNombreProducto?.Text ?? string.Empty;
            set { if (lblNombreProducto != null) lblNombreProducto.Text = value; }
        }

        [Category("Precio"), Description("Precio base del producto")] // Propiedad para el precio base del producto
        public decimal Precio // Propiedad para el precio base del producto 
        {
            get => precioBase;
            set { precioBase = value; ActualizarPrecios(); }
        }

        [Category("Precio"), Description("Descuento en porcentaje (0-100)")] // Propiedad para el descuento en porcentaje
        public int Descuento // Propiedad para el descuento en porcentaje
        {
            get => descuento;
            set
            {
                descuento = Math.Min(Math.Max(value, 0), 100);
                ActualizarPrecios();
            }
        }


        [Category("Cantidad"), Description("Cantidad del producto")] // Propiedad para la cantidad del producto
        public int Cantidad // Propiedad para la cantidad del producto
        {
            get => cantidad;
            set
            {
                cantidad = Math.Max(value, 0);
                ActualizarPrecios();
            }
        }

        [Category("Producto"), Description("Imagen del producto")] // Propiedad para la imagen del producto
        public Image ImagenProducto // Propiedad para la imagen del producto
        {
            get => pbProducto?.Image;
            set { if (pbProducto != null) pbProducto.Image = value; }
        }

        [Category("Acciones"), Description("Evento al hacer clic en Eliminar")] // Evento al hacer clic en Eliminar
        public event EventHandler EliminarClick // Evento al hacer clic en Eliminar
        {
            add { btnEliminar.Click += value; }
            remove { btnEliminar.Click -= value; }
        }

        [Category("Acciones"), Description("Evento al hacer clic en Actualizar")] // Evento al hacer clic en Actualizar
        public event EventHandler ActualizarClick // Evento al hacer clic en Actualizar
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

        private void card_producto_carrito_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new CustomModals.md_actualizar_carrito(this.Cantidad, this.StockDisponible)) // Crear instancia del modal de actualización
                {
                    if (modal.ShowDialog() == DialogResult.OK) // Si se actualizó la cantidad
                    {
                        int nuevaCantidad = modal.NuevaCantidad; // Obtener la nueva cantidad del modal
                        this.Cantidad = nuevaCantidad;
                        //MessageBox.Show(nuevaCantidad.ToString());
                        CantidadActualizada?.Invoke(this, nuevaCantidad);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la cantidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}