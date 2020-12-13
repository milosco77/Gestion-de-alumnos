using Entidades;
using Microsoft.EntityFrameworkCore;
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
            try
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
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
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

        public static string Agregar(Entidades.Carreras carrera)
        {
            try
            {
                db.Carreras.Add(carrera);
                db.SaveChanges();
                return $"La carrera con AlumnoID: {carrera.AlumnoId} ListadoCarrerasID: {carrera.ListadoCarrerasId} ha sido agregado.";
            }
            catch (DbUpdateException e)
            {
                return $"La asignatura con AlumnoID: {carrera.AlumnoId} ListadoCarrerasID: {carrera.ListadoCarrerasId} no ha sido agregado debido a excepcion:\n{e}\n\nIndicando que se realizo una infraccion a una de las restricciones de la tabla. Lea el detalle de la excepcion.";
            }
            catch (Exception e)
            {
                return $"La carrera con AlumnoID: {carrera.AlumnoId} ListadoCarrerasID: {carrera.ListadoCarrerasId} no ha sido agregado debido a excepcion: {e}";
            }
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
                db.Carreras.Remove(db.Carreras.Where(c => c.CarreraId == carreraID).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Carrera con ID {carreraID} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Carrera con ID {carreraID} no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Carrera con ID {carreraID} no ha sido eliminado debido a excepcion: {e}";
            }
        }
    }
}
