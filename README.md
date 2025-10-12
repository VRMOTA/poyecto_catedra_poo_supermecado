# 🧩 Proyecto Windows Forms — Configuración Inicial

Este proyecto utiliza **Windows Forms (.NET)** y requiere una configuración inicial al clonar el repositorio por primera vez.  
Sigue los pasos descritos a continuación para evitar errores comunes del diseñador y asegurar que el entorno esté correctamente preparado.

---

## ⚙️ Pasos para configurar el proyecto

### 1. Clonar el repositorio
Clona el repositorio desde Visual Studio o desde Git usando tu método preferido.

### 2. Abrir la consola de PowerShell en Visual Studio
Puedes abrir la consola usando:
- Atajo de teclado: `Ctrl + Ñ`
- Menú: **Ver → Otras ventanas → Consola de Administrador de Paquetes** (según tu versión de Visual Studio)

### 3. Desbloquear archivos `.resx`
Ejecuta el siguiente comando en la consola de PowerShell:

```powershell
Get-ChildItem -Recurse *.resx | Unblock-File
