USE db_supermercado
GO

-- ========================================
-- VISTA 1: Resumen completo de todas las ventas
-- ========================================
CREATE VIEW vw_ventas_completas AS
SELECT 
    v.id_venta,
    v.fecha,
    v.nombre_cliente,
    u.nombre AS cajero,
    u.correo AS correo_cajero,
    v.total_venta,
    v.total_descuento,
    v.estado,
    COUNT(dv.id_detalle) AS cantidad_productos,
    (v.total_venta + v.total_descuento) AS total_sin_descuento
FROM tb_ventas v
INNER JOIN tb_usuario u ON v.id_usuario = u.id_usuario
LEFT JOIN tb_detalle_venta dv ON v.id_venta = dv.id_venta
GROUP BY 
    v.id_venta, v.fecha, v.nombre_cliente, u.nombre, u.correo,
    v.total_venta, v.total_descuento, v.estado
GO

-- ========================================
-- VISTA 2: Detalle completo de ventas (productos vendidos)
-- ========================================
CREATE VIEW vw_detalle_ventas_completo AS
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
LEFT JOIN tb_distribuidores d ON p.id_distribuidor = d.id_distribuidor
GO

-- ========================================
-- VISTA 3: Ventas por cajero (resumen estadístico)
-- ========================================
CREATE VIEW vw_ventas_por_cajero AS
SELECT 
    u.id_usuario,
    u.nombre AS cajero,
    u.correo,
    COUNT(v.id_venta) AS total_ventas,
    SUM(v.total_venta) AS monto_total_vendido,
    SUM(v.total_descuento) AS total_descuentos_aplicados,
    AVG(v.total_venta) AS promedio_venta,
    MAX(v.fecha) AS ultima_venta,
    MIN(v.fecha) AS primera_venta
FROM tb_usuario u
LEFT JOIN tb_ventas v ON u.id_usuario = v.id_usuario AND v.estado = 'Completada'
WHERE u.tipo_usuario = 'Cajero'
GROUP BY u.id_usuario, u.nombre, u.correo
GO

-- ========================================
-- VISTA 4: Productos más vendidos
-- ========================================
CREATE VIEW vw_productos_mas_vendidos AS
SELECT 
    p.id_producto,
    p.nombre AS producto,
    c.nombre AS categoria,
    d.nombre AS distribuidor,
    SUM(dv.cantidad) AS unidades_vendidas,
    SUM(dv.subtotal) AS ingresos_totales,
    COUNT(DISTINCT dv.id_venta) AS numero_ventas,
    AVG(dv.precio_unitario) AS precio_promedio
FROM tb_detalle_venta dv
INNER JOIN tb_producto p ON dv.id_producto = p.id_producto
INNER JOIN tb_ventas v ON dv.id_venta = v.id_venta
LEFT JOIN tb_categorias c ON p.id_categoria = c.id_categoria
LEFT JOIN tb_distribuidores d ON p.id_distribuidor = d.id_distribuidor
WHERE v.estado = 'Completada'
GROUP BY p.id_producto, p.nombre, c.nombre, d.nombre
GO

-- ========================================
-- VISTA 5: Ventas por período (día/mes)
-- ========================================
CREATE VIEW vw_ventas_por_periodo AS
SELECT 
    CAST(v.fecha AS DATE) AS fecha_venta,
    YEAR(v.fecha) AS año,
    MONTH(v.fecha) AS mes,
    DAY(v.fecha) AS dia,
    DATENAME(WEEKDAY, v.fecha) AS dia_semana,
    COUNT(v.id_venta) AS cantidad_ventas,
    SUM(v.total_venta) AS total_vendido,
    SUM(v.total_descuento) AS total_descuentos,
    AVG(v.total_venta) AS promedio_venta
FROM tb_ventas v
WHERE v.estado = 'Completada'
GROUP BY CAST(v.fecha AS DATE), YEAR(v.fecha), MONTH(v.fecha), 
         DAY(v.fecha), DATENAME(WEEKDAY, v.fecha)
GO

-- ========================================
-- EJEMPLOS DE USO
-- ========================================

-- Ver todas las ventas con información resumida
SELECT * FROM vw_ventas_completas ORDER BY fecha DESC

-- Ver detalle completo de productos vendidos
SELECT * FROM vw_detalle_ventas_completo 
WHERE id_cajero = 2
ORDER BY fecha DESC

SELECT * FROM vw_detalle_ventas_completo 
WHERE id_cajero = 2
ORDER BY fecha DESC

SELECT * FROM vw_detalle_ventas_completo 
WHERE id_venta = 11 AND id_cajero = 2
ORDER BY fecha DESC

SELECT 
    id_venta,
    MAX(fecha) AS fecha,
    MAX(nombre_cliente) AS cliente,
    MAX(cajero) AS cajero,
    COUNT(*) AS productos,
    SUM(cantidad) AS unidades,
    SUM(subtotal) AS total,
    MAX(estado) AS estado
FROM vw_detalle_ventas_completo 
GROUP BY id_venta
ORDER BY MAX(fecha) DESC

-- Ver ventas de un cajero específico
SELECT * FROM vw_ventas_completas WHERE cajero = 'JOSE'

-- Ver estadísticas por cajero
-- SELECT * FROM vw_ventas_por_cajero ORDER BY monto_total_vendido DESC

-- Ver productos más vendidos
-- SELECT TOP 10 * FROM vw_productos_mas_vendidos ORDER BY unidades_vendidas DESC

-- Ver ventas de hoy
-- SELECT * FROM vw_ventas_por_periodo WHERE fecha_venta = CAST(GETDATE() AS DATE)

-- Ver ventas del mes actual
-- SELECT * FROM vw_ventas_por_periodo 
-- WHERE año = YEAR(GETDATE()) AND mes = MONTH(GETDATE())

---------------------------------------------------- 
CREATE  VIEW vw_detalle_ventas_completo AS
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
LEFT JOIN tb_distribuidores d ON p.id_distribuidor = d.id_distribuidor
GO


SELECT id_venta, fecha, nombre_cliente, cajero, producto,categoria,cantidad,precio_unitario, descuento_aplicado, subtotal, estado FROM vw_detalle_ventas_completo 




WHERE id_cajero = 2
ORDER BY fecha DESC

SELECT * FROM vw_detalle_ventas_completo 
WHERE id_venta = 11 AND id_cajero = 2
ORDER BY fecha DESC


SELECT 
    id_venta,
    MAX(fecha) AS fecha,
    MAX(nombre_cliente) AS cliente,
    MAX(cajero) AS cajero,
    COUNT(*) AS productos,
    SUM(cantidad) AS unidades,
    SUM(subtotal) AS total,
    MAX(estado) AS estado
FROM vw_detalle_ventas_completo 
GROUP BY id_venta
ORDER BY MAX(fecha) DESC