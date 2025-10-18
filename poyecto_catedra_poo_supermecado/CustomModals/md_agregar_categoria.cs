using poyecto_catedra_poo_supermecado.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.Utilities;

namespace poyecto_catedra_poo_supermecado.CustomModals
{
    public partial class md_agregar_categoria : Form
    {
        public md_agregar_categoria()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
        }
        //Propiedades para editar
        public int ID_Categories_vista { get; set; } = 0;

        public string NombreCategoria_vista // Propiedad para el nombre de la categoria
        {
            get => txt_nombre.Texts;
            set => txt_nombre.Texts = value;
        }

        public md_agregar_categoria(string labelText, string buttonText) : this() // Sobrecarga del constructor para personalizar textos
        {
            label1.Text = labelText;
            btnActualizar.Text = buttonText;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre.Texts.Trim();
            if (!Validaciones.ValidarTextoNoVacio(nombre, "Categoria")) return; // Validar que el nombre no esté vacío


            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Si es un registro nuevo
                if (ID_Categories_vista == 0)
                {
                    tb_categorias nuevo = new tb_categorias
                    {
                        nombre = nombre
                    };

                    db.tb_categorias.Add(nuevo); // Agregar nueva categoria
                    db.SaveChanges();
                    MessageBox.Show("Categoria agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Si es una edición
                else
                {
                    var categorias = db.tb_categorias.Find(ID_Categories_vista);// Buscar categoria por ID
                    if (categorias != null)
                    {
                        categorias.nombre = nombre;
                        db.SaveChanges();
                        MessageBox.Show("Categoria actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Categoria no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
                //condicion para solo números
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                //para backspace
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                //para que admita tecla de espacio
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                //si no cumple nada de lo anterior que no lo deje pasar
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se admiten letras", "validación de texto",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
        }
    }
}
