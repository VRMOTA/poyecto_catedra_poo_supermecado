using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poyecto_catedra_poo_supermecado.Models
{
    internal class model_usuario
    {
        private int id_usario; 
        private string nombre_usuario; 
        private string correo; 
        private string clave; 
        private bool activo; 
        private string tipo_usuario;

        public int Id_Usuario
        {
            get => id_usario;
            set => id_usario = value;
        } 
        public string Nombre_Usuario
        {
            get => nombre_usuario ?? string.Empty;
            set => nombre_usuario = value; 
        }
        public string Correo
        {
            get => correo ?? string.Empty;
            set => correo = value;
        } 
        public string Clave
        {
            get => clave ?? string.Empty;
            set => clave = value;
        } 
        public bool Activo
        {
            get => activo;
            set => activo = value;
        } 
        public string Tipo_Usuario
        {
            get => tipo_usuario ?? string.Empty;
            set => tipo_usuario = value;
        } 
        public model_usuario ()
        {
            nombre_usuario = string.Empty;
            correo = string.Empty;
            clave = string.Empty;
            tipo_usuario = string.Empty;
        }
    }
}
