# 📚 APLICACIÓN DE CONCEPTOS POO104 - SUPERMERCADO

## 🎓 **ENFOQUE ACADÉMICO UNIVERSITARIO**

Este proyecto demuestra la aplicación práctica de los conceptos de **Programación Orientada a Objetos** y **Entity Framework** tal como se enseñan en el curso universitario POO104.

---

## 🔷 **PARTE 1: PROGRAMACIÓN ORIENTADA A OBJETOS**

### **1. HERENCIA SIMPLE**

#### 📖 **Concepto Académico:**
- Una **clase base** (superclase) define propiedades comunes
- Las **clases derivadas** (subclases) heredan usando `:` (dos puntos)
- Se usa `base()` en el constructor de la subclase para llamar al constructor de la superclase

#### 💻 **Implementación:**

**Archivo:** `Models/Usuario.cs`

```csharp
// CLASE BASE (Superclase)
public class Usuario
{
    protected int idUsuario;      // Atributo protegido
    protected string nombre;      // Solo accesible por subclases
    protected string correo;
    
    // Constructor de la clase base
    public Usuario(int idUsuario, string nombre, string correo, string clave)
    {
        this.idUsuario = idUsuario;
        this.nombre = nombre;
        // ...
    }
}

// CLASE DERIVADA (Subclase)
public class Administrador : Usuario  // Herencia con :
{
    private int numeroOperacionesRealizadas;
    
    // Constructor que llama al constructor base
    public Administrador(int id, string nombre, string correo, string clave) 
        : base(id, nombre, correo, clave)  // Llamada a base()
    {
        this.numeroOperacionesRealizadas = 0;
    }
    
    // Método específico de la subclase
    public void RegistrarOperacion()
    {
        numeroOperacionesRealizadas++;
    }
}
```

#### 🎯 **Ejemplo de Uso:**
```csharp
// Crear instancia de la clase base
Usuario usuarioGenerico = new Usuario(1, "Juan", "juan@email.com", "123");

// Crear instancia de la subclase
Administrador admin = new Administrador(2, "María", "maria@email.com", "admin123");

// Polimorfismo: mismo método, comportamiento diferente
Console.WriteLine(usuarioGenerico.ObtenerTipoUsuario()); // "Usuario Genérico"
Console.WriteLine(admin.ObtenerTipoUsuario());           // "Administrador"
```

---

### **2. CLASES ABSTRACTAS**

#### 📖 **Concepto Académico:**
- `abstract class` no se puede instanciar directamente
- `abstract` métodos DEBEN ser implementados por todas las subclases
- Las subclases DEBEN usar `override` para implementar métodos abstractos

#### 💻 **Implementación:**

**Archivo:** `Models/ProductoBase.cs`

```csharp
// CLASE ABSTRACTA (No se puede instanciar)
public abstract class ProductoBase
{
    protected string nombre;
    protected decimal precio;
    
    // Constructor protegido
    protected ProductoBase(string nombre, decimal precio)
    {
        this.nombre = nombre;
        this.precio = precio;
    }
    
    // MÉTODO ABSTRACTO: debe ser implementado por subclases
    public abstract string ObtenerTipoProducto();
    public abstract decimal CalcularDescuentoAplicable();
}

// SUBCLASE que implementa métodos abstractos
public class ProductoPerecedero : ProductoBase
{
    private DateTime fechaVencimiento;
    
    public ProductoPerecedero(string nombre, decimal precio, DateTime fechaVencimiento) 
        : base(nombre, precio)
    {
        this.fechaVencimiento = fechaVencimiento;
    }
    
    // IMPLEMENTACIÓN OBLIGATORIA del método abstracto
    public override string ObtenerTipoProducto()
    {
        return "Producto Perecedero";
    }
    
    // IMPLEMENTACIÓN OBLIGATORIA
    public override decimal CalcularDescuentoAplicable()
    {
        int diasParaVencer = (fechaVencimiento - DateTime.Now).Days;
        if (diasParaVencer <= 1) return 50; // 50% descuento
        return 0;
    }
}
```

