using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Scriptum.Models;
using Scriptum.Data;

namespace Scriptum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Busca el empleado correspondiente al usuario actual. Si existe, activa la
            // vista (View) y en caso contrario, se redirige para crear el empleado.
            string? emailUsuario = User.Identity.Name;
            Usuario? usuario = _context.Usuarios.Where(e => e.Email == emailUsuario)
            .FirstOrDefault();
            if (User.Identity.IsAuthenticated &&
            User.IsInRole("Usuario") &&
            usuario == null)
            {
                return RedirectToAction("Create", "MisDatos");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
