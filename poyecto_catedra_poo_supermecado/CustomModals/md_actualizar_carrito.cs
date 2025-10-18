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

namespace poyecto_catedra_poo_supermecado.CustomModals
{
    public partial class md_actualizar_carrito : Form
    {
        public int CantidadActual { get; set; }
        public int NuevaCantidad { get; private set; }

        public int StockDisponible { get; set; }
        public md_actualizar_carrito(int cantidadActual, int stockDisponible)
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            CantidadActual = cantidadActual;
            StockDisponible = stockDisponible;
            txtCantidad.Text = cantidadActual.ToString();
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            string cantidadTexto = txtCantidad.Texts.Trim();
            if (!Validaciones.ValidarTextoNoVacio(cantidadTexto, "Cantidad")) return;
            if (int.TryParse(txtCantidad.Texts, out int cantidad) && cantidad > 0)
            {
                if (cantidad > StockDisponible)   
                {
                    MessageBox.Show($"La cantidad ingresada ({cantidad}) supera el stock disponible ({StockDisponible}).",
                                    "Stock insuficiente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                NuevaCantidad = cantidad;
                //MessageBox.Show(NuevaCantidad.ToString());
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMaxing2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de números",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
