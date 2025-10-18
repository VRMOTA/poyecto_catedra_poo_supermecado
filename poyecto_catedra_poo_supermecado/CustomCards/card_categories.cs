using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using poyecto_catedra_poo_supermecado.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_categories : RoundedControlBase
    {
        private model_categoria categoria_modelo; // Instancia del modelo de categoria
        public event EventHandler<int> BotonVisualizarClick;
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_categories()
        {
            InitializeComponent();
            categoria_modelo = new model_categoria(); // Inicializar el modelo
        }

        public int ID_Categoria_Card //Propiedad para el ID de la categoria
        {
            get => categoria_modelo.ID_Categoria_Modelo;
            set => categoria_modelo.ID_Categoria_Modelo = value;
        }

        [Category("Categoria"), Description("Nombre de la categoria")]// Propiedad para el nombre de la categoria
        public string NombreCategoria_Card// Propiedad para el nombre de la categoria
        {
            get => categoria_modelo.NombreCategoria_Modelo;
            set
            {
                categoria_modelo.NombreCategoria_Modelo = value;
                if (lblNombre_categoria != null) lblNombre_categoria.Text = value;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_categoria("Editar Categoria", "Guardar cambios"); // Abrir modal en modo edición

            modal.ID_Categories_vista = ID_Categoria_Card; // Pasar el ID de la categoria al modal
            modal.NombreCategoria_vista = NombreCategoria_Card;// Pasar el nombre de la categoria al modal

            if (modal.ShowDialog() == DialogResult.OK) // Si se guardaron los cambios
            {
                RecargaRequerida?.Invoke(this, EventArgs.Empty); // Disparar el evento para recargar
                // En el formulario se encuentra el metodo recargar y lo usa parapara disparar el evento junto al metodo
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar el registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ); // Mensaje de confirmación

            if (resultado == DialogResult.Yes) // Si el usuario confirma
            {
                try
                {
                    using (db_supermercadoEntities1 db = new db_supermercadoEntities1()) // Conexión a la base de datos
                    {
                        var categoria = db.tb_categorias.Find(ID_Categoria_Card); // Buscar la categoría por ID
                        if (categoria != null) // Si se encuentra la categoría
                        {
                            db.tb_categorias.Remove(categoria); 
                            db.SaveChanges();
                            MessageBox.Show("Categoría eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RecargaRequerida?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Categoría no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}