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

## Uso

Para subir un nuevo libro, haz clic en tu perfil registrado y dale a "Subir Libro", completa el formulario con título, descripción, idioma, autor, tipo y género, selecciona un archivo PDF y opcionalmente una imagen de portada, luego haz clic en "Guardar". El tamaño del archivo se calcula automáticamente en megabytes.

Para editar un libro, haz clic en "Editar" en el listado, modifica los campos necesarios, y si quieres cambiar el PDF selecciona un nuevo archivo, si quieres cambiar la portada selecciona una nueva imagen. Los campos de archivo son independientes: puedes cambiar solo el PDF, solo la imagen, o ambos. Luego haz clic en "Guardar cambios".

Para buscar libros, usa el buscador en la página principal filtrando por título o nombre del autor, haz clic en "Buscar" y usa "Limpiar filtros" para resetear la búsqueda.

## Tecnologías Utilizadas

| Tecnología | Versión | Propósito |

| ASP.NET Core | 9.0 | Framework backend |
| Entity Framework Core | 9.0 | ORM para base de datos |
| PostgreSQL | 15+ | Base de datos relacional |
| Cloudinary | - | Almacenamiento de archivos en la nube |
| ASP.NET Core Identity | 9.0 | Autenticación y autorización |
| HTML5/CSS3/JavaScript | - | Interfaz de usuario |
| Bootstrap | 5.x | Estilos y componentes |

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

  ### Paso 4: Ejecutar la aplicación

      - dotnet run

      Y esperar a que aparezca:

      Now listening on: http://localhost:5000
      Now listening on: https://localhost:5001

  > [!NOTE]
  > Nota: La base de datos y los servicios externos ya están configurados en el repositorio. No es necesario instalar PostgreSQL, pgAdmin ni realizar migraciones.


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


## Autores

Desheng Zhan y Enrique Martínez Escolano
