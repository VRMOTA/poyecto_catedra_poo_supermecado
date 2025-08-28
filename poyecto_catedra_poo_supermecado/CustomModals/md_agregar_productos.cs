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

namespace poyecto_catedra_poo_supermecado.CustomModals
{
    public partial class md_agregar_productos : Form
    {
        public md_agregar_productos()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            buttonMaxing1.BackColor = Color.FromArgb(105, 105, 105);
        }

        public md_agregar_productos(string labelText, string buttonText) : this()
        {
            label1.Text = labelText;
            btnActualizar.Text = buttonText;
        }
    }
}
