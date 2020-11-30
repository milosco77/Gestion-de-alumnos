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
        public static void Agregar(Entidades.Asignaturas asignatura)
        {
            db.Asignaturas.Add(asignatura);
            db.SaveChanges();
        }
#nullable enable
        public static Entidades.Asignaturas ListarUna(int? asignaturaID = null, int? listadoAsignaturaID = null, int? alumnoID = null, int? comision = null)
        {
            return db.Asignaturas.Where(a => a.AsignaturaId == asignaturaID).SingleOrDefault();
        }

        public static List<Entidades.Asignaturas> ListarVarias(int ID)
        {
            return db.Asignaturas.Where(a => a.AlumnoId == ID).ToList();
        }
#nullable disable
        public static List<Entidades.Asignaturas> ListarTodas()
        {
            return db.Asignaturas.ToList();
        }
    }
}
