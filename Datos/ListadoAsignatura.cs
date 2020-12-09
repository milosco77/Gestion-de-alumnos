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
#nullable enable
        public static Entidades.ListadoAsignaturas ListarUna(int? listadoAsignaturasID = null, string? codigo = null, string? nombre = null, int? creditos = null, int? horas = null, string? correlativas = null, string? categoria = null, int? listadoCarrerasID = null)
        {
            if (listadoAsignaturasID != null)
            {
                return db.ListadoAsignaturas.Where(m => m.ListadoAsignaturasId == listadoAsignaturasID).FirstOrDefault();
            }
            else if (codigo != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Codigo == codigo).FirstOrDefault();
            }
            else if (nombre != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Nombre == nombre).FirstOrDefault();
            }
            else if (creditos != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Creditos == creditos).FirstOrDefault();
            }
            else if (horas != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Horas == horas).FirstOrDefault();
            }
            else if (correlativas != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Correlativas == correlativas).FirstOrDefault();
            }
            else if (categoria != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Categoria == categoria).FirstOrDefault();
            }
            return db.ListadoAsignaturas.Where(m => m.ListadoCarrerasId == listadoCarrerasID).FirstOrDefault();
        }

        public static List<Entidades.ListadoAsignaturas> ListarVarias(int? listadoAsignaturasID = null, string? codigo = null, string? nombre = null, int? creditos = null, int? horas = null, string? correlativas = null, string? categoria = null, int? listadoCarrerasID = null)
        {
            if (listadoAsignaturasID != null)
            {
                return db.ListadoAsignaturas.Where(m => m.ListadoAsignaturasId == listadoAsignaturasID).ToList();
            }
            else if (codigo != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Codigo == codigo).ToList();
            }
            else if (nombre != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Nombre == nombre).ToList();
            }
            else if (creditos != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Creditos == creditos).ToList();
            }
            else if (horas != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Horas == horas).ToList();
            }
            else if (correlativas != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Correlativas == correlativas).ToList();
            }
            else if (categoria != null)
            {
                return db.ListadoAsignaturas.Where(m => m.Categoria == categoria).ToList();
            }
            return db.ListadoAsignaturas.Where(m => m.ListadoCarrerasId == listadoCarrerasID).ToList();
        }
#nullable disable
        public static List<Entidades.ListadoAsignaturas> ListarTodas()
        {
            return db.ListadoAsignaturas.ToList();
        }

        public static void Agregar(Entidades.ListadoAsignaturas listadoAsignatura)
        {
            db.ListadoAsignaturas.Add(listadoAsignatura);
            db.SaveChanges();
        }

        public static void Editar(Entidades.ListadoAsignaturas pListadoAsignatura)
        {
            Entidades.ListadoAsignaturas listadoAsignatura = db.ListadoAsignaturas.Where(la => la.ListadoAsignaturasId == pListadoAsignatura.ListadoAsignaturasId).SingleOrDefault();
            listadoAsignatura.ListadoAsignaturasId = pListadoAsignatura.ListadoAsignaturasId;
            listadoAsignatura.Codigo = pListadoAsignatura.Codigo;
            listadoAsignatura.Nombre = pListadoAsignatura.Nombre;
            listadoAsignatura.Creditos = pListadoAsignatura.Creditos;
            listadoAsignatura.Horas = pListadoAsignatura.Horas;
            listadoAsignatura.Correlativas = pListadoAsignatura.Correlativas;
            listadoAsignatura.Categoria = pListadoAsignatura.Categoria;
            listadoAsignatura.ListadoCarrerasId = pListadoAsignatura.ListadoCarrerasId;
            db.SaveChanges();
        }

        public static string Eliminar(int listadoAsignaturasID)
        {
            try
            {
                db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(la => la.ListadoAsignaturasId == listadoAsignaturasID).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento del ListadoAsignaturas con ID {listadoAsignaturasID} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento del ListadoAsignaturas con ID {listadoAsignaturasID} no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento del ListadoAsignaturas con ID {listadoAsignaturasID} no ha sido eliminado debido a excepcion: {e.Message}";
            }
        }
    }
}
