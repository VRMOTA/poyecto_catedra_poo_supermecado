using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomModals;
using poyecto_catedra_poo_supermecado.Models;
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
        private model_categoria categoria_modelo;
        public event EventHandler<int> BotonVisualizarClick;
        public event EventHandler RecargaRequerida; // Nuevo evento para recargar

        public card_categories()
        {
            InitializeComponent();
            categoria_modelo = new model_categoria();
        }

        public int ID_Categoria_Card
        {
            get => categoria_modelo.ID_Categoria_Modelo;
            set => categoria_modelo.ID_Categoria_Modelo = value;
        }

        [Category("Categoria"), Description("Nombre de la categoria")]
        public string NombreCategoria_Card
        {
            get => categoria_modelo.NombreCategoria_Modelo;
            set 
            { 
                categoria_modelo.NombreCategoria_Modelo = value;
                if (lblNombre_categoria != null) lblNombre_categoria.Text = value;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var modal = new md_agregar_categoria("Editar Categoria", "Guardar cambios");

            modal.ID_Categories_vista = ID_Categoria_Card;
            modal.NombreCategoria_vista = NombreCategoria_Card;

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
                    var categoria = db.tb_categorias.Find(ID_Categoria_Card);
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
                var categoria = db.tb_categorias.Find(ID_Categoria_Card);
                if (categoria != null)
                {
                    NombreCategoria_Card = categoria.nombre;
                }
            }
        }
    }
}