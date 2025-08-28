using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using project_supermercado;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            var usuarios = new List<(string nombre, string correo)>
            {
                ("Juan Pérez", "juan.perez@email.com"),
                ("Ana Gómez", "ana.gomez@email.com"),
                ("Carlos Ruiz", "carlos.ruiz@email.com"),
                ("María López", "maria.lopez@email.com"),
                ("Pedro Sánchez", "pedro.sanchez@email.com"),
                ("Lucía Torres", "lucia.torres@email.com"),
                ("Miguel Castro", "miguel.castro@email.com"),
                ("Sofía Ramos", "sofia.ramos@email.com"),
                ("Diego Fernández", "diego.fernandez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com"),
                ("Laura Martínez", "laura.martinez@email.com")
            };

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            Size cardSize = new Size(495, 107); // Tamaño predeterminado de las tarjetas

            for (int i = 0; i < usuarios.Count; i++)
            {
                var card = new card_usuarios
                {
                    NombreUsuario = usuarios[i].nombre,
                    CorreoUsuario = usuarios[i].correo,
                    Margin = new Padding(espacio),
                    Size = cardSize // Asignar tamaño predeterminado
                };

                int fila = i / columnas;
                int columna = i % columnas;

                card.Left = columna * (card.Width + espacio);
                card.Top = fila * (card.Height + espacio);

                panel_cards.Controls.Add(card);
            }

            int filasNecesarias = (int)Math.Ceiling((double)usuarios.Count / columnas);
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
