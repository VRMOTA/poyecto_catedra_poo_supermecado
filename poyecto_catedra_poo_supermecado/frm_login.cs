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
            if(txtClave.Texts=="clave123" && txtCorreo.Texts == "cajero@root.com")
            {
                this.Hide();
                
            }
        }
    }
}
