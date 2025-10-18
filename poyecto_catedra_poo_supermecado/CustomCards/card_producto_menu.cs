using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.Models;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_producto_menu : RoundedControlBase
    {
        private model_productos model_Productos; // Instancia del modelo

        // Evento personalizado que se disparará cuando se presione el botón
        public event EventHandler<int> BotonVisualizarClick;

        public card_producto_menu()
        {
            InitializeComponent();
            model_Productos = new model_productos(); // Inicializar el modelo
            if (lblPrecioDescuento != null) lblPrecioDescuento.Visible = false;

            // Suscribir el evento del botón (si existe en el diseñador)
            if (btnVisualizar != null)
            {
                btnVisualizar.Click += BtnVisualizar_Click;
            }
        }

        [Category("Producto"), Description("ID único del producto")] // Propiedad para el ID del producto
        public int IDProducto // Propiedad para el ID del producto
        {
            get => model_Productos.ID_Producto_model;
            set => model_Productos.ID_Producto_model = value;
        }

        [Category("Producto"), Description("Nombre del producto")] // Propiedad para el nombre del producto
        public string Producto // Propiedad para el nombre del producto
        {
            get => model_Productos.NombreProducto_model;
            set
            {
                model_Productos.NombreProducto_model = value;
                if (lblProducto != null) lblProducto.Text = value;
            }
        }

        [Category("Precio"), Description("Precio base del producto")] //    Propiedad para el precio base del producto
        public decimal Precio // Propiedad para el precio base del producto
        {
            get => model_Productos.Precio_model;
            set
            {
                model_Productos.Precio_model = value;
                ActualizarPrecios();
            }
        }

        [Category("Precio"), Description("Descuento en porcentaje (0-100)")] // Propiedad para el descuento en porcentaje
        public int Descuento // Propiedad para el descuento en porcentaje
        {
            get => model_Productos.Descuento_model;
            set
            {
                model_Productos.Descuento_model = Math.Min(Math.Max(value, 0), 100);
                ActualizarPrecios();
            }
        }

        [Category("Producto"), Description("Imagen del producto")] // Propiedad para la imagen del producto
        public Image ImagenProducto // Propiedad para la imagen del producto
        {
            get => model_Productos.ImagenProducto_model;
            set
            {
                try
                {
                    model_Productos.ImagenProducto_model = value;
                    if (pbProducto != null) pbProducto.Image = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al asignar la imagen del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        [Category("Producto"), Description("Stock del producto")] // Propiedad para el stock del producto
        public int Stock // Propiedad para el stock del producto
        {
            get => model_Productos.Stock;
            set => model_Productos.Stock = value;
        }

        [Category("Producto"), Description("Descripción del producto")] // Propiedad para la descripción del producto
        public string Descripcion // Propiedad para la descripción del producto
        {
            get => model_Productos.Descripcion_model;
            set => model_Productos.Descripcion_model = value;
        }

        [Category("Producto"), Description("Categoría del producto")] //    Propiedad para la categoría del producto
        public string Categoria // Propiedad para la categoría del producto
        {
            get => model_Productos.Categoria_model;
            set => model_Productos.Categoria_model = value;
        }

        [Category("Producto"), Description("Distribuidor del producto")] // Propiedad para el distribuidor del producto
        public string Distribuidor //   Propiedad para el distribuidor del producto
        {
            get => model_Productos.NombreDistribuidor_model;
            set => model_Productos.NombreDistribuidor_model = value;
        }

        [Category("Producto"), Description("Estado activo del producto")] // Propiedad para el estado activo del producto
        public bool Activo //   Propiedad para el estado activo del producto
        {
            get => model_Productos.Activo_model;
            set => model_Productos.Activo_model = value;
        }

        private void ActualizarPrecios()
        {
            try
            {   // Asegurarse de que las etiquetas no sean nulas
                if (lblPrecio == null || lblPrecioDescuento == null) return;

                lblPrecio.Text = model_Productos.Precio_model.ToString("C2"); // Formatear como moneda

                if (model_Productos.Descuento_model > 0) // Aplicar descuento si es mayor a 0
                {
                    // Calcular el precio con descuento
                    decimal precioConDescuento = model_Productos.Precio_model * (1 - (model_Productos.Descuento_model / 100m));
                    lblPrecioDescuento.Text = precioConDescuento.ToString("C2"); // Formatear como moneda
                    lblPrecioDescuento.Visible = true;
                    SetStrikeout(lblPrecio, true);
                }
                else
                {
                    lblPrecioDescuento.Visible = false;
                    SetStrikeout(lblPrecio, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los precios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetStrikeout(Label lbl, bool strike)
        {
            try
            {   // Asegurarse de que la etiqueta no sea nula
                if (lbl == null) return;
                var family = lbl.Font.FontFamily;
                var size = lbl.Font.Size;
                var style = lbl.Font.Style;
                style = strike ? (style | FontStyle.Strikeout) : (style & ~FontStyle.Strikeout);
                lbl.Font = new Font(family, size, style);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el estilo de fuente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que se ejecuta cuando se presiona el botón
        private void BtnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Disparar el evento pasando el ID del producto
                BotonVisualizarClick?.Invoke(this, model_Productos.ID_Producto_model);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la visualización del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}