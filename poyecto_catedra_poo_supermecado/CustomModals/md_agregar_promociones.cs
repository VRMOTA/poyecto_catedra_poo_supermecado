using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.Utilities;
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
    public partial class md_agregar_promociones : Form
    {
        public md_agregar_promociones()
        {
            InitializeComponent();
            FormHelper.DefaultFormValues(this);
        }
        public md_agregar_promociones (string labelText, string buttonText) : this()
        {
            label1.Text = labelText;
            btn_crear.Text = buttonText;
        }
        public int ID_Promocion { get; set; } = 0;
        public string Producto_combox
        {             get => cmb_prod.Texts;
            set => cmb_prod.Texts = value;
        } 
        public int Cantidad_minima
        {
            get => int.TryParse(txt_cantidad_min.Texts, out int result) ? result : 0;
            set => txt_cantidad_min.Texts = value.ToString();
        }
        public string Precio_promocional
        {
            get => txt_precio_prom.Texts;
            set => txt_precio_prom.Texts = value;
        } 
        public string Descripcion
        {
            get => txt_descripcion.Texts;
            set => txt_descripcion.Texts = value;
        }
        public DateTime Fecha_inicio
        {
            get => dtp_fecha_inicio.Value;
            set => dtp_fecha_inicio.Value = value;
        }
        public DateTime Fecha_final
        {
            get => dtp_fecha_final.Value;
            set => dtp_fecha_final.Value = value;
        }
        public bool Activa
        {
            get => cmb_activo.Texts.ToLower() == "true";
            set => cmb_activo.Texts = value ? "true" : "false";
        }
        private void crear_prom()
        {
            string nombre_prod = cmb_prod.Texts.Trim();
            int cantidad_min;
            if (!int.TryParse(txt_cantidad_min.Texts.Trim(), out cantidad_min))
            {
                MessageBox.Show("Por favor, ingrese un número válido para la cantidad mínima.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double precio_prom;
            if (!double.TryParse(txt_precio_prom.Texts.Trim(), out precio_prom))
            {
                MessageBox.Show("Por favor, ingrese un número válido para el precio promocional.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string descripcion = txt_descripcion.Texts.Trim();
            DateTime fecha_inicio = dtp_fecha_inicio.Value;
            DateTime fecha_fin = dtp_fecha_final.Value;

            using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
            {
                if(ID_Promocion == 0)
                {
                    tb_promociones nuevo = new tb_promociones
                    {
                        id_producto = db.tb_producto.Where(p => p.nombre == nombre_prod).Select(p => p.id_producto).FirstOrDefault(),
                        cantidad_minima = cantidad_min,
                        precio_promocional = (decimal)precio_prom,
                        descripcion = descripcion,
                        fecha_inicio = fecha_inicio,
                        fecha_fin = fecha_fin,
                        activa = true
                    }; 
                    db.tb_promociones.Add(nuevo); 
                    db.SaveChanges(); 
                    MessageBox.Show("Promoción agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Edicion 
                else
                {
                    var promociones = db.tb_promociones.Find(ID_Promocion); 
                    if (promociones != null)
                    {
                        promociones.id_producto = db.tb_producto.Where(p => p.nombre == nombre_prod).Select(p => p.id_producto).FirstOrDefault();
                        promociones.cantidad_minima = cantidad_min;
                        promociones.precio_promocional = (decimal)precio_prom;
                        promociones.descripcion = descripcion;
                        promociones.fecha_inicio = fecha_inicio;
                        promociones.fecha_fin = fecha_fin;
                        db.SaveChanges(); 
                        MessageBox.Show("Promoción actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            crear_prom();
        }
    }
}
