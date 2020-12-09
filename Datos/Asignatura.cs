using Entidades;
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

        public static void Agregar(Entidades.Asignaturas asignatura)
        {
            db.Asignaturas.Add(asignatura);
            db.SaveChanges();
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
        
        public static string Eliminar(int asignaturaID)
        {
            try
            {
                db.Asignaturas.Remove(db.Asignaturas.Where(a => a.AsignaturaId == asignaturaID).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Asignatura con ID {asignaturaID} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Asignatura con ID {asignaturaID} no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Asignatura con ID {asignaturaID} no ha sido eliminado debido a excepcion: {e.Message}";
            }
        }
    }
}
