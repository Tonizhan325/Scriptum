using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scriptum.Data;
using Scriptum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Scriptum.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Cloudinary _cloudinary; //Esto conecta con las imágenes

        public LibrosController(ApplicationDbContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        // GET: Libros
        public async Task<IActionResult> Index(string strCadenaBusqueda, string strCadenaAutor, int? pageNumber)
        {
            int pageSize = 5;

            // Guardar los parámetros de búsqueda en ViewData
            ViewData["BusquedaActual"] = strCadenaBusqueda;
            ViewData["BusquedaAutor"] = strCadenaAutor;

            // Cargar datos de los libros como IQueryable
            var libros = _context.Libros.AsQueryable();

            // Aplicar filtros si existen
            if (!String.IsNullOrEmpty(strCadenaBusqueda))
            {
                libros = libros.Where(s => s.Titulo.Contains(strCadenaBusqueda));
            }

            if (!String.IsNullOrEmpty(strCadenaAutor))
            {
                libros = libros.Where(s => s.NombreAutor.Contains(strCadenaAutor));
            }

            // ORDENAR SIEMPRE por FechaSubida de forma descendente
            libros = libros.OrderByDescending(s => s.FechaSubida);

            // Crear la lista paginada
            return View(await PaginatedList<Libro>.CreateAsync(
                libros.AsNoTracking(),
                pageNumber ?? 1,
                pageSize
            ));
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Idioma,TamañoArchivo,URL,Estado,FechaSubida,FechaRevision,IdUsuario,IdGenero,NombreAutor,EnlaceImagen")] Libro libro, IFormFile imagenArchivo)

        {
            if (ModelState.IsValid)
            {
                // Verificar si el usuario subió una imagen
                if (imagenArchivo != null && imagenArchivo.Length > 0)
                {
                    // Configurar la subida a Cloudinary
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(imagenArchivo.FileName, imagenArchivo.OpenReadStream()),
                        AssetFolder = "portadas_libros" // Carpeta opcional en Cloudinary
                    };

                    // Ejecutar la subida
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    // Guardar la URL resultante en el objeto libro
                    libro.EnlaceImagen = uploadResult.SecureUrl.ToString();
                }

                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro libro, IFormFile? imagenArchivo)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            // Buscar el libro existente
            var libroEnBd = await _context.Libros.FindAsync(id);
            if (libroEnBd == null)
            {
                return NotFound();
            }

            // Actualizar propiedades
            libroEnBd.Titulo = libro.Titulo;
            libroEnBd.Descripcion = libro.Descripcion;
            libroEnBd.Idioma = libro.Idioma;
            libroEnBd.TamañoArchivo = libro.TamañoArchivo;
            libroEnBd.URL = libro.URL;
            libroEnBd.FechaRevision = libro.FechaRevision;
            libroEnBd.NombreAutor = libro.NombreAutor;
            libroEnBd.IdGenero = libro.IdGenero;

            // PROCESAR IMAGEN
            if (imagenArchivo != null && imagenArchivo.Length > 0)
            {
                try
                {
                    // Validar extensión
                    var extension = Path.GetExtension(imagenArchivo.FileName).ToLower();

                    // Generar nombre único
                    var fileName = $"{Guid.NewGuid()}{extension}";

                    // Ruta completa donde se guardará
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "portadas");
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    // Crear directorio si no existe
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Guardar archivo
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imagenArchivo.CopyToAsync(stream);
                    }

                    // ELIMINAR IMAGEN ANTERIOR
                    if (!string.IsNullOrEmpty(libroEnBd.EnlaceImagen))
                    {
                        var oldFilePath = Path.Combine(uploadsFolder, libroEnBd.EnlaceImagen);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // ASIGNAR NUEVO NOMBRE DE ARCHIVO
                    libroEnBd.EnlaceImagen = fileName;

                    // Mensaje de depuración (TempData)
                    TempData["Debug"] = $"Imagen guardada: {fileName}";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al guardar la imagen: {ex.Message}");
                    return View(libroEnBd);
                }
            }

            // Guardar cambios en BD
            await _context.SaveChangesAsync();

            TempData["Success"] = "Libro actualizado correctamente";
            return RedirectToAction(nameof(Index));
        }

        // Método helper para verificar si el libro existe
        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
