using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class Nota
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();
        public static void Agregar(Entidades.Notas nota)
        {
            db.Notas.Add(nota);
            db.SaveChanges();
        }

        public static Entidades.Notas ListarUna(int ID)
        {
            return db.Notas.Where(n => n.NotasId == ID).SingleOrDefault();
        }

        public static List<Entidades.Notas> ListarVarias(int ID)
        {
            return db.Notas.Where(a => a.NotasId == ID).ToList();
        }

        public static List<Entidades.Notas> ListarTodas()
        {
            return db.Notas.ToList();
        }
    }
}
