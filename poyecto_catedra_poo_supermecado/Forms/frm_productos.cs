using poyecto_catedra_poo_supermecado.Conexion;  
using poyecto_catedra_poo_supermecado.CustomCards; 
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_productos : Form
    {    //Fernando José Gomez Martínez GM251673
         //Jeanfranco Andre Campos López CL250978
         //Darlyn Marisol Romero Argueta RA250216
         //José Alejandro Sánchez Henríquez SH250142
         //Stalin Jafet Dubón Lemus DL251728
        public frm_productos()
        {
            InitializeComponent();       
            CargarProductosAdmin();      // Carga la lista de productos al abrir el formulario
        }

        // Método que carga los productos en formato de tarjetas para el administrador
        private void CargarProductosAdmin()
        {
            try
            {
                int espacio = 10; // Espacio entre tarjetas
                List<dynamic> lista_productos;

                // Obtiene los productos desde la base de datos con sus relaciones
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    lista_productos = (from p in db.tb_producto
                                       join d in db.tb_distribuidores on p.id_distribuidor equals d.id_distribuidor
                                       join c in db.tb_categorias on p.id_categoria equals c.id_categoria
                                       select new
                                       {
                                           p.id_producto,
                                           p.nombre,
                                           p.precio,
                                           p.stock,
                                           p.imagen,
                                           p.descripcion,
                                           nombre_distribuidor = d.nombre,
                                           nombre_categoria = c.nombre,
                                           p.activo
                                       }).ToList<dynamic>();
                }

                // Limpia el panel antes de volver a cargar los productos
                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;
                int posicionY = 0; // Control de posición vertical

                // Recorre cada producto y crea una tarjeta personalizada
                foreach (var producto in lista_productos)
                {
                    // Convierte la imagen de byte[] a Image
                    Image imageProducto = null;
                    if (producto.imagen != null)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(producto.imagen))
                            {
                                imageProducto = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            imageProducto = null; // Si la imagen está dañada
                        }
                    }

                    // Crea una tarjeta personalizada con la información del producto
                    var card = new card_producto_admin
                    {
                        ID_Producto_card = producto.id_producto,
                        NombreProducto_card = producto.nombre,
                        NombreDistribuidor_card = producto.nombre_distribuidor,
                        Descripcion_card = producto.descripcion,
                        Cateogoria_card = producto.nombre_categoria,
                        Stock_card = producto.stock,
                        Precio_card = producto.precio,
                        ImagenProducto_card = imageProducto,
                        Activo_card = producto.activo,
                        Margin = new Padding(espacio)
                    };

                    // Se suscribe al evento para recargar los productos si se modifica algo
                    card.RecargaRequerida += (s, e) => CargarProductosAdmin();

                    // Posiciona la tarjeta una debajo de otra
                    card.Left = 0;
                    card.Top = posicionY;
                    panel_cards.Controls.Add(card);
                    posicionY += card.Height + espacio;
                }

                // Configura el tamaño de desplazamiento del panel según el total de tarjetas
                panel_cards.AutoScrollMinSize = new Size(
                    panel_cards.Width,
                    posicionY
                );
            }
            catch (Exception ex)
            {
                // Muestra un mensaje si ocurre un error al cargar los productos
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que abre la ventana para agregar un nuevo producto
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new md_agregar_productos())
                {
                    // Si el modal se confirma, recarga la lista de productos
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        CargarProductosAdmin();
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje si ocurre un error al abrir el formulario
                MessageBox.Show($"Error al abrir el formulario de agregar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
