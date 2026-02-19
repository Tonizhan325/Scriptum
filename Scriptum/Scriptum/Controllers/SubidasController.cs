using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scriptum.Data;
using Scriptum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scriptum.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class SubidasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubidasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subidas.ToListAsync());
        }

        // GET: Subidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subida = await _context.Subidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subida == null)
            {
                return NotFound();
            }

            return View(subida);
        }

        // GET: Subidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,FechaSubida,URL,IdLibro,Descripcion")] Subida subida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subida);
        }

        // GET: Subidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subida = await _context.Subidas.FindAsync(id);
            if (subida == null)
            {
                return NotFound();
            }
            return View(subida);
        }

        // POST: Subidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,FechaSubida,URL,IdLibro,Descripcion")] Subida subida)
        {
            if (id != subida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubidaExists(subida.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subida);
        }

        // GET: Subidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subida = await _context.Subidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subida == null)
            {
                return NotFound();
            }

            return View(subida);
        }

        // POST: Subidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subida = await _context.Subidas.FindAsync(id);
            if (subida != null)
            {
                _context.Subidas.Remove(subida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubidaExists(int id)
        {
            return _context.Subidas.Any(e => e.Id == id);
        }
    }
}
