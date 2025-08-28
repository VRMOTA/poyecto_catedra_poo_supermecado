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
    public partial class card_consultas : RoundedControlBase
    {
        // Evento personalizado que se disparará cuando se presione el botón
        public event EventHandler<int> BotonVisualizarClick;
        public card_consultas()
        {
            InitializeComponent();
        }

        [Category("Consulta"), Description("Imagen del producto")]
        public Image ImagenProducto
        {
            get => pbProducto?.Image;
            set { if (pbProducto != null) pbProducto.Image = value; }
        }

        [Category("Consulta"), Description("Nombre del producto")]
        public string NombreProducto
        {
            get => lblProducto?.Text ?? string.Empty;
            set { if (lblProducto != null) lblProducto.Text = value; }
        }

        [Category("Consulta"), Description("Nombre del cliente")]
        public string NombreCliente
        {
            get => lblCliente?.Text ?? string.Empty;
            set { if (lblCliente != null) lblCliente.Text = value; }
        }
    }
}