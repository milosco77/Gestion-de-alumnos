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
    public class CarrerasController : Controller
    {
        private readonly AlumnosContext _context;

        public CarrerasController(AlumnosContext context)
        {
            _context = context;
        }

        // GET: Carreras
        public async Task<IActionResult> Index()
        {
            var alumnosContext = _context.Carreras.Include(c => c.Alumno).Include(c => c.ListadoCarreras);
            return View(await alumnosContext.ToListAsync());
        }

        // GET: Carreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras
                .Include(c => c.Alumno)
                .Include(c => c.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.AlumnoId == id);
            if (carreras == null)
            {
                return NotFound();
            }

            return View(carreras);
        }

        // GET: Carreras/Create
        public IActionResult Create()
        {
            var alumnos = _context.Alumnos.Select(a => new
            {
                a.AlumnoId,
                nombreCompleto = $"{a.Nombre} {a.Apellido}"
            });
            ViewData["AlumnoId"] = new SelectList(alumnos, "AlumnoId", "nombreCompleto");
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre");
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarreraId,AlumnoId,ListadoCarrerasId")] Carreras carreras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carreras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var alumnos = _context.Alumnos.Select(a => new
            {
                a.AlumnoId,
                nombreCompleto = $"{a.Nombre} {a.Apellido}"
            });
            ViewData["AlumnoId"] = new SelectList(alumnos, "AlumnoId", "nombreCompleto", carreras.AlumnoId);
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", carreras.ListadoCarrerasId);
            return View(carreras);
        }

        // GET: Carreras/Edit/5
        public async Task<IActionResult> Edit(int? id, int? listadoCarrerasId)
        {
            if (id == null || listadoCarrerasId == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras.FindAsync(id, listadoCarrerasId);
            if (carreras == null)
            {
                return NotFound();
            }
            var alumnos = _context.Alumnos.Select(a => new
            {
                a.AlumnoId,
                nombreCompleto = $"{a.Nombre} {a.Apellido}"
            });
            ViewData["AlumnoId"] = new SelectList(alumnos, "AlumnoId", "nombreCompleto", carreras.AlumnoId);
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", carreras.ListadoCarrerasId);
            return View(carreras);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarreraId,AlumnoId,ListadoCarrerasId")] Carreras carreras)
        {
            if (id != carreras.AlumnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carreras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrerasExists(carreras.AlumnoId))
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
            var alumnos = _context.Alumnos.Select(a => new
            {
                a.AlumnoId,
                nombreCompleto = $"{a.Nombre} {a.Apellido}"
            });
            ViewData["AlumnoId"] = new SelectList(alumnos, "AlumnoId", "nombreCompleto", carreras.AlumnoId);
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", carreras.ListadoCarrerasId);
            return View(carreras);
        }

        // GET: Carreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras
                .Include(c => c.Alumno)
                .Include(c => c.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.AlumnoId == id);
            if (carreras == null)
            {
                return NotFound();
            }

            return View(carreras);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int listadoCarrerasId)
        {
            var carreras = await _context.Carreras.FindAsync(id, listadoCarrerasId);
            _context.Carreras.Remove(carreras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrerasExists(int id)
        {
            return _context.Carreras.Any(e => e.AlumnoId == id);
        }
    }
}
