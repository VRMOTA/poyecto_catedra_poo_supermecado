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
    {    //Fernando José Gomez Martínez GM251673
         //Jeanfranco Andre Campos López CL250978
         //Darlyn Marisol Romero Argueta RA250216
         //José Alejandro Sánchez Henríquez SH250142
         //Stalin Jafet Dubón Lemus DL251728
        public frm_categories()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235); // Fondo gris claro
        }

        // Al cargar el formulario se muestran las categorías
        private void frm_consultas_cajero_Load_1(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        // Carga las categorías desde la base de datos y las muestra como tarjetas
        private void CargarCategorias()
        {
            try
            {
                int columnas = 2, espacio = 10; // Configura el diseño
                List<dynamic> listaCat;

                // Obtiene las categorías desde la BD
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    listaCat = db.tb_categorias
                        .Select(u => new { u.id_categoria, u.nombre })
                        .ToList<dynamic>();
                }

                // Limpia el panel y configura el scroll
                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;
                Size cardSize = new Size(495, 107);

                int indice = 0;
                foreach (var cat in listaCat)
                {
                    // Crea una tarjeta por cada categoría
                    var card = new card_categories
                    {
                        ID_Categoria_Card = cat.id_categoria,
                        NombreCategoria_Card = cat.nombre,
                        Margin = new Padding(espacio),
                        Size = cardSize
                    };

                    // Actualiza el panel si se modifica algo
                    card.RecargaRequerida += (s, e) => CargarCategorias();

                    // Posiciona las tarjetas en forma de cuadrícula
                    int fila = indice / columnas;
                    int columna = indice % columnas;
                    card.Left = columna * (card.Width + espacio);
                    card.Top = fila * (card.Height + espacio);

                    panel_cards.Controls.Add(card);
                    indice++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}");
            }
        }

        // Filtra las categorías según el texto ingresado
        private void Buscador()
        {
            try
            {
                string busqueda = txt_buscar.Texts.ToLower();

                var todas = panel_cards.Controls.OfType<card_categories>().ToList();
                var filtradas = todas.Where(c => c.NombreCategoria_Card.ToLower().Contains(busqueda)).ToList();

                // Solo muestra las que coinciden
                foreach (var card in todas)
                    card.Visible = filtradas.Contains(card);

                panel_cards.AutoScrollPosition = new Point(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en búsqueda: {ex.Message}");
            }
        }

        // Abre el modal para agregar una nueva categoría
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new md_agregar_categoria())
                {
                    if (modal.ShowDialog() == DialogResult.OK)
                        CargarCategorias(); // Recarga la lista
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar categoría: {ex.Message}");
            }
        }

        // Busca mientras el usuario escribe
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }
    }
}
