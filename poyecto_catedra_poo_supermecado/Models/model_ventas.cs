using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_ventas
    {
        private int idVenta;
        private DateTime fecha;
        private int idUsuario;
        private string nombreCliente;
        private decimal totalVenta;
        private decimal totalDescuento;
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

        public int ID_Usuario_model
        {
            get => idUsuario;
            set => idUsuario = value;
        }

        public string NombreCliente_model
        {
            get => nombreCliente;
            set => nombreCliente = value;
        }

        public decimal TotalVenta_model
        {
            get => totalVenta;
            set => totalVenta = value;
        }

        public decimal TotalDescuento_model
        {
            get => totalDescuento;
            set => totalDescuento = value;
        }

        public string Estado_model
        {
            get => estado;
            set => estado = value;
        }

        // Constructor por defecto
        public model_ventas()
        {
            fecha = DateTime.Now;
            nombreCliente = string.Empty;
            totalVenta = 0m;
            totalDescuento = 0m;
            estado = "Completada";
        }
    }
}

