using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_distribuidores : Form
    {
        public frm_distribuidores()
        {
            InitializeComponent();
            CargarDistribuidores();
        }

        private void CargarDistribuidores()
        {
            try
            {
                int columnas = 3;
                int anchoCarta = 385;
                int altoCarta = 204;
                int espacio = 10;

                List<dynamic> lista_distribuidores;

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

                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;

                int indice = 0;
                foreach (var distribuidor in lista_distribuidores)
                {
                    // Convertir byte[] a Image
                    Image imagenDistribuidor = null;
                    if (distribuidor.logo != null)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(distribuidor.logo))
                            {
                                imagenDistribuidor = Image.FromStream(ms);
                            }
                        }
                        catch
                        {
                            imagenDistribuidor = null; // Manejo silencioso si la imagen está corrupta
                        }
                    }

                    var card = new card_distribuidores
                    {
                        ID_Distribuidor_card = distribuidor.id_distribuidor,
                        NombreDistribuidora_card = distribuidor.nombre,
                        ImagenDistribuidora_card = imagenDistribuidor,
                        Width = anchoCarta,
                        Height = altoCarta,
                        Margin = new Padding(espacio)
                    };

                    // Suscribirse al evento de recarga
                    card.RecargaRequerida += (s, e) => CargarDistribuidores();

                    int fila = indice / columnas;
                    int columna = indice % columnas;

                    card.Left = columna * (anchoCarta + espacio);
                    card.Top = fila * (altoCarta + espacio);

                    panel_cards.Controls.Add(card);
                    indice++;
                }

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

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new md_agregar_distribuidor())
                {
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        CargarDistribuidores();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de agregar distribuidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscador()
        {
            try
            {
                string busqueda = txt_buscar.Texts.ToLower();
                int columnas = 3;
                int anchoCarta = 385;
                int altoCarta = 204;
                int espacio = 10;

                var todasLasCartas = panel_cards.Controls.OfType<card_distribuidores>().ToList();

                var cartasFiltradas = todasLasCartas
                    .Where(c => c.NombreDistribuidora_card.ToLower().Contains(busqueda))
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

                    card.Left = columna * (anchoCarta + espacio);
                    card.Top = fila * (altoCarta + espacio);
                    card.Visible = cartasFiltradas.Contains(card);
                    indice++;
                }

                panel_cards.AutoScrollPosition = new Point(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda de distribuidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }
    }
}