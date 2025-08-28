using project_supermercado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
{
    public partial class frm_clientes : Form
    {
        public frm_clientes()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            rd_fondo.FillColor = Color.FromArgb(235, 235, 235);
            pln_cards.BackColor = Color.FromArgb(235, 235, 235);
        }

        private void card_producto_carrito1_Load(object sender, EventArgs e)
        {

        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            int columnas = 4;
            int anchoCarta = 241;
            int altoCarta = 266;
            int espacio = 10;

            var productos = new List<(string nombre, decimal precio, int cantidad, Image imagen)>
            {
                ("Manzana", 1.20m, 2, Properties.Resources.Rigbyyyy),
                ("Banana", 0.80m, 1, Properties.Resources.Rigbyyyy),
                ("Leche", 2.50m, 3, Properties.Resources.Rigbyyyy),
                ("Pan", 1.00m, 1, Properties.Resources.Rigbyyyy),
                ("Queso", 3.75m, 2, Properties.Resources.Rigbyyyy),
                ("Jamon", 2.90m, 1, Properties.Resources.Rigbyyyy),
                ("Cereal", 4.10m, 1, Properties.Resources.Rigbyyyy),
                ("Yogur", 1.60m, 2, Properties.Resources.Rigbyyyy),
                ("Huevos", 2.20m, 1, Properties.Resources.Rigbyyyy),
                ("Agua", 0.60m, 4, Properties.Resources.Rigbyyyy),
                ("Refresco", 1.50m, 2, Properties.Resources.Rigbyyyy),
                ("Galletas", 2.30m, 1, Properties.Resources.Rigbyyyy),
                ("Arroz", 1.10m, 1, Properties.Resources.Rigbyyyy),
                ("Fideos", 1.40m, 1, Properties.Resources.Rigbyyyy),
                ("Aceite", 3.20m, 1, Properties.Resources.Rigbyyyy),
                ("Azúcar", 1.80m, 1, Properties.Resources.Rigbyyyy),
            };

            pln_cards.Controls.Clear();
            pln_cards.AutoScroll = true;

            for (int i = 0; i < productos.Count; i++)
            {
                var card = new CustomCards.card_producto_menu();    
                card.Producto = productos[i].nombre;
                card.Precio = productos[i].precio;
                card.Descuento = 0; // Puedes cambiar el descuento si lo necesitas
                card.ImagenProducto = productos[i].imagen;
                // Si tienes una propiedad para cantidad, stock o descripción, asígnala aquí:
                // card.Stock = productos[i].cantidad;
                // card.Descripcion = "Tu descripción aquí";

                int fila = i / columnas;
                int columna = i % columnas;

                card.Width = anchoCarta;
                card.Height = altoCarta;
                card.Left = columna * (anchoCarta + espacio);
                card.Top = fila * (altoCarta + espacio);

                pln_cards.Controls.Add(card);
            }

            int filasNecesarias = (int)Math.Ceiling((double)productos.Count / columnas);
            pln_cards.AutoScrollMinSize = new Size(
                columnas * (anchoCarta + espacio),
                filasNecesarias * (altoCarta + espacio)
            );
        }

        private void card_Load(object sender, EventArgs e)
        {

        }
    }
}
