using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Scriptum.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
