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
            var alumnosContext = _context.Asignaturas.Include(a => a.Alumno).Include(a => a.Carrera).Include(a => a.ListadoAsignaturas);
            return View(await alumnosContext.ToListAsync());
        }

        // GET: Asignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas
                .Include(a => a.Alumno)
                .Include(a => a.Carrera)
                .Include(a => a.ListadoAsignaturas)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (asignaturas == null)
            {
                return NotFound();
            }

            return View(asignaturas);
        }

        // GET: Asignaturas/Create
        public IActionResult Create()
        {
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido");
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId");
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Nombre");
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsignaturaId,ListadoAsignaturasId,AlumnoId,CarreraId,Comision,HorarioEntrada,HorarioSalida,Dias")] Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido", asignaturas.AlumnoId);
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId", asignaturas.CarreraId);
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Categoria", asignaturas.ListadoAsignaturasId);
            return View(asignaturas);
        }

        // GET: Asignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id, int? alumnoId)
        {
            if (id == null || alumnoId == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas.FindAsync(id, alumnoId);
            if (asignaturas == null)
            {
                return NotFound();
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido", asignaturas.AlumnoId);
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId", asignaturas.CarreraId);
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Categoria", asignaturas.ListadoAsignaturasId);
            return View(asignaturas);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsignaturaId,ListadoAsignaturasId,AlumnoId,CarreraId,Comision,HorarioEntrada,HorarioSalida,Dias")] Asignaturas asignaturas)
        {
            if (id != asignaturas.ListadoAsignaturasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasExists(asignaturas.ListadoAsignaturasId))
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
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido", asignaturas.AlumnoId);
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "CarreraId", asignaturas.CarreraId);
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Categoria", asignaturas.ListadoAsignaturasId);
            return View(asignaturas);
        }

        // GET: Asignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas
                .Include(a => a.Alumno)
                .Include(a => a.Carrera)
                .Include(a => a.ListadoAsignaturas)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (asignaturas == null)
            {
                return NotFound();
            }

            return View(asignaturas);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturas = await _context.Asignaturas.FindAsync(id);
            _context.Asignaturas.Remove(asignaturas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturasExists(int id)
        {
            return _context.Asignaturas.Any(e => e.ListadoAsignaturasId == id);
        }
    }
}
