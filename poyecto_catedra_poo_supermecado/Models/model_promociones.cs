using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_promociones
    {
        private int id_promocion; 
        private string nombre_producto; 
        private int cantidad_minima; 
        private decimal precio_promocion; 
        private string descripcion; 
        private DateTime fecha_inicio; 
        private DateTime fecha_fin; 
        private bool activa; 

        public int ID_Promocion_model
        {
            get => id_promocion;
            set => id_promocion = value;
        } 
        public string Nombre_Producto_model
        {
            get => nombre_producto;
            set => nombre_producto = value;
        } 
        public int Cantidad_Minima_model
        {
            get => cantidad_minima;
            set => cantidad_minima = value;
        } 
        public decimal Precio_Promocion_model
        {
            get => precio_promocion;
            set => precio_promocion = value;
        } 
        public string Descripcion_model
        {
            get => descripcion;
            set => descripcion = value;
        } 
        public DateTime Fecha_Inicio_model
        {
            get => fecha_inicio;
            set => fecha_inicio = value;
        }
        public DateTime Fecha_Fin_model
        {
            get => fecha_fin;
            set => fecha_fin = value;
        }
        public bool Activa_model
        {
            get => activa;
            set => activa = value;
        }
        public model_promociones() 
        {
            nombre_producto = string.Empty;
            descripcion = string.Empty;
            cantidad_minima = 0; 
            precio_promocion = 0.0m; 
            fecha_inicio = DateTime.Now;
            fecha_fin = DateTime.Now.AddDays(1);
            activa = true; 
        }
    }
}
