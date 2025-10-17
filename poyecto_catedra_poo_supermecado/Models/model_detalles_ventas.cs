using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_detalles_ventas
    {
        private int idDetalle;
        private int idVenta;
        private int idProducto;
        private int cantidad;
        private decimal precioUnitario;
        private decimal descuentoAplicado;
        private decimal subtotal;

        // Propiedades públicas
        public int ID_Detalle_model
        {
            get => idDetalle;
            set => idDetalle = value;
        }

        public int ID_Venta_model
        {
            get => idVenta;
            set => idVenta = value;
        }

        public int ID_Producto_model
        {
            get => idProducto;
            set => idProducto = value;
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

        // Constructor por defecto
        public model_detalles_ventas()
        {
            cantidad = 0;
            precioUnitario = 0m;
            descuentoAplicado = 0m;
            subtotal = 0m;
        }
    }
}
