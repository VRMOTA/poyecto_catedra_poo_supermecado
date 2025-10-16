using System;

namespace poyecto_catedra_poo_supermecado.Utilities
{
    /// <summary>
    /// Clase estática para operaciones matemáticas del supermercado
    /// Ejemplo académico: clase que no se puede instanciar, solo contiene métodos static
    /// </summary>
    public static class CalculadoraSupermercado
    {
        // Constantes estáticas para el negocio
        private static readonly decimal IVA_PORCENTAJE = 13.0m;
        private static readonly decimal DESCUENTO_MAXIMO = 50.0m;

        /// <summary>
        /// Calcula el IVA de un monto dado
        /// Método estático que se llama directamente desde la clase
        /// </summary>
        public static decimal CalcularIVA(decimal monto)
        {
            if (monto < 0)
                throw new ArgumentException("El monto no puede ser negativo");
            
            return monto * (IVA_PORCENTAJE / 100);
        }

        /// <summary>
        /// Calcula el precio total incluyendo IVA
        /// </summary>
        public static decimal CalcularPrecioConIVA(decimal precioSinIVA)
        {
            if (precioSinIVA < 0)
                throw new ArgumentException("El precio no puede ser negativo");
            
            return precioSinIVA + CalcularIVA(precioSinIVA);
        }

        /// <summary>
        /// Aplica un descuento porcentual a un precio
        /// </summary>
        public static decimal AplicarDescuento(decimal precio, decimal porcentajeDescuento)
        {
            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo");
            
            if (porcentajeDescuento < 0 || porcentajeDescuento > DESCUENTO_MAXIMO)
                throw new ArgumentException($"El descuento debe estar entre 0% y {DESCUENTO_MAXIMO}%");
            
            decimal descuento = precio * (porcentajeDescuento / 100);
            return precio - descuento;
        }

        /// <summary>
        /// Calcula el total de una venta con múltiples productos
        /// </summary>
        public static decimal CalcularTotalVenta(decimal subtotal, decimal porcentajeDescuento = 0)
        {
            if (subtotal < 0)
                throw new ArgumentException("El subtotal no puede ser negativo");
            
            decimal subtotalConDescuento = AplicarDescuento(subtotal, porcentajeDescuento);
            return CalcularPrecioConIVA(subtotalConDescuento);
        }

        /// <summary>
        /// Calcula el cambio a devolver en una venta
        /// </summary>
        public static decimal CalcularCambio(decimal totalVenta, decimal montoRecibido)
        {
            if (totalVenta < 0 || montoRecibido < 0)
                throw new ArgumentException("Los montos no pueden ser negativos");
            
            if (montoRecibido < totalVenta)
                throw new ArgumentException("El monto recibido es insuficiente");
            
            return montoRecibido - totalVenta;
        }

        /// <summary>
        /// Verifica si un producto tiene stock suficiente
        /// </summary>
        public static bool VerificarStockSuficiente(int stockActual, int cantidadSolicitada)
        {
            return stockActual >= cantidadSolicitada && cantidadSolicitada > 0;
        }

        /// <summary>
        /// Calcula el precio unitario basado en cantidad y precio total
        /// </summary>
        public static decimal CalcularPrecioUnitario(decimal precioTotal, int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero");
            
            if (precioTotal < 0)
                throw new ArgumentException("El precio total no puede ser negativo");
            
            return precioTotal / cantidad;
        }

        /// <summary>
        /// Redondea un monto a la centésima más cercana (para monedas)
        /// </summary>
        public static decimal RedondearMoneda(decimal monto)
        {
            return Math.Round(monto, 2, MidpointRounding.AwayFromZero);
        }
    }

    /// <summary>
    /// Clase estática para conversiones y formateo
    /// Otra clase estática que agrupa utilidades relacionadas
    /// </summary>
    public static class FormateadorDatos
    {
        /// <summary>
        /// Formatea un precio para mostrar en la UI
        /// </summary>
        public static string FormatearPrecio(decimal precio)
        {
            return $"₡{precio:N2}"; // Formato con símbolo de colón costarricense
        }

        /// <summary>
        /// Formatea una fecha para mostrar solo día/mes/año
        /// </summary>
        public static string FormatearFecha(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Formatea una fecha y hora completa
        /// </summary>
        public static string FormatearFechaHora(DateTime fechaHora)
        {
            return fechaHora.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Convierte un porcentaje decimal a string con símbolo %
        /// </summary>
        public static string FormatearPorcentaje(decimal porcentaje)
        {
            return $"{porcentaje:N1}%";
        }

        /// <summary>
        /// Formatea números enteros con separadores de miles
        /// </summary>
        public static string FormatearCantidad(int cantidad)
        {
            return cantidad.ToString("N0");
        }

        /// <summary>
        /// Convierte texto a formato título (Primera Letra Mayúscula)
        /// </summary>
        public static string ConvertirATitulo(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;
            
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }
    }
}