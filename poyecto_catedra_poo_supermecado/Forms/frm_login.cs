using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Texts.Trim();
            string clave = txtClave.Texts.Trim();

            if (!Validaciones.ValidarTextoNoVacio(correo, "Correo")) return;
            if (!Validaciones.ValidarTextoNoVacio(clave, "Contraseña")) return;

            try
            {
                using (var db = new db_supermercadoEntities1())
                {
                    var usuario = db.tb_usuario.FirstOrDefault(u => u.correo == correo && u.activo == true);

                    if (usuario == null)
                    {
                        MessageBox.Show("Usuario no encontrado o inactivo.");
                        return;
                    }

                    // Verificar contraseña con hash seguro
                    bool passOk = SeguridadHelper.VerifyPassword(clave, usuario.clave);

                    // Si no coincide, verificar por compatibilidad temporal (texto plano)
                    if (!passOk && usuario.clave == clave)
                    {
                        passOk = true;

                        // Auto-migración: actualizar la contraseña a hash
                        try
                        {
                            usuario.clave = SeguridadHelper.HashPassword(clave);
                            db.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("Ha ocurrido un error al intentar hashear su contraseña previa");
                        }
                    }

                    if (!passOk)
                    {
                        MessageBox.Show("Correo o contraseña incorrectos.");
                        return;
                    }

                    // Login exitoso: abrir interfaz correspondiente
                    if (usuario.tipo_usuario == "Administrador")
                    {
                        Helpers.LimpiarControles(this);
                        this.Hide();
                        new frm_dashboard_admin().ShowDialog();
                        this.Show();
                    }
                    else if (usuario.tipo_usuario == "Cajero")
                    {
                        Helpers.LimpiarControles(this);
                        this.Hide();
                        new frm_dashboard_cajero().ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tipo de usuario no reconocido.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message);
            }
        }

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frm_clientes().ShowDialog();
        }

        private void frm_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
