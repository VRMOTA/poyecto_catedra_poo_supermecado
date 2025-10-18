using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using poyecto_catedra_poo_supermecado.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_distribuidores : RoundedControlBase
    {

        private model_distruhibidores model_distruhibidores; // Instancia del modelo
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_distribuidores()
        {
            InitializeComponent();
            model_distruhibidores = new model_distruhibidores(); // Inicializar el modelo
        }

        public int ID_Distribuidor_card // Propiedad para el ID del distribuidor
        {
            get => model_distruhibidores.ID_Distribuidor_model;
            set => model_distruhibidores.ID_Distribuidor_model = value;
        }

        [Category("Distribuidora"), Description("Imagen de la distribuidora")] // Propiedad para la imagen de la distribuidora
        public Image ImagenDistribuidora_card // Propiedad para la imagen de la distribuidora
        {
            get => model_distruhibidores.ImagenDistribuidora_model ?? pbDistribuidora?.Image;
            set
            {
                model_distruhibidores.ImagenDistribuidora_model = value;
                if (pbDistribuidora != null)
                    pbDistribuidora.Image = value;
            }
        }

        [Category("Distribuidora"), Description("Nombre de la distribuidora")]// Propiedad para el nombre de la distribuidora
        public string NombreDistribuidora_card // Propiedad para el nombre de la distribuidora
        {
            get => model_distruhibidores.NombreDistribuidora_model;
            set
            {
                model_distruhibidores.NombreDistribuidora_model = value;
                if (lblDistribuidora != null) lblDistribuidora.Text = value;
            }
        }

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_distribuidor("Editar distribuidor", "Guardar cambios"); // Crear instancia del modal de edición

            modal.ID_Distribuidor_vista = ID_Distribuidor_card; // Pasar el ID del distribuidor al modal
            modal.NombreDistribuidor_vista = NombreDistribuidora_card; // Pasar el nombre del distribuidor al modal
            modal.ImagenDistribuidor_vista = ImagenDistribuidora_card;   // Pasar la imagen del distribuidor al modal

            if (modal.ShowDialog() == DialogResult.OK) // Si se guardaron los cambios
            {
                RecargaRequerida?.Invoke(this, EventArgs.Empty); // Disparar el evento para recargar los datos
                // En el formulario se encuentra el metodo recargar y lo usa parapara disparar el evento junto al metodo
            }
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar el registro?",
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
                        var distribuidor = db.tb_distribuidores.Find(ID_Distribuidor_card); // Buscar el distribuidor por ID
                        if (distribuidor != null)
                        {
                            db.tb_distribuidores.Remove(distribuidor); // Eliminar el distribuidor
                            db.SaveChanges();
                            MessageBox.Show("Distribuidor eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RecargaRequerida?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("Distribuidor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el distribuidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}