#### 🎯 **Ejemplo de Uso:**
```csharp
// NO SE PUEDE: ProductoBase producto = new ProductoBase(); ❌

// SÍ SE PUEDE: Crear instancias de subclases
ProductoPerecedero leche = new ProductoPerecedero("Leche", 850, DateTime.Now.AddDays(3));
ProductoNoPerecedero arroz = new ProductoNoPerecedero("Arroz", 1200, "Tío Pelón");

// Cada subclase implementa su propia lógica
Console.WriteLine(leche.ObtenerTipoProducto()); // "Producto Perecedero"
Console.WriteLine(arroz.ObtenerTipoProducto()); // "Producto No Perecedero"
```

---

### **3. CLASES ESTÁTICAS**

#### 📖 **Concepto Académico:**
- `static class` no se puede instanciar
- Todos los métodos deben ser `static`
- Se usan para agrupar utilidades relacionadas
- Se llaman directamente desde la clase

#### 💻 **Implementación:**

**Archivo:** `Utilities/CalculadoraSupermercado.cs`

```csharp
// CLASE ESTÁTICA (No se puede instanciar)
public static class CalculadoraSupermercado
{
    private static readonly decimal IVA_PORCENTAJE = 13.0m;
    
    // MÉTODO ESTÁTICO
    public static decimal CalcularIVA(decimal monto)
    {
        return monto * (IVA_PORCENTAJE / 100);
    }
    
    public static decimal CalcularPrecioConIVA(decimal precioSinIVA)
    {
        return precioSinIVA + CalcularIVA(precioSinIVA);
    }
}

public static class FormateadorDatos
{
    public static string FormatearPrecio(decimal precio)
    {
        return $"₡{precio:N2}";
    }
    
    public static string FormatearFecha(DateTime fecha)
    {
        return fecha.ToString("dd/MM/yyyy");
    }
}
```

#### 🎯 **Ejemplo de Uso:**
```csharp
// NO SE PUEDE: CalculadoraSupermercado calc = new CalculadoraSupermercado(); ❌

// SÍ SE PUEDE: Llamar métodos estáticos directamente
decimal precio = 1000.0m;
decimal iva = CalculadoraSupermercado.CalcularIVA(precio);           // 130.00
decimal total = CalculadoraSupermercado.CalcularPrecioConIVA(precio); // 1130.00
string precioFormateado = FormateadorDatos.FormatearPrecio(total);    // "₡1,130.00"
```

---

## 🔷 **PARTE 2: ENTITY FRAMEWORK CON LINQ**

### **1. CONTEXTO DE BASE DE DATOS**

#### 📖 **Concepto Académico:**
- Clase que hereda de `DbContext`
- Define `DbSet<T>` para cada tabla
- Se usa `using` para manejo automático de recursos

#### 💻 **Implementación:**

**Archivo:** `Data/SupermercadoContext.cs`

```csharp
// CONTEXTO ACADÉMICO
public class SupermercadoContext : DbContext
{
    // Constructor que llama al constructor base
    public SupermercadoContext() : base("name=db_supermercadoEntities1")
    {
    }
    
    // DbSet para cada tabla
    public virtual DbSet<tb_usuario> Usuarios { get; set; }
    public virtual DbSet<tb_producto> Productos { get; set; }
    public virtual DbSet<tb_categorias> Categorias { get; set; }
}
```

---

### **2. OPERACIONES CRUD ACADÉMICAS**

#### **A) INSERTAR DATOS**

```csharp
public static bool InsertarUsuario(string nombre, string correo, string clave)
{
    using (var db = new SupermercadoContext())
    {
        // Crear nueva entidad
        var nuevoUsuario = new tb_usuario
        {
            nombre = nombre,
            correo = correo,
            clave = clave,
            activo = true
        };
        
        // Agregar al contexto
        db.Usuarios.Add(nuevoUsuario);
        
        // Guardar cambios
        db.SaveChanges();
        
        return true;
    }
}
```

#### **B) CONSULTAR DATOS - LINQ Sintaxis Textual**

```csharp
public static tb_usuario BuscarUsuarioPorCorreo(string correo)
{
    using (var db = new SupermercadoContext())
    {
        // LINQ sintaxis textual (estilo académico)
        var usuario = (from u in db.Usuarios
                      where u.correo == correo && u.activo == true
                      select u).FirstOrDefault();
        
        return usuario;
    }
}
```

#### **C) CONSULTAR DATOS - LINQ Sintaxis Lambda**

```csharp
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
```

#### **D) CONSULTAS CON JOIN**

