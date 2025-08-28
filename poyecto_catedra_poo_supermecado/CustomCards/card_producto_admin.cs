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

        public card_producto_admin()
        {
            InitializeComponent();
            ActualizarPrecioDescuento();
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

        [Category("Producto"), Description("Descuento del producto (0-100)")]
        public int? Descuento
        {
            get => _descuento;
            set
            {
                _descuento = value;
                ActualizarPrecioDescuento();
                ActualizarVisibilidadDescuento();
            }
        }

        private void ActualizarPrecioDescuento()
        {
            if (lblPrecio != null)
            {
                lblPrecio.Text = _precio.ToString("C");
            }

            if (lblPrecioDescuento != null && _descuento.HasValue && _descuento > 0)
            {
                decimal precioConDescuento = _precio * (1 - (_descuento.Value / 100m));
                lblPrecioDescuento.Text = precioConDescuento.ToString("C");
            }
            else if (lblPrecioDescuento != null)
            {
                lblPrecioDescuento.Text = string.Empty;
            }
        }

        private void ActualizarVisibilidadDescuento()
        {
            bool mostrarDescuento = _descuento.HasValue && _descuento > 0;

            if (lblDescuento != null)
            {
                lblDescuento.Visible = mostrarDescuento;
                if (mostrarDescuento)
                {
                    lblDescuento.Text = $"{_descuento.Value}%";
                }
            }

            if (lblPrecioDescuento != null)
                lblPrecioDescuento.Visible = mostrarDescuento;

            if (pbDescuentoContainer != null)
                pbDescuentoContainer.Visible = mostrarDescuento;

            if (pbPrecioDecoration != null)
                pbPrecioDecoration.Visible = mostrarDescuento;

            // Opcional: tachar el precio original cuando hay descuento
            if (lblPrecio != null)
            {
                if (mostrarDescuento)
                {
                    lblPrecio.Font = new Font(lblPrecio.Font, FontStyle.Strikeout);
                    lblPrecio.ForeColor = Color.Gray;
                }
                else
                {
                    lblPrecio.Font = new Font(lblPrecio.Font, FontStyle.Regular);
                    lblPrecio.ForeColor = SystemColors.ControlText;
                }
            }
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
    }
}