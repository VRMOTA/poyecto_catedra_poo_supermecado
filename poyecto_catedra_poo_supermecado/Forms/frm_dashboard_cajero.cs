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
using poyecto_catedra_poo_supermecado.Models;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_dashboard_cajero : Form
    {    //Fernando José Gomez Martínez GM251673
         //Jeanfranco Andre Campos López CL250978
         //Darlyn Marisol Romero Argueta RA250216
         //José Alejandro Sánchez Henríquez SH250142
         //Stalin Jafet Dubón Lemus DL251728
        private model_usuario model_usuario;

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
            model_usuario = new model_usuario();
        }

        public frm_dashboard_cajero(model_usuario usuario)
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            navegador.BackColor = Color.FromArgb(204, 0, 0);
            btn_menu.BackColor = Color.FromArgb(204, 0, 0);
            btn_carrito.BackColor = Color.FromArgb(204, 0, 0);
            btn_categoria.BackColor = Color.FromArgb(204, 0, 0);
            btn_menu.FlatAppearance.BorderColor = Color.FromArgb(204, 0, 0);
            btn_salir.BackColor = Color.FromArgb(204, 0, 0);
            model_usuario = usuario;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            // Elimina todos los controles abiertos en el panel
            this.panel_control.Controls.Clear();
        }

        private void btn_consultas_Click(object sender, EventArgs e)
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

        private void btn_carrito_Click(object sender, EventArgs e)
        {
            try
            {
                abrir_panel(new frm_carrito_cajero(model_usuario));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_categoria_Click(object sender, EventArgs e)
        {
            try
            {
                abrir_panel(new frm_catalogo_cajero());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el catálogo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void frm_dashboard_cajero_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