```csharp
public static List<dynamic> ObtenerProductosConCategoria()
{
    using (var db = new SupermercadoContext())
    {
        // Join académico con sintaxis textual
        var productos = (from p in db.Productos
                        join c in db.Categorias on p.id_categoria equals c.id_categoria
                        where p.activo == true
                        select new
                        {
                            IdProducto = p.id_producto,
                            NombreProducto = p.nombre,
                            Precio = p.precio,
                            NombreCategoria = c.nombre
                        }).ToList<dynamic>();
        
        return productos;
    }
}
```

#### **E) MODIFICAR DATOS**

```csharp
public static bool ActualizarStockProducto(int idProducto, int nuevoStock)
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
```

#### **F) ELIMINAR DATOS**

```csharp
// Eliminación lógica (recomendada)
public static bool DesactivarUsuario(int idUsuario)
{
    using (var db = new SupermercadoContext())
    {
        var usuario = db.Usuarios.First(u => u.id_usuario == idUsuario);
        usuario.activo = false; // Cambiar estado
        db.SaveChanges();
        return true;
    }
}

// Eliminación física
public static bool EliminarUsuario(int idUsuario)
{
    using (var db = new SupermercadoContext())
    {
        var usuario = db.Usuarios.First(u => u.id_usuario == idUsuario);
        db.Usuarios.Remove(usuario); // Eliminar del contexto
        db.SaveChanges();
        return true;
    }
}
```

---

### **3. CONSULTAS COMPLEJAS ACADÉMICAS**

#### **A) Consultas con Agregación**

```csharp
// Contar registros
public static int ContarProductosPorCategoria(int idCategoria)
{
    using (var db = new SupermercadoContext())
    {
        var cantidad = db.Productos
            .Where(p => p.id_categoria == idCategoria && p.activo == true)
            .Count();
        
        return cantidad;
    }
}

// Sumar valores
public static decimal ObtenerTotalVentasDelDia(DateTime fecha)
{
    using (var db = new SupermercadoContext())
    {
        var totalVentas = (from v in db.Ventas
                          where v.fecha.Value.Date == fecha.Date
                          select v.total).Sum() ?? 0;
        
        return totalVentas;
    }
}
```

#### **B) Consultas con Múltiples Joins**

```csharp
public static List<dynamic> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
{
    using (var db = new SupermercadoContext())
    {
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
                                  Subtotal = dv.subtotal
                              }).ToList<dynamic>();
        
        return ventasDetalladas;
    }
}
```

---

## 🔷 **APLICACIÓN EN FORMULARIOS**

### **Ejemplo en `frm_usuarios.cs`:**

```csharp
public partial class frm_usuarios : Form
{
    private void CargarUsuarios()
    {
        // Usar contexto académico
        using (var db = new SupermercadoContext())
        {
            // LINQ sintaxis textual
            var listaUsuarios = (from u in db.Usuarios
                               where u.activo == true
                               orderby u.nombre ascending
                               select new
                               {
                                   u.id_usuario,
                                   u.nombre,
                                   u.correo,
                                   u.tipo_usuario
                               }).ToList<dynamic>();
            
            foreach (var usuarioDB in listaUsuarios)
            {
                // Aplicar herencia según tipo
                Usuario usuario = CrearUsuarioSegunTipo(usuarioDB);
                
                // Usar método polimórfico
                string tipo = usuario.ObtenerTipoUsuario();
                
                // Crear card con información
                var card = new card_usuarios
                {
                    NombreUsuario = usuarioDB.nombre,
                    CorreoUsuario = usuarioDB.correo
                };
                
                panel_cards.Controls.Add(card);
            }
        }
    }
    
    // Demostrar herencia
    private Usuario CrearUsuarioSegunTipo(dynamic usuarioDB)
    {
        if (usuarioDB.tipo_usuario == "Administrador")
        {
            return new Administrador(usuarioDB.id_usuario, usuarioDB.nombre, 
                                   usuarioDB.correo, "");
        }
        else if (usuarioDB.tipo_usuario == "Cajero")
        {
            return new Cajero(usuarioDB.id_usuario, usuarioDB.nombre, 
                            usuarioDB.correo, "");
        }
        else
        {
            return new Usuario(usuarioDB.id_usuario, usuarioDB.nombre, 
                             usuarioDB.correo, "");
        }
    }
}
```

