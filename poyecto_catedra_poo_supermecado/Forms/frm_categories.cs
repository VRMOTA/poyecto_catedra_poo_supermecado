using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_categories : Form
    {
        public frm_categories()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235);
        }

        private void frm_consultas_cajero_Load_1(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                int columnas = 2;
                int espacio = 10;

                List<dynamic> listaCat;

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    listaCat = db.tb_categorias
                        .Select(u => new
                        {
                            u.id_categoria,
                            u.nombre,
                        }).ToList<dynamic>();
                }

                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;
                Size cardSize = new Size(495, 107);

                int indice = 0;
                foreach (var cat in listaCat)
                {
                    var card = new card_categories
                    {
                        ID_Categoria_Card = cat.id_categoria,
                        NombreCategoria_Card = cat.nombre,
                        Margin = new Padding(espacio),
                        Size = cardSize
                    };

                    // Suscribirse al evento de recarga
                    card.RecargaRequerida += (s, e) => CargarCategorias();

                    int fila = indice / columnas;
                    int columna = indice % columnas;

                    card.Left = columna * (card.Width + espacio);
                    card.Top = fila * (card.Height + espacio);

                    panel_cards.Controls.Add(card);
                    indice++;
                }

                int filasNecesarias = (int)Math.Ceiling((double)listaCat.Count / columnas);
                panel_cards.AutoScrollMinSize = new Size(
                    columnas * (cardSize.Width + espacio),
                    filasNecesarias * (cardSize.Height + espacio)
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscador()
        {
            try
            {
                string busqueda = txt_buscar.Texts.ToLower();
                int columnas = 2;
                int espacio = 10;

                var todasLasCartas = panel_cards.Controls.OfType<card_categories>().ToList();

                var cartasFiltradas = todasLasCartas
                    .Where(c => c.NombreCategoria_Card.ToLower().Contains(busqueda))
                    .ToList();

                var cartasNoFiltradas = todasLasCartas
                    .Where(c => !cartasFiltradas.Contains(c))
                    .ToList();

                var cartasOrdenadas = cartasFiltradas.Concat(cartasNoFiltradas).ToList();

                int indice = 0;
                foreach (var card in cartasOrdenadas)
                {
                    int fila = indice / columnas;
                    int columna = indice % columnas;

                    card.Left = columna * (card.Width + espacio);
                    card.Top = fila * (card.Height + espacio);
                    card.Visible = cartasFiltradas.Contains(card);
                    indice++;
                }

                panel_cards.AutoScrollPosition = new Point(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda de categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new md_agregar_categoria())
                {
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        CargarCategorias();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de agregar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }
    }
}