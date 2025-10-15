using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_prom : UserControl
    {
        private int id_promocion;

        public card_prom()
        {
            InitializeComponent();
        }

        public int ID_Promocion
        {
            get => id_promocion;
            set => id_promocion = value;
        }

        [Category("Promocion"), Description("Nombre del Producto")]
        public string Nombre_Producto
        {
            get => lblProducto?.Text ?? string.Empty;
            set { if (lblProducto != null) lblProducto.Text = value; }
        }

        [Category("Promocion"), Description("Cantidad minima de la promocion")]
        public int Cantidad_Minima
        {
            get => int.TryParse(lb_cantidad_min?.Text, out int result) ? result : 0;
            set { if (lb_cantidad_min != null) lb_cantidad_min.Text = value.ToString(); }
        }

        [Category("Promocion"), Description("Precio de la promocion")]
        public decimal Precio_Promocion
        {
            get => decimal.TryParse(lb_precio_prom?.Text, out decimal result) ? result : 0;
            set { if (lb_precio_prom != null) lb_precio_prom.Text = value.ToString("F2"); }
        }

        [Category("Promocion"), Description("Descripcion de la promocion")]
        public string Descripcion_Promocion
        {
            get => lblDescripcion?.Text ?? string.Empty;
            set { if (lblDescripcion != null) lblDescripcion.Text = value; }
        }

        [Category("Promocion"), Description("Fecha de inicio de la promocion")]
        public DateTime Fecha_Inicio
        {
            get => DateTime.TryParse(lb_fecha_inicio?.Text, out DateTime result) ? result : DateTime.Now;
            set { if (lb_fecha_inicio != null) lb_fecha_inicio.Text = value.ToString("dd-MM-yyyy"); }
        }

        [Category("Promocion"), Description("Fecha de finalizacion de la promocion")]
        public DateTime Fecha_Fin
        {
            get => DateTime.TryParse(lb_fecha_fin?.Text, out DateTime result) ? result : DateTime.Now;
            set { if (lb_fecha_fin != null) lb_fecha_fin.Text = value.ToString("dd-MM-yyyy"); }
        }

        [Category("Promocion"), Description("Estado de la promocion")]
        public string Activa 
        {
            get => lb_activo?.Text ?? string.Empty;
            set { if (lb_activo != null) lb_activo.Text = value; }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_promocion("Actualizar promoción", "Actualizar");

            // Obtener los datos completos de la promoción desde la base de datos
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var promocion = db.tb_promociones.Find(ID_Promocion);
                if (promocion != null)
                {
                    // Pasar datos actuales
                    modal.ID_Promocion = ID_Promocion;

                    // Pasar el ID del producto para que se seleccione en el ComboBox
                    modal.IDProducto = promocion.id_producto;

                    modal.Cantidad_minima = promocion.cantidad_minima ?? 0;
                    modal.Precio_promocional = promocion.precio_promocional?.ToString("F2");
                    modal.Descripcion = promocion.descripcion;
                    modal.Fecha_inicio = promocion.fecha_inicio ?? DateTime.Now;
                    modal.Fecha_final = promocion.fecha_fin ?? DateTime.Now;
                    modal.Activa = promocion.activa ?? false;
                }
            }

            // Mostrar modal y refrescar si se actualizó
            if (modal.ShowDialog() == DialogResult.OK)
            {
                CargarDatosPROD();
            }
        }

        public void CargarDatosPROD()
        {
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var promocion = (from pr in db.tb_promociones
                                 join p in db.tb_producto on pr.id_producto equals p.id_producto
                                 where pr.id_promocion == ID_Promocion
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
                                 }).FirstOrDefault();

                if (promocion != null)
                {
                    Nombre_Producto = promocion.nombre_producto;
                    Cantidad_Minima = promocion.cantidad_minima ?? 0;
                    Precio_Promocion = promocion.precio_promocional ?? 0;
                    Descripcion_Promocion = promocion.descripcion;
                    Fecha_Inicio = promocion.fecha_inicio ?? DateTime.Now;
                    Fecha_Fin = promocion.fecha_fin ?? DateTime.Now;
                    Activa = (promocion.activa ?? false) ? "Sí" : "No";
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar esta promoción?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var promociones = db.tb_promociones.Find(ID_Promocion);
                    if (promociones != null)
                    {
                        db.tb_promociones.Remove(promociones);
                        db.SaveChanges();
                        MessageBox.Show("Promoción eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Notificar al padre que debe refrescar
                        this.Parent?.Controls.Remove(this);
                    }
                    else
                    {
                        MessageBox.Show("Promoción no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}