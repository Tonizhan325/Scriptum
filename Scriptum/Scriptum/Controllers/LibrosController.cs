using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scriptum.Data;
using Scriptum.Models;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Scriptum.Controllers
{
    //[Authorize(Roles = "Administrador")]
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Cloudinary _cloudinary; //Esto conecta con las imágenes
        private readonly Usuario _usuario;

        public LibrosController(ApplicationDbContext context, Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }
        [Authorize(Roles = "Administrador")]
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

            libros = libros.OrderByDescending(s => s.FechaSubida);

            return View(await PaginatedList<Libro>.CreateAsync(
                libros.AsNoTracking(),
                pageNumber ?? 1,
                pageSize
            ));
        }
        [Authorize(Roles = "Administrador")]
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
        [Authorize]
        // GET: Libros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Idioma,TamañoArchivo,URL,IdGenero,NombreAutor,Tipo,EnlaceImagen")] Libro libro, IFormFile imagenArchivo, IFormFile archivoPdf)
        {
            if (ModelState.IsValid)
            {

                if (imagenArchivo != null && imagenArchivo.Length > 0)
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(imagenArchivo.FileName, imagenArchivo.OpenReadStream()),
                        AssetFolder = "portadas_libros"
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    libro.EnlaceImagen = uploadResult.SecureUrl.ToString();
                }

                if (archivoPdf != null && archivoPdf.Length > 0)
                {

                    if (!archivoPdf.ContentType.Contains("pdf"))
                    {
                        ModelState.AddModelError("", "Solo se permiten archivos PDF");
                        return View(libro);
                    }

                    if (archivoPdf.Length > 50 * 1024 * 1024)
                    {
                        ModelState.AddModelError("", "El PDF es demasiado grande. Tamaño máximo: 50MB");
                        return View(libro);
                    }

                    libro.TamañoArchivo = Math.Round((decimal)archivoPdf.Length / (1024 * 1024), 2);

                    var uploadParamsPdf = new RawUploadParams()
                    {
                        File = new FileDescription(archivoPdf.FileName, archivoPdf.OpenReadStream()),
                        Folder = "libros_pdf",
                        Type = "upload"
                    };

                    var uploadResultPdf = await _cloudinary.UploadAsync(uploadParamsPdf);

                    if (uploadResultPdf != null && !string.IsNullOrEmpty(uploadResultPdf.SecureUrl?.ToString()))
                    {
                        libro.URL = uploadResultPdf.SecureUrl.ToString();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error subiendo el PDF a Cloudinary");
                        return View(libro);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Debe subir un archivo PDF");
                    return View(libro);
                }

                libro.FechaSubida = DateTime.Now;

                _context.Add(libro);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Catalogo");
            }
            return View(libro);
        }
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro libro, IFormFile imagenArchivo, IFormFile archivoPdf)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            var libroExistente = await _context.Libros.FindAsync(id);
            if (libroExistente == null)
            {
                return NotFound();
            }

            ModelState.Remove("imagenArchivo");
            ModelState.Remove("archivoPdf");
            ModelState.Remove("EnlaceImagen");
            ModelState.Remove("URL");
            ModelState.Remove("TamañoArchivo");

            if (imagenArchivo == null || imagenArchivo.Length == 0)
            {
                libro.EnlaceImagen = libroExistente.EnlaceImagen;
            }

            if (archivoPdf == null || archivoPdf.Length == 0)
            {
                libro.URL = libroExistente.URL;
                libro.TamañoArchivo = libroExistente.TamañoArchivo;
            }

            if (ModelState.IsValid)
            {
                try
                {

                    libroExistente.Titulo = libro.Titulo;
                    libroExistente.Descripcion = libro.Descripcion;
                    libroExistente.Idioma = libro.Idioma;
                    libroExistente.IdGenero = libro.IdGenero;
                    libroExistente.NombreAutor = libro.NombreAutor;
                    libroExistente.Tipo = libro.Tipo;
                    libroExistente.FechaRevision = libro.FechaRevision;

                    if (archivoPdf != null && archivoPdf.Length > 0)
                    {

                        if (!archivoPdf.ContentType.Contains("pdf"))
                        {
                            ModelState.AddModelError("", "Solo se permiten archivos PDF");
                            return View(libro);
                        }

                        if (archivoPdf.Length > 50 * 1024 * 1024)
                        {
                            ModelState.AddModelError("", "El PDF es demasiado grande. Tamaño máximo: 50MB");
                            return View(libro);
                        }

                        libroExistente.TamañoArchivo = Math.Round((decimal)archivoPdf.Length / (1024 * 1024), 2);

                        var uploadParamsPdf = new RawUploadParams()
                        {
                            File = new FileDescription(archivoPdf.FileName, archivoPdf.OpenReadStream()),
                            Folder = "libros_pdf",
                            Type = "upload"
                        };

                        var uploadResultPdf = await _cloudinary.UploadAsync(uploadParamsPdf);

                        if (uploadResultPdf?.SecureUrl != null)
                        {
                            libroExistente.URL = uploadResultPdf.SecureUrl.ToString();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Error subiendo el PDF a Cloudinary");
                            return View(libro);
                        }
                    }

                    if (imagenArchivo != null && imagenArchivo.Length > 0)
                    {

                        if (!imagenArchivo.ContentType.StartsWith("image/"))
                        {
                            ModelState.AddModelError("", "Solo se permiten archivos de imagen");
                            return View(libro);
                        }

                        if (imagenArchivo.Length > 5 * 1024 * 1024)
                        {
                            ModelState.AddModelError("", "La imagen es demasiado grande. Tamaño máximo: 5MB");
                            return View(libro);
                        }

                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(imagenArchivo.FileName, imagenArchivo.OpenReadStream()),
                            AssetFolder = "portadas_libros"
                        };

                        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                        libroExistente.EnlaceImagen = uploadResult.SecureUrl.ToString();
                    }

                    _context.Update(libroExistente);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(libro);
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
