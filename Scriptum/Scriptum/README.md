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

## Instalación y Configuración

Primero clona el repositorio con git clone y entra en la carpeta del proyecto. Luego restaura los paquetes NuGet con dotnet restore. Crea una base de datos en PostgreSQL llamada ScriptumDB. Configura la cadena de conexión en appsettings.Development.json o usando User Secrets con dotnet user-secrets. Para Cloudinary, regístrate en cloudinary.com, obtén tu CloudinaryUrl desde el Dashboard y configúralo también con user secrets. Aplica las migraciones con dotnet ef migrations add InitialCreate y dotnet ef database update. Finalmente ejecuta la aplicación con dotnet run. La aplicación estará disponible en http://localhost:5000 y https://localhost:5001.

## Estructura del Proyecto

La carpeta Controllers contiene LibrosController.cs para el CRUD de libros, CatalogoController.cs para visualización y búsqueda, y HomeController.cs para la página principal. La carpeta Models contiene los modelos Libro.cs, Usuario.cs que hereda de IdentityUser con clave int, Genero.cs, Reseña.cs, Subida.cs y Descarga.cs. La carpeta Views contiene las vistas para Libros como Index, Create, Edit y Details, más Catalogo/Index.cshtml y las vistas compartidas en Shared. La carpeta Data contiene ApplicationDbContext.cs. También hay Migrations, wwwroot para archivos estáticos, Program.cs, appsettings.json y Scriptum.csproj.

## Uso

Para crear un nuevo libro, haz clic en "Nuevo Libro", completa el formulario con título, descripción, idioma, autor, tipo y género, selecciona un archivo PDF y opcionalmente una imagen de portada, luego haz clic en "Guardar". El tamaño del archivo se calcula automáticamente en megabytes.

Para editar un libro, haz clic en "Editar" en el listado, modifica los campos necesarios, y si quieres cambiar el PDF selecciona un nuevo archivo, si quieres cambiar la portada selecciona una nueva imagen. Los campos de archivo son independientes: puedes cambiar solo el PDF, solo la imagen, o ambos. Luego haz clic en "Guardar cambios".

Para buscar libros, usa el buscador en la página principal filtrando por título o nombre del autor, haz clic en "Buscar" y usa "Limpiar filtros" para resetear la búsqueda.

## Modelo de Datos

Las principales entidades son Usuario que hereda de IdentityUser con clave primaria int, Libro que almacena título, autor, tamaño del archivo como decimal, URL del PDF y enlace de la imagen, Genero para categorías, y Reseña para opiniones de usuarios.

Las relaciones son: un usuario puede subir muchos libros, muchos libros pertenecen a un género, y un libro puede tener muchas reseñas.

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