---

## 📊 **EJEMPLO COMPLETO COMBINADO**

**Archivo:** `Examples/EjemploAcademicoPOO.cs`

```csharp
private void DemostrarConceptosPOO()
{
    // 1. HERENCIA SIMPLE
    Administrador admin = new Administrador(1, "María", "maria@email.com", "123");
    Cajero cajero = new Cajero(2, "Carlos", "carlos@email.com", "456");
    
    // Polimorfismo
    Console.WriteLine(admin.ObtenerTipoUsuario()); // "Administrador"
    Console.WriteLine(cajero.ObtenerTipoUsuario()); // "Cajero"
    
    // 2. CLASES ABSTRACTAS
    ProductoPerecedero leche = new ProductoPerecedero("Leche", 850, DateTime.Now.AddDays(3));
    ProductoNoPerecedero arroz = new ProductoNoPerecedero("Arroz", 1200, "Marca");
    
    // Métodos abstractos implementados diferente en cada subclase
    decimal descuentoLeche = leche.CalcularDescuentoAplicable(); // Lógica de vencimiento
    decimal descuentoArroz = arroz.CalcularDescuentoAplicable(); // Lógica de stock
    
    // 3. CLASES ESTÁTICAS
    decimal precio = 1000m;
    decimal iva = CalculadoraSupermercado.CalcularIVA(precio);
    string precioFormateado = FormateadorDatos.FormatearPrecio(precio);
    
    // 4. ENTITY FRAMEWORK
    using (var db = new SupermercadoContext())
    {
        var usuarios = (from u in db.Usuarios
                       where u.activo == true
                       select u).ToList();
        
        foreach (var user in usuarios)
        {
            Console.WriteLine($"Usuario: {user.nombre}");
        }
    }
}
```

---

## 🎯 **TÉRMINOS ACADÉMICOS CLAVE**

- **Clase Base / Superclase:** Usuario
- **Clase Derivada / Subclase:** Administrador, Cajero
- **Herencia:** Uso de `:` para heredar
- **Constructor Base:** Uso de `base()` en subclases
- **Atributos Protegidos:** `protected` para acceso en subclases
- **Polimorfismo:** Mismo método, comportamiento diferente
- **Clase Abstracta:** `abstract class` que no se puede instanciar
- **Método Abstracto:** `abstract` que debe implementarse en subclases
- **Clase Estática:** `static class` para métodos utilitarios
- **DbContext:** Contexto de base de datos de Entity Framework
- **DbSet:** Conjunto de entidades para operaciones CRUD
- **LINQ:** Consultas integradas al lenguaje (textual y lambda)

---

## ✅ **CONCEPTOS APLICADOS CORRECTAMENTE**

✓ **Herencia simple** con `:` y `base()`  
✓ **Clases abstractas** con métodos `abstract`  
✓ **Clases estáticas** para utilidades  
✓ **Modificadores de acceso** (`protected`, `private`, `public`)  
✓ **Entity Framework** con `DbContext` y `DbSet<T>`  
✓ **LINQ** sintaxis textual y lambda  
✓ **Operaciones CRUD** académicas  
✓ **Polimorfismo** con `override`  
✓ **Encapsulamiento** con propiedades  

---

## 🚫 **LO QUE NO SE USA (Patrones Modernos)**

❌ Inyección de dependencias  
❌ Repositorios y servicios  
❌ Arquitectura en capas  
❌ Interfaces (para herencia múltiple)  
❌ Patrones empresariales  
❌ Migraciones automáticas  
❌ Code First  

---

## 📁 **ESTRUCTURA DE ARCHIVOS**

```
poyecto_catedra_poo_supermecado/
├── Models/
│   ├── Usuario.cs (Herencia simple)
│   └── ProductoBase.cs (Clases abstractas)
├── Data/
│   └── SupermercadoContext.cs (Entity Framework académico)
├── Utilities/
│   ├── CalculadoraSupermercado.cs (Clases estáticas)
│   └── Validaciones.cs (Clase estática mejorada)
├── Examples/
│   └── EjemploAcademicoPOO.cs (Demostración completa)
└── Forms/
    └── frm_usuarios.cs (Aplicación en UI)
```

Este enfoque académico sigue exactamente lo que se enseña en el curso universitario POO104, sin introducir conceptos modernos de desarrollo empresarial.