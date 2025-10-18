using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.Utilities;

namespace poyecto_catedra_poo_supermecado.Forms
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                abrir_panel(new frm_productos());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el módulo de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                abrir_panel(new frm_usuarios());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el módulo de empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDistribuidores_Click(object sender, EventArgs e)
        {
            try
            {
                abrir_panel(new frm_distribuidores());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el módulo de distribuidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            try
            {
                abrir_panel(new frm_categories());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el módulo de categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                abrir_panel(new frm_default_dashboard_admin_page());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la página principal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_dashboard_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        { // prm
            try
            {
                abrir_panel(new frm_promociones());
            }
            catch
            {
                MessageBox.Show("Error al abrir el módulo de promociones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        { // ventas
            try
            {
                abrir_panel(new frm_ventas_new());
            }
            catch
            {
                MessageBox.Show("Error al abrir el módulo de ventas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
