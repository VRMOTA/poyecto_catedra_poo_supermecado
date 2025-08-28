using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using project_supermercado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
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
            int columnas = 3;
            int anchoCarta = 385; // Ajusta según el tamaño real de card_distribuidores
            int altoCarta = 204;  // Ajusta según el tamaño real de card_distribuidores
            int espacio = 10;     // Espacio entre cartas

            // Ejemplo: lista de distribuidores (puedes reemplazar por tu fuente de datos real)
            var distribuidores = new List<(string nombre, string categoria, Image imagen)>
        {
            ("La Constancia " , "Alimentos", Properties.Resources.laconstancia),
            ("Scott", "Bebidas", Properties.Resources.scoot),
            ("Morazan", "Limpieza", Properties.Resources.images),
            ("El mago", "Higiene", Properties.Resources.elmago),
            ("Distribuidora Salvadoreña", "Electrónica", Properties.Resources.distsal),
            ("Siman", "Ropa", Properties.Resources.siman),
        };

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            for (int i = 0; i < distribuidores.Count; i++)
            {
                var card = new card_distribuidores
                {
                    NombreDistribuidora = distribuidores[i].nombre,
                    Categoria = distribuidores[i].categoria,
                    ImagenDistribuidora = distribuidores[i].imagen,
                    Width = anchoCarta,
                    Height = altoCarta,
                    Margin = new Padding(espacio)
                };

                int fila = i / columnas;
                int columna = i % columnas;

                card.Left = columna * (anchoCarta + espacio);
                card.Top = fila * (altoCarta + espacio);

                panel_cards.Controls.Add(card);
            }

            int filasNecesarias = (int)Math.Ceiling((double)distribuidores.Count / columnas);
            panel_cards.AutoScrollMinSize = new Size(
                columnas * (anchoCarta + espacio),
                filasNecesarias * (altoCarta + espacio)
            );
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_agregar_distribuidor())
            {
                modal.ShowDialog();
            }
        }
    }
}
