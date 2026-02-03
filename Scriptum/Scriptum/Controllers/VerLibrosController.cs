using Microsoft.AspNetCore.Mvc;

namespace Scriptum.Controllers
{
    public class VerLibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
