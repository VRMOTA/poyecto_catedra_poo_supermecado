using System;

namespace poyecto_catedra_poo_supermecado.Models
{
    /// <summary>
    /// Clase abstracta que sirve como base para todos los tipos de productos
    /// No se puede instanciar directamente, solo a través de sus subclases
    /// </summary>
    public abstract class ProductoBase
    {
        // Atributos protegidos accesibles por las subclases
        protected int idProducto;
        protected string nombre;
        protected decimal precio;
        protected int stock;
        protected string descripcion;
        protected bool activo;

        // Constructor protegido para que solo las subclases puedan usarlo
        protected ProductoBase(int idProducto, string nombre, decimal precio, int stock, string descripcion)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.descripcion = descripcion;
            this.activo = true;
        }

        // Constructor vacío protegido
        protected ProductoBase()
        {
            this.activo = true;
        }

        // Propiedades públicas
        public int IdProducto 
        { 
            get { return idProducto; } 
            set { idProducto = value; } 
        }

        public string Nombre 
        { 
            get { return nombre; } 
            set { nombre = value; } 
        }

        public decimal Precio 
        { 
            get { return precio; } 
            set { precio = value; } 
        }

        public int Stock 
        { 
            get { return stock; } 
            set { stock = value; } 
        }

        public string Descripcion 
        { 
            get { return descripcion; } 
            set { descripcion = value; } 
        }

        public bool Activo 
        { 
            get { return activo; } 
            set { activo = value; } 
        }

        // Método abstracto: DEBE ser implementado por todas las subclases
        public abstract string ObtenerTipoProducto();

        // Método abstracto para calcular descuentos específicos de cada tipo
        public abstract decimal CalcularDescuentoAplicable();

        // Método abstracto para verificar disponibilidad según reglas específicas
        public abstract bool VerificarDisponibilidad();

        // Método concreto que pueden usar todas las subclases
        public virtual decimal CalcularPrecioConDescuento()
        {
            decimal descuento = CalcularDescuentoAplicable();
            return precio - (precio * descuento / 100);
        }

        // Método común para todas las subclases
        public string ObtenerInformacionBasica()
        {
            return $"Producto: {nombre}, Precio: ${precio}, Stock: {stock}";
        }
    }

    /// <summary>
    /// Clase derivada para productos perecederos (frutas, verduras, lácteos, etc.)
    /// Implementa todos los métodos abstractos de la clase base
    /// </summary>
    public class ProductoPerecedero : ProductoBase
    {
        private DateTime fechaVencimiento;
        private bool requiereRefrigeracion;

        // Constructor que llama al constructor protegido de la clase base
        public ProductoPerecedero(int idProducto, string nombre, decimal precio, int stock, 
                                 string descripcion, DateTime fechaVencimiento, bool requiereRefrigeracion) 
            : base(idProducto, nombre, precio, stock, descripcion)
        {
            this.fechaVencimiento = fechaVencimiento;
            this.requiereRefrigeracion = requiereRefrigeracion;
        }

        // Constructor vacío
        public ProductoPerecedero() : base()
        {
            this.fechaVencimiento = DateTime.Now.AddDays(7); // 7 días por defecto
            this.requiereRefrigeracion = false;
        }

        public DateTime FechaVencimiento 
        { 
            get { return fechaVencimiento; } 
            set { fechaVencimiento = value; } 
        }

        public bool RequiereRefrigeracion 
        { 
            get { return requiereRefrigeracion; } 
            set { requiereRefrigeracion = value; } 
        }

        // Implementación obligatoria del método abstracto
        public override string ObtenerTipoProducto()
        {
            return "Producto Perecedero";
        }

        // Implementación obligatoria: descuento mayor si está próximo a vencer
        public override decimal CalcularDescuentoAplicable()
        {
            int diasParaVencer = (fechaVencimiento - DateTime.Now).Days;
            
            if (diasParaVencer <= 1)
                return 50; // 50% de descuento
            else if (diasParaVencer <= 3)
                return 25; // 25% de descuento
            else if (diasParaVencer <= 7)
                return 10; // 10% de descuento
            else
                return 0;  // Sin descuento
        }

        // Implementación obligatoria: verificar fecha de vencimiento
        public override bool VerificarDisponibilidad()
        {
            return activo && stock > 0 && fechaVencimiento > DateTime.Now;
        }

        // Método específico para productos perecederos
        public bool EstaProximoAVencer()
        {
            return (fechaVencimiento - DateTime.Now).Days <= 3;
        }
    }

    /// <summary>
    /// Clase derivada para productos no perecederos (enlatados, limpieza, etc.)
    /// </summary>
    public class ProductoNoPerecedero : ProductoBase
    {
        private string marca;
        private int mesesGarantia;

        public ProductoNoPerecedero(int idProducto, string nombre, decimal precio, int stock, 
                                   string descripcion, string marca, int mesesGarantia) 
            : base(idProducto, nombre, precio, stock, descripcion)
        {
            this.marca = marca;
            this.mesesGarantia = mesesGarantia;
        }

        public ProductoNoPerecedero() : base()
        {
            this.marca = "";
            this.mesesGarantia = 12; // 12 meses por defecto
        }

        public string Marca 
        { 
            get { return marca; } 
            set { marca = value; } 
        }

        public int MesesGarantia 
        { 
            get { return mesesGarantia; } 
            set { mesesGarantia = value; } 
        }

        // Implementación obligatoria del método abstracto
        public override string ObtenerTipoProducto()
        {
            return "Producto No Perecedero";
        }

        // Implementación obligatoria: descuento fijo para no perecederos
        public override decimal CalcularDescuentoAplicable()
        {
            // Descuento basado en stock alto
            if (stock > 100)
                return 15; // 15% si hay mucho stock
            else if (stock > 50)
                return 10; // 10% si hay stock moderado
            else
                return 5;  // 5% descuento mínimo
        }

        // Implementación obligatoria: solo verificar stock y estado activo
        public override bool VerificarDisponibilidad()
        {
            return activo && stock > 0;
        }

        // Método específico para productos no perecederos
        public bool TieneGarantiaExtendida()
        {
            return mesesGarantia >= 24;
        }
    }
}