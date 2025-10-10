using project_supermercado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado
{
    public partial class frm_dashboard_admin : Form
    {
        public frm_dashboard_admin()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            abrir_panel(new frm_default_dashboard_admin_page());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            this.Hide();
            login.Show();
        }

        private void abrir_panel(object formularioHijo) // Metodo para abrir formularios dentro del panel
        {
            if (this.panel_control.Controls.Count > 0)
                this.panel_control.Controls.RemoveAt(0); // Pregunta si hay un formulario abierto y lo cierra
            Form fh = formularioHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_control.Controls.Add(fh);
            this.panel_control.Tag = fh;
            fh.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_productos());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_usuarios());
        }

        private void btnDistribuidores_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_distribuidores());
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_categories());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_default_dashboard_admin_page());
        }

        private void frm_dashboard_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_promociones());
        }
    }
}
