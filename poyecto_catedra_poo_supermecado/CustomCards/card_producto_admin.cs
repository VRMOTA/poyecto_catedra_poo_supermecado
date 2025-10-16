using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_producto_admin : RoundedControlBase
    {
        private int? _descuento;
        private int id_producto;
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_producto_admin()
        {
            InitializeComponent();
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
            get => decimal.TryParse(lblPrecio?.Text, out var precio) ? precio : 0m;
            set { if (lblPrecio != null) lblPrecio.Text = value.ToString("F2"); }
        }

        [Category("Producto"), Description("Activo del producto")]
        public string Activo
        {
            get => lb_activo?.Text ?? string.Empty;
            set { if (lb_activo != null) lb_activo.Text = value; }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_productos("Actualizar producto", "Actualizar");

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var producto = db.tb_producto.Find(id_producto);
                if (producto != null)
                {
                    modal.IDProducto = id_producto;
                    modal.NombreProducto = producto.nombre;
                    modal.PrecioProducto = producto.precio?.ToString();
                    modal.StockProducto = producto.stock?.ToString();
                    modal.IDCategoriaProducto = producto.id_categoria;
                    modal.IDDistribuidorProducto = producto.id_distribuidor;
                    modal.DescripcionProducto = producto.descripcion;
                    modal.ActivoProducto = producto.activo == true ? "Activo" : "Inactivo";

                    if (producto.imagen != null)
                    {
                        using (MemoryStream ms = new MemoryStream(producto.imagen))
                        {
                            modal.ImagenProducto = Image.FromStream(ms);
                        }
                    }
                }
            }

            if (modal.ShowDialog() == DialogResult.OK)
            {
                RecargaRequerida?.Invoke(this, EventArgs.Empty);
            }
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
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var producto = db.tb_producto.Find(ID_Producto);
                    if (producto != null)
                    {
                        db.tb_producto.Remove(producto);
                        db.SaveChanges();
                        MessageBox.Show("Producto eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecargaRequerida?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void CargarDatosPROD()
        {
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var producto = db.tb_producto.Find(ID_Producto);
                if (producto != null)
                {
                    NombreProducto = producto.nombre;
                    Precio = producto.precio ?? 0m;
                    Stock = producto.stock.ToString();
                    Descripcion = producto.descripcion;
                    Cateogoria = producto.id_categoria.ToString();
                    NombreDistribuidor = producto.id_distribuidor.ToString();

                    if (producto.imagen != null)
                    {
                        using (MemoryStream ms = new MemoryStream(producto.imagen))
                        {
                            ImagenProducto = Image.FromStream(ms);
                        }
                    }
                }
            }
        }
    }
}