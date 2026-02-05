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
    }
}
