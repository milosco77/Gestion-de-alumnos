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
    public class ListadoCarrerasController : Controller
    {
        private readonly AlumnosContext _context;

        public ListadoCarrerasController(AlumnosContext context)
        {
            _context = context;
        }

        // GET: ListadoCarreras
        public async Task<IActionResult> Index()
        {
            var alumnosContext = _context.ListadoCarreras.Include(l => l.Facultad);
            return View(await alumnosContext.ToListAsync());
        }

        // GET: ListadoCarreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoCarreras = await _context.ListadoCarreras
                .Include(l => l.Facultad)
                .FirstOrDefaultAsync(m => m.ListadoCarrerasId == id);
            if (listadoCarreras == null)
            {
                return NotFound();
            }

            return View(listadoCarreras);
        }

        // GET: ListadoCarreras/Create
        public IActionResult Create()
        {
            ViewData["FacultadId"] = new SelectList(_context.Facultades, "FacultadId", "Nombre");
            return View();
        }

        // POST: ListadoCarreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListadoCarrerasId,FacultadId,Nombre,Titulo,DuracionEstimadaAnios")] ListadoCarreras listadoCarreras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listadoCarreras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultadId"] = new SelectList(_context.Facultades, "FacultadId", "Nombre", listadoCarreras.FacultadId);
            return View(listadoCarreras);
        }

        // GET: ListadoCarreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoCarreras = await _context.ListadoCarreras.FindAsync(id);
            if (listadoCarreras == null)
            {
                return NotFound();
            }
            ViewData["FacultadId"] = new SelectList(_context.Facultades, "FacultadId", "Nombre", listadoCarreras.FacultadId);
            return View(listadoCarreras);
        }

        // POST: ListadoCarreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListadoCarrerasId,FacultadId,Nombre,Titulo,DuracionEstimadaAnios")] ListadoCarreras listadoCarreras)
        {
            if (id != listadoCarreras.ListadoCarrerasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listadoCarreras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListadoCarrerasExists(listadoCarreras.ListadoCarrerasId))
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
            ViewData["FacultadId"] = new SelectList(_context.Facultades, "FacultadId", "Nombre", listadoCarreras.FacultadId);
            return View(listadoCarreras);
        }

        // GET: ListadoCarreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listadoCarreras = await _context.ListadoCarreras
                .Include(l => l.Facultad)
                .FirstOrDefaultAsync(m => m.ListadoCarrerasId == id);
            if (listadoCarreras == null)
            {
                return NotFound();
            }

            return View(listadoCarreras);
        }

        // POST: ListadoCarreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listadoCarreras = await _context.ListadoCarreras.FindAsync(id);
            _context.ListadoCarreras.Remove(listadoCarreras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListadoCarrerasExists(int id)
        {
            return _context.ListadoCarreras.Any(e => e.ListadoCarrerasId == id);
        }
    }
}
