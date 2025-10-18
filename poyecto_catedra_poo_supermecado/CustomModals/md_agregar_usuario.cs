using poyecto_catedra_poo_supermecado.CustomControls;
using poyecto_catedra_poo_supermecado.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using poyecto_catedra_poo_supermecado.Utilities;

namespace poyecto_catedra_poo_supermecado.CustomModals
{
    public partial class md_agregar_usuario : Form
    {
        public md_agregar_usuario()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
        }

        public md_agregar_usuario(string labelText, string buttonText) : this() // Llama al constructor predeterminado
        {
            label1.Text = labelText;
            btn_crear.Text = buttonText;
        }

        public int id_Usuario_vista { get; set; } = 0;// Valor predeterminado 0 para nuevo usuario

        public string nombre_usuario_vista // propiedad para obtener el nombre del usuario
        {
            get => txt_nombre.Texts;
            set => txt_nombre.Texts = value;
        }

        public string correo_usuario_vista// propiedad para obtener el correo del usuario
        {
            get => txt_correo.Texts;
            set => txt_correo.Texts = value;
        }
        public string tipo_usuario_vista // propiedad para obtener el tipo de usuario
        {
            get => cmb_rol.SelectedItem?.ToString() ?? "";
            set => cmb_rol.SelectedItem = value;
        }

        public bool activo_usuario_vista // propiedad para obtener el estado del usuario
        {
            get => cmb_activo.Texts.ToLower() == "activo";
            set => cmb_activo.Texts = value ? "Activo" : "Inactivo";
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            if (id_Usuario_vista > 0)
            {
                Actualizar();
            }
            else
            {
                Agregar();
            }
        }

        void Agregar()
        {
            // Obtener los valores de los campos
            string nombre = txt_nombre.Texts.Trim();
            string correo = txt_correo.Texts.Trim();
            string clave = txt_clave.Texts.Trim();
            string rol = cmb_rol.SelectedItem?.ToString() ?? "";
            string nivelTexto = cmb_activo.SelectedItem?.ToString() ?? "";
            byte nivel = (nivelTexto == "Activo") ? (byte)1 : (byte)0;
            string confirmaClave = txt_confirma_clave.Texts.Trim();


            if (!Validaciones.ValidarTextoNoVacio(nombre, "Nombre")) return; // Validar nombre no vacío
            if (!Validaciones.ValidarTextoNoVacio(correo, "Correo")) return;// Validar correo no vacío
            if (!Validaciones.ValidarTextoNoVacio(clave, "Clave")) return;// Validar clave no vacío
            if (string.IsNullOrWhiteSpace(cmb_rol.Texts)) // Validar selección de rol
            {
                MessageBox.Show("Debe seleccionar un Rol (Administrador o Cajero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmb_activo.Texts))// Validar selección de estado
            {
                MessageBox.Show("Debe seleccionar un estado (Activo o Inactivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clave != confirmaClave)// Validar que las contraseñas coincidan
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Encriptar la contraseña antes de guardarla
                string claveEncriptada = SeguridadHelper.HashPassword(clave);

                tb_usuario usuario = new tb_usuario
                {
                    // Asignar los valores a las propiedades del nuevo usuario
                    nombre = nombre,
                    correo = correo,
                    clave = claveEncriptada,
                    tipo_usuario = rol,
                    activo = (nivel == 1),
                };

                db.tb_usuario.Add(usuario);
                db.SaveChanges();
                MessageBox.Show("Usuario agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        void Actualizar()
        {
            // Obtener los valores de los campos
            string nombre = txt_nombre.Texts.Trim();
            string correo = txt_correo.Texts.Trim();
            string clave = txt_clave.Texts.Trim();
            string rol = cmb_rol.SelectedItem?.ToString() ?? "";
            string nivelTexto = cmb_activo.SelectedItem?.ToString() ?? "";
            byte nivel = (nivelTexto == "Activo") ? (byte)1 : (byte)0;
            string confirmaClave = txt_confirma_clave.Texts.Trim();

            if (!Validaciones.ValidarTextoNoVacio(nombre, "Nombre")) return; // Validar nombre no vacío
            if (!Validaciones.ValidarTextoNoVacio(correo, "Correo")) return;// Validar correo no vacío
            if (!Validaciones.ValidarTextoNoVacio(clave, "Clave")) return;// Validar clave no vacío
            if (string.IsNullOrWhiteSpace(cmb_rol.Texts)) // Validar selección de rol
            {
                MessageBox.Show("Debe seleccionar un Rol (Administrador o Cajero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmb_activo.Texts))// Validar selección de estado
            {
                MessageBox.Show("Debe seleccionar un estado (Activo o Inactivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(clave) && clave != confirmaClave) //  Validar que las contraseñas coincidan si se proporciona una nueva contraseña
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var usuario = db.tb_usuario.Find(id_Usuario_vista); // Buscar el usuario por ID
                if (usuario != null)
                {
                    // Actualizar los valores del usuario
                    usuario.nombre = nombre;
                    usuario.correo = correo;
                    if (!string.IsNullOrEmpty(clave))
                    {
                        // Encriptar la nueva contraseña antes de guardarla
                        usuario.clave = SeguridadHelper.HashPassword(clave);
                    }
                    usuario.tipo_usuario = rol;
                    usuario.activo = (nivel == 1);

                    db.SaveChanges();
                    MessageBox.Show("Usuario actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //para que admita tecla de espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}