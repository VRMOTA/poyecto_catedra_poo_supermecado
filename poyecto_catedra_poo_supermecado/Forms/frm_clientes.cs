using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.Utilities;

namespace poyecto_catedra_poo_supermecado.Forms
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

            // Verifica si la base de datos existe y es accesible
            if (!Helpers.DatabaseExists())
            {
                MessageBox.Show("La base de datos no está disponible o no se puede conectar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pln_cards.Enabled = false;
            }
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {
            CargarProductosDesdeBD();
            MostrarProductosEnUI();
        }

        private void CargarProductosDesdeBD()
        {
            try
            {
                using (var db = new db_supermercadoEntities1())
                {
                    // Carga todos los productos desde la BD
                    productos = db.tb_producto
                        .Select(p => new Producto
                        {
                            Id = p.id_producto,
                            Nombre = p.nombre,
                            Precio = p.precio ?? 0m,
                            Stock = p.stock ?? 0,
                            Descripcion = p.descripcion
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos desde la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                productos = new List<Producto>();
            }
        }

        private void MostrarProductosEnUI()
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
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private Image ImagenDesdeBytes(byte[] bytes)
        {
            using (var ms = new System.IO.MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            var frmLogin = new frm_login();
            this.Hide();
            frmLogin.Show();
        }

        private void frm_clientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonMaxing3_Click(object sender, EventArgs e)
        {
            using (var modal = new CustomModals.md_consulta())
            {
                modal.ShowDialog();
            }
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            // Prueba de conexión a BD
            try
            {
                using (var db = new db_supermercadoEntities1())
                {
                    int total = db.tb_producto.Count();
                    MessageBox.Show("Conexión exitosa. Total de productos: " + total, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int Descuento { get; set; }
        public string Descripcion { get; set; }
        public Image Imagen { get; set; }
    }
}
