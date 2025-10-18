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
    public partial class md_agregar_distribuidor : Form
    {
        public md_agregar_distribuidor()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            buttonMaxing1.BackColor = Color.FromArgb(105, 105, 105);
        }
        //Propiedades para editar
        public int ID_Distribuidor_vista { get; set; } = 0;

        public string NombreDistribuidor_vista // Propiedad para el nombre del distribuidor
        {
            get => txt_nombre.Texts;
            set => txt_nombre.Texts = value;
        }

        public Image ImagenDistribuidor_vista // Propiedad para la imagen del distribuidor
        {
            get => pbProducto.Image;
            set => pbProducto.Image = value;
        }
        public md_agregar_distribuidor(string labelText, string buttonText) : this() // Sobrecarga del constructor
        {
            label1.Text = labelText;
            btnActualizar.Text = buttonText;
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) // Abrir cuadro de diálogo para seleccionar imagen
            {
                openFileDialog.Title = "Seleccionar imagen";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pbProducto.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre.Texts.Trim();
            Image image = pbProducto.Image;

            if (!Validaciones.ValidarTextoNoVacio(nombre, "Distribuhidor")) return; // Validar que el nombre no esté vacío
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Si es un registro nuevo
                if (ID_Distribuidor_vista == 0)
                {
                    if (image == null) // Validar que se haya seleccionado una imagen
                    {
                        MessageBox.Show("Debe seleccionar una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (MemoryStream ms = new MemoryStream()) // Convertir la imagen a byte array
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imagenBytes = ms.ToArray();

                        tb_distribuidores nuevo = new tb_distribuidores
                        {
                            nombre = nombre, // Asignar el nombre
                            logo = imagenBytes // Asignar la imagen como byte array 
                        };

                        db.tb_distribuidores.Add(nuevo); // Agregar el nuevo distribuidor a la base de datos
                        db.SaveChanges();
                        MessageBox.Show("Distribuidor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // Si es una edición
                else
                {
                    var distribuidor = db.tb_distribuidores.Find(ID_Distribuidor_vista);  // Buscar el distribuidor por ID
                    if (distribuidor != null)
                    {
                        distribuidor.nombre = nombre; // Actualizar el nombre

                        if (image != null)
                        {
                            using (MemoryStream ms = new MemoryStream()) // Convertir la imagen a byte array
                            {
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                distribuidor.logo = ms.ToArray();
                            }
                        }

                        db.SaveChanges();
                        MessageBox.Show("Distribuidor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   
                    else
                    {
                        MessageBox.Show("Distribuidor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void md_agregar_distribuidor_Load(object sender, EventArgs e)
        {

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

