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
        public int ID_Categories { get; set; } = 0;

        public string NombreCategoria
        {
            get => txt_nombre.Texts;
            set => txt_nombre.Texts = value;
        }

        public md_agregar_categoria(string labelText, string buttonText) : this()
        {
            label1.Text = labelText;
            btnActualizar.Text = buttonText;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre.Texts.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar el nombre de la categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Si es un registro nuevo
                if (ID_Categories == 0)
                {
                        tb_categorias nuevo = new tb_categorias
                        {
                            nombre = nombre
                        };

                        db.tb_categorias.Add(nuevo);
                        db.SaveChanges();
                        MessageBox.Show("Categoria agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Si es una edición
                else
                {
                    var categorias = db.tb_categorias.Find(ID_Categories);
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
    }
}
