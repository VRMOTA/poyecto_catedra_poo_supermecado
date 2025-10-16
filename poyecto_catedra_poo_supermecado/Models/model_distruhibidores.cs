using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_distruhibidores
    {
        private int idDistribuidor;
        private string nombreDistribuidora;
        private Image imagenDistribuidora;

        public int ID_Distribuidor_model
        {
            get => idDistribuidor;
            set => idDistribuidor = value;
        }

        public string NombreDistribuidora_model
        {
            get => nombreDistribuidora;
            set => nombreDistribuidora = value;
        }

        public Image ImagenDistribuidora_model
        {
            get => imagenDistribuidora;
            set => imagenDistribuidora = value;
        }

        public model_distruhibidores()
        {
            nombreDistribuidora = string.Empty;
        }

        public model_distruhibidores(int id, string nombre, Image imagen)
        {
            idDistribuidor = id;
            nombreDistribuidora = nombre ?? string.Empty;
            imagenDistribuidora = imagen;
        }
    }
}
