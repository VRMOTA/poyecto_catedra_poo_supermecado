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
    public partial class frm_dashboard_cajero : Form
    {
        public frm_dashboard_cajero()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            navegador.BackColor = Color.FromArgb(204, 0, 0);
            btn_menu.BackColor = Color.FromArgb(204, 0, 0);
            btn_carrito.BackColor = Color.FromArgb(204, 0, 0);
            btn_categoria.BackColor = Color.FromArgb(204, 0, 0);
            btn_menu.FlatAppearance.BorderColor = Color.FromArgb(204, 0, 0);
            btn_salir.BackColor = Color.FromArgb(204, 0, 0);
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            frm_login login = new frm_login();  
            this.Hide();
            login.Show(); 
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            // Elimina todos los controles abiertos en el panel
            this.panel_control.Controls.Clear();
        }

        private void btn_consultas_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_categories());
        }

        private void btn_carrito_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_carrito_cajero());
        }

        private void btn_categoria_Click(object sender, EventArgs e)
        {
            abrir_panel(new frm_catalogo_cajero());
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

        private void frm_dashboard_cajero_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicacion al cerrar el formulario
        }
    }
}
