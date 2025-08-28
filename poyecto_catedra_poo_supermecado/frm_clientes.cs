using project_supermercado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
{
    public partial class frm_clientes : Form
    {
        private List<Producto> productos = new List<Producto>();
        private List<CustomCards.card_producto_menu> productosCards = new List<CustomCards.card_producto_menu>();

        // Constantes para layout
        private const int Columnas = 4;
        private const int AnchoCarta = 241;
        private const int AltoCarta = 266;
        private const int Espacio = 10;

        public frm_clientes()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            rd_fondo.FillColor = Color.FromArgb(235, 235, 235);
            pln_cards.BackColor = Color.FromArgb(235, 235, 235);
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            InicializarProductos();
            CargarProductos();
        }

        private void InicializarProductos()
        {
            productos = new List<Producto>
            {
                new Producto(1, "Manzana", 1.20m, 50, 30, "Fruta fresca y jugosa", Properties.Resources.Rigbyyyy),
                new Producto(2, "Banana", 0.80m, 40, 10, "Rica en potasio", Properties.Resources.Rigbyyyy),
                new Producto(3, "Leche", 2.50m, 30, 5, "Entera, 1 litro", Properties.Resources.Rigbyyyy),
                new Producto(4, "Pan", 1.00m, 60, 0, "Pan artesanal", Properties.Resources.Rigbyyyy),
                new Producto(5, "Queso", 3.75m, 20, 15, "Queso fresco", Properties.Resources.Rigbyyyy),
                new Producto(6, "Jamon", 2.90m, 25, 0, "Jamón cocido", Properties.Resources.Rigbyyyy),
                new Producto(7, "Cereal", 4.10m, 35, 20, "Cereal integral", Properties.Resources.Rigbyyyy),
                new Producto(8, "Yogur", 1.60m, 45, 0, "Yogur natural", Properties.Resources.Rigbyyyy),
                new Producto(9, "Huevos", 2.20m, 80, 0, "Docena de huevos", Properties.Resources.Rigbyyyy),
                new Producto(10, "Agua", 0.60m, 100, 0, "Botella 500ml", Properties.Resources.Rigbyyyy),
                new Producto(11, "Refresco", 1.50m, 70, 5, "Refresco sabor cola", Properties.Resources.Rigbyyyy),
                new Producto(12, "Galletas", 2.30m, 55, 0, "Galletas dulces", Properties.Resources.Rigbyyyy),
                new Producto(13, "Arroz", 1.10m, 90, 0, "Arroz blanco", Properties.Resources.Rigbyyyy),
                new Producto(14, "Fideos", 1.40m, 85, 0, "Fideos secos", Properties.Resources.Rigbyyyy),
                new Producto(15, "Aceite", 3.20m, 15, 10, "Aceite vegetal", Properties.Resources.Rigbyyyy),
                new Producto(16, "Azúcar", 1.80m, 75, 0, "Azúcar refinada", Properties.Resources.Rigbyyyy),
            };
        }

        private void CargarProductos()
        {
            pln_cards.Controls.Clear();
            productosCards.Clear();
            pln_cards.AutoScroll = true;

            for (int i = 0; i < productos.Count; i++)
            {
                var p = productos[i];
                var card = new CustomCards.card_producto_menu
                {
                    IDProducto = p.Id,
                    Producto = p.Nombre,
                    Precio = p.Precio,
                    Descuento = p.Descuento,
                    ImagenProducto = p.Imagen,
                    Width = AnchoCarta,
                    Height = AltoCarta,
                    Left = (i % Columnas) * (AnchoCarta + Espacio),
                    Top = (i / Columnas) * (AltoCarta + Espacio)
                };

                card.BotonVisualizarClick += Card_BotonVisualizarClick;

                pln_cards.Controls.Add(card);
                productosCards.Add(card);
            }

            int filas = (int)Math.Ceiling((double)productos.Count / Columnas);
            pln_cards.AutoScrollMinSize = new Size(
                Columnas * (AnchoCarta + Espacio),
                filas * (AltoCarta + Espacio)
            );
        }

        private void Card_BotonVisualizarClick(object sender, int idProducto)
        {
            var producto = productos.FirstOrDefault(p => p.Id == idProducto);
            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            lblProducto.Text = producto.Nombre;
            lblPrecio.Text = producto.Precio.ToString("C2");
            lbstock.Text = producto.Stock.ToString();
            lbdescriccion.Text = producto.Descripcion;
            pbProducto.Image = producto.Imagen;

            if (producto.Descuento > 0)
            {
                decimal precioDescuento = producto.Precio * (1 - (producto.Descuento / 100m));
                lblPrecioDescuento.Text = precioDescuento.ToString("C2");
                lblPrecioDescuento.Visible = true;
            }
            else
            {
                lblPrecioDescuento.Visible = false;
            }
        }
    }

    public class Producto
    {
        public int Id { get; }
        public string Nombre { get; }
        public decimal Precio { get; }
        public int Stock { get; }
        public int Descuento { get; }
        public string Descripcion { get; }
        public Image Imagen { get; }

        public Producto(int id, string nombre, decimal precio, int stock, int descuento, string descripcion, Image imagen)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Descuento = descuento;
            Descripcion = descripcion;
            Imagen = imagen;
        }
    }
}
