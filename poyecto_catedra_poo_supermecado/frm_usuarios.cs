using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using project_supermercado;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
{
    public partial class frm_usuarios : Form
    {
        public frm_usuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            int columnas = 2;
            int espacio = 10; // Espacio entre cartas

            // Declaramos la lista fuera del using para poder usarla después
            List<dynamic> listaUsuarios;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Seleccionar datos con Entity Framework
                listaUsuarios = db.tb_usario
                    .Select(u => new
                    {
                        u.id_usuario,
                        u.nombre,
                        u.correo,
                        u.nivel_usario
                    }).ToList<dynamic>(); // Convertimos a lista dinámica
            }

            // Limpiar y preparar el panel
            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            Size cardSize = new Size(495, 107); // Tamaño de las tarjetas

            // Crear y posicionar las tarjetas
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                var usuario = listaUsuarios[i]; // Obtenemos el usuario actual

                var card = new card_usuarios
                {
                    IDUsuario = usuario.id_usuario,
                    NombreUsuario = usuario.nombre,
                    CorreoUsuario = usuario.correo,
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
            int filasNecesarias = (int)Math.Ceiling((double)listaUsuarios.Count / columnas);
            panel_cards.AutoScrollMinSize = new Size(
                columnas * (cardSize.Width + espacio),
                filasNecesarias * (cardSize.Height + espacio)
            );
        }


        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_agregar_usuario())
            {
                modal.ShowDialog();
            }
        }
    }
}
