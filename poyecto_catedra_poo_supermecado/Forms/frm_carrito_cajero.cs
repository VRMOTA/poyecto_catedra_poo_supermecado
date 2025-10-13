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
            CargarCarrito();
            //int anchoCarta = 775; // Ajusta según el tamaño real de card_producto_carrito
            //int altoCarta = 204;   // Ajusta según el tamaño real de card_producto_carrito
            //int espacio = 10;     // Espacio entre cartas

            //// Ejemplo: lista de productos en el carrito (puedes reemplazar por tu fuente de datos real)
            ////var productosCarrito = new List<(string nombre, decimal precio, int cantidad,Image imb)>
            ////{
            ////    ("Manzana", 1.20m, 2,Properties.Resources.manzana),
            ////    ("Leche", 2.50m, 1, Properties.Resources.leche),
            ////    ("Pan", 1.00m, 3, Properties.Resources.pan),
            ////    ("Queso", 3.75m, 1, Properties.Resources.queso),
            ////    ("Cereal", 4.10m, 2, Properties.Resources.cereal),
            ////    ("Yogur", 1.60m, 4, Properties.Resources.yogyur),
            ////    ("Huevos", 2.20m, 1, Properties.Resources.huevo),
            ////    ("Agua", 0.60m, 6, Properties.Resources.agua    )
            ////};

            //panel1.Controls.Clear();
            //panel1.AutoScroll = true;

            //var productosCarrito = Utilities.Carrito.Productos;

            //decimal totalPagar = 0m;
            //int totalCantidad = 0;

            //for (int i = 0; i < productosCarrito.Count; i++)
            //{
            //    var producto = productosCarrito[i];
            //    var card = new CustomCards.card_producto_carrito
            //    {
            //        IDProducto = producto.Id,
            //        NombreProducto = producto.Nombre,
            //        Precio = producto.Precio,
            //        Cantidad = producto.Cantidad,
            //        ImagenProducto = producto.Imagen,
            //        Width = anchoCarta,
            //        Height = altoCarta,
            //        Left = 0,
            //        Top = i * (altoCarta + espacio)
            //    };

            //    card.EliminarClick += (s, ev) => EliminarProducto(producto.Id);
            //    card.CantidadActualizada += (s, nuevaCantidad) => ActualizarProducto(producto.Id, nuevaCantidad);

            //    panel1.Controls.Add(card);
            //    totalCantidad += producto.Cantidad;
            //    totalPagar += producto.Precio * producto.Cantidad;

            //}

            //// Ajusta el tamaño mínimo del panel para el scroll
            //panel1.AutoScrollMinSize = new Size(
            //    anchoCarta,
            //    productosCarrito.Count * (altoCarta + espacio)
            //);

            //label2.Text = totalCantidad.ToString();
            //label4.Text = totalPagar.ToString("C2");
        }

        private void EliminarProducto(int idProducto)
        {
            var producto = Utilities.Carrito.Productos.FirstOrDefault(p => p.Id == idProducto);
            if (producto != null)
            {
                var confirmar = MessageBox.Show(
                    $"¿Desea eliminar '{producto.Nombre}' del carrito?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    Utilities.Carrito.Productos.Remove(producto);
                    RecargarCarrito();
                }
            }
        }

        private void ActualizarProducto(int idProducto, int nuevaCantidad)
        {
            //se busca el codigo pepe
            var producto = Utilities.Carrito.Productos.FirstOrDefault(p => p.Id == idProducto);
            if (producto == null) return;

            // Actualizar cantidad en la lista global, prueba
            producto.Cantidad = nuevaCantidad;

            // Buscar la card correspondiente y actualizar solo esa
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is CustomCards.card_producto_carrito card && card.IDProducto == idProducto)
                {
                    card.Cantidad = nuevaCantidad; // esto ya actualiza los labels internamente
                    //MessageBox.Show(producto.Cantidad.ToString());
                    break;
                }
            }

            // Actualizar totales del carrito
            ActualizarTotales();
        }
        private void ActualizarTotales()
        {
            decimal totalPagar = 0m;
            int totalCantidad = 0;

            foreach (var producto in Utilities.Carrito.Productos)
            {
                totalCantidad += producto.Cantidad;
                totalPagar += producto.Precio * producto.Cantidad;
            }

            label2.Text = totalCantidad.ToString();
            label4.Text = totalPagar.ToString("C2");
        }

        private void RecargarCarrito()
        {
            panel1.Controls.Clear();
            CargarCarrito();
        }

        private void CargarCarrito()
        {
            int anchoCarta = 775;
            int altoCarta = 204;
            int espacio = 10;

            panel1.Controls.Clear();
            panel1.AutoScroll = true;

            var productosCarrito = Utilities.Carrito.Productos;

            decimal totalPagar = 0m;
            int totalCantidad = 0;

            for (int i = 0; i < productosCarrito.Count; i++)
            {
                var producto = productosCarrito[i];
                var card = new CustomCards.card_producto_carrito
                {
                    IDProducto = producto.Id,
                    NombreProducto = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = producto.Cantidad,
                    ImagenProducto = producto.Imagen,
                    StockDisponible = producto.Stock,
                    Width = anchoCarta,
                    Height = altoCarta,
                    Left = 0,
                    Top = i * (altoCarta + espacio)
                };

                card.EliminarClick += (s, ev) => EliminarProducto(producto.Id);
                card.CantidadActualizada += (s, nuevaCantidad) => ActualizarProducto(producto.Id, nuevaCantidad);
                

                panel1.Controls.Add(card);

                totalCantidad += producto.Cantidad;
                totalPagar += producto.Precio * producto.Cantidad;
            }

            label2.Text = totalCantidad.ToString();
            label4.Text = totalPagar.ToString("C2");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
