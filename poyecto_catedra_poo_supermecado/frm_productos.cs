using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using project_supermercado;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
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
            int espacio = 10; // Espacio entre cartas
            
            
            List<dynamic> lista_productos;
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Seleccionar datos con Entity Framework
                lista_productos = db.tb_producto
                    .Select(d => new
                    {
                       d.id_producto,
                       d.nombre, 
                       d.precio,
                       d.stock,
                       d.imagen,
                       d.descripcion,
                       d.id_distribuidor, 
                       d.id_categoria, 
                       d.activo
                    }).ToList<dynamic>(); // Convertimos a lista dinámica
            }


            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            int posicionY = 0;
            for (int i = 0; i < lista_productos.Count; i++)
            {
                var producto = lista_productos[i]; // Obtenemos el distribuidor actual

                // Convertir byte[] a Image
                Image imageProducto = null;
                if (producto.imagen != null)
                {
                    using (MemoryStream ms = new MemoryStream(producto.logo))
                    {
                        imageProducto = Image.FromStream(ms);
                    }
                }
                var card = new card_producto_admin
                {
                    //NombreProducto = productos[i].nombre,
                    //NombreDistribuidor = productos[i].distribuidor,
                    //ImagenProducto = productos[i].imagen,
                    //Descripcion = productos[i].descripcion,
                    //Precio = productos[i].precio,
                    //Descuento = productos[i].descuento,
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
