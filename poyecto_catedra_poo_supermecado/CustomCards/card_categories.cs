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
        // Evento personalizado que se disparará cuando se presione el botón
        public event EventHandler<int> BotonVisualizarClick;
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

            // Pasar datos actuales
            modal.ID_Categories = id_categoria;
            modal.NombreCategoria = NombreCategoria;
 

            // Mostrar modal y refrescar si se actualizó
            if (modal.ShowDialog() == DialogResult.OK)
            {
                CargarDatosCategoria();
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
                using (db_supermercadoEntities db = new db_supermercadoEntities())
                {
                    var categoria = db.tb_categorias.Find(id_categoria);
                    if (categoria != null)
                    {
                        db.tb_categorias.Remove(categoria);
                        db.SaveChanges();
                        MessageBox.Show("Prohebedor eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Prohebedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        //Recarga los datos actualizados del distribuidor
        public void CargarDatosCategoria()
        {
            using (db_supermercadoEntities db = new db_supermercadoEntities())
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