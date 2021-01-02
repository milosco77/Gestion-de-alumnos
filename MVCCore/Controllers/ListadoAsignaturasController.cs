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
    public class ListadoAsignaturasController : Controller
    {
        private readonly AlumnosContext _context;

        public ListadoAsignaturasController(AlumnosContext context)
        {
            _context = context;
        }

        // GET: ListadoAsignaturas
        public async Task<IActionResult> Index()
        {
            var alumnosContext = _context.ListadoAsignaturas.Include(l => l.ListadoCarreras);
            return View(await alumnosContext.ToListAsync());
        }

        // GET: ListadoAsignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoAsignatura = await _context.ListadoAsignaturas
                .Include(l => l.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (listadoAsignatura == null)
            {
                return NotFound();
            }

            return View(listadoAsignatura);
        }

        // GET: ListadoAsignaturas/Create
        public IActionResult Create()
        {
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre");
            return View();
        }

        // POST: ListadoAsignaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListadoAsignaturasId,Codigo,Nombre,Creditos,Horas,Correlativas,Categoria,ListadoCarrerasId")] ListadoAsignatura listadoAsignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listadoAsignatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", listadoAsignatura.ListadoCarrerasId);
            return View(listadoAsignatura);
        }

        // GET: ListadoAsignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoAsignatura = await _context.ListadoAsignaturas.FindAsync(id);
            if (listadoAsignatura == null)
            {
                return NotFound();
            }
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", listadoAsignatura.ListadoCarrerasId);
            return View(listadoAsignatura);
        }

        // POST: ListadoAsignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListadoAsignaturasId,Codigo,Nombre,Creditos,Horas,Correlativas,Categoria,ListadoCarrerasId")] ListadoAsignatura listadoAsignatura)
        {
            if (id != listadoAsignatura.ListadoAsignaturasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listadoAsignatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListadoAsignaturaExists(listadoAsignatura.ListadoAsignaturasId))
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
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", listadoAsignatura.ListadoCarrerasId);
            return View(listadoAsignatura);
        }

        // GET: ListadoAsignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoAsignatura = await _context.ListadoAsignaturas
                .Include(l => l.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (listadoAsignatura == null)
            {
                return NotFound();
            }

            return View(listadoAsignatura);
        }

        // POST: ListadoAsignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listadoAsignatura = await _context.ListadoAsignaturas.FindAsync(id);
            _context.ListadoAsignaturas.Remove(listadoAsignatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListadoAsignaturaExists(int id)
        {
            return _context.ListadoAsignaturas.Any(e => e.ListadoAsignaturasId == id);
        }
    }
}
