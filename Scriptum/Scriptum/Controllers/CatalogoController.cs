using Microsoft.AspNetCore.Mvc;

namespace Scriptum.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
