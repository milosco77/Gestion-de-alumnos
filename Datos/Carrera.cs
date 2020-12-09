using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class Carrera
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();

        public static Entidades.Carreras ListarUna(int? carreraID = null, int? alumnoID = null, int? listadoCarrerasID = null)
        {
            if (carreraID != null)
            {
                return db.Carreras.Where(c => c.CarreraId == carreraID).SingleOrDefault();
            }
            else if (alumnoID != null)
            {
                return db.Carreras.Where(c => c.AlumnoId == alumnoID).SingleOrDefault();
            }
            return db.Carreras.Where(c => c.ListadoCarrerasId == listadoCarrerasID).SingleOrDefault();
        }

        public static List<Entidades.Carreras> ListarVarias(int? carreraID = null, int? alumnoID = null, int? listadoCarrerasID = null)
        {
            if (carreraID != null)
            {
                return db.Carreras.Where(c => c.CarreraId == carreraID).ToList();
            }
            else if (alumnoID != null)
            {
                return db.Carreras.Where(c => c.AlumnoId == alumnoID).ToList();
            }
            return db.Carreras.Where(c => c.ListadoCarrerasId == listadoCarrerasID).ToList();
        }

        public static List<Entidades.Carreras> ListarTodas()
        {
            return db.Carreras.ToList();
        }

        public static void Agregar(Entidades.Carreras carrera)
        {
            db.Carreras.Add(carrera);
            db.SaveChanges();
        }

        public static void Editar(Entidades.Carreras pCarrera)
        {
            Entidades.Carreras carrera = db.Carreras.Where(c => c.CarreraId == pCarrera.CarreraId).SingleOrDefault();
            carrera.CarreraId = pCarrera.CarreraId;
            carrera.AlumnoId = pCarrera.AlumnoId;
            carrera.ListadoCarrerasId = pCarrera.ListadoCarrerasId;
            db.SaveChanges();
        }

        public static string Eliminar(int carreraID)
        {
            try
            {
                db.Carreras.Remove(db.Carreras.Where(c => c.AlumnoId == carreraID).SingleOrDefault());
                db.SaveChanges();
                return $"Carrera con ID {carreraID} eliminado.";
            }
            catch (ArgumentNullException e)
            {
                return e.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
