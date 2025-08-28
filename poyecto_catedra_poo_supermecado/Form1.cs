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

            
            var productos = new List<(string nombre, decimal precio, int descuento, Image imagen)>
            {
                ("Manzana", 1.20m, 30, Properties.Resources.Rigbyyyy),    
                ("Banana", 0.80m, 10, Properties.Resources.Rigbyyyy),
                ("Leche", 2.50m, 5, Properties.Resources.Rigbyyyy),
                ("Pan", 1.00m, 0, Properties.Resources.Rigbyyyy),
                ("Queso", 3.75m, 15, Properties.Resources.Rigbyyyy),
                ("Jamon", 2.90m, 0, Properties.Resources.Rigbyyyy),
                ("Cereal", 4.10m, 20, Properties.Resources.Rigbyyyy),
                ("Yogur", 1.60m, 0, Properties.Resources.Rigbyyyy),
                ("Huevos", 2.20m, 0, Properties.Resources.Rigbyyyy),
                ("Agua", 0.60m, 0, Properties.Resources.Rigbyyyy),
                ("Refresco", 1.50m, 5, Properties.Resources.Rigbyyyy),
                ("Galletas", 2.30m, 0, Properties.Resources.Rigbyyyy),
                ("Arroz", 1.10m, 0, Properties.Resources.Rigbyyyy),
                ("Fideos", 1.40m, 0, Properties.Resources.Rigbyyyy),
                ("Aceite", 3.20m, 10, Properties.Resources.Rigbyyyy),
                ("Azúcar", 1.80m, 0, Properties.Resources.Rigbyyyy),
            };

            pln_cards.Controls.Clear();
            pln_cards.AutoScroll = true;

            for (int i = 0; i < productos.Count; i++)
            {
                var card = new CustomCards.card_producto_menu();    
                card.Producto = productos[i].nombre;
                card.Precio = productos[i].precio;
                card.Descuento = productos[i].descuento; 
                card.ImagenProducto = productos[i].imagen;


                int fila = i / columnas;
                int columna = i % columnas;

                card.Width = anchoCarta;
                card.Height = altoCarta;
                card.Left = columna * (anchoCarta + espacio);
                card.Top = fila * (altoCarta + espacio);

                pln_cards.Controls.Add(card);
            }

            int filasNecesarias = (int)Math.Ceiling((double)productos.Count / columnas); // Calcular filas necesarias
            pln_cards.AutoScrollMinSize = new Size( 
                columnas * (anchoCarta + espacio), // Ancho total
                filasNecesarias * (altoCarta + espacio) // Alto total
            ); // Ajustar tamaño mínimo para scroll
        }

        private void card_Load(object sender, EventArgs e)
        {

        }
    }
}
