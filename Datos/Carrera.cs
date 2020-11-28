//using Entidades;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Datos
//{
//    public static class Carrera
//    {
//        public static Entidades.AlumnosContext db = new AlumnosContext();

//        public static Entidades.Carreras ListarUna(int ID)
//        {
//            return db.Carreras.Where(c => c.CarreraId == ID).SingleOrDefault();
//        }

//        public static List<Entidades.Carreras> ListarVarias(int ID)
//        {
//            return db.Carreras.Where(a => a.CarreraId == ID).ToList();
//        }

//        public static List<Entidades.Carreras> ListarTodas()
//        {
//            return db.Carreras.ToList();
//        }
//    }

//}
