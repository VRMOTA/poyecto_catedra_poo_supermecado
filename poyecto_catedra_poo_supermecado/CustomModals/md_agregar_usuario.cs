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
        public md_agregar_usuario(string labelText, string buttonText) : this()
        {
            label1.Text = labelText;
            btn_crear.Text = buttonText;
        }


        private void btn_crear_Click(object sender, EventArgs e)
        {
            Agregar();
        }


        void Agregar()
        {
            string nombre = txt_nombre.Texts.Trim();
            string correo = txt_correo.Texts.Trim();
            string clave = txt_clave.Texts.Trim();
            string confirmaClave = txt_confirma_clave.Texts.Trim();

            if (clave != confirmaClave)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                tb_usuario usuario = new tb_usuario
                {
                    nombre = nombre,
                    correo = correo,
                    clave = clave,
                    // AGREGAR COMBO CON EL NIVEL
                };

                db.tb_usuario.Add(usuario);
                db.SaveChanges();

                MessageBox.Show("Usuario agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
