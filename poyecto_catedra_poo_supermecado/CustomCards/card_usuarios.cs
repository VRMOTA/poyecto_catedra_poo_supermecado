using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_usuarios : RoundedControlBase
    {

        private int idUsuario;
        public event EventHandler<int> BotonActualizarClick;
        public event EventHandler<int> BotonEliminarClick;
        public int IDUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Disparar el evento pasando el ID del producto
            BotonActualizarClick?.Invoke(this, idUsuario);
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Disparar el evento pasando el ID del producto
            BotonEliminarClick?.Invoke(this, idUsuario);
        }


        public card_usuarios()
        {
            InitializeComponent();

            if (btnActualizar != null)
            {
                btnActualizar.Click += BtnActualizar_Click;
            }

            if (btnEliminar != null)
            {
                btnEliminar.Click += BtnEliminar_Click;
            }
        }

        [Category("Usuario"), Description("Nombre del usuario")]
        public string NombreUsuario
        {
            get => lblNombreUsuario?.Text ?? string.Empty;
            set { if (lblNombreUsuario != null) lblNombreUsuario.Text = value; }
        }

        [Category("Usuario"), Description("Correo electrónico del usuario")]
        public string CorreoUsuario
        {
            get => lblCorreoUsuario?.Text ?? string.Empty;
            set { if (lblCorreoUsuario != null) lblCorreoUsuario.Text = value; }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            var modal = new md_agregar_usuario("Actualizar nuevo usuario", "Actualizar");
            modal.ShowDialog();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
   "¿Está seguro que desea eliminar el registro?",
   "Confirmar eliminación",
   MessageBoxButtons.YesNo,
   MessageBoxIcon.Warning
);

            if (resultado == DialogResult.Yes)
            {

            }
        }
    }
}