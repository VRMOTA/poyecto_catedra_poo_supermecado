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
            int columnas = 3;
            int anchoCarta = 385; // Ajusta según el tamaño real de card_distribuidores
            int altoCarta = 204;  // Ajusta según el tamaño real de card_distribuidores
            int espacio = 10;     // Espacio entre cartas

            List<dynamic> lista_distribuidores;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Seleccionar datos con Entity Framework
                lista_distribuidores = db.tb_distribuidores
                    .Select(d => new
                    {
                        d.id_distribuidor,
                        d.nombre,
                        d.logo
                    }).ToList<dynamic>(); // Convertimos a lista dinámica
            }

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            for (int i = 0; i < lista_distribuidores.Count; i++)
            {
                var distribuidor = lista_distribuidores[i]; // Obtenemos el distribuidor actual

                // Convertir byte[] a Image
                Image imagenDistribuidor = null;
                if (distribuidor.logo != null)
                {
                    using (MemoryStream ms = new MemoryStream(distribuidor.logo))
                    {
                        imagenDistribuidor = Image.FromStream(ms);
                    }
                }

                var card = new card_distribuidores
                {
                    IDDistribuidor = distribuidor.id_distribuidor,
                    NombreDistribuidora = distribuidor.nombre,
                    ImagenDistribuidora = imagenDistribuidor,
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

            int filasNecesarias = (int)Math.Ceiling((double)lista_distribuidores.Count / columnas);
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
