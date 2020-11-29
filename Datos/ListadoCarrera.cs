using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class ListadoCarrera
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();

        public static Entidades.ListadoCarreras ListarUna(int ID)
        {
            return db.ListadoCarreras.Where(c => c.ListadoCarrerasId == ID).SingleOrDefault();
        }

        public static List<Entidades.ListadoCarreras> ListarVarias(int ID)
        {
            return db.ListadoCarreras.Where(a => a.ListadoCarrerasId == ID).ToList();
        }

        public static List<Entidades.ListadoCarreras> ListarTodas()
        {
            return db.ListadoCarreras.ToList();
        }
    }

}
