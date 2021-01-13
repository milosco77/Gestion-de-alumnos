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

            var listadoAsignaturas = await _context.ListadoAsignaturas
                .Include(l => l.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (listadoAsignaturas == null)
            {
                return NotFound();
            }

            return View(listadoAsignaturas);
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
        public async Task<IActionResult> Create([Bind("ListadoAsignaturasId,ListadoCarrerasId,Codigo,Nombre,Creditos,Horas,Correlativas,Categoria")] ListadoAsignaturas listadoAsignaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listadoAsignaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", listadoAsignaturas.ListadoCarrerasId);
            return View(listadoAsignaturas);
        }

        // GET: ListadoAsignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoAsignaturas = await _context.ListadoAsignaturas.FindAsync(id);
            if (listadoAsignaturas == null)
            {
                return NotFound();
            }
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", listadoAsignaturas.ListadoCarrerasId);
            return View(listadoAsignaturas);
        }

        // POST: ListadoAsignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListadoAsignaturasId,ListadoCarrerasId,Codigo,Nombre,Creditos,Horas,Correlativas,Categoria")] ListadoAsignaturas listadoAsignaturas)
        {
            if (id != listadoAsignaturas.ListadoAsignaturasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listadoAsignaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListadoAsignaturasExists(listadoAsignaturas.ListadoAsignaturasId))
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
            ViewData["ListadoCarrerasId"] = new SelectList(_context.ListadoCarreras, "ListadoCarrerasId", "Nombre", listadoAsignaturas.ListadoCarrerasId);
            return View(listadoAsignaturas);
        }

        // GET: ListadoAsignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoAsignaturas = await _context.ListadoAsignaturas
                .Include(l => l.ListadoCarreras)
                .FirstOrDefaultAsync(m => m.ListadoAsignaturasId == id);
            if (listadoAsignaturas == null)
            {
                return NotFound();
            }

            return View(listadoAsignaturas);
        }

        // POST: ListadoAsignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listadoAsignaturas = await _context.ListadoAsignaturas.FindAsync(id);
            _context.ListadoAsignaturas.Remove(listadoAsignaturas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListadoAsignaturasExists(int id)
        {
            return _context.ListadoAsignaturas.Any(e => e.ListadoAsignaturasId == id);
        }
    }
}
