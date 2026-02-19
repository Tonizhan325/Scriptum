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

namespace Scriptum.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Idioma,TamañoArchivo,URL,Estado,FechaSubida,FechaRevision,IdUsuario,NombreAutor,EnlaceImagen,IdGenero")] Libro libro)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Idioma,TamañoArchivo,URL,Estado,FechaSubida,FechaRevision,IdUsuario,NombreAutor,EnlaceImagen,IdGenero")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
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

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
