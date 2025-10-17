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
            int espacio = 10;

            List<dynamic> listaUsuarios;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                listaUsuarios = db.tb_usuario
                    .Select(u => new
                    {
                        u.id_usuario,
                        u.nombre,
                        u.correo,
                        u.activo
                    }).ToList<dynamic>();
            }

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;
            Size cardSize = new Size(495, 107);

            int indice = 0;
            foreach (var usuario in listaUsuarios)
            {
                var card = new card_usuarios
                {
                    IDUsuario_card = usuario.id_usuario,
                    NombreUsuario_card = usuario.nombre,
                    CorreoUsuario_card = usuario.correo,
                    Activa_card = usuario.activo ?? false, // Asignar bool directamente
                    Margin = new Padding(espacio),
                    Size = cardSize
                };

                card.RecargaRequerida += (s, e) => CargarUsuarios(); // Recargar la lista al actualizar o eliminar

                int fila = indice / columnas;
                int columna = indice % columnas;

                card.Left = columna * (card.Width + espacio);
                card.Top = fila * (card.Height + espacio);

                panel_cards.Controls.Add(card);
                indice++;
            }

            int filasNecesarias = (int)Math.Ceiling((double)listaUsuarios.Count / columnas);
            panel_cards.AutoScrollMinSize = new Size(
                columnas * (cardSize.Width + espacio),
                filasNecesarias * (cardSize.Height + espacio)
            );
        }

        private void Buscador()
        {
            string busqueda = txt_buscar.Texts.ToLower().Trim();
            int columnas = 2;
            int espacio = 10;

            var todasLasCartas = panel_cards.Controls.OfType<card_usuarios>().ToList();

            var cartasFiltradas = todasLasCartas
                .Where(c => c.NombreUsuario_card.ToLower().Contains(busqueda) ||
                           c.CorreoUsuario_card.ToLower().Contains(busqueda) ||
                           BuscarEstado(c.Activa_card, busqueda))
                .ToList();

            // Primero ocultar todas las cartas que no coinciden
            foreach (var card in todasLasCartas)
            {
                card.Visible = cartasFiltradas.Contains(card);
            }

            // Luego posicionar SOLO las cartas visibles
            int indice = 0;
            foreach (var card in cartasFiltradas)
            {
                int fila = indice / columnas;
                int columna = indice % columnas;

                card.Left = columna * (card.Width + espacio);
                card.Top = fila * (card.Height + espacio);

                indice++;
            }

            panel_cards.AutoScrollPosition = new Point(0, 0);
        }

        private bool BuscarEstado(bool activo, string busqueda)
        {
            // Convertir el bool a string "activo" o "inactivo"
            string estadoTexto = activo ? "activo" : "inactivo";

            // Comparar con la búsqueda
            return estadoTexto.StartsWith(busqueda.ToLower());
        }
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_agregar_usuario())
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }
    }
}