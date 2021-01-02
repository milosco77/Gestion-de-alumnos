using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCore.DatabaseFirstModel;

namespace MVCCore.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly AlumnosContext _context;

        public AsignaturasController(AlumnosContext context)
        {
            _context = context;
        }

        // GET: Asignaturas
        public async Task<IActionResult> Index()
        {
            var alumnosContext = _context.Asignaturas.Include(a => a.Carrera).Include(a => a.ListadoAsignaturas);
            return View(await alumnosContext.ToListAsync());
        }

        // GET: Asignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas
                .Include(a => a.Carrera)
                .Include(a => a.ListadoAsignaturas)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // GET: Asignaturas/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId");
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Categoria");
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsignaturaId,ListadoAsignaturasId,AlumnoId,CarreraId,Comision,HorarioEntrada,HorarioSalida,Dias")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId", asignatura.CarreraId);
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Categoria", asignatura.ListadoAsignaturasId);
            return View(asignatura);
        }

        // GET: Asignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId", asignatura.CarreraId);
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Categoria", asignatura.ListadoAsignaturasId);
            return View(asignatura);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsignaturaId,ListadoAsignaturasId,AlumnoId,CarreraId,Comision,HorarioEntrada,HorarioSalida,Dias")] Asignatura asignatura)
        {
            if (id != asignatura.ListadoAsignaturasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaExists(asignatura.ListadoAsignaturasId))
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
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId", asignatura.CarreraId);
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Categoria", asignatura.ListadoAsignaturasId);
            return View(asignatura);
        }

        // GET: Asignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignatura = await _context.Asignaturas
                .Include(a => a.Carrera)
                .Include(a => a.ListadoAsignaturas)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (asignatura == null)
            {
                return NotFound();
            }

            return View(asignatura);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignatura = await _context.Asignaturas.FindAsync(id);
            _context.Asignaturas.Remove(asignatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaExists(int id)
        {
            return _context.Asignaturas.Any(e => e.ListadoAsignaturasId == id);
        }
    }
}
