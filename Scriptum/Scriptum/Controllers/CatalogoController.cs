using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scriptum.Data;
using Scriptum.Models;

namespace Scriptum.Controllers
{
    //[Authorize(Roles = "Usuario")]
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    var vm = new CatalogoViewModel
        //    {
        //        Libros = _context.Libros
        //                         .Include(l => l.Genero)
        //                         .ToList(),

        //        Generos = _context.Generos.ToList()
        //    };

        //    return View(vm);
        //}
        public async Task<IActionResult> Index(string? generoId, int? tipoRecurso, string buscar, int pagina = 1)
        {
            int registrosPorPagina = 6;
            var query = _context.Libros.AsQueryable();

            // Filtros
            if (tipoRecurso != null)
            {
                query = query.Where(l => l.Tipo == (Scriptum.Models.Tipo)tipoRecurso);
            };
            if (generoId != null) query = query.Where(l => l.IdGenero == generoId);
            if (!string.IsNullOrEmpty(buscar)) query = query.Where(l => l.Titulo.Contains(buscar));

            // Paginación
            int totalRegistros = await query.CountAsync();
            var libros = await query
                .Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToListAsync();

            return View(new CatalogoViewModel
            {
                Libros = libros,
                Generos = await _context.Generos.ToListAsync(),
                PaginaActual = pagina,
                TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)registrosPorPagina),
                FiltroBusqueda = buscar,
                GeneroSeleccionado = generoId,
                TipoSeleccionado = tipoRecurso
            });
        }

    }
}
