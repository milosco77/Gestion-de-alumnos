using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class ListadoAsignatura
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();

        public static Entidades.ListadoAsignaturas ListarUna(int ID)
        {
            return db.ListadoAsignaturas.Where(m => m.ListadoAsignaturasId == ID).SingleOrDefault();
        }

        public static List<Entidades.ListadoAsignaturas> ListarVarias(int ID)
        {
            return db.ListadoAsignaturas.Where(a => a.ListadoAsignaturasId == ID).ToList();
        }

        public static List<Entidades.ListadoAsignaturas> ListarTodas()
        {
            return db.ListadoAsignaturas.ToList();
        }

    }
}
