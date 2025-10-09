using poyecto_catedra_poo_supermecado.Conexion;
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

namespace poyecto_catedra_poo_supermecado.CustomCards
{
    public partial class cardcategorias : RoundedControlBase
    {

        private int id_categoria;
        public event EventHandler<int> BotonActualizarClick;
        public event EventHandler<int> BotonEliminarClick;
        public int ID_categoria
        {
            get => id_categoria;
            set => id_categoria = value;
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Disparar el evento pasando el ID del producto
            BotonActualizarClick?.Invoke(this, ID_categoria);
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Disparar el evento pasando el ID del producto
            BotonEliminarClick?.Invoke(this, ID_categoria);
        }


        public cardcategorias()
        {
            InitializeComponent();

            if (btnActualizar != null)
            {
                btnActualizar.Click += BtnActualizar_Click;
            }

            if (btnEliminar != null)
            {
                btnEliminar.Click += BtnEliminar_Click;
            }
        }

        [Category("Categoria"), Description("Nombre de la categoria")]
        public string NombreUsuario
        {
            get => lblNombre_categorias?.Text ?? string.Empty;
            set { if (lblNombre_categorias != null) lblNombre_categorias.Text = value; }
        }
 
        private void btnActualizar_Click_1(object sender, EventArgs e)
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
            MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                using (db_supermercadoEntities db = new db_supermercadoEntities() )
                {
                    var usuario = db.tb_usario.Find(idUsuario);
                    if (usuario != null)
                    {
                        db.tb_usario.Remove(usuario);
                        db.SaveChanges();
                        MessageBox.Show("Usuario eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}