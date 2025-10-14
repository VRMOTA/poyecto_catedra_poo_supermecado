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
            using (var modal = new md_promocion())
            {
                modal.ShowDialog();
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
                                     /* where pr.activa == true */
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

            MessageBox.Show("Promociones encontradas: " + lista_promociones.Count);

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var promos = db.tb_promociones.ToList();
                MessageBox.Show("Total promociones en tabla: " + promos.Count);
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var promos = (from pr in db.tb_promociones
                              join p in db.tb_producto on pr.id_producto equals p.id_producto into joined
                              from p in joined.DefaultIfEmpty()
                              select new
                              {
                                  pr.id_promocion,
                                  pr.id_producto,
                                  nombre_producto = p != null ? p.nombre : "(sin producto)"
                              }).ToList();

                var sinProducto = promos.Where(x => x.nombre_producto == "(sin producto)").ToList();
                MessageBox.Show("Promos sin producto: " + sinProducto.Count);
            }

            panel_cards.Controls.Clear();
            panel_cards.AutoScroll = true;

            int posicionY = 0;
            for (int i = 0; i < lista_promociones.Count; i++)
            {
                var promocion = lista_promociones[i];
                var card = new card_prom
                {
                    ID_Promocion = promocion.id_promocion,
                    Nombre_Producto = promocion.nombre_producto,
                    Cantidad_Minima = promocion.cantidad_minima ?? 0,
                    Precio_Promocion = promocion.precio_promocional ?? 0,
                    Descripcion_Promocion = promocion.descripcion,
                    Fecha_Inicio = promocion.fecha_inicio ?? DateTime.Now,
                    Fecha_Fin = promocion.fecha_fin ?? DateTime.Now,
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
    }
}
