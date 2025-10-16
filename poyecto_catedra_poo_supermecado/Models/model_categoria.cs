using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_categoria
    {
        private int idCategoria;
        private string nombreCategoria;

        public int ID_Categoria_Modelo
        {
            get => idCategoria;
            set => idCategoria = value;
        }

        public string NombreCategoria_Modelo
        {
            get => nombreCategoria ?? string.Empty;
            set => nombreCategoria = value;
        }

        // Constructor por defecto
        public model_categoria()
        {
            idCategoria = 0;
            nombreCategoria = string.Empty;
        }

    }
}
