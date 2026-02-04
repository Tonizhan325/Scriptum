using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Scriptum.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class SubirLibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
