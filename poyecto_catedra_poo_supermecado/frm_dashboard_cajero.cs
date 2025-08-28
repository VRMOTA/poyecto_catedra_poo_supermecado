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
            btn_consultas.BackColor = Color.FromArgb(204, 0, 0);
        }
    }
}
