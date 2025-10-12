using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.CustomControls;
using poyecto_catedra_poo_supermecado.CustomCards;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_carrito_cajero : Form
    {
        public frm_carrito_cajero()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235);
        }

        private void frm_carrito_cajero_Load(object sender, EventArgs e)
        {
   
        }

        private void roundedControlBase1_Load(object sender, EventArgs e)
        {

        }

        private void frm_carrito_cajero_Load_1(object sender, EventArgs e)
        {
            int anchoCarta = 775; // Ajusta según el tamaño real de card_producto_carrito
            int altoCarta = 204;   // Ajusta según el tamaño real de card_producto_carrito
            int espacio = 10;     // Espacio entre cartas

            // Ejemplo: lista de productos en el carrito (puedes reemplazar por tu fuente de datos real)
            var productosCarrito = new List<(string nombre, decimal precio, int cantidad,Image imb)>
            {
                ("Manzana", 1.20m, 2,Properties.Resources.manzana),
                ("Leche", 2.50m, 1, Properties.Resources.leche),
                ("Pan", 1.00m, 3, Properties.Resources.pan),
                ("Queso", 3.75m, 1, Properties.Resources.queso),
                ("Cereal", 4.10m, 2, Properties.Resources.cereal),
                ("Yogur", 1.60m, 4, Properties.Resources.yogyur),
                ("Huevos", 2.20m, 1, Properties.Resources.huevo),
                ("Agua", 0.60m, 6, Properties.Resources.agua    )
            };

            panel1.Controls.Clear();
            panel1.AutoScroll = true;

            for (int i = 0; i < productosCarrito.Count; i++)
            {
                var card = new CustomCards.card_producto_carrito();
                // Asigna los datos al control si tiene propiedades públicas
                 card.NombreProducto = productosCarrito[i].nombre;
                 card.Precio = productosCarrito[i].precio;
                card.Cantidad = productosCarrito[i].cantidad;
                card.ImagenProducto = productosCarrito[i].imb;

                card.Width = anchoCarta;
                card.Height = altoCarta;
                card.Left = 0;
                card.Top = i * (altoCarta + espacio);

                panel1.Controls.Add(card);
            }

            // Ajusta el tamaño mínimo del panel para el scroll
            panel1.AutoScrollMinSize = new Size(
                anchoCarta,
                productosCarrito.Count * (altoCarta + espacio)
            );
        }
    }
}
