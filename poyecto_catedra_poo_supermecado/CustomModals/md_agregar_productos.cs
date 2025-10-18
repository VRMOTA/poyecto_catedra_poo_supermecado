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
    public partial class md_agregar_productos : Form
    {
        public md_agregar_productos()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
            buttonMaxing1.BackColor = Color.FromArgb(105, 105, 105);
        }
        // Propiedades para editar 
        public int IDProducto_vista { get; set; } = 0; // Valor predeterminado 0 para nuevo producto

        public string NombreProducto_vista // Nombre del producto
        {
            get => txt_nombre.Texts;
            set => txt_nombre.Texts = value;
        }

        public Image ImagenProducto_vista // Imagen del producto
        {
            get => pbProducto.Image;
            set => pbProducto.Image = value;
        }

        public double PrecioProducto_vista  //  Precio del producto
        {
            get => double.TryParse(txt_precio.Texts, out double precio) ? precio : 0.0;
            set => txt_precio.Texts = value.ToString();
        }

        public int StockProducto_vista  // Stock del producto
        {
            get => int.TryParse(txt_stock.Texts, out int stock) ? stock : 0;
            set => txt_stock.Texts = value.ToString();
        }

        // Nuevas propiedades para manejar IDs
        public int? IDCategoriaProducto_vista { get; set; }
        public int? IDDistribuidorProducto_vista { get; set; }

        public string DescripcionProducto_vista // Descripción del producto
        {
            get => txt_descripcion.Texts;
            set => txt_descripcion.Texts = value;
        }

        public bool ActivoProducto_vista // Estado activo/inactivo del producto
        {
            get => cmb_activo.Texts == "Activo";
            set => cmb_activo.Texts = value ? "Activo" : "Inactivo";
        }

        public md_agregar_productos(string labelText, string buttonText) : this() // Constructor adicional
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
            string precioText = txt_precio.Texts.Trim();
            string stockText = txt_stock.Texts.Trim();


            int? idCategoria = null;
            int? idDistribuidor = null;

            // Validar que cmb_activo no esté vacío o sin seleccionar
            if (string.IsNullOrWhiteSpace(cmb_activo.Texts))
            {
                MessageBox.Show("Debe seleccionar un estado (Activo o Inactivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Obtener los IDs seleccionados en los ComboBoxes para validar
            if (cmb_distruhibidora.SelectedIndex >= 0 && cmb_distruhibidora.SelectedValue != null)
            {
                idDistribuidor = Convert.ToInt32(cmb_distruhibidora.SelectedValue);
            }
            // Obtener el ID de la categoría seleccionada para validar
            if (cmb_categoria.SelectedIndex >= 0 && cmb_categoria.SelectedValue != null)
            {
                idCategoria = Convert.ToInt32(cmb_categoria.SelectedValue);
            }
            // Validar que se haya seleccionado una categoría y un distribuidor
            if (idCategoria == null || idCategoria == 0)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idDistribuidor == null || idDistribuidor == 0)
            {
                MessageBox.Show("Debe seleccionar un distribuidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string activoText = cmb_activo.Texts.Trim();
            byte nivel = (activoText == "Activo") ? (byte)1 : (byte)0; // Convertir a byte según selección
            string descripcion = txt_descripcion.Texts.Trim();
            Image image = pbProducto.Image;

            if (!Validaciones.ValidarTextoNoVacio(nombre, "Nombre Producto")) return;
            if (!Validaciones.ValidarTextoNoVacio(precioText, "Precio")) return;
            if (!Validaciones.ValidarTextoNoVacio(stockText, "Stock")) return;
            if (!Validaciones.ValidarTextoNoVacio(descripcion, "Descripcion")) return;

            if (idCategoria == null || idCategoria == 0) // Validar que se haya seleccionado una categoría y un distribuidor
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idDistribuidor == null || idDistribuidor == 0)// Validar que se haya seleccionado una categoría y un distribuidor
            {
                MessageBox.Show("Debe seleccionar un distribuidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                if (IDProducto_vista == 0) // Nuevo producto
                {
                    if (image == null)
                    {
                        MessageBox.Show("Debe seleccionar una imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (MemoryStream ms = new MemoryStream()) // Guardar imagen en memoria
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imagenBytes = ms.ToArray(); // Convertir imagen a byte array

                        tb_producto nuevo = new tb_producto 
                        {
                            // datos del producto
                            nombre = nombre,
                            precio = decimal.TryParse(precioText, out decimal precio) ? precio : (decimal?)null, // Manejo de conversión segura
                            stock = int.TryParse(stockText, out int stock) ? stock : (int?)null,// Manejo de conversión segura
                            id_categoria = idCategoria,
                            id_distribuidor = idDistribuidor,
                            activo = (nivel == 1),// Convertir byte a bool
                            descripcion = descripcion,
                            imagen = imagenBytes
                        };

                        db.tb_producto.Add(nuevo);
                        db.SaveChanges();
                        MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var producto = db.tb_producto.Find(IDProducto_vista); // Buscar producto existente
                    if (producto != null)
                    {
                        // Actualizar datos del producto existente
                        producto.nombre = nombre;
                        producto.precio = decimal.TryParse(precioText, out decimal precio) ? precio : (decimal?)null; // Manejo de conversión segura ? = puede ser null 
                        producto.stock = int.TryParse(stockText, out int stock) ? stock : (int?)null; // Manejo de conversión segura ? = puede ser null
                        producto.id_categoria = idCategoria;
                        producto.id_distribuidor = idDistribuidor;
                        producto.activo = (nivel == 1);
                        producto.descripcion = descripcion;

                        if (image != null)
                        {
                            using (MemoryStream ms = new MemoryStream()) // Actualizar imagen si se seleccionó una nueva
                            {
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                producto.imagen = ms.ToArray();
                            }
                        }

                        db.SaveChanges();
                        MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cargar_combox_categoria()
        {
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var categorias = db.tb_categorias.ToList(); // Obtener todas las categorías
                cmb_categoria.DataSource = categorias;// Asignar lista al DataSource
                cmb_categoria.DisplayMember = "nombre"; // Mostrar nombre de la categoría
                cmb_categoria.ValueMember = "id_categoria";// Asignar ID como valor
                cmb_categoria.SelectedIndex = -1; // No seleccionar nada por defecto
            }
        }

        private void cargar_combox_distribuidor()
        {
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var distribuidores = db.tb_distribuidores.ToList();// Obtener todas los distribuidores
                cmb_distruhibidora.DataSource = distribuidores;// Asignar lista al DataSource
                cmb_distruhibidora.DisplayMember = "nombre";// Mostrar nombre del distribuidor
                cmb_distruhibidora.ValueMember = "id_distribuidor";//   Asignar ID como valor
                cmb_distruhibidora.SelectedIndex = -1; // No seleccionar nada por defecto
            }
        }

        private void md_agregar_productos_Load(object sender, EventArgs e)
        {
            cargar_combox_categoria();// Cargar categorías en el ComboBox
            cargar_combox_distribuidor();// Cargar distribuidores en el ComboBox

            // Seleccionar valores si se están editando
            if (IDCategoriaProducto_vista.HasValue)
            {
                cmb_categoria.SelectedValue = IDCategoriaProducto_vista.Value;
            }
            // Seleccionar valores si se están editando
            if (IDDistribuidorProducto_vista.HasValue)
            {
                cmb_distruhibidora.SelectedValue = IDDistribuidorProducto_vista.Value;
            }
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

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            /*verifica que pueda ingresar punto y también que solo pueda
           ingresar un punto*/
            else if ((e.KeyChar == '.') && (!txt_precio.Text.Contains(".")))
            {
                e.Handled = false;
            }
            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de números",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void txt_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de números",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}