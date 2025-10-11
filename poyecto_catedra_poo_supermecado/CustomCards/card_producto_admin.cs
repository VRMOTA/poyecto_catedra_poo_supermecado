using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_producto_admin : RoundedControlBase
    {
        private decimal _precio;
        private int? _descuento;
        private int id_producto;
        public card_producto_admin()
        {
            InitializeComponent();
            ActualizarPrecioDescuento();
        }
        public int ID_Producto
        {
            get => id_producto;
            set => id_producto = value;
        }

        [Category("Producto"), Description("Imagen del producto")]
        public Image ImagenProducto
        {
            get => pbProducto?.Image;
            set { if (pbProducto != null) pbProducto.Image = value; }
        }

        [Category("Producto"), Description("Nombre del producto")]
        public string NombreProducto
        {
            get => lblProducto?.Text ?? string.Empty;
            set { if (lblProducto != null) lblProducto.Text = value; }
        }

        [Category("Producto"), Description("Nombre del distribuidor")]
        public string NombreDistribuidor
        {
            get => lblDistribuidor?.Text ?? string.Empty;
            set { if (lblDistribuidor != null) lblDistribuidor.Text = value; }
        }

        [Category("Producto"), Description("Descripción del producto")]
        public string Descripcion
        {
            get => lblDescripcion?.Text ?? string.Empty;
            set { if (lblDescripcion != null) lblDescripcion.Text = value; }
        }
        [Category("Producto"), Description("Categoria del producto")]
        public string Cateogoria
        {
            get => lbl_categoria?.Text ?? string.Empty;
            set { if (lbl_categoria != null) lbl_categoria.Text = value; }
        }
        [Category("Producto"), Description("Stock del producto")]
        public string Stock 
        {
            get => lb_stock?.Text ?? string.Empty;
            set { if (lb_stock != null) lb_stock.Text = value; }
        }

        [Category("Producto"), Description("Precio del producto")]
        public decimal Precio
        {
            get => _precio;
            set
            {
                _precio = value;
                ActualizarPrecioDescuento();
            }
        }


        private void ActualizarPrecioDescuento()
        {

        }

        private void ActualizarVisibilidadDescuento()
        {

        }

        // Método para forzar la actualización de la visibilidad si es necesario
        public void RefreshDescuentoVisibility()
        {
            ActualizarVisibilidadDescuento();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_productos("Actualizar nuevo producto", "Actualizar");
            modal.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
            "¿Está seguro que desea eliminar el registro?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

            if (resultado == DialogResult.Yes)
            {

            }
        }
    }
}