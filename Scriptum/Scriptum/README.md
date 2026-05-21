# Scriptum

Biblioteca digital que permite al usuario ver, descargar y subir libros que se guardan en la nube

## Tabla de Contenidos
- [Características]
- [Tecnologías Utilizadas]
- [Requisitos Previos]
- [Instalación]
- [Configuración]
- [Uso]
- [Base de Datos]
- [Estructura del Proyecto]
- [API Endpoints]
- [Contribución]
- [Licencia]
- [Autores] 

## Características
- Lista de funcionalidades principales
- Lo que hace único al proyecto
- Ejemplo: 
  - Subida/descarga de archivos PDF a/en la nube
  - Gestión de usuarios con autenticación
  - Búsqueda y filtrado de libros (tanto admin como catálogo)
  - Búsqueda y filtrado de géneros
  - Búsqueda y filtrado de usuarios
  - Vista previa de imágenes

## Tecnologías Utilizadas
- **Backend**: ASP.NET Core 9.0, C#
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap
- **Base de Datos**: PostgreSQL
- **Almacenamiento en la nube**: Cloudinary
- **Autenticación**: ASP.NET Core Identity
- **ORM**: Entity Framework Core

## Requisitos Previos
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/)
- Cuenta en [Cloudinary](https://cloudinary.com/)

## Instalación

### 1. Clonar el repositorio
```bash
git clone https://github.com/tu-usuario/tu-proyecto.git
cd tu-proyecto

### Credenciales de admin:
Email: admin@empresa.com
Contraseña: Admin-123

### Estructura del proyecto

Scriptum/
├── Controllers/
│   ├── LibrosController.cs
│   ├── GenerosController.cs
│   ├── MisDatosController.cs
│   ├── UsuariosController.cs
│   ├── CatalogoController.cs
│   └── HomeController.cs
├── Models/
│   ├── CatalogoViewModel.cs
│   ├── ErrorViewModel.cs
│   ├── Libro.cs
│   ├── Usuario.cs
│   └── Genero.cs
├── Views/
│   ├── Libros/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   └── Edit.cshtml
│   │   └── Create.cshtml
│   │   └── Delete.cshtml
│   ├── Usuarios/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   └── Edit.cshtml
│   │   └── Create.cshtml
│   │   └── Delete.cshtml
│   ├── Generos/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   └── Edit.cshtml
│   │   └── Create.cshtml
│   │   └── Delete.cshtml
│   └── Shared/
│   │   └── _Layout.cshtml
│   │   └── _LoginPartial.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   └── Home/
│   │   └── Contacto.cshtml
│   │   └── Index.cshtml
│   │   └── Privacy.cshtml
├── Data/
│   └── ApplicationDbContext.cs
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
├── Program.cs
├── PaginatedList.cs
├── appsettings.json
└── Scriptum.csproj