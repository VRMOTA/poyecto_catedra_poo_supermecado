using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_catalogo_cajero : Form
    {
        private List<card_producto_menu> productosCards = new List<card_producto_menu>();
        private int idSeleccionado = 0; // guarda el id seleccionado para usarlo luego

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
            idSeleccionado = idProducto;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var producto = db.tb_producto
                                .Where(p => p.id_producto == idProducto)
                                .Select(p => new
                                {
                                    p.id_producto,
                                    p.nombre,
                                    p.precio,
                                    p.stock,
                                    p.descripcion,
                                    p.imagen
                                })
                                .FirstOrDefault();

                if (producto != null)
                {
                    lblProducto.Text = producto.nombre;
                    lblPrecio.Text = (producto.precio ?? 0m).ToString("C2");
                    lbstock.Text = (producto.stock ?? 0).ToString();
                    lbdescriccion.Text = producto.descripcion ?? "";

                    if (producto.imagen != null)
                    {
                        using (MemoryStream ms = new MemoryStream(producto.imagen))
                        {
                            pbProducto.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pbProducto.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.");
                }
            }
        }

        private void CargarProductos()
        {
            int columnas = 4;
            int anchoCarta = 238; // Ajusta según el tamaño real de card_producto_menu
            int altoCarta = 266;  // Ajusta según el tamaño real de card_producto_menu
            int espacio = 10;     // Espacio entre cartas

            List<dynamic> listaProductos;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Traer los campos necesarios de tb_producto (sin descuentos ni promociones)
                listaProductos = db.tb_producto
                    .Where(p => p.activo == true) // solo activos, opcional
                    .Select(p => new
                    {
                        p.id_producto,
                        p.nombre,
                        p.precio,
                        p.stock,
                        p.descripcion,
                        p.imagen
                    })
                    .ToList<dynamic>();
            }

            panel1.Controls.Clear();
            productosCards.Clear();
            panel1.AutoScroll = true;

            for (int i = 0; i < listaProductos.Count; i++)
            {
                var prod = listaProductos[i];

                // Convertir byte[] a Image si existe
                Image imgProd = null;
                if (prod.imagen != null)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(prod.imagen))
                        {
                            imgProd = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        imgProd = null; // Manejar error de imagen si fuera necesario
                    }
                }

                var card = new card_producto_menu
                {
                    IDProducto = prod.id_producto,        
                    Producto = prod.nombre,               
                    Precio = prod.precio ?? 0m,           
                    ImagenProducto = imgProd,
                    Descuento = 0,                        
                    Width = anchoCarta,
                    Height = altoCarta,
                    Margin = new Padding(espacio)
                };

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

            int filasNecesarias = (int)Math.Ceiling((double)listaProductos.Count / columnas);
            panel1.AutoScrollMinSize = new Size(
                columnas * (anchoCarta + espacio),
                filasNecesarias * (altoCarta + espacio)
            );
        }
    }
}
