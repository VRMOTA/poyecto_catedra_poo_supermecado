using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

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
            try
            {
                idSeleccionado = idProducto;

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    // Traer los campos necesarios de tb_producto
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
                        // Actualizar los controles con la información del producto
                        lblProducto.Text = producto.nombre;
                        lblPrecio.Text = (producto.precio ?? 0m).ToString("C2");
                        lbstock.Text = (producto.stock ?? 0).ToString();
                        lbdescriccion.Text = producto.descripcion ?? "";

                        // pa la promo
                        var promo = db.tb_promociones
                            .Where(pr => pr.id_producto == idProducto
                                         && pr.activa == true
                                         && pr.fecha_inicio <= DateTime.Now
                                         && pr.fecha_fin >= DateTime.Now)
                            .FirstOrDefault();

                        if (promo != null)
                        {
                            lbPromo.Text = $"Promoción: {promo.descripcion}\nPrecio Promo: {promo.precio_promocional:C2}";
                            lbPromo.ForeColor = Color.DarkGreen;
                        }
                        else
                        {
                            lbPromo.Text = "Sin promoción activa.";
                            lbPromo.ForeColor = Color.Gray;
                        }


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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar información del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                int columnas = 3;
                int anchoCarta = 238; // Ajusta según el tamaño real de card_producto_menu
                int altoCarta = 266;  // Ajusta según el tamaño real de card_producto_menu
                int espacio = 10;     // Espacio entre cartas

                List<dynamic> listaProductos;

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    // Traer los campos necesarios de tb_producto incluyendo la categoría
                    listaProductos = db.tb_producto
                        .Include("tb_categorias")
                        .Where(p => p.activo == true) // solo activos, opcional
                        .Select(p => new
                        {
                            p.id_producto,
                            p.nombre,
                            p.precio,
                            p.stock,
                            p.descripcion,
                            p.imagen,
                            categoria = p.tb_categorias.nombre ?? ""
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
                        // Dar valores a las propiedades necesarias
                        IDProducto = prod.id_producto,
                        Producto = prod.nombre,
                        Precio = prod.precio ?? 0m,
                        ImagenProducto = imgProd,
                        Categoria = prod.categoria ?? "",
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSeleccionado == 0)
                {
                    MessageBox.Show("Seleccione un producto primero.");
                    return;
                }

                int cantidad = 1;
                if (!int.TryParse(textboxMaxing2.Texts, out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                    return;
                }

                using (var db = new db_supermercadoEntities1())
                {
                    var prod = db.tb_producto.FirstOrDefault(p => p.id_producto == idSeleccionado);
                    if (prod != null)
                    {
                        int stockDisponible = prod.stock ?? 0;

                        if (cantidad > stockDisponible)
                        {
                            MessageBox.Show($"La cantidad ingresada ({cantidad}) supera el stock disponible ({stockDisponible}).");
                            return;
                        }
                        Image imagen = null;
                        if (prod.imagen != null)
                        {
                            using (var ms = new MemoryStream(prod.imagen))
                            {
                                imagen = Image.FromStream(ms);
                            }
                        }

                        var seleccionado = new Utilities.ProductoSeleccionado
                        {
                            Id = prod.id_producto,
                            Nombre = prod.nombre,
                            Precio = prod.precio ?? 0m,
                            Cantidad = cantidad,
                            Imagen = imagen,
                            Stock = prod.stock ?? 0
                        };

                        Utilities.Carrito.AgregarProducto(seleccionado);
                        MessageBox.Show(
                        $"{prod.nombre} agregado al carrito ({cantidad} unidad(es)).",
                        "Producto agregado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                        textboxMaxing2.Texts = ""; // Resetear a 1 después de agregar
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto al carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscador()
        {
            try
            {
                string busqueda = txt_buscar.Texts.ToLower().Trim();
                int columnas = 3;
                int anchoCarta = 238;
                int altoCarta = 266;
                int espacio = 10;

                // Obtener todas las cartas
                var todasLasCartas = panel1.Controls.OfType<card_producto_menu>().ToList();
                List<card_producto_menu> cartasFiltradas = new List<card_producto_menu>();

                if (string.IsNullOrEmpty(busqueda))
                {
                    // Si no hay búsqueda, mostrar todos los productos
                    cartasFiltradas = todasLasCartas;
                }
                else
                {
                    // Filtrar las cartas usando la información ya disponible en ellas
                    foreach (var card in todasLasCartas)
                    {
                        bool encontrado = false;

                        // Buscar por nombre del producto
                        if (card.Producto.ToLower().Contains(busqueda))
                        {
                            encontrado = true;
                        }
                        // Buscar por categoría usando la propiedad Categoria de la carta
                        else if (!string.IsNullOrEmpty(card.Categoria) &&
                                 card.Categoria.ToLower().Contains(busqueda))
                        {
                            encontrado = true;
                        }

                        if (encontrado)
                        {
                            cartasFiltradas.Add(card);
                        }
                    }
                }

                var cartasNoFiltradas = todasLasCartas
                    .Where(c => !cartasFiltradas.Contains(c))
                    .ToList();

                // Reposicionar: primero las filtradas, luego las no filtradas
                var cartasOrdenadas = cartasFiltradas.Concat(cartasNoFiltradas).ToList();

                for (int i = 0; i < cartasOrdenadas.Count; i++)
                {
                    var card = cartasOrdenadas[i];

                    int fila = i / columnas;
                    int columna = i % columnas;

                    card.Left = columna * (anchoCarta + espacio);
                    card.Top = fila * (altoCarta + espacio);
                    card.Visible = cartasFiltradas.Contains(card);
                }

                // Scroll al inicio cuando se busca
                panel1.AutoScrollPosition = new Point(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }

        private void lblProducto_Click(object sender, EventArgs e)
        {

        }

        private void roundedControlBase1_Load(object sender, EventArgs e)
        {

        }

        private void lbPromo_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textboxMaxing2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de números", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}