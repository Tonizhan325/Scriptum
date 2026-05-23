# Scriptum - Biblioteca Digital

[![.NET Version](https://img.shields.io/badge/.NET-9.0-blue)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15%2B-blue)](https://www.postgresql.org/)
[![Cloudinary](https://img.shields.io/badge/Cloudinary-Integration-blue)](https://cloudinary.com/)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)

## Descripción

Scriptum es una aplicación web para la gestión de libros digitales que permite a los usuarios subir, editar y visualizar libros en formato PDF junto con sus portadas. El sistema calcula automáticamente el tamaño de los archivos y los almacena en la nube mediante Cloudinary.

## Características Principales

- **Subida de libros** - Carga de archivos PDF y portadas simultáneamente
- **Almacenamiento en la nube** - Integración con Cloudinary para guardar archivos
- **Tamaño automático** - Cálculo del tamaño del archivo en MB con 2 decimales
- **Búsqueda avanzada** - Filtrado por título y nombre del autor
- **Edición independiente** - Actualización de PDF y portada por separado sin afectar al otro
- **Autenticación segura** - Sistema de usuarios con ASP.NET Core Identity
- **Gestión de géneros** - Clasificación de libros por categorías
- **Diseño responsive** - Interfaz adaptada a todos los dispositivos

## 🛠️ Tecnologías Utilizadas

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| ASP.NET Core | 9.0 | Framework backend |
| Entity Framework Core | 9.0 | ORM para base de datos |
| PostgreSQL | 15+ | Base de datos relacional |
| Cloudinary | - | Almacenamiento de archivos en la nube |
| ASP.NET Core Identity | 9.0 | Autenticación y autorización |
| HTML5/CSS3/JavaScript | - | Interfaz de usuario |
| Bootstrap | 5.x | Estilos y componentes |

## 📋 Requisitos Previos

Antes de comenzar, necesitas tener instalado:
- **.NET 9 SDK** - Para compilar y ejecutar la aplicación
- **PostgreSQL** (versión 15 o superior) - Base de datos relacional
- **Git** - Para clonar el repositorio
- **Cuenta gratuita en Cloudinary** - Para el almacenamiento de archivos (PDF e imágenes)

## Instalacion y Configuracion

Sigue estos pasos para instalar y ejecutar el proyecto en Visual Studio Code:

### Paso 1: Clonar el repositorio

Abre Visual Studio Code y presiona Ctrl + Shift + P (Windows/Linux) o Cmd + Shift + P (Mac). Escribe "Git: Clone" y selecciona la opcion. Ingresa la URL del repositorio y elige la carpeta donde deseas guardar el proyecto. Alternativamente, abre la terminal integrada de VS Code con Ctrl + Ñ y ejecuta:

- git clone https://github.com/tu-usuario/scriptum.git
- cd scriptum

### Paso 2: Abrir el proyecto en Visual Studio Code

Una vez clonado, abre la carpeta del proyecto en VS Code seleccionando Archivo > Abrir carpeta.

### Paso 3: Restaurar paquetes NuGet

Abre la terminal integrada con Ctrl + Ñ y ejecuta:

- dotnet restore

### Paso 4: Instalar herramientas Entity Framework Core

- dotnet tool install --global dotnet-ef

### Paso 5: Crear la base de datos en PostgreSQL

Abre pgAdmin o la terminal de PostgreSQL y crea la base de datos:

- CREATE DATABASE ScriptumDB;

### Paso 6: Configurar la cadena de conexion

En Visual Studio Code, crea un archivo en la raiz del proyecto llamado `appsettings.Development.json` con el siguiente contenido:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ScriptumDB;Username=postgres;Password=tu_contraseña"
  }
}

Reemplaza `tu_contraseña` con la contraseña de tu usuario de PostgreSQL.

### Paso 7: Configurar Cloudinary

En el mismo archivo `appsettings.Development.json`, agrega la configuracion de Cloudinary. El archivo completo quedaria asi:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ScriptumDB;Username=postgres;Password=tu_contraseña"
  },
  "CloudinarySettings": {
    "CloudinaryUrl": "cloudinary://tu_api_key:tu_api_secret@tu_cloud_name"
  }
}

Para obtener tu Cloudinary URL:
1. Ve a cloudinary.com e inicia sesion
2. En el Dashboard, busca "Account Details" o "API Environment variable"
3. Copia la URL que se ve similar a: `cloudinary://123456789123456:abc123def456ghi789jkl@mi-super-cloud`
4. Pega esa URL en el campo `CloudinaryUrl`

### Paso 8: Aplicar las migraciones a la base de datos

En la terminal integrada de VS Code, ejecuta estos comandos en orden:

- dotnet ef migrations add InitialCreate
- dotnet ef database update

Si aparece un error diciendo que no se encuentra el comando "dotnet-ef", cierra y vuelve a abrir la terminal de VS Code, y repite los comandos. Cuando veas el mensaje "Done." o "Aplicando migracion... Hecho", significa que la base de datos se creo correctamente.

