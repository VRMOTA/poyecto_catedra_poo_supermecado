using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomModals;
using poyecto_catedra_poo_supermecado.Data;
using poyecto_catedra_poo_supermecado.Models;
using poyecto_catedra_poo_supermecado.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    /// <summary>
    /// Formulario mejorado aplicando conceptos académicos de POO104
    /// Demuestra uso de herencia, clases estáticas y Entity Framework con LINQ
    /// </summary>
    public partial class frm_usuarios : Form
    {
        public frm_usuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        /// <summary>
        /// Método mejorado que aplica conceptos académicos de Entity Framework y LINQ
        /// </summary>
        private void CargarUsuarios()
        {
            int columnas = 2;
            int espacio = 10;

            List<dynamic> listaUsuarios;

            // Usar el contexto académico mejorado
            using (var db = new SupermercadoContext())
            {
                // LINQ sintaxis textual (estilo académico)
                listaUsuarios = (from u in db.Usuarios
                               where u.activo == true
                               orderby u.nombre ascending
                               select new
                               {
                                   u.id_usuario,
                                   u.nombre,
                                   u.correo,
                                   u.tipo_usuario,
                                   u.activo
                               }).ToList<dynamic>();
            }

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;
            Size cardSize = new Size(495, 107);

            int indice = 0;
            foreach (var usuarioDB in listaUsuarios)
            {
                // Aplicar herencia: crear instancia según tipo de usuario
                Usuario usuario = CrearUsuarioSegunTipo(usuarioDB);

                var card = new card_usuarios
                {
                    IDUsuario = usuarioDB.id_usuario,
                    NombreUsuario = usuarioDB.nombre,
                    CorreoUsuario = usuarioDB.correo,
                    Activa = usuarioDB.activo ? "Activo" : "Inactivo",
                    Margin = new Padding(espacio),
                    Size = cardSize
                };

                // Usar método polimórfico para mostrar información específica del tipo de usuario
                string tipoUsuario = usuario.ObtenerTipoUsuario();
                card.Text += $" ({tipoUsuario})"; // Mostrar tipo en la card

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

        /// <summary>
        /// Método académico que demuestra HERENCIA SIMPLE
        /// Crea instancias de subclases según el tipo de usuario de la base de datos
        /// </summary>
        private Usuario CrearUsuarioSegunTipo(dynamic usuarioDB)
        {
            // Aplicar herencia: crear instancia según tipo específico
            if (usuarioDB.tipo_usuario == "Administrador")
            {
                // Crear instancia de la subclase Administrador
                return new Administrador(
                    usuarioDB.id_usuario,
                    usuarioDB.nombre,
                    usuarioDB.correo,
                    "" // No mostramos la clave por seguridad
                );
            }
            else if (usuarioDB.tipo_usuario == "Cajero")
            {
                // Crear instancia de la subclase Cajero
                return new Cajero(
                    usuarioDB.id_usuario,
                    usuarioDB.nombre,
                    usuarioDB.correo,
                    "" // No mostramos la clave por seguridad
                );
            }
            else
            {
                // Crear instancia de la clase base Usuario
                return new Usuario(
                    usuarioDB.id_usuario,
                    usuarioDB.nombre,
                    usuarioDB.correo,
                    "" // No mostramos la clave por seguridad
                );
            }
        }

        /// <summary>
        /// Método mejorado usando clases estáticas para validaciones
        /// </summary>
        private void Buscador()
        {
            string busqueda = txt_buscar.Texts.ToLower().Trim();
            
            // Usar clase estática de validaciones
            if (!Validaciones.ValidarTextoNoVacio(busqueda, "Búsqueda"))
            {
                // Si está vacío, mostrar todos los usuarios
                CargarUsuarios();
                return;
            }

            int columnas = 2;
            int espacio = 10;

            var todasLasCartas = panel_cards.Controls.OfType<card_usuarios>().ToList();

            var cartasFiltradas = todasLasCartas
                .Where(c => c.NombreUsuario.ToLower().Contains(busqueda) ||
                           c.CorreoUsuario.ToLower().Contains(busqueda) ||
                           BuscarEstado(c.Activa.ToLower(), busqueda))
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

        private bool BuscarEstado(string estado, string busqueda)
        {
            // Si el estado comienza con la búsqueda, es válido
            if (estado.StartsWith(busqueda))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método del botón agregar usuario aplicando conceptos académicos
        /// </summary>
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

        /// <summary>
        /// Evento de búsqueda en tiempo real
        /// </summary>
        private void txt_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }

        /// <summary>
        /// Método adicional que demuestra uso de Entity Framework con consultas académicas complejas
        /// </summary>
        private void MostrarEstadisticasUsuarios()
        {
            try
            {
                using (var db = new SupermercadoContext())
                {
                    // Consulta académica con LINQ sintaxis textual - contar usuarios por tipo
                    var estadisticasTipos = (from u in db.Usuarios
                                           where u.activo == true
                                           group u by u.tipo_usuario into g
                                           select new
                                           {
                                               TipoUsuario = g.Key,
                                               Cantidad = g.Count()
                                           }).ToList();

                    // Mostrar estadísticas usando clase estática FormateadorDatos
                    string mensaje = "ESTADÍSTICAS DE USUARIOS:\n\n";
                    foreach (var stat in estadisticasTipos)
                    {
                        mensaje += $"{stat.TipoUsuario}: {FormateadorDatos.FormatearCantidad(stat.Cantidad)} usuarios\n";
                    }

                    // Consulta total de usuarios activos
                    int totalUsuarios = db.Usuarios.Count(u => u.activo == true);
                    mensaje += $"\nTotal usuarios activos: {FormateadorDatos.FormatearCantidad(totalUsuarios)}";

                    MessageBox.Show(mensaje, "Estadísticas Académicas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener estadísticas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que demuestra operaciones académicas con las clases POO creadas
        /// </summary>
        private void DemostrarOperacionesPOO()
        {
            try
            {
                using (var db = new SupermercadoContext())
                {
                    // Obtener un administrador de la base de datos
                    var adminDB = db.Usuarios.FirstOrDefault(u => u.tipo_usuario == "Administrador" && u.activo == true);
                    
                    if (adminDB != null)
                    {
                        // Crear instancia de la subclase Administrador
                        Administrador admin = new Administrador(
                            adminDB.id_usuario,
                            adminDB.nombre,
                            adminDB.correo,
                            adminDB.clave
                        );

                        // Usar métodos específicos de la subclase
                        admin.RegistrarOperacion(); // Método propio de Administrador
                        
                        // Usar método polimórfico (sobrescrito)
                        string tipoUsuario = admin.ObtenerTipoUsuario(); // Retorna "Administrador"
                        
                        // Usar método de la clase base
                        string info = admin.ObtenerInformacionCompleta();
                        
                        // Usar método específico que accede a atributo protegido
                        bool puedeGestionar = admin.PuedeGestionarUsuarios();

                        MessageBox.Show(
                            $"DEMOSTRACIÓN POO - HERENCIA:\n\n" +
                            $"Tipo: {tipoUsuario}\n" +
                            $"Info: {info}\n" +
                            $"Puede gestionar: {(puedeGestionar ? "Sí" : "No")}\n" +
                            $"Operaciones realizadas: {admin.NumeroOperacionesRealizadas}",
                            "Ejemplo Académico POO",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en demostración POO: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}