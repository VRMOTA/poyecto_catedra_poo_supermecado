using poyecto_catedra_poo_supermecado.Conexion;
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
        public event EventHandler RecargaRequerida; // Evento para solicitar recarga de datos

        public int IDUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            BotonActualizarClick?.Invoke(this, idUsuario);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
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

        [Category("Usuario"), Description("El usuario se encuentra activo")]
        public string Activa
        {
            get => lb_activo?.Text ?? string.Empty;
            set { if (lb_activo != null) lb_activo.Text = value; }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            var modal = new md_agregar_usuario("Actualizar usuario", "Actualizar");

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var usuario = db.tb_usuario.Find(IDUsuario);
                if (usuario != null)
                {
                    modal.id_Usuario = IDUsuario;
                    modal.nombre_usuario = usuario.nombre;
                    modal.correo_usuario = usuario.correo;
                    modal.tipo_usuario = usuario.tipo_usuario;
                    modal.activo_usuario = usuario.activo ?? false;
                }
            }

            if (modal.ShowDialog() == DialogResult.OK)
            {
                RecargaRequerida?.Invoke(this, EventArgs.Empty); // Disparar el evento para recargar
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar el registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var usuario = db.tb_usuario.Find(idUsuario);
                    if (usuario != null)
                    {
                        db.tb_usuario.Remove(usuario);
                        db.SaveChanges();
                        MessageBox.Show("Usuario eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecargaRequerida?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}