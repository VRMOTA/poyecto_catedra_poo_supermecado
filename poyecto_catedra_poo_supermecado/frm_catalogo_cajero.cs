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
    public partial class frm_catalogo_cajero : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        

        public frm_catalogo_cajero()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235);

            // Crear y configurar el TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Opcional: establecer tamaños proporcionales 
            for (int i = 0; i < 3; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            this.Controls.Add(tableLayoutPanel);
        }

        private void frm_catalogo_cajero_Load(object sender, EventArgs e)
        {
          
            int columnas = 4;
            int anchoCarta = 238; // Ajusta según el tamaño real de card_producto_menu
            int altoCarta = 266;  // Ajusta según el tamaño real de card_producto_menu
            int espacio = 10;     // Espacio entre cartas

            // Ejemplo: lista de productos (puedes reemplazar por tu fuente de datos real)
            var productos = new List<(string nombre, decimal precio, int descuento)>
            {
                ("Manzana", 1.20m, 0),
                ("Banana", 0.80m, 10),
                ("Leche", 2.50m, 5),
                ("Pan", 1.00m, 0),
                ("Queso", 3.75m, 15),
                ("Jamon", 2.90m, 0),
                ("Cereal", 4.10m, 20),
                ("Yogur", 1.60m, 0),
                ("Huevos", 2.20m, 0),
                ("Agua", 0.60m, 0),
                ("Refresco", 1.50m, 5),
                ("Galletas", 2.30m, 0),
                ("Galletas", 2.30m, 0),
                ("Galletas", 2.30m, 0),
                ("Galletas", 2.30m, 0)
            };

            panel1.Controls.Clear();
            panel1.AutoScroll = true;

            for (int i = 0; i < productos.Count; i++)
            {
                var card = new CustomCards.card_producto_menu();
                card.Producto = productos[i].nombre;
                card.Precio = productos[i].precio;
                card.Descuento = productos[i].descuento;

                int fila = i / columnas;
                int columna = i % columnas;

                card.Width = anchoCarta;
                card.Height = altoCarta;
                card.Left = columna * (anchoCarta + espacio);
                card.Top = fila * (altoCarta + espacio);

                panel1.Controls.Add(card);
            }

            // Ajusta el tamaño mínimo del panel para el scroll
            int filasNecesarias = (int)Math.Ceiling((double)productos.Count / columnas);
            panel1.AutoScrollMinSize = new Size(
                columnas * (anchoCarta + espacio),
                filasNecesarias * (altoCarta + espacio)
            );
        }
    }
}
