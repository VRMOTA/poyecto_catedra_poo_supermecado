using poyecto_catedra_poo_supermecado.Conexion;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace poyecto_catedra_poo_supermecado.Utilities
{
    /// <summary>
    /// Clase estática para validaciones académicas
    /// Las clases estáticas no se pueden instanciar y agrupan métodos utilitarios
    /// Todos los métodos deben ser static y no puede tener atributos de instancia
    /// </summary>
    public static class Validaciones
    {
        public static bool ValidarTextoNoVacio(string texto, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarError($"El campo '{nombreCampo}' no puede estar vacío.");
                return false;
            }
            return true;
        }

        public static bool ValidarLongitudTexto(string texto, string nombreCampo, int longitudMinima, int longitudMaxima)
        {
            if (texto.Length < longitudMinima || texto.Length > longitudMaxima)
            {
                MostrarError($"El campo '{nombreCampo}' debe tener entre {longitudMinima} y {longitudMaxima} caracteres.");
                return false;
            }
            return true;
        }

        public static bool ValidarNumeroPositivo(decimal numero, string nombreCampo)
        {
            if (numero <= 0)
            {
                MostrarError($"El campo '{nombreCampo}' debe ser un número positivo.");
                return false;
            }
            return true;
        }

        public static bool ValidarEnteroPositivo(int numero, string nombreCampo)
        {
            if (numero <= 0)
            {
                MostrarError($"El campo '{nombreCampo}' debe ser un número entero positivo.");
                return false;
            }
            return true;
        }

        public static void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error de Validación",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
