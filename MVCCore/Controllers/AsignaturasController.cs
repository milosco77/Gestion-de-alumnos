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
            var alumnos = _context.Alumnos.Select(a => new
            {
                a.AlumnoId,
                nombreCompleto = $"ID {a.AlumnoId} - {a.Nombre} {a.Apellido}"
            });

            var carreras = _context.Carreras.Select(c => new
            {
                c.CarreraId,
                carreraNombreApellido = $"{_context.ListadoCarreras.Where(lc => lc.ListadoCarrerasId == c.ListadoCarrerasId).SingleOrDefault().Nombre} - ID {_context.Alumnos.Where(a => a.AlumnoId == c.AlumnoId).SingleOrDefault().AlumnoId} {_context.Alumnos.Where(a => a.AlumnoId == c.AlumnoId).SingleOrDefault().Nombre} {_context.Alumnos.Where(a => a.AlumnoId == c.AlumnoId).SingleOrDefault().Apellido}"
            });
            ViewData["AlumnoId"] = new SelectList(alumnos, "AlumnoId", "nombreCompleto");
            ViewData["CarreraId"] = new SelectList(carreras, "CarreraId", "carreraNombreApellido");
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Nombre");
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsignaturaId,ListadoAsignaturasId,AlumnoId,CarreraId,Comision,HorarioEntrada,HorarioSalida,Dias")] Asignaturas asignaturas, string[] Dias)
        {
            if (ModelState.IsValid)
            {
                asignaturas.Dias = null;
                for (int i = 0; i < Dias.Length; i++)
                {
                    if (Dias[i] == null)
                    {
                        Dias[i] = "false";
                    }

                    if (Dias[i] != "false")
                    {
                        asignaturas.Dias += Dias[i] + "-";
                    }
                }
                if (asignaturas.Dias.EndsWith("-"))
                {
                    asignaturas.Dias = asignaturas.Dias.Remove(asignaturas.Dias.Length - 1);
                }
                _context.Add(asignaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var alumnos = _context.Alumnos.Select(a => new
            {
                a.AlumnoId,
                nombreCompleto = $"ID {a.AlumnoId} - {a.Nombre} {a.Apellido}"
            });

            var carreras = _context.Carreras.Select(c => new
            {
                c.CarreraId,
                carreraNombreApellido = $"{_context.ListadoCarreras.Where(lc => lc.ListadoCarrerasId == c.ListadoCarrerasId).SingleOrDefault().Nombre} - {_context.Alumnos.Where(a => a.AlumnoId == c.AlumnoId).SingleOrDefault().Nombre} {_context.Alumnos.Where(a => a.AlumnoId == c.AlumnoId).SingleOrDefault().Apellido}"
            });
            ViewData["AlumnoId"] = new SelectList(alumnos, "AlumnoId", "nombreCompleto");
            ViewData["CarreraId"] = new SelectList(carreras, "CarreraId", "carreraNombreApellido");
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Nombre");
            return View(asignaturas);
        }

        // GET: Asignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id, int? listadoAsignaturasId, int? alumnoId)
        {
            bool[] Dias = new bool[6];
            if (id == null || alumnoId == null || listadoAsignaturasId == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas.FindAsync(id, listadoAsignaturasId, alumnoId);
            if (asignaturas == null)
            {
                return NotFound();
            }

            var alumnos = _context.Alumnos.Select(a => new
            {
                a.AlumnoId,
                nombreCompleto = $"ID {a.AlumnoId} - {a.Nombre} {a.Apellido}"
            });

            var carreras = _context.Carreras.Select(c => new
            {
                c.CarreraId,
                carreraNombreApellido = $"{_context.ListadoCarreras.Where( lc => lc.ListadoCarrerasId == c.ListadoCarrerasId).SingleOrDefault().Nombre} - {_context.Alumnos.Where(a => a.AlumnoId == c.AlumnoId).SingleOrDefault().Nombre} {_context.Alumnos.Where(a => a.AlumnoId == c.AlumnoId).SingleOrDefault().Apellido}"
            });

            ViewData["AlumnoId"] = new SelectList(alumnos, "AlumnoId", "nombreCompleto", asignaturas.AlumnoId);
            ViewData["CarreraId"] = new SelectList(carreras, "CarreraId", "carreraNombreApellido", asignaturas.CarreraId);
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Nombre", asignaturas.ListadoAsignaturasId);
            if (asignaturas.Dias.Contains("Lunes") == true)
            {
                Dias[0] = true;
            }
            else if (asignaturas.Dias.Contains("Martes") == true)
            {
                Dias[1] = true;
            }
            else if (asignaturas.Dias.Contains("Miercoles") == true)
            {
                Dias[2] = true;
            }
            else if (asignaturas.Dias.Contains("Jueves") == true)
            {
                Dias[3] = true;
            }
            else if (asignaturas.Dias.Contains("Viernes") == true)
            {
                Dias[4] = true;
            }
            else if (asignaturas.Dias.Contains("Sabado") == true)
            {
                Dias[5] = true;
            }
            else if (asignaturas.Dias.Contains("Domingo") == true)
            {
                Dias[6] = true;
            }
            return View(asignaturas);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsignaturaId,ListadoAsignaturasId,AlumnoId,CarreraId,Comision,HorarioEntrada,HorarioSalida,Dias")] Asignaturas asignaturas, string[] Dias)
        {
            if (id != asignaturas.AsignaturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                asignaturas.Dias = null;
                for (int i = 0; i < Dias.Length; i++)
                {
                    if (Dias[i] == null)
                    {
                        Dias[i] = "false";
                    }

                    if (Dias[i] != "false")
                    {
                        asignaturas.Dias += Dias[i] + "-";
                    }
                }
                if (asignaturas.Dias.EndsWith("-"))
                {
                    asignaturas.Dias = asignaturas.Dias.Remove(asignaturas.Dias.Length - 1);
                }

                try
                {
                    _context.Update(asignaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasExists(asignaturas.AsignaturaId))
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
            ViewData["ListadoAsignaturasId"] = new SelectList(_context.ListadoAsignaturas, "ListadoAsignaturasId", "Nombre", asignaturas.ListadoAsignaturasId);
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
            return _context.Asignaturas.Any(e => e.AsignaturaId == id);
        }
    }
}
