# Minuta de Relevamiento - E-commerce de Componentes PC

## Contexto del Proyecto
Una empresa de comercialización de componentes de PC cuenta con un local
comercial para desarrollar su actividad, y ahora desea crear una tienda virtual.

## Proceso Actual
- Local comercial físico como único punto de venta
- Software actual limitado a:
  - Facturación
  - Control de stock
  
## Proceso deseado con el sistema de informacion

Al ingresar al ecommere, cualquier usuario podrán ver todos los productos
disponibles aún sin haber iniciado una sesión en el sistema.
Al registrarse, el cliente podrá iniciar sesión con sus credenciales y agregar
productos al carrito de compras, visualizar la cantidad de productos y monto del
contenido del carrito, y finalmente generar una orden de compra.

## Requerimientos del Sistema

### Funcionalidades Públicas
- Visualización de catálogo de productos
  - Accesible sin necesidad de inicio de sesión
  - Mostrar stock disponible
  - Mostrar precios actualizados

### Funcionalidades para Clientes Registrados
1.  - Registro de usuario
   - Inicio de sesión con credenciales
   - Acceso al historial de compras
  

2. Carrito de Compras
   - Agregar productos
   - Visualizar cantidad de items
   - Generar orden de compra

### Panel de Administración

#### Administradores
Permisos para:
- Gestión de productos
  - Crear nuevos productos
  - Editar productos existentes
  - Eliminar productos
- Gestión de clientes
  - Crear usuarios
  - Editar información
  - Eliminar usuarios


#### Super Administrador
Incluye todos los permisos de administrador más:
- Gestión de administradores
  - Crear nuevos administradores
  - Eliminar administradores existentes

