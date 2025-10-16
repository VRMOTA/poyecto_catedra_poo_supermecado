using System;
using System.Data.Entity;
using System.Linq;
using poyecto_catedra_poo_supermecado.Conexion;

namespace poyecto_catedra_poo_supermecado.Data
{
    /// <summary>
    /// Contexto de base de datos académico siguiendo las prácticas del curso POO104
    /// Hereda de DbContext y define DbSet para cada entidad
    /// </summary>
    public class SupermercadoContext : DbContext
    {
        // Constructor que llama al constructor base con la cadena de conexión
        public SupermercadoContext() : base("name=db_supermercadoEntities1")
        {
            // Configuración académica básica
            Database.SetInitializer<SupermercadoContext>(null);
        }

        // DbSet para cada tabla - siguiendo el patrón académico
        public virtual DbSet<tb_usuario> Usuarios { get; set; }
        public virtual DbSet<tb_producto> Productos { get; set; }
        public virtual DbSet<tb_categorias> Categorias { get; set; }
        public virtual DbSet<tb_distribuidores> Distribuidores { get; set; }
        public virtual DbSet<tb_ventas> Ventas { get; set; }
        public virtual DbSet<tb_detalle_venta> DetalleVentas { get; set; }
        public virtual DbSet<tb_promociones> Promociones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuración mínima para evitar errores de convención
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Clase de acceso a datos académica
    /// Implementa operaciones CRUD básicas usando LINQ como se enseña en clase
    /// </summary>
    public class RepositorioAcademico
    {
        /// <summary>
        /// INSERTAR DATOS - Ejemplo académico de inserción
        /// </summary>
        public static bool InsertarUsuario(string nombre, string correo, string clave, string tipoUsuario)
        {
            try
            {
                // Crear contexto de base de datos
                using (var db = new SupermercadoContext())
                {
                    // Crear nueva entidad
                    var nuevoUsuario = new tb_usuario
                    {
                        nombre = nombre,
                        correo = correo,
                        clave = clave,
                        tipo_usuario = tipoUsuario,
                        activo = true
                    };

                    // Agregar al contexto
                    db.Usuarios.Add(nuevoUsuario);
                    
                    // Guardar cambios
                    db.SaveChanges();
                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// CONSULTAR DATOS - Ejemplo académico con LINQ (sintaxis textual)
        /// </summary>
        public static tb_usuario BuscarUsuarioPorCorreo(string correo)
        {
            using (var db = new SupermercadoContext())
            {
                // LINQ sintaxis textual (como se enseña en clase)
                var usuario = (from u in db.Usuarios
                              where u.correo == correo && u.activo == true
                              select u).FirstOrDefault();
                
                return usuario;
            }
        }

        /// <summary>
        /// CONSULTAR DATOS - Ejemplo académico con LINQ (sintaxis lambda)
        /// </summary>
        public static tb_usuario BuscarUsuarioPorCorreoLambda(string correo)
        {
            using (var db = new SupermercadoContext())
            {
                // LINQ sintaxis lambda (alternativa académica)
                var usuario = db.Usuarios
                    .Where(u => u.correo == correo && u.activo == true)
                    .FirstOrDefault();
                
                return usuario;
            }
        }

        /// <summary>
        /// CONSULTAR MÚLTIPLES REGISTROS - Join académico
        /// </summary>
        public static System.Collections.Generic.List<dynamic> ObtenerProductosConCategoria()
        {
            using (var db = new SupermercadoContext())
            {
                // Join con sintaxis textual LINQ
                var productosConCategoria = (from p in db.Productos
                                           join c in db.Categorias on p.id_categoria equals c.id_categoria
                                           where p.activo == true
                                           select new
                                           {
                                               IdProducto = p.id_producto,
                                               NombreProducto = p.nombre,
                                               Precio = p.precio,
                                               Stock = p.stock,
                                               NombreCategoria = c.nombre
                                           }).ToList<dynamic>();
                
                return productosConCategoria;
            }
        }

        /// <summary>
        /// MODIFICAR DATOS - Ejemplo académico de actualización
        /// </summary>
        public static bool ActualizarStockProducto(int idProducto, int nuevoStock)
        {
            try
            {
                using (var db = new SupermercadoContext())
                {
                    // Buscar el producto a modificar
                    var producto = db.Productos.First(p => p.id_producto == idProducto);
                    
                    // Modificar la propiedad
                    producto.stock = nuevoStock;
                    
                    // Guardar cambios
                    db.SaveChanges();
                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ELIMINAR DATOS - Ejemplo académico de eliminación lógica
        /// </summary>
        public static bool DesactivarUsuario(int idUsuario)
        {
            try
            {
                using (var db = new SupermercadoContext())
                {
                    // Buscar usuario usando LINQ
                    var usuario = (from u in db.Usuarios
                                  where u.id_usuario == idUsuario
                                  select u).First();
                    
                    // Eliminación lógica (cambiar estado en lugar de borrar)
                    usuario.activo = false;
                    
                    // Guardar cambios
                    db.SaveChanges();
                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ELIMINAR FÍSICAMENTE - Ejemplo académico de eliminación real
        /// </summary>
        public static bool EliminarUsuario(int idUsuario)
        {
            try
            {
                using (var db = new SupermercadoContext())
                {
                    // Buscar el usuario
                    var usuario = db.Usuarios.First(u => u.id_usuario == idUsuario);
                    
                    // Eliminar del contexto
                    db.Usuarios.Remove(usuario);
                    
                    // Guardar cambios
                    db.SaveChanges();
                    
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// CONSULTA COMPLEJA - Ejemplo académico con múltiples condiciones
        /// </summary>
        public static System.Collections.Generic.List<dynamic> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var db = new SupermercadoContext())
            {
                // LINQ con múltiples joins y condiciones
                var ventasDetalladas = (from v in db.Ventas
                                      join u in db.Usuarios on v.id_usuario equals u.id_usuario
                                      join dv in db.DetalleVentas on v.id_venta equals dv.id_venta
                                      join p in db.Productos on dv.id_producto equals p.id_producto
                                      where v.fecha >= fechaInicio && v.fecha <= fechaFin
                                      select new
                                      {
                                          IdVenta = v.id_venta,
                                          FechaVenta = v.fecha,
                                          NombreUsuario = u.nombre,
                                          NombreProducto = p.nombre,
                                          Cantidad = dv.cantidad,
                                          PrecioUnitario = dv.precio_unitario,
                                          Subtotal = dv.subtotal
                                      }).ToList<dynamic>();
                
                return ventasDetalladas;
            }
        }

        /// <summary>
        /// OPERACIONES AGREGADAS - Ejemplo académico con funciones de agregación
        /// </summary>
        public static decimal ObtenerTotalVentasDelDia(DateTime fecha)
        {
            using (var db = new SupermercadoContext())
            {
                // LINQ con función de agregación Sum()
                var totalVentas = (from v in db.Ventas
                                 where v.fecha.Value.Date == fecha.Date
                                 select v.total).Sum() ?? 0;
                
                return totalVentas;
            }
        }

        /// <summary>
        /// CONTEO DE REGISTROS - Ejemplo académico con Count()
        /// </summary>
        public static int ContarProductosPorCategoria(int idCategoria)
        {
            using (var db = new SupermercadoContext())
            {
                // LINQ con función Count()
                var cantidad = db.Productos
                    .Where(p => p.id_categoria == idCategoria && p.activo == true)
                    .Count();
                
                return cantidad;
            }
        }
    }
}