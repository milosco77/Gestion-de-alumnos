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

            var carrera = await _context.Carreras
                .Include(c => c.Alumno)
                .Include(c => c.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.AlumnoId == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
        }

        // GET: Carreras/Create
        public IActionResult Create()
        {
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido");
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre");
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarreraId,AlumnoId,ListadoCarrerasId")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido", carrera.AlumnoId);
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", carrera.ListadoCarrerasId);
            return View(carrera);
        }

        // GET: Carreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido", carrera.AlumnoId);
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", carrera.ListadoCarrerasId);
            return View(carrera);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarreraId,AlumnoId,ListadoCarrerasId")] Carrera carrera)
        {
            if (id != carrera.AlumnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraExists(carrera.AlumnoId))
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
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "AlumnoId", "Apellido", carrera.AlumnoId);
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", carrera.ListadoCarrerasId);
            return View(carrera);
        }

        // GET: Carreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carreras
                .Include(c => c.Alumno)
                .Include(c => c.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.AlumnoId == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            _context.Carreras.Remove(carrera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreraExists(int id)
        {
            return _context.Carreras.Any(e => e.AlumnoId == id);
        }
    }
}
