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
        private model_promociones model_Promociones; // Instancia del modelo
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_prom()
        {
            InitializeComponent();
            model_Promociones = new model_promociones(); // Inicializar el modelo
        }

        public int ID_Promocion_card // Propiedad para el ID de la promocion
        {
            get => model_Promociones.ID_Promocion_model;
            set => model_Promociones.ID_Promocion_model = value;
        }

        [Category("Promocion"), Description("Nombre del Producto")] // Propiedad para el nombre del producto
        public string Nombre_Producto_card // Propiedad para el nombre del producto
        {
            get => model_Promociones.Nombre_Producto_model;
            set
            {
                model_Promociones.Nombre_Producto_model = value;
                if (lblProducto != null) lblProducto.Text = value;
            }
        }

        [Category("Promocion"), Description("Cantidad minima de la promocion")] // Propiedad para la cantidad minima de la promocion
        public int Cantidad_Minima_card // Propiedad para la cantidad minima de la promocion
        {
            get => model_Promociones.Cantidad_Minima_model;
            set
            {
                model_Promociones.Cantidad_Minima_model = value;
                if (lb_cantidad_min != null) lb_cantidad_min.Text = value.ToString();
            }
        }


        [Category("Promocion"), Description("Precio de la promocion")]// Propiedad para el precio de la promocion
        public decimal Precio_Promocion_card // Propiedad para el precio de la promocion
        {
            get => model_Promociones.Precio_Promocion_model;
            set
            {
                model_Promociones.Precio_Promocion_model = value;
                if (lb_precio_prom != null) lb_precio_prom.Text = value.ToString("F2");
            }
        }


        [Category("Promocion"), Description("Descripcion de la promocion")] // Propiedad para la descripcion de la promocion
        public string Descripcion_Promocion_card // Propiedad para la descripcion de la promocion
        {
            get => model_Promociones.Descripcion_model; // Propiedad para la descripcion de la promocion
            set
            {
                model_Promociones.Descripcion_model = value;
                if (lblDescripcion != null) lblDescripcion.Text = value;
            }
        }

        [Category("Promocion"), Description("Fecha de inicio de la promocion")] // Propiedad para la fecha de inicio de la promocion
        public DateTime Fecha_Inicio_card //    Propiedad para la fecha de inicio de la promocion
        {
            get => model_Promociones.Fecha_Inicio_model;
            set
            {
                model_Promociones.Fecha_Inicio_model = value;
                if (lb_fecha_inicio != null) lb_fecha_inicio.Text = value.ToString("dd-MM-yyyy");
            }
        }

        [Category("Promocion"), Description("Fecha de finalizacion de la promocion")] // Propiedad para la fecha de finalizacion de la promocion
        public DateTime Fecha_Fin_card// Propiedad para la fecha de finalizacion de la promocion
        {
            get => model_Promociones.Fecha_Fin_model;
            set
            {
                model_Promociones.Fecha_Fin_model = value;
                if (lb_fecha_fin != null) lb_fecha_fin.Text = value.ToString("dd-MM-yyyy");
            }
        }

        [Category("Promocion"), Description("Estado de la promocion")] // Propiedad para el estado de la promocion
        public bool Activa_card // Propiedad para el estado de la promocion
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
            try
            {
                var modal = new md_promocion("Actualizar promoción", "Actualizar"); // Crear instancia del modal de edición

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var promocion = db.tb_promociones.Find(ID_Promocion_card); // Buscar la promoción por ID
                    if (promocion != null)
                    {   // Pasar los datos de la promoción al modal
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
                    RecargaRequerida?.Invoke(this, EventArgs.Empty); // Disparar el evento para recargar los datos
                    // En el formulario se encuentra el metodo recargar y lo usa parapara disparar el evento junto al metodo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la promoción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar esta promoción?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ); // Preguntar confirmación al usuario

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (db_supermercadoEntities1 db = new db_supermercadoEntities1()) // Conectar a la base de datos
                    {
                        var promocion = db.tb_promociones.Find(ID_Promocion_card); // Buscar la promoción por ID
                        if (promocion != null)
                        {
                            db.tb_promociones.Remove(promocion); // Eliminar la promoción
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la promoción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}