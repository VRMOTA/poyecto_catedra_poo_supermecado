using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
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
            int columnas = 2;
            int espacio = 10; // Espacio entre cartas

            // Declaramos la lista fuera del using para poder usarla después
            List<dynamic> listaCat;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Seleccionar datos con Entity Framework
                listaCat = db.tb_categorias
                    .Select(u => new
                    {
                        u.id_categoria,
                        u.nombre,
                    }).ToList<dynamic>(); // Convertimos a lista dinámica
            }

            // Limpiar y preparar el panel
            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            Size cardSize = new Size(495, 107); // Tamaño de las tarjetas

            // Crear y posicionar las tarjetas
            for (int i = 0; i < listaCat.Count; i++)
            {
                var cat = listaCat[i]; // Obtenemos el usuario actual

                var card = new card_categories
                {
                    ID_Categoria = cat.id_cat,
                    NombreCategoria = cat.nombre,
                    Margin = new Padding(espacio),
                    Size = cardSize
                };

                int fila = i / columnas;
                int columna = i % columnas;

                card.Left = columna * (card.Width + espacio);
                card.Top = fila * (card.Height + espacio);

                panel_cards.Controls.Add(card);
            }

            // Ajustar el área de scroll
            int filasNecesarias = (int)Math.Ceiling((double)listaCat.Count / columnas);
            panel_cards.AutoScrollMinSize = new Size(
                columnas * (cardSize.Width + espacio),
                filasNecesarias * (cardSize.Height + espacio)
            );
        }
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_agregar_categoria())
            {
                modal.ShowDialog();
            }
        }
    }
}