### Paso 9: Ejecutar la aplicacion

En la terminal integrada de VS Code, ejecuta:

- dotnet run

Espera a que aparezca un mensaje similar a:

Now listening on: http://localhost:5000
Now listening on: https://localhost:5001

La aplicacion ya esta corriendo. Para abrirla, mantén presionada la tecla Ctrl (Windows/Linux) o Cmd (Mac) y haz clic en cualquiera de las dos direcciones que aparecen en la terminal. Para detener la aplicacion, presiona Ctrl + C en la terminal.

### Extensiones recomendadas para Visual Studio Code

Instala las siguientes extensiones:
- C# Dev Kit (Microsoft)
- C# Extensions (jchannon)
- PostgreSQL (Chris Kolkman)
- NuGet Gallery (pcislo)
- GitLens (GitKraken)

### Solucion de problemas comunes en VS Code

Error: dotnet-ef no se reconoce como comando: Ejecuta dotnet tool install --global dotnet-ef y reinicia VS Code.

Error: No se puede conectar a PostgreSQL: Verifica que PostgreSQL este ejecutandose. En Windows busca "Services" y asegurate que "postgresql" este iniciado. En Mac/Linux ejecuta sudo systemctl start postgresql.

Error: La base de datos no se crea: Verifica que la cadena de conexion en appsettings.Development.json sea correcta y que la contraseña no tenga errores.

### Credenciales de admin

- Email: admin@empresa.com
- Contraseña: Admin-123

##Estructura del Proyecto

Scriptum
├── Controllers
│   ├── LibrosController.cs
│   ├── CatalogoController.cs
│   ├── HomeController.cs
│   ├── UsuariosController.cs
│   ├── MisDatosController.cs
│   └── GenerosController.cs
│
├── Models
│   ├── Libro.cs
│   ├── Usuario.cs
│   ├── Genero.cs
│   ├── Reseña.cs
│   ├── Subida.cs
│   └── Descarga.cs
│
├── Views
│   ├── Libros
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Details.cshtml
│   ├── Catalogo
│   │   └── Index.cshtml
│   ├── Usuarios
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Details.cshtml
│   ├── Generos
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Details.cshtml
│   ├── MisDatos
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   └── Shared
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Migrations
│   └── (archivos de migracion)
│
├── wwwroot
│   ├── css
│   ├── js
│   └── images
│
├── Program.cs
├── appsettings.json
├── SeedData.cs
├── Utils.cs
├── PaginatedList.cs
└── Scriptum.csproj

## Uso

Para subir un nuevo libro, haz clic en tu perfil registrado y dale a "Subir Libro", completa el formulario con título, descripción, idioma, autor, tipo y género, selecciona un archivo PDF y opcionalmente una imagen de portada, luego haz clic en "Guardar". El tamaño del archivo se calcula automáticamente en megabytes.

Para editar un libro, haz clic en "Editar" en el listado, modifica los campos necesarios, y si quieres cambiar el PDF selecciona un nuevo archivo, si quieres cambiar la portada selecciona una nueva imagen. Los campos de archivo son independientes: puedes cambiar solo el PDF, solo la imagen, o ambos. Luego haz clic en "Guardar cambios".

Para buscar libros, usa el buscador en la página principal filtrando por título o nombre del autor, haz clic en "Buscar" y usa "Limpiar filtros" para resetear la búsqueda.

## Modelo de Datos

Las principales entidades son Usuario que hereda de IdentityUser con clave primaria int, Libro que almacena título, autor, tamaño del archivo como decimal, URL del PDF y enlace de la imagen y Género para categorías.

Las relaciones son: un usuario puede subir muchos libros, muchos libros pertenecen a un género, y un libro puede solo tener
un género

## Solución de Problemas Comunes

Si tienes problemas con la conexión a PostgreSQL, verifica que el servicio esté corriendo y que la cadena de conexión sea correcta usando dotnet user-secrets list.

Si aparece el error "AddEntityFrameworkStores can only be called with a user that derives from IdentityUser", asegúrate de que la clase Usuario herede de IdentityUser.

Si la imagen no se guarda en Cloudinary, verifica tu CloudinaryUrl en la configuración, asegúrate de que la cuenta tenga espacio disponible y revisa los logs.

Si el tamaño del archivo muestra "--" en lugar del tamaño, verifica que el PDF se esté subiendo correctamente y que el campo TamañoArchivo tenga valor en la base de datos.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.

## 👥 Autores

Desheng Zhan y Enrique Martínez Escolano

## Agradecimientos

A Cloudinary por el servicio de almacenamiento de archivos, a Microsoft por ASP.NET Core, y a PostgreSQL por la base de datos.

## Contacto

Para preguntas o sugerencias, abre un Issue en el repositorio de GitHub.