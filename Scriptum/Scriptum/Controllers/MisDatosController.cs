using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scriptum.Data;
using Scriptum.Models;

namespace Scriptum.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisDatosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MisDatosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: MisDatos/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: MisDatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre")] Usuario usuario)
        {
            // Asignar el Email del usuario actual
            usuario.Email = User.Identity.Name;
            usuario.fechaRegistro = DateTime.Now;  // ← ¡ASIGNAR AQUÍ, ANTES DE VALIDAR!
            usuario.Estado = "Activo";
            usuario.Contraseña = Guid.NewGuid().ToString();
            
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            var errores = ModelState.Values.SelectMany(v => v.Errors);
            return View(usuario);
        }

        // GET: MisDatos/Edit
        public async Task<IActionResult> Edit()
        {
            string? emailUsuario = User.Identity.Name;
            Usuario? empleado = await _context.Usuarios
            .Where(e => e.Email == emailUsuario)
            .FirstOrDefaultAsync();
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }
        // POST: MisDatos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Nombre")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }
        private bool EmpleadoExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
