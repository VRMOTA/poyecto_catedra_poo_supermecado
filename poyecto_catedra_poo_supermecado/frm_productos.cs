using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using project_supermercado;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            var productos = new List<(string nombre, string distribuidor, Image imagen, string descripcion, decimal precio, int descuento)>
            {
                ("Manzana", "Distribuidora 1", Properties.Resources.manzana, "Fruta fresca y jugosa", 1.20m, 0),
                ("Banana", "Distribuidora 2", Properties.Resources.banana, "Rica en potasio", 0.80m, 10),
                ("Leche", "Distribuidora 3", Properties.Resources.leche, "Entera, 1 litro", 2.50m, 5),
                ("Pan", "Distribuidora 4", Properties.Resources.pan, "Pan artesanal", 1.00m, 0),
                ("Queso", "Distribuidora 5", Properties.Resources.queso, "Queso fresco", 3.75m, 15),
                ("Jamon", "Distribuidora 6", Properties.Resources.jamon, "Jamón cocido", 2.90m, 0),
                ("Cereal", "Distribuidora 7", Properties.Resources.cereal, "Cereal integral", 4.10m, 20),
                ("Yogur", "Distribuidora 8", Properties.Resources.yogyur, "Yogur natural", 1.60m, 0),
                ("Huevos", "Distribuidora 9", Properties.Resources.huevo, "Docena de huevos", 2.20m, 0),
                ("Agua", "Distribuidora 10", Properties.Resources.agua, "Botella 500ml", 0.60m, 0),
                ("Refresco", "Distribuidora 11", Properties.Resources.soda, "Refresco sabor cola", 1.50m, 5),
                ("Galletas", "Distribuidora 12", Properties.Resources.cokie, "Galletas dulces", 2.30m, 0),
                ("Arroz", "Distribuidora 13", Properties.Resources.rice, "Arroz blanco", 1.10m, 0),
            };

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            int posicionY = 0;
            for (int i = 0; i < productos.Count; i++)
            {
                var card = new card_producto_admin
                {
                    NombreProducto = productos[i].nombre,
                    NombreDistribuidor = productos[i].distribuidor,
                    ImagenProducto = productos[i].imagen,
                    Descripcion = productos[i].descripcion,
                    Precio = productos[i].precio,
                    Descuento = productos[i].descuento,
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
