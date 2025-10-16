using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_productos
    {
        private int idProducto;
        private Image imagenProducto; 
        private string nombreProducto; 
        private string nombreDistribuidor; 
        private string descripcion; 
        private string categoria; 
        private int stock; 
        private decimal precio; 
        private bool activo; 

        public int ID_Producto_model
        {
            get => idProducto;
            set => idProducto = value;
        } 
         public Image ImagenProducto_model
         {
                get => imagenProducto;
                set => imagenProducto = value;
         } 
        public string NombreProducto_model
        {
            get => nombreProducto;
            set => nombreProducto = value;
        } 
        public string NombreDistribuidor_model
        {
            get => nombreDistribuidor;
            set => nombreDistribuidor = value;
        } 
        public string Descripcion_model
        {
            get => descripcion;
            set => descripcion = value;
        } 
        public string Categoria_model
        {
            get => categoria;
            set => categoria = value;
        } 
        public int Stock
        {
            get => stock;
            set => stock = value;
        }
        public decimal Precio_model
        {
            get => precio;
            set => precio = value;
        }
        public bool Activo_model
        {
            get => activo;
            set => activo = value;
        }
        public model_productos()
        {
            nombreProducto = string.Empty;
            nombreDistribuidor = string.Empty;
            descripcion = string.Empty;
            categoria = string.Empty;
            stock = 0;
            precio = 0m;
            activo = true;
        }
    }
}
