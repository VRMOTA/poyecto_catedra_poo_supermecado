using poyecto_catedra_poo_supermecado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_supermercado
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            if(txtClave.Texts=="123" && txtCorreo.Texts == "123")
            {
                this.Hide();
                new frm_dashboard_cajero().ShowDialog();
            }
            else if (txtClave.Texts == "456" && txtCorreo.Texts == "456")
            {
                this.Hide();
                new frm_dashboard_admin().ShowDialog();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
