using poyecto_catedra_poo_supermecado.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.CustomModals
{
    public partial class md_promocion : Form
    {
        public md_promocion()
        {
            InitializeComponent();
        }

        public md_promocion(string labelText, string buttonText) : this()
        {
            label1.Text = labelText;
            btnActualizar.Text = buttonText;
        }

        public int ID_Promocion_vista { get; set; } = 0;

        // Nueva propiedad para manejar el ID del producto
        public int? IDProducto_vista { get; set; }

        public int Cantidad_minima_vista
        {
            get => int.TryParse(txt_cantidad_min.Texts, out int result) ? result : 0;
            set => txt_cantidad_min.Texts = value.ToString();
        }

        public string Precio_promocional_vista
        {
            get => txt_precio_prom.Texts;
            set => txt_precio_prom.Texts = value;
        }

        public string Descripcion_vista
        {
            get => txt_descripcion.Texts;
            set => txt_descripcion.Texts = value;
        }

        public DateTime Fecha_inicio_vista
        {
            get => dtp_fecha_inicio.Value;
            set => dtp_fecha_inicio.Value = value;
        }

        public DateTime Fecha_final_vista
        {
            get => dtp_fecha_final.Value;
            set => dtp_fecha_final.Value = value;
        }

        public bool Activa_vista
        {
            get => cmb_activo.Texts.ToLower() == "activo";
            set => cmb_activo.Texts = value ? "Activo" : "Inactivo";
        }

        private void crear_prom()
        {
            // Validar producto seleccionado
            int? idProducto = null;
            if (cmb_prod.SelectedIndex >= 0 && cmb_prod.SelectedValue != null)
            {
                idProducto = Convert.ToInt32(cmb_prod.SelectedValue);
            }

            if (idProducto == null || idProducto == 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar cantidad mínima
            int cantidad_min;
            if (!int.TryParse(txt_cantidad_min.Texts.Trim(), out cantidad_min) || cantidad_min <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número válido para la cantidad mínima.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar precio promocional
            decimal precio_prom;
            if (!decimal.TryParse(txt_precio_prom.Texts.Trim(), out precio_prom) || precio_prom <= 0)
            {
                MessageBox.Show("Por favor, ingrese un número válido para el precio promocional.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string activoText = cmb_activo.Texts.Trim();
            bool activa = (activoText == "Activo");
            string descripcion = txt_descripcion.Texts.Trim();
            DateTime fecha_inicio = dtp_fecha_inicio.Value;
            DateTime fecha_fin = dtp_fecha_final.Value;

            // Validar fechas
            if (fecha_fin < fecha_inicio)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                if (ID_Promocion_vista == 0)
                {
                    // Crear nueva promoción
                    tb_promociones nuevo = new tb_promociones
                    {
                        id_producto = idProducto,
                        cantidad_minima = cantidad_min,
                        precio_promocional = precio_prom,
                        descripcion = descripcion,
                        fecha_inicio = fecha_inicio,
                        fecha_fin = fecha_fin,
                        activa = activa,
                    };
                    db.tb_promociones.Add(nuevo);
                    db.SaveChanges();
                    MessageBox.Show("Promoción agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Editar promoción existente
                    var promociones = db.tb_promociones.Find(ID_Promocion_vista);
                    if (promociones != null)
                    {
                        promociones.id_producto = idProducto;
                        promociones.cantidad_minima = cantidad_min;
                        promociones.precio_promocional = precio_prom;
                        promociones.descripcion = descripcion;
                        promociones.fecha_inicio = fecha_inicio;
                        promociones.fecha_fin = fecha_fin;
                        promociones.activa = activa;

                        db.SaveChanges();
                        MessageBox.Show("Promoción actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Promoción no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            crear_prom();
        }

        private void cargar_productos()
        {
            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                var productos = db.tb_producto.Where(p => p.activo == true).ToList();
                cmb_prod.DataSource = productos;
                cmb_prod.DisplayMember = "nombre";
                cmb_prod.ValueMember = "id_producto";
                cmb_prod.SelectedIndex = -1;
            }
        }

        private void md_promocion_Load(object sender, EventArgs e)
        {
            cargar_productos();

            // Seleccionar el producto si se está editando
            if (IDProducto_vista.HasValue && IDProducto_vista.Value > 0)
            {
                cmb_prod.SelectedValue = IDProducto_vista.Value;
            }
        }
    }
}