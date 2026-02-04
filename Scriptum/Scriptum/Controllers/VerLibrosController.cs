using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Scriptum.Controllers
{
    [Authorize(Roles="Usuario")]
    public class VerLibrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
