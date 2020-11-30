using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class Facultad
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();
        public static void Agregar(Entidades.Facultades facultad)
        {
            db.Facultades.Add(facultad);
            db.SaveChanges();
        }

        public static Entidades.Facultades ListarUna(int ID)
        {
            return db.Facultades.Where(a => a.FacultadId == ID).SingleOrDefault();
        }

        public static List<Entidades.Facultades> ListarVarias(int ID)
        {
            return db.Facultades.Where(a => a.FacultadId == ID).ToList();
        }

        public static List<Entidades.Facultades> ListarTodas()
        {
            return db.Facultades.ToList();
        }
    }
}
