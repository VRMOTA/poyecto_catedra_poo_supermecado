using System;

namespace poyecto_catedra_poo_supermecado.Models
{
    /// <summary>
    /// Clase base para todos los tipos de usuarios del sistema
    /// Ejemplo de herencia simple: Una superclase que define propiedades comunes
    /// </summary>
    public class Usuario
    {
        // Atributos protegidos: solo accesibles por esta clase y sus subclases
        protected int idUsuario;
        protected string nombre;
        protected string correo;
        protected string clave;
        protected bool activo;

        // Constructor de la clase base que inicializa los atributos comunes
        public Usuario(int idUsuario, string nombre, string correo, string clave)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.correo = correo;
            this.clave = clave;
            this.activo = true; // Por defecto, usuario activo
        }

        // Constructor vacío para Entity Framework
        public Usuario()
        {
            this.activo = true;
        }

        // Propiedades públicas para acceso controlado
        public int IdUsuario 
        { 
            get { return idUsuario; } 
            set { idUsuario = value; } 
        }

        public string Nombre 
        { 
            get { return nombre; } 
            set { nombre = value; } 
        }

        public string Correo 
        { 
            get { return correo; } 
            set { correo = value; } 
        }

        public string Clave 
        { 
            get { return clave; } 
            set { clave = value; } 
        }

        public bool Activo 
        { 
            get { return activo; } 
            set { activo = value; } 
        }

        // Método que puede ser sobrescrito por las subclases
        public virtual string ObtenerTipoUsuario()
        {
            return "Usuario Genérico";
        }

        // Método común para todos los usuarios
        public string ObtenerInformacionCompleta()
        {
            return $"ID: {idUsuario}, Nombre: {nombre}, Correo: {correo}, Activo: {activo}";
        }
    }

    /// <summary>
    /// Clase derivada (subclase) para usuarios tipo Administrador
    /// Hereda de Usuario usando : (dos puntos)
    /// </summary>
    public class Administrador : Usuario
    {
        private DateTime fechaUltimoAcceso;
        private int numeroOperacionesRealizadas;

        // Constructor que llama al constructor de la clase base usando base()
        public Administrador(int idUsuario, string nombre, string correo, string clave) 
            : base(idUsuario, nombre, correo, clave)
        {
            this.fechaUltimoAcceso = DateTime.Now;
            this.numeroOperacionesRealizadas = 0;
        }

        // Constructor vacío para Entity Framework
        public Administrador() : base()
        {
            this.fechaUltimoAcceso = DateTime.Now;
            this.numeroOperacionesRealizadas = 0;
        }

        public DateTime FechaUltimoAcceso 
        { 
            get { return fechaUltimoAcceso; } 
            set { fechaUltimoAcceso = value; } 
        }

        public int NumeroOperacionesRealizadas 
        { 
            get { return numeroOperacionesRealizadas; } 
            set { numeroOperacionesRealizadas = value; } 
        }

        // Sobrescribir el método de la clase base
        public override string ObtenerTipoUsuario()
        {
            return "Administrador";
        }

        // Método específico para administradores
        public void RegistrarOperacion()
        {
            numeroOperacionesRealizadas++;
            fechaUltimoAcceso = DateTime.Now;
        }

        // Método específico que usa atributos protegidos de la clase base
        public bool PuedeGestionarUsuarios()
        {
            // Acceso a atributo protegido 'activo' desde la subclase
            return activo && numeroOperacionesRealizadas >= 0;
        }
    }

    /// <summary>
    /// Clase derivada (subclase) para usuarios tipo Cajero
    /// También hereda de Usuario
    /// </summary>
    public class Cajero : Usuario
    {
        private decimal totalVentasDelDia;
        private int numeroVentasRealizadas;

        // Constructor que llama al constructor de la clase base
        public Cajero(int idUsuario, string nombre, string correo, string clave) 
            : base(idUsuario, nombre, correo, clave)
        {
            this.totalVentasDelDia = 0;
            this.numeroVentasRealizadas = 0;
        }

        // Constructor vacío para Entity Framework
        public Cajero() : base()
        {
            this.totalVentasDelDia = 0;
            this.numeroVentasRealizadas = 0;
        }

        public decimal TotalVentasDelDia 
        { 
            get { return totalVentasDelDia; } 
            set { totalVentasDelDia = value; } 
        }

        public int NumeroVentasRealizadas 
        { 
            get { return numeroVentasRealizadas; } 
            set { numeroVentasRealizadas = value; } 
        }

        // Sobrescribir el método de la clase base
        public override string ObtenerTipoUsuario()
        {
            return "Cajero";
        }

        // Método específico para cajeros
        public void RegistrarVenta(decimal montoVenta)
        {
            totalVentasDelDia += montoVenta;
            numeroVentasRealizadas++;
        }

        // Método que calcula promedio usando atributos protegidos
        public decimal ObtenerPromedioVentas()
        {
            if (numeroVentasRealizadas == 0) return 0;
            return totalVentasDelDia / numeroVentasRealizadas;
        }
    }
}