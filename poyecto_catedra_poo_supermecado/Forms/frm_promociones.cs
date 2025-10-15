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
    public partial class frm_promociones : Form
    {
        public frm_promociones()
        {
            InitializeComponent();
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_promocion("Agregar nueva promoción", "Agregar"))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarProm();
                }
            }
        }

        private void CargarProm()
        {
            int espacio = 10;
            List<dynamic> lista_promociones;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // SELECT con JOIN para obtener el nombre del producto
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

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;
            int posicionY = 0;

            for (int i = 0; i < lista_promociones.Count; i++)
            {
                var promocion = lista_promociones[i];

                // Convertir explícitamente los valores dinámicos
                bool activaValor = promocion.activa != null ? (bool)promocion.activa : false;

                var card = new card_prom
                {
                    ID_Promocion = (int)promocion.id_promocion,
                    Nombre_Producto = promocion.nombre_producto?.ToString() ?? "",
                    Cantidad_Minima = promocion.cantidad_minima ?? 0,
                    Precio_Promocion = promocion.precio_promocional ?? 0m,
                    Descripcion_Promocion = promocion.descripcion?.ToString() ?? "",
                    Fecha_Inicio = promocion.fecha_inicio ?? DateTime.Now,
                    Fecha_Fin = promocion.fecha_fin ?? DateTime.Now,
                    Activa = activaValor ? "Activo" : "Desactivo",
                    Margin = new Padding(espacio)
                };

                card.Left = 0;
                card.Top = posicionY;
                panel_cards.Controls.Add(card);
                posicionY += card.Height + espacio;
            }

            panel_cards.AutoScrollMinSize = new Size(
                panel_cards.Width,
                posicionY
            );
        }

        private void frm_promociones_Load(object sender, EventArgs e)
        {
            CargarProm();
        }

        private void Buscador()
        {
            string busqueda = txt_buscar.Texts.ToLower();
            int espacio = 10;

            // Obtener todas las cartas de promociones
            var todasLasCartas = panel_cards.Controls.OfType<card_prom>().ToList();

            // Separar en filtradas y no filtradas
            var cartasFiltradas = todasLasCartas
                .Where(c => c.Nombre_Producto.ToLower().Contains(busqueda) ||
                           c.Descripcion_Promocion.ToLower().Contains(busqueda))
                .ToList();

            var cartasNoFiltradas = todasLasCartas
                .Where(c => !cartasFiltradas.Contains(c))
                .ToList();

            // Reposicionar: primero las filtradas, luego las no filtradas
            var cartasOrdenadas = cartasFiltradas.Concat(cartasNoFiltradas).ToList();
            int posicionY = 0;

            for (int i = 0; i < cartasOrdenadas.Count; i++)
            {
                var card = cartasOrdenadas[i];

                card.Left = 0;
                card.Top = posicionY;
                card.Visible = cartasFiltradas.Contains(card);

                if (card.Visible)
                {
                    posicionY += card.Height + espacio;
                }
            }

            // Scroll al inicio cuando se busca
            panel_cards.AutoScrollPosition = new Point(0, 0);
        }

        private void textboxMaxing2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscador();
        }
    }
}