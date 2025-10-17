using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.Utilities;
using poyecto_catedra_poo_supermecado.Models;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_clientes : Form
    {
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
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<dynamic> lista_productos;

            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    lista_productos = (from p in db.tb_producto
                                       join c in db.tb_categorias on p.id_categoria equals c.id_categoria into catJoin
                                       from c in catJoin.DefaultIfEmpty()
                                       select new
                                       {
                                           p.id_producto,
                                           p.nombre,
                                           p.precio,
                                           p.stock,
                                           p.descripcion,
                                           categoria = c != null ? c.nombre : "",
                                           p.imagen
                                       }).ToList<dynamic>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos desde la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pln_cards.Controls.Clear();
            pln_cards.AutoScroll = true;

            int indice = 0;
            foreach (var producto in lista_productos)
            {
                // Convertir byte[] a Image si existe
                Image imagenProducto = null;
                if (producto.imagen != null)
                {
                    imagenProducto = ImagenDesdeBytes(producto.imagen);
                }

                var card = new CustomCards.card_producto_menu
                {
                    IDProducto = producto.id_producto,
                    Producto = producto.nombre ?? "",
                    Precio = producto.precio ?? 0m,
                    Descuento = 0, // Asumiendo que no hay descuento por defecto
                    ImagenProducto = imagenProducto,
                    Width = AnchoCarta,
                    Height = AltoCarta
                };

                card.BotonVisualizarClick += Card_BotonVisualizarClick;

                int fila = indice / Columnas;
                int columna = indice % Columnas;

                card.Left = columna * (AnchoCarta + Espacio);
                card.Top = fila * (AltoCarta + Espacio);

                pln_cards.Controls.Add(card);
                indice++;
            }

            int filasNecesarias = (int)Math.Ceiling((double)lista_productos.Count / Columnas);
            pln_cards.AutoScrollMinSize = new Size(
                Columnas * (AnchoCarta + Espacio),
                filasNecesarias * (AltoCarta + Espacio)
            );
        }

        private void Card_BotonVisualizarClick(object sender, int idProducto)
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var producto = (from p in db.tb_producto
                                    join c in db.tb_categorias on p.id_categoria equals c.id_categoria into catJoin
                                    from c in catJoin.DefaultIfEmpty()
                                    where p.id_producto == idProducto
                                    select new
                                    {
                                        p.nombre,
                                        p.precio,
                                        p.stock,
                                        p.descripcion,
                                        p.imagen,
                                        categoria = c != null ? c.nombre : ""
                                    }).FirstOrDefault();

                    if (producto == null)
                    {
                        MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lblProducto.Text = producto.nombre ?? "";
                    lblPrecio.Text = (producto.precio ?? 0m).ToString("C2");
                    lbstock.Text = (producto.stock ?? 0).ToString();
                    lbdescriccion.Text = producto.descripcion ?? "";

                    if (producto.imagen != null)
                    {
                        pbProducto.Image = ImagenDesdeBytes(producto.imagen);
                    }
                    else
                    {
                        pbProducto.Image = null;
                    }

                    // Por ahora ocultamos el precio de descuento ya que no tenemos esa información
                    lblPrecioDescuento.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void Buscar()
        {
            string busqueda = txt_buscar.Texts.ToLower();

            var todasLasCartas = pln_cards.Controls.OfType<CustomCards.card_producto_menu>().ToList();

            // Buscar por nombre de producto Y por categoría
            var cartasFiltradas = todasLasCartas
                .Where(c => c.Producto.ToLower().Contains(busqueda) ||
                           (!string.IsNullOrEmpty(c.Categoria) &&
                            c.Categoria.ToLower().Contains(busqueda)))
                .ToList();

            var cartasNoFiltradas = todasLasCartas
                .Where(c => !cartasFiltradas.Contains(c))
                .ToList();

            var cartasOrdenadas = cartasFiltradas.Concat(cartasNoFiltradas).ToList();

            int indice = 0;
            foreach (var card in cartasOrdenadas)
            {
                int fila = indice / Columnas;
                int columna = indice % Columnas;

                card.Left = columna * (AnchoCarta + Espacio);
                card.Top = fila * (AltoCarta + Espacio);
                card.Visible = cartasFiltradas.Contains(card);
                indice++;
            }

            pln_cards.AutoScrollPosition = new Point(0, 0);
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscar();
        }
    }


}