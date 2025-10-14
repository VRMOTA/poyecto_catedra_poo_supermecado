using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_promociones : Form
    {
        public frm_promociones()
        {
            InitializeComponent();
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_agregar_promociones())
            {
                modal.ShowDialog();
            }
        }
    }
}
