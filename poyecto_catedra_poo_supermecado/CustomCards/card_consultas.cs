using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_consultas : RoundedControlBase
    {
        private int id_categoria;
        // Evento personalizado que se disparará cuando se presione el botón
        public event EventHandler<int> BotonVisualizarClick;
        public card_consultas()
        {
            InitializeComponent();
        }
        public int ID_Categoria
        {
            get => id_categoria;
            set => id_categoria = value;
        }
        [Category("Categoria"), Description("Nombre de la categoria")]
        public string NombreCategoria
        {
            get => lblNombre_categoria?.Text ?? string.Empty;
            set { if (lblNombre_categoria != null) lblNombre_categoria.Text = value; }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_usuario("Actualizar nuevo usuario", "Actualizar");
            modal.ShowDialog();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
            "¿Está seguro que desea eliminar el registro?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {

            }
        }
    }
}