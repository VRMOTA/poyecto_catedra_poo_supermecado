using poyecto_catedra_poo_supermecado.Conexion;   
using poyecto_catedra_poo_supermecado.CustomCards; 
using poyecto_catedra_poo_supermecado.CustomModals; 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_promociones : Form
    {
        public frm_promociones()
        {
            InitializeComponent(); 
        }

        // Evento del botón para abrir el modal de agregar una nueva promoción
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre el modal para agregar una nueva promoción
                using (var modal = new md_promocion("Agregar nueva promoción", "Agregar"))
                {
                    // Si se agrega correctamente, recarga las promociones
                    if (modal.ShowDialog() == DialogResult.OK)
                    {
                        CargarProm();
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier error al abrir el modal
                MessageBox.Show($"Error al abrir el formulario de promociones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga todas las promociones desde la base de datos
        private void CargarProm()
        {
            try
            {
                int espacio = 10; // Espacio entre tarjetas
                List<dynamic> lista_promociones;

                // Consulta a la base de datos para obtener las promociones con su producto asociado
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    lista_promociones = (from pr in db.tb_promociones
                                         join p in db.tb_producto on pr.id_producto equals p.id_producto
                                         select new
                                         {
                                             pr.id_promocion,
                                             nombre_producto = p.nombre,
                                             pr.cantidad_minima,
                                             pr.precio_promocional,
                                             pr.descripcion,
                                             pr.fecha_inicio,
                                             pr.fecha_fin,
                                             pr.activa
                                         }).ToList<dynamic>();
                }

                // Limpia el panel antes de agregar nuevas tarjetas
                panel_cards.Controls.Clear();
                panel_cards.AutoScroll = true;
                int posicionY = 0;

                // Recorre las promociones y genera una tarjeta para cada una
                foreach (var promocion in lista_promociones)
                {
                    bool activaValor = promocion.activa != null ? (bool)promocion.activa : false;

                    var card = new card_prom
                    {
                        ID_Promocion_card = (int)promocion.id_promocion,
                        Nombre_Producto_card = promocion.nombre_producto?.ToString() ?? "",
                        Cantidad_Minima_card = promocion.cantidad_minima ?? 0,
                        Precio_Promocion_card = promocion.precio_promocional ?? 0m,
                        Descripcion_Promocion_card = promocion.descripcion?.ToString() ?? "",
                        Fecha_Inicio_card = promocion.fecha_inicio ?? DateTime.Now,
                        Fecha_Fin_card = promocion.fecha_fin ?? DateTime.Now,
                        Activa_card = activaValor,
                        Margin = new Padding(espacio)
                    };

                    // Suscripción al evento de recarga (por si se edita o elimina una promoción)
                    card.RecargaRequerida += (s, e) => CargarProm();

                    // Posiciona la tarjeta en el panel
                    card.Left = 0;
                    card.Top = posicionY;
                    panel_cards.Controls.Add(card);
                    posicionY += card.Height + espacio;
                }

                // Ajusta el tamaño del área desplazable
                panel_cards.AutoScrollMinSize = new Size(
                    panel_cards.Width,
                    posicionY
                );
            }
            catch (Exception ex)
            {
                // Muestra un mensaje en caso de error al cargar las promociones
                MessageBox.Show($"Error al cargar las promociones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se ejecuta cuando el formulario se carga
        private void frm_promociones_Load(object sender, EventArgs e)
        {
            CargarProm(); // Carga las promociones al iniciar el formulario
        }

        // Método para buscar promociones según nombre o estado
        private void Buscador()
        {
            try
            {
                string busqueda = txt_buscar.Texts.ToLower().Trim(); // Texto ingresado en el buscador
                int espacio = 10;

                var todasLasCartas = panel_cards.Controls.OfType<card_prom>().ToList();

                // Filtra las tarjetas según el nombre del producto o su estado (activa/inactiva)
                var cartasFiltradas = todasLasCartas
                    .Where(c => c.Nombre_Producto_card.ToLower().Contains(busqueda) ||
                               BuscarEstado(c.Activa_card, busqueda))
                    .ToList();

                // Oculta las que no coinciden
                foreach (var card in todasLasCartas)
                {
                    card.Visible = cartasFiltradas.Contains(card);
                }

                // Reorganiza solo las cartas visibles
                int posicionY = 0;
                foreach (var card in cartasFiltradas)
                {
                    card.Left = 0;
                    card.Top = posicionY;
                    posicionY += card.Height + espacio;
                }

                // Reinicia la posición del scroll
                panel_cards.AutoScrollPosition = new Point(0, 0);
            }
            catch (Exception ex)
            {
                // Maneja cualquier error en la búsqueda
                MessageBox.Show($"Error en la búsqueda de promociones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Convierte el estado de la promoción en texto y compara con el término buscado
        private bool BuscarEstado(bool activa, string busqueda)
        {
            string estadoTexto = activa ? "activa" : "inactiva"; // Convierte el estado a texto
            return estadoTexto.StartsWith(busqueda.ToLower());   // Compara con la búsqueda
        }

        // Evento que ejecuta el buscador cuando el usuario escribe
        private void textboxMaxing2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador(); // Llama al método de búsqueda en tiempo real
        }
    }
}
