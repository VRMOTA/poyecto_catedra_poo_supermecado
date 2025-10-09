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
        public card_distribuidores()
        {
            InitializeComponent();
        }
        private int idDistribuidor;
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

        [Category("Distribuidora"), Description("Categoría de productos que distribuyen")]

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_distribuidor("Editar distribuidor", "Guardar cambios");

            // Pasar datos actuales
            modal.IDDistribuidor = idDistribuidor;
            modal.NombreDistribuidor = NombreDistribuidora;
            modal.ImagenDistribuidor = ImagenDistribuidora;

            // Mostrar modal y refrescar si se actualizó
            if (modal.ShowDialog() == DialogResult.OK)
            {
                CargarDatosDistribuidor();
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
                    var distribuhidores = db.tb_distribuidores.Find(idDistribuidor);
                    if (distribuhidores != null)
                    {
                        db.tb_distribuidores.Remove(distribuhidores);
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
        //Recarga los datos actualizados del distribuidor
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