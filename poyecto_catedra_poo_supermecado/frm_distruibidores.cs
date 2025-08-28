using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.CustomCards;

namespace poyecto_catedra_poo_supermecado
{
    public partial class frm_distruibidores : Form
    {
        public frm_distruibidores()
        {
            InitializeComponent();
            pnl_principal.BackColor = Color.FromArgb(245, 245, 245);
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
                ("Distribuidora 1", "Alimentos", Properties.Resources.Rigbyyyy),
                ("Distribuidora 2", "Bebidas", Properties.Resources.Rigbyyyy),
                ("Distribuidora 3", "Limpieza", Properties.Resources.Rigbyyyy),
                ("Distribuidora 4", "Higiene", Properties.Resources.Rigbyyyy),
                ("Distribuidora 5", "Electrónica", Properties.Resources.Rigbyyyy),
                ("Distribuidora 6", "Ropa", Properties.Resources.Rigbyyyy),
                ("Distribuidora 7", "Juguetes", Properties.Resources.Rigbyyyy),
                ("Distribuidora 8", "Papelería", Properties.Resources.Rigbyyyy),
                ("Distribuidora 9", "Mascotas", Properties.Resources.Rigbyyyy),
                ("Distribuidora 10", "Ferretería", Properties.Resources.Rigbyyyy),
                ("Distribuidora 11", "Ferretería", Properties.Resources.Rigbyyyy),
                ("Distribuidora 12", "Ferretería", Properties.Resources.Rigbyyyy),
                ("Distribuidora 13", "Ferretería", Properties.Resources.Rigbyyyy)
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
    }
}
