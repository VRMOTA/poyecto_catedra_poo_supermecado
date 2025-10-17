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
using poyecto_catedra_poo_supermecado.Models;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_ventas_new : Form
    {
        public frm_ventas_new()
        {
            InitializeComponent();
        }

        private void cargarusuarios()
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var cajeros = db.tb_usuario
                        .Where(u => u.tipo_usuario == "Cajero")
                        .Select(u => new { u.id_usuario, u.nombre })
                        .ToList();

                    cmb_cajero.DataSource = cajeros;
                    cmb_cajero.DisplayMember = "nombre";
                    cmb_cajero.ValueMember = "id_usuario";
                    cmb_cajero.SelectedIndex = -1; // No seleccionar nada por defecto

                    // Configurar AutoComplete para búsqueda
                    cmb_cajero.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmb_cajero.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                        .ToList()
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

                    // Configurar AutoComplete para búsqueda
                    cmb_ventas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmb_ventas.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVentasPorCajero(int idCajero)
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    var ventas = db.tb_ventas
                        .Where(v => v.id_usuario == idCajero)
                        .OrderByDescending(v => v.id_venta)
                        .ToList()
                        .Select(v => new {
                            v.id_venta,
                            v.fecha,
                            v.nombre_cliente
                        })
                        .ToList();

                    cmb_ventas.DataSource = ventas;
                    cmb_ventas.DisplayMember = "Correlativo";
                    cmb_ventas.ValueMember = "id_venta";
                    cmb_ventas.SelectedIndex = -1;

                    // Configurar AutoComplete para búsqueda
                    cmb_ventas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmb_ventas.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas del cajero: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarDetalleVentas()
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    // Usar LINQ directamente con la vista
                    var listaDetalleVentas = db.vw_detalle_ventas_completo
                        .OrderByDescending(v => v.id_venta)
                        .ToList()
                        .Select(v => new model_detalle_ventas_completo
                        {
                            ID_Venta_model = v.id_venta,
                            Fecha_model = v.fecha ?? DateTime.MinValue,
                            NombreCliente_model = v.nombre_cliente ?? "",
                            Cajero_model = v.cajero ?? "",
                            Producto_model = v.producto ?? "",
                            Categoria_model = v.categoria ?? "",
                            Cantidad_model = v.cantidad ?? 0,
                            PrecioUnitario_model = v.precio_unitario ?? 0,
                            DescuentoAplicado_model = v.descuento_aplicado ?? 0,
                            Subtotal_model = v.subtotal ?? 0,
                            Estado_model = v.estado ?? ""
                        })
                        .ToList();

                    // Asignar la lista al DataGridView
                    dg_ventas.DataSource = listaDetalleVentas;

                    // Configurar las columnas del DataGridView
                    ConfigurarDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleVentasPorCajero(int idCajero)
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    // Filtrar por id_cajero usando LINQ
                    var listaDetalleVentas = db.vw_detalle_ventas_completo
                        .Where(v => v.id_cajero == idCajero)
                        .OrderByDescending(v => v.fecha)
                        .ToList()
                        .Select(v => new model_detalle_ventas_completo
                        {
                            ID_Venta_model = v.id_venta,
                            Fecha_model = v.fecha ?? DateTime.MinValue,
                            NombreCliente_model = v.nombre_cliente ?? "",
                            Cajero_model = v.cajero ?? "",
                            Producto_model = v.producto ?? "",
                            Categoria_model = v.categoria ?? "",
                            Cantidad_model = v.cantidad ?? 0,
                            PrecioUnitario_model = v.precio_unitario ?? 0,
                            DescuentoAplicado_model = v.descuento_aplicado ?? 0,
                            Subtotal_model = v.subtotal ?? 0,
                            Estado_model = v.estado ?? ""
                        })
                        .ToList();

                    // Asignar la lista filtrada al DataGridView
                    dg_ventas.DataSource = listaDetalleVentas;

                    // Configurar las columnas del DataGridView
                    ConfigurarDataGridView();

                    // Mostrar mensaje informativo sobre los resultados
                    if (listaDetalleVentas.Count == 0)
                    {
                        MessageBox.Show("No se encontraron ventas para el cajero seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Se encontraron {listaDetalleVentas.Count} registros de ventas para el cajero seleccionado.", "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle de ventas por cajero: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleVentasPorCajeroYVenta(int idCajero, int idVenta)
        {
            try
            {
                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    // Filtrar por id_venta e id_cajero usando LINQ (equivalente al query SQL solicitado)
                    var listaDetalleVentas = db.vw_detalle_ventas_completo
                        .Where(v => v.id_venta == idVenta && v.id_cajero == idCajero)
                        .OrderByDescending(v => v.fecha)
                        .ToList()
                        .Select(v => new model_detalle_ventas_completo
                        {
                            ID_Venta_model = v.id_venta,
                            Fecha_model = v.fecha ?? DateTime.MinValue,
                            NombreCliente_model = v.nombre_cliente ?? "",
                            Cajero_model = v.cajero ?? "",
                            Producto_model = v.producto ?? "",
                            Categoria_model = v.categoria ?? "",
                            Cantidad_model = v.cantidad ?? 0,
                            PrecioUnitario_model = v.precio_unitario ?? 0,
                            DescuentoAplicado_model = v.descuento_aplicado ?? 0,
                            Subtotal_model = v.subtotal ?? 0,
                            Estado_model = v.estado ?? ""
                        })
                        .ToList();

                    // Asignar la lista filtrada al DataGridView
                    dg_ventas.DataSource = listaDetalleVentas;

                    // Configurar las columnas del DataGridView
                    ConfigurarDataGridView();

                    // Mostrar mensaje informativo sobre los resultados
                    if (listaDetalleVentas.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros para la venta y cajero seleccionados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Se encontraron {listaDetalleVentas.Count} registros para la venta y cajero seleccionados.", "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle de ventas por cajero y venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            if (dg_ventas.Columns.Count > 0)
            {
                // Configurar encabezados de columnas usando los nombres de las propiedades del modelo
                if (dg_ventas.Columns["ID_Venta_model"] != null)
                    dg_ventas.Columns["ID_Venta_model"].HeaderText = "ID Venta";

                if (dg_ventas.Columns["Fecha_model"] != null)
                    dg_ventas.Columns["Fecha_model"].HeaderText = "Fecha";

                if (dg_ventas.Columns["NombreCliente_model"] != null)
                    dg_ventas.Columns["NombreCliente_model"].HeaderText = "Cliente";

                if (dg_ventas.Columns["Cajero_model"] != null)
                    dg_ventas.Columns["Cajero_model"].HeaderText = "Cajero";

                if (dg_ventas.Columns["Producto_model"] != null)
                    dg_ventas.Columns["Producto_model"].HeaderText = "Producto";

                if (dg_ventas.Columns["Categoria_model"] != null)
                    dg_ventas.Columns["Categoria_model"].HeaderText = "Categoría";

                if (dg_ventas.Columns["Cantidad_model"] != null)
                    dg_ventas.Columns["Cantidad_model"].HeaderText = "Cantidad";

                if (dg_ventas.Columns["PrecioUnitario_model"] != null)
                    dg_ventas.Columns["PrecioUnitario_model"].HeaderText = "Precio Unitario";

                if (dg_ventas.Columns["DescuentoAplicado_model"] != null)
                    dg_ventas.Columns["DescuentoAplicado_model"].HeaderText = "Descuento";

                if (dg_ventas.Columns["Subtotal_model"] != null)
                    dg_ventas.Columns["Subtotal_model"].HeaderText = "Subtotal";

                if (dg_ventas.Columns["Estado_model"] != null)
                    dg_ventas.Columns["Estado_model"].HeaderText = "Estado";

                // Configurar formato para columnas de dinero
                if (dg_ventas.Columns["PrecioUnitario_model"] != null)
                    dg_ventas.Columns["PrecioUnitario_model"].DefaultCellStyle.Format = "C2";

                if (dg_ventas.Columns["DescuentoAplicado_model"] != null)
                    dg_ventas.Columns["DescuentoAplicado_model"].DefaultCellStyle.Format = "C2";

                if (dg_ventas.Columns["Subtotal_model"] != null)
                    dg_ventas.Columns["Subtotal_model"].DefaultCellStyle.Format = "C2";

                // Configurar formato para fecha
                if (dg_ventas.Columns["Fecha_model"] != null)
                    dg_ventas.Columns["Fecha_model"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Configurar ancho de columnas
                if (dg_ventas.Columns["ID_Venta_model"] != null)
                    dg_ventas.Columns["ID_Venta_model"].Width = 80;

                if (dg_ventas.Columns["Fecha_model"] != null)
                    dg_ventas.Columns["Fecha_model"].Width = 130;

                if (dg_ventas.Columns["NombreCliente_model"] != null)
                    dg_ventas.Columns["NombreCliente_model"].Width = 150;

                if (dg_ventas.Columns["Cajero_model"] != null)
                    dg_ventas.Columns["Cajero_model"].Width = 120;

                if (dg_ventas.Columns["Producto_model"] != null)
                    dg_ventas.Columns["Producto_model"].Width = 200;

                if (dg_ventas.Columns["Categoria_model"] != null)
                    dg_ventas.Columns["Categoria_model"].Width = 120;

                if (dg_ventas.Columns["Cantidad_model"] != null)
                    dg_ventas.Columns["Cantidad_model"].Width = 80;

                if (dg_ventas.Columns["PrecioUnitario_model"] != null)
                    dg_ventas.Columns["PrecioUnitario_model"].Width = 100;

                if (dg_ventas.Columns["DescuentoAplicado_model"] != null)
                    dg_ventas.Columns["DescuentoAplicado_model"].Width = 100;

                if (dg_ventas.Columns["Subtotal_model"] != null)
                    dg_ventas.Columns["Subtotal_model"].Width = 100;

                if (dg_ventas.Columns["Estado_model"] != null)
                    dg_ventas.Columns["Estado_model"].Width = 100;

                // Configurar modo de redimensionamiento
                dg_ventas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dg_ventas.AllowUserToResizeColumns = true;

                // Solo lectura
                dg_ventas.ReadOnly = true;
                dg_ventas.AllowUserToAddRows = false;
                dg_ventas.AllowUserToDeleteRows = false;
            }
        }

        private void frm_ventas_new_Load(object sender, EventArgs e)
        {
            cargarusuarios();
            CargarDetalleVentas();

            // Deshabilitar combobox de ventas inicialmente
            if (cmb_ventas != null)
            {
                cmb_ventas.Visible = false;
                cmb_ventas.DataSource = null;
            }

            // Habilitar escritura en los comboboxes para búsqueda
            if (cmb_cajero != null)
            {
                cmb_cajero.EnableTextInput = true;
                // Agregar evento para cuando cambie la selección del cajero
                cmb_cajero.OnSelectedIndexChanged += cmb_cajero_SelectedIndexChanged;
            }

            if (cmb_ventas != null)
            {
                cmb_ventas.EnableTextInput = true;
            }
        }

        private void cmb_cajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_cajero.SelectedIndex >= 0 && cmb_cajero.SelectedValue != null)
            {
                // Habilitar combobox de ventas
                cmb_ventas.Visible = true;

                // Obtener el ID del cajero seleccionado
                int idCajero = Convert.ToInt32(cmb_cajero.SelectedValue);

                // Cargar las ventas específicas del cajero seleccionado
                CargarVentasPorCajero(idCajero);
            }
            else
            {
                // Deshabilitar combobox de ventas si no hay cajero seleccionado
                cmb_ventas.Visible = false;
                cmb_ventas.DataSource = null;
                cmb_ventas.SelectedIndex = -1;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmb_cajero.SelectedIndex >= 0 && cmb_cajero.SelectedValue != null)
            {
                int idCajero = Convert.ToInt32(cmb_cajero.SelectedValue);

                // Verificar si también hay una venta seleccionada
                if (cmb_ventas.Visible && cmb_ventas.SelectedIndex >= 0 && cmb_ventas.SelectedValue != null)
                {
                    int idVenta = Convert.ToInt32(cmb_ventas.SelectedValue);
                    // Ejecutar consulta con ambos filtros (equivalente al query SQL solicitado)
                    CargarDetalleVentasPorCajeroYVenta(idCajero, idVenta);
                }
                else
                {
                    // Solo filtrar por cajero
                    CargarDetalleVentasPorCajero(idCajero);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cajero antes de buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            // Limpiar selección del combobox
            cmb_cajero.SelectedIndex = -1;
            cmb_ventas.Visible = false;
            cmb_ventas.DataSource = null;

            // Recargar todas las ventas
            CargarDetalleVentas();
        }
    }

}
