using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using poyecto_catedra_poo_supermecado.Conexion;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_ventas : Form
    {
        public frm_ventas()
        {
            InitializeComponent();
        }

        private void CargarCajeros()
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var cajeros = db.tb_usuario
                        .Where(u => u.activo == true)
                        .Select(u => new { u.id_usuario, u.nombre })
                        .ToList();

                    cmb_cajero.DataSource = cajeros;
                    cmb_cajero.DisplayMember = "nombres";
                    cmb_cajero.ValueMember = "id_usuario";
                    cmb_cajero.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cajeros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVentas()
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var ventas = db.tb_ventas
                        .OrderByDescending(v => v.id_venta)
                        .Select(v => new { 
                            v.id_venta, 
                            Correlativo = "V-" + v.id_venta.ToString().PadLeft(6, '0'),
                            v.fecha,
                            v.nombre_cliente 
                        })
                        .ToList();

                    cmb_ventas.DataSource = ventas;
                    cmb_ventas.DisplayMember = "Correlativo";
                    cmb_ventas.ValueMember = "id_venta";
                    cmb_ventas.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleVentas()
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    // Consulta a la vista vw_detalle_ventas_completo
                    var query = @"SELECT id_venta, fecha, nombre_cliente, cajero, producto, categoria, cantidad, precio_unitario, descuento_aplicado, subtotal, estado FROM vw_detalle_ventas_completo ORDER BY id_venta DESC";
                    
                    var detalleVentas = db.Database.SqlQuery<vw_detalle_ventas_completo>(query).ToList();
                    
                    dg_ventas.DataSource = detalleVentas;
                    
                    // Configurar las columnas del DataGridView
                    ConfigurarDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            if (dg_ventas.Columns.Count > 0)
            {
                // Configurar encabezados de columnas
                dg_ventas.Columns["id_venta"].HeaderText = "ID Venta";
                dg_ventas.Columns["fecha"].HeaderText = "Fecha";
                dg_ventas.Columns["nombre_cliente"].HeaderText = "Cliente";
                dg_ventas.Columns["cajero"].HeaderText = "Cajero";
                dg_ventas.Columns["producto"].HeaderText = "Producto";
                dg_ventas.Columns["categoria"].HeaderText = "Categoría";
                dg_ventas.Columns["cantidad"].HeaderText = "Cantidad";
                dg_ventas.Columns["precio_unitario"].HeaderText = "Precio Unitario";
                dg_ventas.Columns["descuento_aplicado"].HeaderText = "Descuento";
                dg_ventas.Columns["subtotal"].HeaderText = "Subtotal";
                dg_ventas.Columns["estado"].HeaderText = "Estado";

                // Configurar formato para columnas de dinero
                dg_ventas.Columns["precio_unitario"].DefaultCellStyle.Format = "C2";
                dg_ventas.Columns["descuento_aplicado"].DefaultCellStyle.Format = "C2";
                dg_ventas.Columns["subtotal"].DefaultCellStyle.Format = "C2";

                // Configurar formato para fecha
                dg_ventas.Columns["fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Configurar ancho de columnas
                dg_ventas.Columns["id_venta"].Width = 80;
                dg_ventas.Columns["fecha"].Width = 130;
                dg_ventas.Columns["nombre_cliente"].Width = 150;
                dg_ventas.Columns["cajero"].Width = 120;
                dg_ventas.Columns["producto"].Width = 200;
                dg_ventas.Columns["categoria"].Width = 120;
                dg_ventas.Columns["cantidad"].Width = 80;
                dg_ventas.Columns["precio_unitario"].Width = 100;
                dg_ventas.Columns["descuento_aplicado"].Width = 100;
                dg_ventas.Columns["subtotal"].Width = 100;
                dg_ventas.Columns["estado"].Width = 100;

                // Configurar modo de redimensionamiento
                dg_ventas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dg_ventas.AllowUserToResizeColumns = true;
                
                // Solo lectura
                dg_ventas.ReadOnly = true;
                dg_ventas.AllowUserToAddRows = false;
                dg_ventas.AllowUserToDeleteRows = false;
            }
        }

        private void frm_ventas_Load(object sender, EventArgs e)
        {
            CargarCajeros();
            CargarVentas();
            CargarDetalleVentas();
        }
    }

}
