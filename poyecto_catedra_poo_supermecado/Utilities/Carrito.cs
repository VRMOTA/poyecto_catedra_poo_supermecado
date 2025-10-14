using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Utilities
{
    internal class Carrito
    {
        public static List<ProductoSeleccionado> Productos { get; set; } = new List<ProductoSeleccionado>();

        public static void AgregarProducto(ProductoSeleccionado producto)
        {
            var existente = Productos.Find(p => p.Id == producto.Id);
            if (existente != null)
            {
                existente.Cantidad += producto.Cantidad;
            }
            else
            {
                Productos.Add(producto);
            }
        }

        public static void VaciarCarrito()
        {
            Productos.Clear();
        }
    }
}
