using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class card_categories : RoundedControlBase
    {
        private int id_categoria;
        public event EventHandler<int> BotonVisualizarClick;
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_categories()
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
            var modal = new md_agregar_categoria("Editar Categoria", "Guardar cambios");

            modal.ID_Categories = id_categoria;
            modal.NombreCategoria = NombreCategoria;

            if (modal.ShowDialog() == DialogResult.OK)
            {
                RecargaRequerida?.Invoke(this, EventArgs.Empty);
            }
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
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var categoria = db.tb_categorias.Find(id_categoria);
                    if (categoria != null)
                    {
                        db.tb_categorias.Remove(categoria);
                        db.SaveChanges();
                        MessageBox.Show("Categoría eliminada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RecargaRequerida?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Categoría no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void CargarDatosCategoria()
        {
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var categoria = db.tb_categorias.Find(id_categoria);
                if (categoria != null)
                {
                    NombreCategoria = categoria.nombre;
                }
            }
        }
    }
}