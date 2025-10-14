using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace poyecto_catedra_poo_supermecado.Utilities
{
    internal class ProductoSeleccionado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public Image Imagen { get; set; }
        public int Stock { get; set; }
    }
}
