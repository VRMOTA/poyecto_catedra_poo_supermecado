using poyecto_catedra_poo_supermecado.Conexion; 
using poyecto_catedra_poo_supermecado.Models;    
using poyecto_catedra_poo_supermecado.Utilities;  
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_login : Form
    {
        private model_usuario model_usuario; // Objeto para guardar los datos del usuario logueado

        public frm_login()
        {
            InitializeComponent();                     
            FormHelper.DefaultFormValues(this);         // Asigna valores por defecto al formulario
            model_usuario = new model_usuario();        // Inicializa el modelo de usuario
        }

        // Evento que maneja el clic del botón de inicio de sesión
        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Texts.Trim();     // Obtiene el correo ingresado
            string clave = txtClave.Texts.Trim();       // Obtiene la contraseña ingresada

            // Validaciones básicas de texto no vacío
            if (!Validaciones.ValidarTextoNoVacio(correo, "Correo")) return;
            if (!Validaciones.ValidarTextoNoVacio(clave, "Contraseña")) return;

            try
            {
                using (var db = new db_supermercadoEntities1()) // Crea contexto de base de datos
                {
                    // Busca un usuario activo con el correo ingresado
                    var usuario = db.tb_usuario.FirstOrDefault(u => u.correo == correo && u.activo == true);

                    if (usuario == null)
                    {
                        MessageBox.Show("Usuario no encontrado o inactivo.");
                        return;
                    }

                    // Verifica la contraseña con hash seguro
                    bool passOk = SeguridadHelper.VerifyPassword(clave, usuario.clave);

                    // Compatibilidad temporal: si no coincide el hash, verifica texto plano
                    if (!passOk && usuario.clave == clave)
                    {
                        passOk = true;

                        // Auto-migración: actualiza la contraseña vieja a formato hash
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

                    // Si la contraseña es incorrecta, detiene el login
                    if (!passOk)
                    {
                        MessageBox.Show("Correo o contraseña incorrectos.");
                        return;
                    }

                    // Asigna los datos del usuario al modelo global
                    model_usuario.Id_Usuario = usuario.id_usuario;
                    model_usuario.Nombre_Usuario = usuario.nombre;
                    model_usuario.Tipo_Usuario = usuario.tipo_usuario;

                    // Redirige según el tipo de usuario
                    if (usuario.tipo_usuario == "Administrador")
                    {
                        Helpers.LimpiarControles(this);     // Limpia los campos del formulario
                        this.Hide();                         // Oculta el login
                        new frm_dashboard_admin().ShowDialog(); // Muestra el panel del administrador
                        this.Show();                         // Vuelve a mostrar el login al cerrar
                    }
                    else if (usuario.tipo_usuario == "Cajero")
                    {
                        Helpers.LimpiarControles(this);
                        this.Hide();
                        new frm_dashboard_cajero(model_usuario).ShowDialog(); // Abre el panel del cajero
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
                // Captura cualquier error al conectar con la base de datos
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message);
            }
        }

        // Evento que maneja el clic del segundo botón (abrir formulario de clientes)
        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            this.Hide();                  // Oculta el formulario de login
            new frm_clientes().ShowDialog(); // Abre el formulario de clientes
        }

        // Evento que se ejecuta al cerrar el formulario
        private void frm_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Cierra completamente la aplicación
        }
    }
}
