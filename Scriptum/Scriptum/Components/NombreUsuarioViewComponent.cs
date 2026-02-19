using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scriptum.Data;

public class NombreUsuarioViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public NombreUsuarioViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            var email = User.Identity.Name;
            var usuario = await _context.Usuarios
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();

            if (usuario != null)
            {
                return Content(usuario.Nombre); // Devuelve solo el nombre
            }
        }

        return Content("Usuario"); // Valor por defecto
    }
}
