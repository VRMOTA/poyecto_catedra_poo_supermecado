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
                listaUsuarios = db.tb_usuario
                    .Select(u => new
                    {
                        u.id_usuario,
                        u.nombre,
                        u.correo,
                        // COMBO BOX CAMBIAR NIVEL
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

        private void Buscador()
        {
            string busqueda = txt_buscar.Texts.ToLower();
            int columnas = 2;
            int espacio = 10;

            // Obtener todas las cartas
            var todasLasCartas = panel_cards.Controls.OfType<card_usuarios>().ToList();

            // Separar en filtradas y no filtradas
            var cartasFiltradas = todasLasCartas
                .Where(c => c.NombreUsuario.ToLower().Contains(busqueda) ||
                           c.CorreoUsuario.ToLower().Contains(busqueda))
                .ToList();

            var cartasNoFiltradas = todasLasCartas
                .Where(c => !cartasFiltradas.Contains(c))
                .ToList();

            // Reposicionar: primero las filtradas, luego las no filtradas
            var cartasOrdenadas = cartasFiltradas.Concat(cartasNoFiltradas).ToList();

            for (int i = 0; i < cartasOrdenadas.Count; i++)
            {
                var card = cartasOrdenadas[i];

                int fila = i / columnas;
                int columna = i % columnas;

                card.Left = columna * (card.Width + espacio);
                card.Top = fila * (card.Height + espacio);
                card.Visible = cartasFiltradas.Contains(card);
            }

            // Scroll al inicio cuando se busca
            panel_cards.AutoScrollPosition = new Point(0, 0);
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_agregar_usuario())
            {
                modal.ShowDialog();
            }
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }
    }
}