using poyecto_catedra_poo_supermecado.CustomCards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
{
    public partial class frm_catalogo_cajero : Form
    {
        private List<card_producto_menu> productosCards = new List<card_producto_menu>();

        public frm_catalogo_cajero()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235);
            // No crear panel1 aquí, debe estar en el diseñador
        }

        private void frm_catalogo_cajero_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        private void card_producto_menu1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Este método se ejecutará cuando se presione cualquier botón btnVisualizar
        private void Card_BotonVisualizarClick(object sender, int idProducto)
        {
            // Ejemplo: lista de productos con stock y descripción
            var productos = new List<(int id, string nombre, decimal precio, int descuento, int stock, string descripcion,Image imb)>
            {
                (1, "Manzana", 1.20m, 0, 50, "Fruta fresca y jugosa",Properties.Resources.manzana),
                (2, "Banana", 0.80m, 10, 40, "Rica en potasio", Properties.Resources.banana),
                (3, "Leche", 2.50m, 5, 30, "Entera, 1 litro", Properties.Resources.leche ),
                (4, "Pan", 1.00m, 0, 60, "Pan artesanal", Properties.Resources.pan ),
                (5, "Queso", 3.75m, 15, 20, "Queso fresco", Properties.Resources.queso   ),
                (6, "Jamon", 2.90m, 0, 25, "Jamón cocido", Properties.Resources.jamon),
                (7, "Cereal", 4.10m, 20, 35, "Cereal integral", Properties.Resources.cereal),
                (8, "Yogur", 1.60m, 0, 45, "Yogur natural", Properties.Resources.yogyur),
                (9, "Huevos", 2.20m, 0, 80, "Docena de huevos", Properties.Resources.huevo),
                (10, "Agua", 0.60m, 0, 100, "Botella 500ml", Properties.Resources.agua),
                (11, "Refresco", 1.50m, 5, 70, "Refresco sabor cola", Properties.Resources.soda ),
                (12, "Galletas", 2.30m, 0, 55, "Galletas dulces"    , Properties.Resources.cokie),
                (13, "Arroz", 1.10m, 0, 90, "Arroz blanco", Properties.Resources.rice   ),
                (14, "Fideos", 1.40m, 0, 85, "Fideos secos", Properties.Resources.Rigbyyyy  ),
                (15, "Aceite", 3.20m, 10, 15, "Aceite vegetal", Properties.Resources.Rigbyyyy),
                (16, "Azúcar", 1.80m, 0, 75, "Azúcar refinada", Properties.Resources.Rigbyyyy)
            };

            var producto = productos.FirstOrDefault(p => p.id == idProducto);
            if (producto.id != 0)
            {
                // Asignar valores a los labels del formulario
                lblProducto.Text = producto.nombre;
                lblPrecio.Text = producto.precio.ToString("C2");
                lbstock.Text = producto.stock.ToString();
                lbdescriccion.Text = producto.descripcion;
                pbProducto.Image = producto.imb;

                if (producto.descuento > 0)
                {
                    decimal precioDescuento = producto.precio * (1 - (producto.descuento / 100m));
                    lblPrecioDescuento.Text = precioDescuento.ToString("C2");
                    lblPrecioDescuento.Visible = true;
                }
                else
                {
                    lblPrecioDescuento.Text = "";
                    lblPrecioDescuento.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Producto no encontrado.");
            }
        }

        private void CargarProductos()
        {
            int columnas = 4;
            int anchoCarta = 238; // Ajusta según el tamaño real de card_producto_menu
            int altoCarta = 266;  // Ajusta según el tamaño real de card_producto_menu
            int espacio = 10;     // Espacio entre cartas

            // Ejemplo: lista de productos (puedes reemplazar por tu fuente de datos real)
            var productos = new List<(int id, string nombre, decimal precio, int descuento, Image img)>
            {
                (1, "Manzana", 1.20m, 0,Properties.Resources.manzana),
                (2, "Banana", 0.80m, 10, Properties.Resources.banana),
                (3, "Leche", 2.50m, 5, Properties.Resources.leche),
                (4, "Pan", 1.00m, 0, Properties.Resources.pan),
                (5, "Queso", 3.75m, 15, Properties.Resources.queso),
                (6, "Jamon", 2.90m, 0, Properties.Resources.jamon),
                (7, "Cereal", 4.10m, 20, Properties.Resources.cereal),
                (8, "Yogur", 1.60m, 0, Properties.Resources.yogyur),
                (9, "Huevos", 2.20m, 0, Properties.Resources.huevo),
                (10, "Agua", 0.60m, 0, Properties.Resources.agua),
                (11, "Refresco", 1.50m, 5, Properties.Resources.soda),
                (12, "Galletas", 2.30m, 0, Properties.Resources.cokie),
                (13, "Arroz", 1.10m, 0, Properties.Resources.rice),
            };

            panel1.Controls.Clear();
            productosCards.Clear();
            panel1.AutoScroll = true;

            for (int i = 0; i < productos.Count; i++)
            {
                var card = new card_producto_menu();
                card.IDProducto = productos[i].id;
                card.Producto = productos[i].nombre;
                card.Precio = productos[i].precio;
                card.Descuento = productos[i].descuento;
                card.ImagenProducto = productos[i].img;

                // Suscribirse al evento personalizado
                card.BotonVisualizarClick += Card_BotonVisualizarClick;

                int fila = i / columnas;
                int columna = i % columnas;

                card.Width = anchoCarta;
                card.Height = altoCarta;
                card.Left = columna * (anchoCarta + espacio);
                card.Top = fila * (altoCarta + espacio);

                panel1.Controls.Add(card);
                productosCards.Add(card);
            }

            int filasNecesarias = (int)Math.Ceiling((double)productos.Count / columnas);
            panel1.AutoScrollMinSize = new Size(
                columnas * (anchoCarta + espacio),
                filasNecesarias * (altoCarta + espacio)
            );
        }
    }
}
