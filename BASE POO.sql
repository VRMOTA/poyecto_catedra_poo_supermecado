USE MASTER 
DROP DATABASE IF EXISTS db_supermercado
CREATE DATABASE db_supermercado 
USE db_supermercado

-- Tabla de Usuarios (Administradores y Cajeros)
CREATE TABLE tb_usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1), 
    nombre NVARCHAR(75), 
    correo NVARCHAR(75), 
    clave NVARCHAR(100),  -- Considera usar más espacio para hash
    tipo_usuario NVARCHAR(20),  -- 'Administrador', 'Cajero'
    activo BIT DEFAULT 1
); 

-- Tabla de Distribuidores/Proveedores
CREATE TABLE tb_distribuidores (
    id_distribuidor INT PRIMARY KEY IDENTITY(1,1),  
    logo VARBINARY(MAX), 
    nombre NVARCHAR(75) 
);

-- Tabla de Categorías
CREATE TABLE tb_categorias (
    id_categoria INT PRIMARY KEY IDENTITY(1,1), 
    nombre NVARCHAR(50)
); 

-- Tabla de Productos
CREATE TABLE tb_producto (
    id_producto INT PRIMARY KEY IDENTITY(1,1),  
    nombre NVARCHAR(50), 
    precio MONEY, 
    stock INT, 
    imagen VARBINARY(MAX), 
    descripcion NVARCHAR(100), 
    id_distribuidor INT,
    id_categoria INT,
    activo BIT DEFAULT 1,
    CONSTRAINT FK_distribuidor FOREIGN KEY (id_distribuidor) REFERENCES tb_distribuidores(id_distribuidor), 
    CONSTRAINT FK_categoria FOREIGN KEY (id_categoria) REFERENCES tb_categorias(id_categoria)
);

-- Tabla de Promociones (vinculada a productos)
CREATE TABLE tb_promociones (
    id_promocion INT PRIMARY KEY IDENTITY(1,1),  
    id_producto INT,
    cantidad_minima INT,  -- ej: 2 para "2x$4"
    precio_promocional MONEY,  -- ej: $4.00
    descripcion NVARCHAR(100),
    fecha_inicio DATETIME DEFAULT GETDATE(),
    fecha_fin DATETIME,
    activa BIT DEFAULT 1,
    CONSTRAINT FK_producto_promo FOREIGN KEY (id_producto) REFERENCES tb_producto(id_producto)
); 

-- Tabla de Ventas (Cabecera)
CREATE TABLE tb_ventas (
    id_venta INT PRIMARY KEY IDENTITY(1,1), 
    fecha DATETIME DEFAULT GETDATE(),
    id_usuario INT,  -- Cajero que hizo la venta
    nombre_cliente NVARCHAR(75),
    total_venta MONEY,
    total_descuento MONEY,
    estado NVARCHAR(20) DEFAULT 'Completada',  -- 'Completada', 'Cancelada' -- 'Proceso'
    CONSTRAINT FK_usuario_venta FOREIGN KEY (id_usuario) REFERENCES tb_usuario(id_usuario)
);

-- Tabla de Detalle de Ventas (Productos de cada venta)
CREATE TABLE tb_detalle_venta (
    id_detalle INT PRIMARY KEY IDENTITY(1,1),
    id_venta INT,
    id_producto INT,
    cantidad INT,
    precio_unitario MONEY,
    descuento_aplicado MONEY,
    subtotal MONEY,
    CONSTRAINT FK_venta FOREIGN KEY (id_venta) REFERENCES tb_ventas(id_venta),
    CONSTRAINT FK_producto_detalle FOREIGN KEY (id_producto) REFERENCES tb_producto(id_producto)
);
CREATE OR ALTER VIEW vw_detalle_ventas_completo AS
SELECT 
    v.id_venta,
    v.fecha,
    v.nombre_cliente,
    v.id_usuario AS id_cajero,
    u.nombre AS cajero,
    p.nombre AS producto,
    c.nombre AS categoria,
    d.nombre AS distribuidor,
    dv.cantidad,
    dv.precio_unitario,
    dv.descuento_aplicado,
    dv.subtotal,
    v.estado
FROM tb_detalle_venta dv
INNER JOIN tb_ventas v ON dv.id_venta = v.id_venta
INNER JOIN tb_usuario u ON v.id_usuario = u.id_usuario
INNER JOIN tb_producto p ON dv.id_producto = p.id_producto
LEFT JOIN tb_categorias c ON p.id_categoria = c.id_categoria
LEFT JOIN tb_distribuidores d ON p.id_distribuidor = d.id_distribuidor;
GO

SELECT * FROM vw_detalle_ventas_completo

-- Datos de ejemplo
INSERT INTO tb_categorias VALUES 
('Alimentos'),
('Limpieza'),
('Eléctricos'),
('Cárnicos');


INSERT INTO tb_usuario VALUES 
('Admin', 'admin@super.com', '123456', 'Administrador', 1),
('Juan Pérez', 'cajero1@super.com', '123456', 'Cajero', 1);