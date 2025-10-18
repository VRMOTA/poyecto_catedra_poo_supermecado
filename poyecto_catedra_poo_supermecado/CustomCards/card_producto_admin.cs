﻿using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using poyecto_catedra_poo_supermecado.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_producto_admin : RoundedControlBase
    {
        private model_productos model_productos; // Instancia del modelo
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_producto_admin()
        {
            InitializeComponent();
            model_productos = new model_productos(); // Inicializar el modelo
        }

        public int ID_Producto_card // Propiedad para el ID del producto
        {
            get => model_productos.ID_Producto_model;
            set => model_productos.ID_Producto_model = value;
        }

        [Category("Producto"), Description("Imagen del producto")]  //Propiedad o atributos para la imagen del producto
        public Image ImagenProducto_card // Propiedad para la imagen del producto
        {
            get => model_productos.ImagenProducto_model ?? pbProducto.Image;
            set
            {
                model_productos.ImagenProducto_model = value;
                if (pbProducto != null) pbProducto.Image = value;
            }
        }

        [Category("Producto"), Description("Nombre del producto")] // Propiedad o atributos para el nombre del producto
        public string NombreProducto_card // Propiedad para el nombre del producto
        {
            get => model_productos.NombreProducto_model;
            set
            {
                model_productos.NombreProducto_model = value;
                if (lblProducto != null) lblProducto.Text = value;
            }
        }

        [Category("Producto"), Description("Nombre del distribuidor")] // Propiedad o atributos para el nombre del distribuidor
        public string NombreDistribuidor_card // Propiedad para el nombre del distribuidor
        {
            get => model_productos.NombreDistribuidor_model;
            set
            {
                model_productos.NombreDistribuidor_model = value;
                if (lblDistribuidor != null) lblDistribuidor.Text = value;
            }
        }

        [Category("Producto"), Description("Descripción del producto")] // Propiedad o atributos para la descripción del producto
        public string Descripcion_card // Propiedad para la descripción del producto
        {
            get => model_productos.Descripcion_model;
            set
            {
                model_productos.Descripcion_model = value;
                if (lblDescripcion != null) lblDescripcion.Text = value;
            }
        }

        [Category("Producto"), Description("Categoria del producto")] // Propiedad o atributos para la categoría del producto
        public string Cateogoria_card // Propiedad para la categoría del producto
        {
            get => model_productos.Categoria_model;
            set
            {
                model_productos.Categoria_model = value;
                if (lbl_categoria != null) lbl_categoria.Text = value;
            }
        }

        [Category("Producto"), Description("Stock del producto")] // Propiedad o atributos para el stock del producto
        public int Stock_card // Propiedad para el stock del producto
        {
            get => model_productos.Stock;
            set
            {
                model_productos.Stock = value;
                if (lb_stock != null) lb_stock.Text = value.ToString(); // Conversión de int a string
            }
        }

        [Category("Producto"), Description("Precio del producto")] // Propiedad o atributos para el precio del producto
        public decimal Precio_card // Propiedad para el precio del producto
        {
            get => model_productos.Precio_model;
            set
            {
                model_productos.Precio_model = value;
                if (lblPrecio != null) lblPrecio.Text = value.ToString("F2");
            }
        }

        [Category("Producto"), Description("Activo del producto")] // Propiedad o atributos para el estado activo del producto
        public bool Activo_card // Propiedad para el estado activo del producto
        {
            get => model_productos.Activo_model;
            set
            {
                model_productos.Activo_model = value;
                if (lb_activo != null) lb_activo.Text = value ? "Activo" : "Inactivo";
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) 
        {
            try
            {
                var modal = new md_agregar_productos("Actualizar producto", "Actualizar"); // Crear instancia del modal de edición

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1()) // Conectar a la base de datos
                {
                    var producto = db.tb_producto.Find(ID_Producto_card);// Buscar el producto por ID
                    if (producto != null)
                    {
                        // Pasar los datos del producto al modal
                        modal.IDProducto_vista = producto.id_producto;
                        modal.NombreProducto_vista = producto.nombre;
                        modal.PrecioProducto_vista = (double)(producto.precio ?? 0m);
                        modal.StockProducto_vista = producto.stock ?? 0;
                        modal.IDCategoriaProducto_vista = producto.id_categoria;
                        modal.IDDistribuidorProducto_vista = producto.id_distribuidor;
                        modal.DescripcionProducto_vista = producto.descripcion;
                        modal.ActivoProducto_vista = producto.activo == true;

                        if (producto.imagen != null)
                        {
                            using (MemoryStream ms = new MemoryStream(producto.imagen))// Convertir el arreglo de bytes a una imagen
                            {
                                modal.ImagenProducto_vista = Image.FromStream(ms);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (modal.ShowDialog() == DialogResult.OK)
                {
                    RecargaRequerida?.Invoke(this, EventArgs.Empty); // Disparar el evento para recargar los datos
                    // En el formulario se encuentra el metodo recargar y lo usa parapara disparar el evento junto al metodo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar el registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );// Preguntar al usuario si está seguro de eliminar

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (db_supermercadoEntities1 db = new db_supermercadoEntities1()) //Conectar a la base de datos
                    {
                        var producto = db.tb_producto.Find(ID_Producto_card); // Buscar el producto por ID
                        if (producto != null)
                        {
                            db.tb_producto.Remove(producto); // Eliminar el producto
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}