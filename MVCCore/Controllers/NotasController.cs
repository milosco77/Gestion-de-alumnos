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
    public class NotasController : Controller
    {
        private readonly AlumnosContext _context;


        public NotasController(AlumnosContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var alumnosContext = _context.Notas.Include(n => n.Asignatura);
            return View(await alumnosContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .Include(n => n.Asignatura)
                .FirstOrDefaultAsync(m => m.NotasId == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            var asignaturas = _context.Asignaturas.Select(asig => new
            {
                asig.AsignaturaId,
                asignaturaNombreApellido = $"ID {asig.AsignaturaId} - {_context.ListadoAsignaturas.Where(la => la.ListadoAsignaturasId == asig.ListadoAsignaturasId).SingleOrDefault().Nombre} - {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Nombre} {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Apellido} - ID {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().AlumnoId}"
            });
            ViewData["AsignaturaId"] = new SelectList(asignaturas, "AsignaturaId", "asignaturaNombreApellido");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotasId,AsignaturaId,PrimerParcial,PrimerRecuperatorio,SegundoParcial,SegundoRecuperatorio,Final")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var asignaturas = _context.Asignaturas.Select(asig => new
            {
                asig.AsignaturaId,
                asignaturaNombreApellido = $"ID {asig.AsignaturaId} - {_context.ListadoAsignaturas.Where(la => la.ListadoAsignaturasId == asig.ListadoAsignaturasId).SingleOrDefault().Nombre} - {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Nombre} {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Apellido} - ID {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().AlumnoId}"
            });
            ViewData["AsignaturaId"] = new SelectList(asignaturas, "AsignaturaId", "asignaturaNombreApellido", notas.AsignaturaId);
            return View(notas);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas.FindAsync(id);
            if (notas == null)
            {
                return NotFound();
            }
            var asignaturas = _context.Asignaturas.Select(asig => new
            {
                asig.AsignaturaId,
                asignaturaNombreApellido = $"ID {asig.AsignaturaId} - {_context.ListadoAsignaturas.Where(la => la.ListadoAsignaturasId == asig.ListadoAsignaturasId).SingleOrDefault().Nombre} - {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Nombre} {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Apellido} - ID {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().AlumnoId}"
            });
            ViewData["AsignaturaId"] = new SelectList(asignaturas, "AsignaturaId", "asignaturaNombreApellido", notas.AsignaturaId);
            return View(notas);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotasId,AsignaturaId,PrimerParcial,PrimerRecuperatorio,SegundoParcial,SegundoRecuperatorio,Final")] Notas notas)
        {
            if (id != notas.NotasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasExists(notas.NotasId))
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
            var asignaturas = _context.Asignaturas.Select(asig => new
            {
                asig.AsignaturaId,
                asignaturaNombreApellido = $"ID {asig.AsignaturaId} - {_context.ListadoAsignaturas.Where(la => la.ListadoAsignaturasId == asig.ListadoAsignaturasId).SingleOrDefault().Nombre} - {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Nombre} {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().Apellido} - ID {_context.Alumnos.Where(a => a.AlumnoId == asig.AlumnoId).SingleOrDefault().AlumnoId}"
            });
            ViewData["AsignaturaId"] = new SelectList(asignaturas, "AsignaturaId", "asignaturaNombreApellido", notas.AsignaturaId);
            return View(notas);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .Include(n => n.Asignatura)
                .FirstOrDefaultAsync(m => m.NotasId == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notas = await _context.Notas.FindAsync(id);
            _context.Notas.Remove(notas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasExists(int id)
        {
            return _context.Notas.Any(e => e.NotasId == id);
        }
    }
}
