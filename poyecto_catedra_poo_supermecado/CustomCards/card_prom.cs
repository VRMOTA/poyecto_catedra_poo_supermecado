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
        [Category("Promocion"), Description("Precion de la promocion")]
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
        [Category("Promocion"), Description("Fecha de inicio de la promocion ")]
        public DateTime Fecha_Inicio
        {
            get => DateTime.TryParse(lb_fecha_inicio?.Text, out DateTime result) ? result : DateTime.Now;
            set { if (lb_fecha_inicio != null) lb_fecha_inicio.Text = value.ToString("dd-MM-yyyy"); }
        }
        [Category("Promocion"), Description("Fecha de finalizacion de la promocion ")]
        public DateTime Fecha_Fin
        {
            get => DateTime.TryParse(lb_fecha_fin?.Text, out DateTime result) ? result : DateTime.Now;
            set { if (lb_fecha_fin != null) lb_fecha_fin.Text = value.ToString("dd-MM-yyyy"); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_promocion("Actualizar nuevo producto", "Actualizar");

            // Pasar datos actuales
            modal.ID_Promocion = ID_Promocion; 
            modal.Cantidad_minima = Cantidad_Minima; 
            modal.Precio_promocional = Precio_Promocion.ToString("F2"); 
            modal.Descripcion = Descripcion_Promocion; 
            modal.Fecha_inicio = Fecha_Inicio;
            modal.Fecha_final = Fecha_Fin;



            // Evaluar como hacer lo de actiov y inactivo 

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
                var producto = db.tb_promociones.Find(ID_Promocion);
                if (producto != null)
                {
                   
                    Cantidad_Minima = producto.cantidad_minima ?? 0;
                    Precio_Promocion = producto.precio_promocional ?? 0;
                    Descripcion_Promocion = producto.descripcion;
                    Fecha_Inicio = producto.fecha_inicio ?? DateTime.Now;
                    Fecha_Fin = producto.fecha_fin ?? DateTime.Now;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
          "¿Está seguro que desea eliminar el registro?",
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
                        MessageBox.Show("Prohebedor eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Prohebedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
