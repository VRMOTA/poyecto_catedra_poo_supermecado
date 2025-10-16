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

        private model_distruhibidores model_distruhibidores;
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_distribuidores()
        {
            InitializeComponent();
            model_distruhibidores = new model_distruhibidores(); 
        }

        public int ID_Distribuidor_card
        {
            get => model_distruhibidores.ID_Distribuidor_model;
            set => model_distruhibidores.ID_Distribuidor_model = value;
        }

        [Category("Distribuidora"), Description("Imagen de la distribuidora")]
        public Image ImagenDistribuidora_card
        {
            get => model_distruhibidores.ImagenDistribuidora_model ?? pbDistribuidora?.Image;
            set
            {
                model_distruhibidores.ImagenDistribuidora_model = value;
                if (pbDistribuidora != null)
                    pbDistribuidora.Image = value;
            }
        }

        [Category("Distribuidora"), Description("Nombre de la distribuidora")]
        public string NombreDistribuidora_card
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
            var modal = new md_agregar_distribuidor("Editar distribuidor", "Guardar cambios");

            modal.ID_Distribuidor_vista = ID_Distribuidor_card;
            modal.NombreDistribuidor_vista = NombreDistribuidora_card;
            modal.ImagenDistribuidor_vista = ImagenDistribuidora_card;

            if (modal.ShowDialog() == DialogResult.OK)
            {
                RecargaRequerida?.Invoke(this, EventArgs.Empty);
            }
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
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
                    var distribuidor = db.tb_distribuidores.Find(ID_Distribuidor_card);
                    if (distribuidor != null)
                    {
                        db.tb_distribuidores.Remove(distribuidor);
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
        }
    }
}