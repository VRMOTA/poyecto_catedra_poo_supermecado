using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_distribuidores : RoundedControlBase
    {
        private int idDistribuidor;
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_distribuidores()
        {
            InitializeComponent();
        }

        public int IDDistribuidor
        {
            get => idDistribuidor;
            set => idDistribuidor = value;
        }

        [Category("Distribuidora"), Description("Imagen de la distribuidora")]
        public Image ImagenDistribuidora
        {
            get => pbDistribuidora?.Image;
            set { if (pbDistribuidora != null) pbDistribuidora.Image = value; }
        }

        [Category("Distribuidora"), Description("Nombre de la distribuidora")]
        public string NombreDistribuidora
        {
            get => lblDistribuidora?.Text ?? string.Empty;
            set { if (lblDistribuidora != null) lblDistribuidora.Text = value; }
        }

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_distribuidor("Editar distribuidor", "Guardar cambios");

            modal.IDDistribuidor = idDistribuidor;
            modal.NombreDistribuidor = NombreDistribuidora;
            modal.ImagenDistribuidor = ImagenDistribuidora;

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
                    var distribuidor = db.tb_distribuidores.Find(idDistribuidor);
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

        public void CargarDatosDistribuidor()
        {
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var distribuidor = db.tb_distribuidores.Find(idDistribuidor);
                if (distribuidor != null)
                {
                    NombreDistribuidora = distribuidor.nombre;
                    if (distribuidor.logo != null)
                    {
                        using (MemoryStream ms = new MemoryStream(distribuidor.logo))
                        {
                            ImagenDistribuidora = Image.FromStream(ms);
                        }
                    }
                }
            }
        }
    }
}