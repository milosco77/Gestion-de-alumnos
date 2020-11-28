using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class Materia
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();

        public static Entidades.Materias ListarUna(int ID)
        {
            return db.Materias.Where(m => m.MateriaId == ID).SingleOrDefault();
        }

        public static List<Entidades.Materias> ListarVarias(int ID)
        {
            return db.Materias.Where(a => a.MateriaId == ID).ToList();
        }

        public static List<Entidades.Materias> ListarTodas()
        {
            return db.Materias.ToList();
        }

    }
}
