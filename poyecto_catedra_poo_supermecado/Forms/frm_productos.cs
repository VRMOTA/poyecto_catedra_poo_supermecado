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
    {
        public frm_productos()
        {
            InitializeComponent();
            CargarProductosAdmin();
        }

        private void CargarProductosAdmin()
        {
            try
            {
                int espacio = 10;
                List<dynamic> lista_productos;

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

                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;
                int posicionY = 0;

                foreach (var producto in lista_productos)
                {
                    // Convertir byte[] a Image
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
                            imageProducto = null; // Manejo silencioso si la imagen está corrupta
                        }
                    }

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

                    // Suscribirse al evento de recarga
                    card.RecargaRequerida += (s, e) => CargarProductosAdmin();

                    card.Left = 0;
                    card.Top = posicionY;
                    panel_cards.Controls.Add(card);
                    posicionY += card.Height + espacio;
                }

                panel_cards.AutoScrollMinSize = new Size(
                    panel_cards.Width,
                    posicionY
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new md_agregar_productos())
                {
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        CargarProductosAdmin();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de agregar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}