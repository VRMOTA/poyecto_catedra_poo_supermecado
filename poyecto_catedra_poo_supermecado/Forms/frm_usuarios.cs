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
    {    //Fernando José Gomez Martínez GM251673
         //Jeanfranco Andre Campos López CL250978
         //Darlyn Marisol Romero Argueta RA250216
         //José Alejandro Sánchez Henríquez SH250142
         //Stalin Jafet Dubón Lemus DL251728
        public frm_usuarios()
        {
            InitializeComponent(); 
            CargarUsuarios();      // Carga la lista de usuarios al iniciar el formulario
        }

        // Carga los usuarios desde la base de datos y los muestra en tarjetas
        private void CargarUsuarios()
        {
            try
            {
                int columnas = 2; // Número de columnas en la cuadrícula
                int espacio = 10; // Espacio entre tarjetas

                List<dynamic> listaUsuarios;

                // Obtiene los usuarios desde la base de datos
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

                // Limpia el panel y habilita el scroll
                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;
                Size cardSize = new Size(495, 107);

                int indice = 0;

                // Recorre los usuarios y genera una tarjeta por cada uno
                foreach (var usuario in listaUsuarios)
                {
                    var card = new card_usuarios
                    {
                        IDUsuario_card = usuario.id_usuario,
                        NombreUsuario_card = usuario.nombre,
                        CorreoUsuario_card = usuario.correo,
                        Activa_card = usuario.activo ?? false, // Si es null, asigna false
                        Margin = new Padding(espacio),
                        Size = cardSize
                    };

                    // Suscripción al evento de recarga (si se edita o elimina un usuario)
                    card.RecargaRequerida += (s, e) => CargarUsuarios();

                    // Calcula posición en la cuadrícula
                    int fila = indice / columnas;
                    int columna = indice % columnas;

                    card.Left = columna * (card.Width + espacio);
                    card.Top = fila * (card.Height + espacio);

                    panel_cards.Controls.Add(card);
                    indice++;
                }

                // Calcula el tamaño necesario para el scroll
                int filasNecesarias = (int)Math.Ceiling((double)listaUsuarios.Count / columnas);
                panel_cards.AutoScrollMinSize = new Size(
                    columnas * (cardSize.Width + espacio),
                    filasNecesarias * (cardSize.Height + espacio)
                );
            }
            catch (Exception ex)
            {
                // Muestra un mensaje si ocurre un error
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método de búsqueda de usuarios
        private void Buscador()
        {
            try
            {
                string busqueda = txt_buscar.Texts.ToLower().Trim(); // Texto ingresado en el buscador
                int columnas = 2;
                int espacio = 10;

                var todasLasCartas = panel_cards.Controls.OfType<card_usuarios>().ToList();

                // Filtra las tarjetas según nombre, correo o estado (activo/inactivo)
                var cartasFiltradas = todasLasCartas
                    .Where(c => c.NombreUsuario_card.ToLower().Contains(busqueda) ||
                               c.CorreoUsuario_card.ToLower().Contains(busqueda) ||
                               BuscarEstado(c.Activa_card, busqueda))
                    .ToList();

                // Oculta las que no coinciden con la búsqueda
                foreach (var card in todasLasCartas)
                {
                    card.Visible = cartasFiltradas.Contains(card);
                }

                // Reorganiza las tarjetas visibles
                int indice = 0;
                foreach (var card in cartasFiltradas)
                {
                    int fila = indice / columnas;
                    int columna = indice % columnas;

                    card.Left = columna * (card.Width + espacio);
                    card.Top = fila * (card.Height + espacio);

                    indice++;
                }

                // Reinicia el scroll
                panel_cards.AutoScrollPosition = new Point(0, 0);
            }
            catch (Exception ex)
            {
                // Muestra error si algo falla en la búsqueda
                MessageBox.Show($"Error en la búsqueda de usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Convierte el estado (bool) en texto y lo compara con la búsqueda
        private bool BuscarEstado(bool activo, string busqueda)
        {
            string estadoTexto = activo ? "activo" : "inactivo"; // Traduce el valor booleano
            return estadoTexto.StartsWith(busqueda.ToLower());   // Compara con el texto buscado
        }

        // Abre el modal para agregar un nuevo usuario
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var modal = new md_agregar_usuario())
                {
                    // Si el usuario se agrega correctamente, recarga la lista
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        CargarUsuarios();
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje en caso de error al abrir el modal
                MessageBox.Show($"Error al abrir el formulario de agregar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ejecuta el buscador mientras el usuario escribe
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador(); // Llama al método de búsqueda en tiempo real
        }
    }
}
