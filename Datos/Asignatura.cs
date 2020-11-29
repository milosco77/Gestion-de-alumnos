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
            db.Asignaturas.Add(entity: asignatura);
            db.SaveChanges();
        }

        public static Entidades.Asignaturas ListarUna(int ID)
        {
            return db.Asignaturas.Where(a => a.AsignaturaId == ID).SingleOrDefault();
        }

        public static List<Entidades.Asignaturas> ListarVarias(int ID)
        {
            return db.Asignaturas.Where(a => a.AlumnoId == ID).ToList();
        }

        public static List<Entidades.Asignaturas> ListarTodas()
        {
            return db.Asignaturas.ToList();
        }
    }
}
