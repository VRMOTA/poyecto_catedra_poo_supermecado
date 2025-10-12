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
            int espacio = 10;

            List<dynamic> lista_productos;
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // SELECT con JOINs para obtener los nombres
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

            for (int i = 0; i < lista_productos.Count; i++)
            {
                var producto = lista_productos[i];

                // Convertir byte[] a Image
                Image imageProducto = null;
                if (producto.imagen != null)
                {
                    using (MemoryStream ms = new MemoryStream(producto.imagen))
                    {
                        imageProducto = Image.FromStream(ms);
                    }
                }

                var card = new card_producto_admin
                {
                    ID_Producto = producto.id_producto,
                    NombreProducto = producto.nombre,
                    NombreDistribuidor = producto.nombre_distribuidor, // Ahora muestra el nombre real
                    Descripcion = producto.descripcion,
                    Cateogoria = producto.nombre_categoria, // Ahora muestra el nombre real
                    Stock = producto.stock.ToString(),
                    Precio = producto.precio,
                    ImagenProducto = imageProducto,
                    Margin = new Padding(espacio)
                };

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
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_agregar_productos())
            {
                modal.ShowDialog();
            }
        }
    }
}
