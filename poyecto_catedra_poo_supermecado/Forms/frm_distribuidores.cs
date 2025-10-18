using poyecto_catedra_poo_supermecado.Conexion;   
using poyecto_catedra_poo_supermecado.CustomCards; 
using poyecto_catedra_poo_supermecado.CustomModals; 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_distribuidores : Form
    {    //Fernando José Gomez Martínez GM251673
         //Jeanfranco Andre Campos López CL250978
         //Darlyn Marisol Romero Argueta RA250216
         //José Alejandro Sánchez Henríquez SH250142
         //Stalin Jafet Dubón Lemus DL251728
        public frm_distribuidores()
        {
            InitializeComponent();
            CargarDistribuidores(); // Carga los distribuidores al abrir el formulario
        }

        // Carga los distribuidores desde la base de datos y los muestra como tarjetas
        private void CargarDistribuidores()
        {
            try
            {
                int columnas = 3;            // Cantidad de columnas de tarjetas
                int anchoCarta = 385;        // Ancho de cada tarjeta
                int altoCarta = 204;         // Alto de cada tarjeta
                int espacio = 10;            // Espacio entre tarjetas

                List<dynamic> lista_distribuidores;

                // Obtiene los distribuidores de la BD
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    lista_distribuidores = db.tb_distribuidores
                        .Select(d => new
                        {
                            d.id_distribuidor,
                            d.nombre,
                            d.logo
                        }).ToList<dynamic>();
                }

                // Limpia el panel antes de recargar las tarjetas
                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;

                int indice = 0;
                foreach (var distribuidor in lista_distribuidores)
                {
                    // Convierte el logo (byte[]) en una imagen
                    Image imagenDistribuidor = null;
                    if (distribuidor.logo != null)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(distribuidor.logo))
                                imagenDistribuidor = Image.FromStream(ms);
                        }
                        catch
                        {
                            imagenDistribuidor = null; // Si la imagen está dañada
                        }
                    }

                    // Crea una tarjeta visual para cada distribuidor
                    var card = new card_distribuidores
                    {
                        ID_Distribuidor_card = distribuidor.id_distribuidor,
                        NombreDistribuidora_card = distribuidor.nombre,
                        ImagenDistribuidora_card = imagenDistribuidor,
                        Width = anchoCarta,
                        Height = altoCarta,
                        Margin = new Padding(espacio)
                    };

                    // Si la tarjeta genera un evento de recarga, vuelve a cargar la lista
                    card.RecargaRequerida += (s, e) => CargarDistribuidores();

                    // Posiciona la tarjeta en el panel
                    int fila = indice / columnas;
                    int columna = indice % columnas;
                    card.Left = columna * (anchoCarta + espacio);
                    card.Top = fila * (altoCarta + espacio);

                    panel_cards.Controls.Add(card);
                    indice++;
                }

                // Configura el tamaño de desplazamiento del panel según el número de tarjetas
                int filasNecesarias = (int)Math.Ceiling((double)lista_distribuidores.Count / columnas);
                panel_cards.AutoScrollMinSize = new Size(
                    columnas * (anchoCarta + espacio),
                    filasNecesarias * (altoCarta + espacio)
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los distribuidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Abre el modal para agregar un nuevo distribuidor
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new md_agregar_distribuidor())
                {
                    if (modal.ShowDialog() == DialogResult.OK)
                        CargarDistribuidores(); // Recarga las tarjetas si se agregó uno nuevo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de agregar distribuidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Filtra los distribuidores según el texto ingresado
        private void Buscador()
        {
            try
            {
                string busqueda = txt_buscar.Texts.ToLower(); // Texto de búsqueda
                int columnas = 3, anchoCarta = 385, altoCarta = 204, espacio = 10;

                var todasLasCartas = panel_cards.Controls.OfType<card_distribuidores>().ToList();

                // Filtra las tarjetas que contienen el texto buscado
                var cartasFiltradas = todasLasCartas
                    .Where(c => c.NombreDistribuidora_card.ToLower().Contains(busqueda))
                    .ToList();

                // Las que no coinciden
                var cartasNoFiltradas = todasLasCartas
                    .Where(c => !cartasFiltradas.Contains(c))
                    .ToList();

                // Ordena: primero las coincidencias visibles
                var cartasOrdenadas = cartasFiltradas.Concat(cartasNoFiltradas).ToList();

                int indice = 0;
                foreach (var card in cartasOrdenadas)
                {
                    int fila = indice / columnas;
                    int columna = indice % columnas;
                    card.Left = columna * (anchoCarta + espacio);
                    card.Top = fila * (altoCarta + espacio);
                    card.Visible = cartasFiltradas.Contains(card); // Muestra solo las que coinciden
                    indice++;
                }

                // Vuelve al inicio del scroll
                panel_cards.AutoScrollPosition = new Point(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda de distribuidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Activa el buscador mientras el usuario escribe
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }
    }
}
