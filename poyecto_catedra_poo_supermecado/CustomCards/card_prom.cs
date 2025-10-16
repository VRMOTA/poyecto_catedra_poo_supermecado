using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using poyecto_catedra_poo_supermecado.Models;
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
        private model_promociones model_Promociones; 
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_prom()
        {
            InitializeComponent();
            model_Promociones = new model_promociones();
        }

        public int ID_Promocion_card
        {
            get => model_Promociones.ID_Promocion_model;
            set => model_Promociones.ID_Promocion_model = value;
        }

        [Category("Promocion"), Description("Nombre del Producto")]
        public string Nombre_Producto_card
        {
            get => model_Promociones.Nombre_Producto_model;
            set
            {
                model_Promociones.Nombre_Producto_model = value;
                if (lblProducto != null) lblProducto.Text = value;
            }
        }

        [Category("Promocion"), Description("Cantidad minima de la promocion")]
        public int Cantidad_Minima_card
        {   get => model_Promociones.Cantidad_Minima_model;
            set
            {
                model_Promociones.Cantidad_Minima_model = value;
                if (lb_cantidad_min != null) lb_cantidad_min.Text = value.ToString();
            }
        }


        [Category("Promocion"), Description("Precio de la promocion")]
        public decimal Precio_Promocion_card
        {             
            get => model_Promociones.Precio_Promocion_model;
            set
            {
                model_Promociones.Precio_Promocion_model = value;
                if (lb_precio_prom != null) lb_precio_prom.Text = value.ToString("F2");
            }
        }


        [Category("Promocion"), Description("Descripcion de la promocion")]
        public string Descripcion_Promocion_card
        {
            get => model_Promociones.Descripcion_model;
            set
            {
                model_Promociones.Descripcion_model = value;
                if (lblDescripcion != null) lblDescripcion.Text = value;
            }
        }

        [Category("Promocion"), Description("Fecha de inicio de la promocion")]
        public DateTime Fecha_Inicio_card
        {
            get => model_Promociones.Fecha_Inicio_model;
            set
            {
                model_Promociones.Fecha_Inicio_model = value;
                if (lb_fecha_inicio != null) lb_fecha_inicio.Text = value.ToString("dd-MM-yyyy");
            }
        }      
 
        [Category("Promocion"), Description("Fecha de finalizacion de la promocion")]
        public DateTime Fecha_Fin_card
        {             
            get => model_Promociones.Fecha_Fin_model;
            set
            {
                model_Promociones.Fecha_Fin_model = value;
                if (lb_fecha_fin != null) lb_fecha_fin.Text = value.ToString("dd-MM-yyyy");
            }
        }

        [Category("Promocion"), Description("Estado de la promocion")]
        public bool Activa_card
        {
            get => model_Promociones.Activa_model;
            set
            {
                model_Promociones.Activa_model = value;
                if (lb_activo != null) lb_activo.Text = value ? "Sí" : "No";
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_promocion("Actualizar promoción", "Actualizar");

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var promocion = db.tb_promociones.Find(ID_Promocion_card);
                if (promocion != null)
                {
                    modal.ID_Promocion_vista = ID_Promocion_card;
                    modal.IDProducto_vista = promocion.id_producto;
                    modal.Cantidad_minima_vista = promocion.cantidad_minima ?? 0;
                    modal.Precio_promocional_vista = promocion.precio_promocional?.ToString("F2");
                    modal.Descripcion_vista = promocion.descripcion;
                    modal.Fecha_inicio_vista = promocion.fecha_inicio ?? DateTime.Now;
                    modal.Fecha_final_vista = promocion.fecha_fin ?? DateTime.Now;
                    modal.Activa_vista = promocion.activa ?? false;
                }
            }

            if (modal.ShowDialog() == DialogResult.OK)
            {
                RecargaRequerida?.Invoke(this, EventArgs.Empty);
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
                    var promocion = db.tb_promociones.Find(ID_Promocion_card);
                    if (promocion != null)
                    {
                        db.tb_promociones.Remove(promocion);
                        db.SaveChanges();
                        MessageBox.Show("Promoción eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecargaRequerida?.Invoke(this, EventArgs.Empty);
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