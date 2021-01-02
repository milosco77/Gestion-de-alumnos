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
    public class FacultadesController : Controller
    {
        private readonly AlumnosContext _context;

        public FacultadesController(AlumnosContext context)
        {
            _context = context;
        }

        // GET: Facultades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facultades.ToListAsync());
        }

        // GET: Facultades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultade = await _context.Facultades
                .FirstOrDefaultAsync(m => m.FacultadId == id);
            if (facultade == null)
            {
                return NotFound();
            }

            return View(facultade);
        }

        // GET: Facultades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facultades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacultadId,Nombre,Direccion,Telefono,DepartamentoAlumnos,Facebook,Instagram,Twitter,PaginaWeb,Email,RecorridoVirtual")] Facultade facultade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultade);
        }

        // GET: Facultades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultade = await _context.Facultades.FindAsync(id);
            if (facultade == null)
            {
                return NotFound();
            }
            return View(facultade);
        }

        // POST: Facultades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacultadId,Nombre,Direccion,Telefono,DepartamentoAlumnos,Facebook,Instagram,Twitter,PaginaWeb,Email,RecorridoVirtual")] Facultade facultade)
        {
            if (id != facultade.FacultadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultadeExists(facultade.FacultadId))
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
            return View(facultade);
        }

        // GET: Facultades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultade = await _context.Facultades
                .FirstOrDefaultAsync(m => m.FacultadId == id);
            if (facultade == null)
            {
                return NotFound();
            }

            return View(facultade);
        }

        // POST: Facultades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultade = await _context.Facultades.FindAsync(id);
            _context.Facultades.Remove(facultade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultadeExists(int id)
        {
            return _context.Facultades.Any(e => e.FacultadId == id);
        }
    }
}
