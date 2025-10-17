using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_detalle_ventas_completo
    {
        private int idVenta;
        private DateTime fecha;
        private string nombreCliente;
        private string cajero;
        private string producto;
        private string categoria;
        private int cantidad;
        private decimal precioUnitario;
        private decimal descuentoAplicado;
        private decimal subtotal;
        private string estado;

        // Propiedades públicas
        public int ID_Venta_model
        {
            get => idVenta;
            set => idVenta = value;
        }

        public DateTime Fecha_model
        {
            get => fecha;
            set => fecha = value;
        }

        public string NombreCliente_model
        {
            get => nombreCliente;
            set => nombreCliente = value;
        }

        public string Cajero_model
        {
            get => cajero;
            set => cajero = value;
        }

        public string Producto_model
        {
            get => producto;
            set => producto = value;
        }

        public string Categoria_model
        {
            get => categoria;
            set => categoria = value;
        }

        public int Cantidad_model
        {
            get => cantidad;
            set => cantidad = value;
        }

        public decimal PrecioUnitario_model
        {
            get => precioUnitario;
            set => precioUnitario = value;
        }

        public decimal DescuentoAplicado_model
        {
            get => descuentoAplicado;
            set => descuentoAplicado = value;
        }

        public decimal Subtotal_model
        {
            get => subtotal;
            set => subtotal = value;
        }

        public string Estado_model
        {
            get => estado;
            set => estado = value;
        }

        // Constructor por defecto
        public model_detalle_ventas_completo()
        {
            fecha = DateTime.Now;
            nombreCliente = string.Empty;
            cajero = string.Empty;
            producto = string.Empty;
            categoria = string.Empty;
            cantidad = 0;
            precioUnitario = 0m;
            descuentoAplicado = 0m;
            subtotal = 0m;
            estado = string.Empty;
        }

        // Constructor con parámetros
        public model_detalle_ventas_completo(int idVenta, DateTime fecha, string nombreCliente,
            string cajero, string producto, string categoria, int cantidad,
            decimal precioUnitario, decimal descuentoAplicado, decimal subtotal, string estado)
        {
            this.idVenta = idVenta;
            this.fecha = fecha;
            this.nombreCliente = nombreCliente ?? string.Empty;
            this.cajero = cajero ?? string.Empty;
            this.producto = producto ?? string.Empty;
            this.categoria = categoria ?? string.Empty;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
            this.descuentoAplicado = descuentoAplicado;
            this.subtotal = subtotal;
            this.estado = estado ?? string.Empty;
        }
    }
}