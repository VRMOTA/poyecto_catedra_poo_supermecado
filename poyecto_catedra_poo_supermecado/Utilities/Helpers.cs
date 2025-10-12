using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Utilities
{
    internal class Helpers
    {
        public static void LimpiarControles(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is TextBox textBox)
                    textBox.Clear();
                else if (ctrl is ComboBox comboBox)
                    comboBox.SelectedIndex = -1;
                else if (ctrl is CheckBox checkBox)
                    checkBox.Checked = false;
                else if (ctrl is RadioButton radioButton)
                    radioButton.Checked = false;
                else if (ctrl is DateTimePicker dateTimePicker)
                    dateTimePicker.Value = DateTime.Now;
                else if (ctrl is DataGridView dataGrid)
                    dataGrid.DataSource = null;
                else if (ctrl.HasChildren)
                    LimpiarControles(ctrl);
            }
        }
    }
}
