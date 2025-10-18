﻿using poyecto_catedra_poo_supermecado.Conexion;
using poyecto_catedra_poo_supermecado.CustomCards;
using poyecto_catedra_poo_supermecado.CustomControls;
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

using poyecto_catedra_poo_supermecado.Models;

namespace poyecto_catedra_poo_supermecado.Forms
{
    public partial class frm_carrito_cajero : Form
    {
        private model_usuario model_usuario;

        public frm_carrito_cajero()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235);
            model_usuario = new model_usuario();
        }

        public frm_carrito_cajero(model_usuario usuario)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(235, 235, 235);
            model_usuario = usuario;
        }

        private void frm_carrito_cajero_Load(object sender, EventArgs e)
        {

        }

        private void roundedControlBase1_Load(object sender, EventArgs e)
        {

        }

        private void frm_carrito_cajero_Load_1(object sender, EventArgs e)
        {
            CargarCarrito(); ;
        }

        private void EliminarProducto(int idProducto)
        {
            var producto = Utilities.Carrito.Productos.FirstOrDefault(p => p.Id == idProducto);
            if (producto != null)
            {
                var confirmar = MessageBox.Show(
                    $"¿Desea eliminar '{producto.Nombre}' del carrito?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    Utilities.Carrito.Productos.Remove(producto);
                    RecargarCarrito();
                }
            }
        }

        private void ActualizarProducto(int idProducto, int nuevaCantidad)
        {
            try
            {
                //se busca el codigo pepe
                var producto = Utilities.Carrito.Productos.FirstOrDefault(p => p.Id == idProducto);
                if (producto == null) return;

                // actualiza cantidad en la lista global, prueba
                producto.Cantidad = nuevaCantidad;

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    DateTime hoy = DateTime.Now;

                    // Buscar promoción activa
                    var promo = db.tb_promociones.FirstOrDefault(p =>
                        p.id_producto == producto.Id &&
                        p.activa == true &&
                        p.fecha_inicio <= hoy &&
                        p.fecha_fin >= hoy &&
                        nuevaCantidad >= p.cantidad_minima);

                    decimal totalProducto = 0m;

                    if (promo != null && promo.precio_promocional.HasValue && promo.cantidad_minima.HasValue)
                    {
                        int cantidadPromo = promo.cantidad_minima.Value;
                        decimal precioPromo = promo.precio_promocional.Value;

                        int bloquesCompletos = nuevaCantidad / cantidadPromo;
                        int resto = nuevaCantidad % cantidadPromo;

                        totalProducto = bloquesCompletos * precioPromo + resto * producto.Precio;
                    }
                    else
                    {
                        totalProducto = nuevaCantidad * producto.Precio;
                    }

                    decimal ahorro = producto.Cantidad * producto.Precio - totalProducto;
                    // Buscar la card correspondiente y actualizar su total
                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl is CustomCards.card_producto_carrito card && card.IDProducto == idProducto)
                        {
                            card.TotalProducto = totalProducto;
                            card.AhorroProducto = ahorro;
                            break;
                        }
                    }
                }

                // actualiza totales del carrito
                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto en el carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarTotales()
        {
            try
            {
                decimal totalPagar = 0m;
                int totalCantidad = 0;

                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is CustomCards.card_producto_carrito card)
                    {
                        totalCantidad += card.Cantidad;
                        totalPagar += card.TotalProducto;
                    }
                }

                label2.Text = totalCantidad.ToString();
                label4.Text = totalPagar.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los totales del carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecargarCarrito()
        {
            panel1.Controls.Clear();
            CargarCarrito();
        }

        private void CargarCarrito()
        {
            try
            {
                int anchoCarta = 775;
                int altoCarta = 204;
                int espacio = 10;

                panel1.Controls.Clear();
                panel1.AutoScroll = true;

                var productosCarrito = Utilities.Carrito.Productos;

                decimal totalPagar = 0m;
                int totalCantidad = 0;

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    DateTime hoy = DateTime.Now;

                    for (int i = 0; i < productosCarrito.Count; i++)
                    {
                        var producto = productosCarrito[i];

                        // Buscar promoción activa
                        var promo = db.tb_promociones.FirstOrDefault(p =>
                            p.id_producto == producto.Id &&
                            p.activa == true &&
                            p.fecha_inicio <= hoy &&
                            p.fecha_fin >= hoy &&
                            producto.Cantidad >= p.cantidad_minima);

                        decimal totalProducto = 0m;
                        int descuentoPorcentaje = 0;
                        decimal ahorro = 0m;

                        if (promo != null && promo.precio_promocional.HasValue && promo.cantidad_minima.HasValue)
                        {
                            int cantidadPromo = promo.cantidad_minima.Value;
                            decimal precioPromo = promo.precio_promocional.Value;

                            int bloquesCompletos = producto.Cantidad / cantidadPromo;
                            int resto = producto.Cantidad % cantidadPromo;

                            totalProducto = bloquesCompletos * precioPromo + resto * producto.Precio;
                            ahorro = producto.Cantidad * producto.Precio - totalProducto;
                            descuentoPorcentaje = (int)Math.Round((1 - ((decimal)(bloquesCompletos * precioPromo + resto * producto.Precio) / (producto.Precio * producto.Cantidad))) * 100);

                            // Ajuste para mostrar solo promo en nombre si aplica
                            if (bloquesCompletos > 0)
                                producto.Nombre += " (Promo)";
                        }
                        else
                        {
                            totalProducto = producto.Cantidad * producto.Precio;
                            ahorro = 0;
                        }

                        var card = new CustomCards.card_producto_carrito
                        {
                            IDProducto = producto.Id,
                            NombreProducto = producto.Nombre + (promo != null ? " (Promo)" : ""),
                            Precio = producto.Precio,
                            Descuento = descuentoPorcentaje,
                            Cantidad = producto.Cantidad,
                            ImagenProducto = producto.Imagen,
                            StockDisponible = producto.Stock,
                            TotalProducto = totalProducto,
                            AhorroProducto = ahorro,
                            Width = anchoCarta,
                            Height = altoCarta,
                            Left = 0,
                            Top = i * (altoCarta + espacio)

                        };

                        card.EliminarClick += (s, ev) => EliminarProducto(producto.Id);
                        card.CantidadActualizada += (s, nuevaCantidad) => ActualizarProducto(producto.Id, nuevaCantidad);

                        panel1.Controls.Add(card);

                        // Total con descuento aplicado
                        totalPagar += totalProducto;
                        totalCantidad += producto.Cantidad;
                    }
                }

                label2.Text = totalCantidad.ToString();
                label4.Text = totalPagar.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonMaxing1_Click(object sender, EventArgs e)
        {
            try
            {
                var productosCarrito = Utilities.Carrito.Productos;

                if (productosCarrito == null || productosCarrito.Count == 0)
                {
                    MessageBox.Show("No hay productos en el carrito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (db_supermercadoEntities1 db = new db_supermercadoEntities1())
                {
                    DateTime hoy = DateTime.Now;
                    decimal totalVenta = 0m;
                    decimal totalDescuento = 0m;

                    // Calcular totales con descuento
                    foreach (var producto in productosCarrito)
                    {
                        var promo = db.tb_promociones.FirstOrDefault(p =>
                            p.id_producto == producto.Id &&
                            p.activa == true &&
                            p.fecha_inicio <= hoy &&
                            p.fecha_fin >= hoy &&
                            producto.Cantidad >= p.cantidad_minima);

                        decimal totalProducto = producto.Cantidad * producto.Precio;
                        decimal descuentoProducto = 0m;

                        if (promo != null && promo.precio_promocional.HasValue && promo.cantidad_minima.HasValue)
                        {
                            int multiples = producto.Cantidad / promo.cantidad_minima.Value;
                            int resto = producto.Cantidad % promo.cantidad_minima.Value;

                            totalProducto = multiples * promo.precio_promocional.Value + resto * producto.Precio;
                            descuentoProducto = producto.Cantidad * producto.Precio - totalProducto;
                        }

                        totalVenta += totalProducto;
                        totalDescuento += descuentoProducto;
                    }

                    tb_ventas nuevaVenta = new tb_ventas
                    {
                        fecha = DateTime.Now,
                        id_usuario = model_usuario.Id_Usuario, // VERIFICAR ESTO 
                        nombre_cliente = txtNombre.Texts.ToString(),
                        total_venta = totalVenta,
                        total_descuento = totalDescuento,
                        estado = "Completada"
                    };

                    db.tb_ventas.Add(nuevaVenta);
                    db.SaveChanges();

                    int idVentaGenerada = nuevaVenta.id_venta;

                    foreach (var producto in productosCarrito)
                    {
                        var promo = db.tb_promociones.FirstOrDefault(p =>
                            p.id_producto == producto.Id &&
                            p.activa == true &&
                            p.fecha_inicio <= hoy &&
                            p.fecha_fin >= hoy &&
                            producto.Cantidad >= p.cantidad_minima);

                        decimal totalProducto = producto.Cantidad * producto.Precio;
                        decimal precioUnitarioAplicado = producto.Precio;
                        decimal descuentoProducto = 0m;

                        if (promo != null && promo.precio_promocional.HasValue && promo.cantidad_minima.HasValue)
                        {
                            int multiples = producto.Cantidad / promo.cantidad_minima.Value;
                            int resto = producto.Cantidad % promo.cantidad_minima.Value;

                            totalProducto = multiples * promo.precio_promocional.Value + resto * producto.Precio;
                            precioUnitarioAplicado = totalProducto / producto.Cantidad;
                            descuentoProducto = producto.Cantidad * producto.Precio - totalProducto;
                        }

                        tb_detalle_venta detalle = new tb_detalle_venta
                        {
                            id_venta = idVentaGenerada,
                            id_producto = producto.Id,
                            cantidad = producto.Cantidad,
                            precio_unitario = precioUnitarioAplicado,
                            descuento_aplicado = descuentoProducto,
                            subtotal = totalProducto
                        };

                        db.tb_detalle_venta.Add(detalle);

                        // resta stock en la base de datos
                        var productoDB = db.tb_producto.FirstOrDefault(p => p.id_producto == producto.Id);
                        if (productoDB != null)
                        {
                            if (productoDB.stock >= producto.Cantidad)
                            {
                                productoDB.stock -= producto.Cantidad;
                            }
                            else
                            {
                                MessageBox.Show($"Stock insuficiente para el producto: {productoDB.nombre}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }

                    db.SaveChanges();

                    // Limpia carrito
                    Utilities.Carrito.Productos.Clear();
                    RecargarCarrito();

                    MessageBox.Show("Venta registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Texts = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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
