using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_usuarios : RoundedControlBase
    {
        public card_usuarios()
        {
            InitializeComponent();
        }

        [Category("Usuario"), Description("Nombre del usuario")]
        public string NombreUsuario
        {
            get => lblNombreUsuario?.Text ?? string.Empty;
            set { if (lblNombreUsuario != null) lblNombreUsuario.Text = value; }
        }

        [Category("Usuario"), Description("Correo electrónico del usuario")]
        public string CorreoUsuario
        {
            get => lblCorreoUsuario?.Text ?? string.Empty;
            set { if (lblCorreoUsuario != null) lblCorreoUsuario.Text = value; }
        }
    }
}