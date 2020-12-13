using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class Asignatura
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();
#nullable enable
        public static Entidades.Asignaturas ListarUna(int? asignaturaID = null, int? listadoAsignaturasID = null, int? alumnoID = null, int? carreraID = null, int? comision = null, TimeSpan? horarioEntrada = null, TimeSpan? horarioSalida = null, string? dias = null)
        {
            if (asignaturaID != null)
            {
                return db.Asignaturas.Where(a => a.AsignaturaId == asignaturaID).FirstOrDefault();
            }
            else if (listadoAsignaturasID != null)
            {
                return db.Asignaturas.Where(a => a.ListadoAsignaturasId == listadoAsignaturasID).FirstOrDefault();
            }
            else if (alumnoID != null)
            {
                return db.Asignaturas.Where(a => a.AlumnoId == alumnoID).FirstOrDefault();
            }
            else if (carreraID != null)
            {
                return db.Asignaturas.Where(a => a.CarreraId == carreraID).FirstOrDefault();
            }
            else if (comision != null)
            {
                return db.Asignaturas.Where(a => a.Comision == comision).FirstOrDefault();
            }
            else if (horarioEntrada != null)
            {
                return db.Asignaturas.Where(a => a.HorarioEntrada == horarioEntrada).FirstOrDefault();
            }
            else if (horarioSalida != null)
            {
                return db.Asignaturas.Where(a => a.HorarioSalida == horarioSalida).FirstOrDefault();
            }
            return db.Asignaturas.Where(a => a.Dias == dias).FirstOrDefault();
        }

        public static List<Entidades.Asignaturas> ListarVarias(int? asignaturaID = null, int? listadoAsignaturasID = null, int? alumnoID = null, int? carreraID = null, int? comision = null, TimeSpan? horarioEntrada = null, TimeSpan? horarioSalida = null, string? dias = null)
        {
            if (asignaturaID != null)
            {
                return db.Asignaturas.Where(a => a.AsignaturaId == asignaturaID).ToList();
            }
            else if (listadoAsignaturasID != null)
            {
                return db.Asignaturas.Where(a => a.ListadoAsignaturasId == listadoAsignaturasID).ToList();
            }
            else if (alumnoID != null)
            {
                return db.Asignaturas.Where(a => a.AlumnoId == alumnoID).ToList();
            }
            else if (carreraID != null)
            {
                return db.Asignaturas.Where(a => a.CarreraId == carreraID).ToList();
            }
            else if (comision != null)
            {
                return db.Asignaturas.Where(a => a.Comision == comision).ToList();
            }
            else if (horarioEntrada != null)
            {
                return db.Asignaturas.Where(a => a.HorarioEntrada == horarioEntrada).ToList();
            }
            else if (horarioSalida != null)
            {
                return db.Asignaturas.Where(a => a.HorarioSalida == horarioSalida).ToList();
            }
            return db.Asignaturas.Where(a => a.Dias == dias).ToList();
        }
#nullable disable
        public static List<Entidades.Asignaturas> ListarTodas()
        {
            return db.Asignaturas.ToList();
        }

        public static string Agregar(Entidades.Asignaturas asignatura)
        {
            try
            {
                db.Asignaturas.Add(asignatura);
                db.SaveChanges();
                return $"La asignatura con AsignaturaID: {asignatura.AsignaturaId} ListadoCarrerasID: {asignatura.AlumnoId} ha sido agregado.";
            }
            catch (DbUpdateException e)
            {
                return $"La asignatura con AsignaturaID: {asignatura.AsignaturaId} ListadoCarrerasID: {asignatura.AlumnoId} no ha sido agregado debido a excepcion:\n{e}\n\nIndicando que se realizo una infraccion a una de las restricciones de la tabla. Lea el detalle de la excepcion.";
            }
            catch (Exception e)
            {
                return $"La asignatura con AsignaturaID: {asignatura.AsignaturaId} ListadoCarrerasID: {asignatura.AlumnoId} no ha sido agregado debido a excepcion:\n{e}";
            }
        }

        public static void Editar(Entidades.Asignaturas pAsignatura)
        {
            Entidades.Asignaturas asignatura = db.Asignaturas.Where(a => a.AsignaturaId == pAsignatura.AsignaturaId).SingleOrDefault();

            if (asignatura != null)
            {
                asignatura.AsignaturaId = pAsignatura.AsignaturaId;
                asignatura.ListadoAsignaturasId = pAsignatura.ListadoAsignaturasId;
                asignatura.AlumnoId = pAsignatura.AlumnoId;
                asignatura.CarreraId = pAsignatura.CarreraId;
                asignatura.Comision = pAsignatura.Comision;
                asignatura.HorarioEntrada = pAsignatura.HorarioEntrada;
                asignatura.HorarioSalida = pAsignatura.HorarioSalida;
                asignatura.Dias = pAsignatura.Dias;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("\nNo hay resultados con ese ID");
            }
        }
#nullable enable
        public static string Eliminar(int? asignaturaID = null, int? listadoAsignaturasID = null, int? alumnoID = null, int? carreraID = null, int? comision = null, TimeSpan? horarioEntrada = null, TimeSpan? horarioSalida = null, string? dias = null)
        {
            try
            {
                if (asignaturaID != null)
                {
                    db.Asignaturas.Remove(db.Asignaturas.Where(a => a.AsignaturaId == asignaturaID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Asignatura con AsignaturaID {asignaturaID} ha sido borrado correctamente.";
                }
                else if (listadoAsignaturasID != null)
                {
                    db.Asignaturas.Remove(db.Asignaturas.Where(la => la.ListadoAsignaturasId == listadoAsignaturasID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Asignatura con ListadoAsignaturasID {listadoAsignaturasID} ha sido borrado correctamente.";
                }
                else if (alumnoID != null)
                {
                    db.Asignaturas.Remove(db.Asignaturas.Where(a => a.AlumnoId == alumnoID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Asignatura con AlumnoID {alumnoID} ha sido borrado correctamente.";
                }
                else if (carreraID != null)
                {
                    db.Asignaturas.Remove(db.Asignaturas.Where(c => c.CarreraId == carreraID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Asignatura con CarreraID {carreraID} ha sido borrado correctamente.";
                }
                else if (comision != null)
                {
                    db.Asignaturas.Remove(db.Asignaturas.Where(c => c.Comision == comision).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Asignatura con Comision {comision} ha sido borrado correctamente.";
                }
                else if (horarioEntrada != null)
                {
                    db.Asignaturas.Remove(db.Asignaturas.Where(he => he.HorarioEntrada == horarioEntrada).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Asignatura con Horario de Entrada {horarioEntrada} ha sido borrado correctamente.";
                }
                else if (horarioSalida != null)
                {
                    db.Asignaturas.Remove(db.Asignaturas.Where(hs => hs.HorarioSalida == horarioSalida).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Asignatura con Horario de Salida {horarioSalida} ha sido borrado correctamente.";
                }
                db.Asignaturas.Remove(db.Asignaturas.Where(d => d.Dias == dias).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Asignatura con Dias {dias} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Asignatura con ID {asignaturaID} no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Asignatura con ID {asignaturaID} no ha sido eliminado debido a excepcion: {e}";
            }
#nullable disable
        }
    }
}
