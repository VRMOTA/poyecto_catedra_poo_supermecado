using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using poyecto_catedra_poo_supermecado.Models;
using poyecto_catedra_poo_supermecado.Utilities;
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
        private model_usuario model_usuario; // Instancia del modelo
        public event EventHandler<int> BotonActualizarClick;
        public event EventHandler<int> BotonEliminarClick;
        public event EventHandler RecargaRequerida; // Evento para solicitar recarga de datos

        public int IDUsuario_card // Propiedad para el ID del usuario
        {
            get => model_usuario.Id_Usuario;
            set => model_usuario.Id_Usuario = value;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            BotonActualizarClick?.Invoke(this, model_usuario.Id_Usuario); // Disparar el evento con el ID del usuario
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            BotonEliminarClick?.Invoke(this, model_usuario.Id_Usuario); // Disparar el evento con el ID del usuario
        }

        public card_usuarios()
        {
            InitializeComponent();
            model_usuario = new model_usuario();
            if (btnActualizar != null)
            {
                btnActualizar.Click += BtnActualizar_Click;
            }

            if (btnEliminar != null)
            {
                btnEliminar.Click += BtnEliminar_Click;
            }
        }

        [Category("Usuario"), Description("Nombre del usuario")] // Propiedad para el nombre del usuario
        public string NombreUsuario_card
        {
            get => model_usuario.Nombre_Usuario; // Propiedad para el nombre del usuario
            set
            {
                model_usuario.Nombre_Usuario = value;
                if (lblNombreUsuario != null) lblNombreUsuario.Text = value;
            }
        }

        [Category("Usuario"), Description("Correo electrónico del usuario")] // Propiedad para el correo electrónico del usuario
        public string CorreoUsuario_card //  Propiedad para el correo electrónico del usuario
        {
            get => model_usuario.Correo;
            set
            {
                model_usuario.Correo = value;
                if (lblCorreoUsuario != null) lblCorreoUsuario.Text = value;
            }
        }

        [Category("Usuario"), Description("El usuario se encuentra activo")] // Propiedad para el estado activo del usuario
        public bool Activa_card //  Propiedad para el estado activo del usuario
        {
            get => model_usuario.Activo;
            set
            {
                model_usuario.Activo = value;
                if (lb_activo != null) lb_activo.Text = value ? "Activo" : "Inactivo";
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var modal = new md_agregar_usuario("Actualizar usuario", "Actualizar"); // Crear instancia del modal de edición

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var usuario = db.tb_usuario.Find(IDUsuario_card); // Buscar el usuario por ID
                    if (usuario != null)
                    {   // Pasar los datos del usuario al modal
                        modal.id_Usuario_vista = IDUsuario_card;
                        modal.nombre_usuario_vista = usuario.nombre;
                        modal.correo_usuario_vista = usuario.correo;
                        modal.tipo_usuario_vista = usuario.tipo_usuario;
                        modal.activo_usuario_vista = usuario.activo ?? false;
                    }
                }

                if (modal.ShowDialog() == DialogResult.OK)
                {
                    RecargaRequerida?.Invoke(this, EventArgs.Empty); // Disparar el evento para recargar
                    // En el formulario se encuentra el metodo recargar y lo usa parapara disparar el evento junto al metodo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar el registro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning); // Mostrar cuadro de diálogo de confirmación

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                    {
                        var usuario = db.tb_usuario.Find(IDUsuario_card); // Buscar el usuario por ID
                        if (usuario != null)
                        {
                            db.tb_usuario.Remove(usuario);// Eliminar el usuario
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}