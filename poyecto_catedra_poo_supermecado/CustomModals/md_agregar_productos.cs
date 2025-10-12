using poyecto_catedra_poo_supermecado.Conexion;
using project_supermercado;
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

namespace poyecto_catedra_poo_supermecado.CustomModals
{
    public partial class md_agregar_productos : Form
    {
        public md_agregar_productos()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            buttonMaxing1.BackColor = Color.FromArgb(105, 105, 105);
        }
        // Propiedades para editar 
        public int IDProducto { get; set; } = 0; 
        public string NombreProducto
        {
            get => txt_nombre.Texts;
            set => txt_nombre.Texts = value;
        }
        public Image ImagenProducto         {
            get => pbProducto.Image;
            set => pbProducto.Image = value;
        }
        public string PrecioProducto // cambiar luego a int  
        {
            get => txt_precio.Texts;
            set => txt_precio.Texts = value;
        } 
        public string StockProducto // cambiar luego a int 
        {
            get => txt_stock.Texts;
            set => txt_stock.Texts = value;
        }
        public string CategoriaProducto
        {
            get => cmb_categoria.Texts;
            set => cmb_categoria.Texts = value;
        }
        public string DistribuidorProducto
        {
            get => cmb_distruhibidora.Texts;
            set => cmb_distruhibidora.Texts = value;
        }
        public string DescripcionProducto
        {
            get => txt_descripcion.Texts;
            set => txt_descripcion.Texts = value;
        }
        public string ActivoProducto
        {
            get => cmb_activo.Texts;
            set => cmb_activo.Texts = value;
        }
        public md_agregar_productos(string labelText, string buttonText) : this()
        {
            label1.Text = labelText;
            btnActualizar.Text = buttonText;
        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
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
            string precioText = txt_precio.Texts.Trim();
            string stockText = txt_stock.Texts.Trim();
            string categoriaText = cmb_categoria.Texts.Trim();
            string distribuidorText = cmb_distruhibidora.Texts.Trim();
            string activoText = cmb_activo.Texts.Trim();
            string descripcion = txt_descripcion.Texts.Trim();
            Image image = pbProducto.Image;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar el nombre del distribuidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                // Si es un registro nuevo
                if (IDProducto == 0)
                {
                    if (image == null)
                    {
                        MessageBox.Show("Debe seleccionar una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imagenBytes = ms.ToArray();

                        tb_producto nuevo = new tb_producto
                        {
                            nombre = nombre, 
                            precio = decimal.TryParse(precioText, out decimal precio) ? precio : (decimal?)null,
                            stock = int.TryParse(stockText, out int stock) ? stock : (int?)null, 
                            id_categoria = int.TryParse(categoriaText, out int categoria) ? categoria : (int?)null, 
                            id_distribuidor = int.TryParse(distribuidorText, out int distribuidor) ? distribuidor : (int?)null, 
                            activo = activoText.ToLower() == "si" ? true : activoText.ToLower() == "no" ? false : (bool?)null,
                            descripcion = descripcion, 
                            imagen = imagenBytes
                        };

                        db.tb_producto.Add(nuevo);
                        db.SaveChanges();
                        MessageBox.Show("Distribuidor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // Si es una edición
                else
                {
                    var producto = db.tb_producto.Find(IDProducto);
                    if (producto != null)
                    {
                        producto.nombre = nombre;
                        producto.precio = decimal.TryParse(precioText, out decimal precio) ? precio : (decimal?)null;
                        producto.stock = int.TryParse(stockText, out int stock) ? stock : (int?)null;
                        producto.id_categoria = int.TryParse(categoriaText, out int categoria) ? categoria : (int?)null;
                        producto.id_distribuidor = int.TryParse(distribuidorText, out int distribuidor) ? distribuidor : (int?)null;
                        producto.activo = activoText.ToLower() == "si" ? true : activoText.ToLower() == "no" ? false : (bool?)null;
                        producto.descripcion = descripcion;

                        if (image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                producto.imagen = ms.ToArray();
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
    }
}
