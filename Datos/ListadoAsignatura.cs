using Entidades;
using Microsoft.EntityFrameworkCore;
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

        public static string Agregar(Entidades.ListadoAsignaturas listadoAsignatura)
        {
            try
            {
                db.ListadoAsignaturas.Add(listadoAsignatura);
                db.SaveChanges();
                return $"La listadoAsignatura con AlumnoID: {listadoAsignatura.ListadoAsignaturasId} Nombre: {listadoAsignatura.Nombre} ha sido agregado.";
            }
            catch (DbUpdateException e)
            {
                return $"La asignatura con AlumnoID: {listadoAsignatura.ListadoAsignaturasId} Nombre: {listadoAsignatura.Nombre} no ha sido agregado debido a excepcion:\n{e}\n\nIndicando que se realizo una infraccion a una de las restricciones de la tabla. Lea el detalle de la excepcion.";
            }
            catch (Exception e)
            {
                return $"La listadoAsignatura con AlumnoID: {listadoAsignatura.ListadoAsignaturasId} Nombre: {listadoAsignatura.Nombre} no ha sido agregado debido a excepcion: {e}";
            }
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
#nullable enable
        public static string Eliminar(int? listadoAsignaturasID = null, string? codigo = null, string? nombre = null, int? creditos = null, int? horas = null, string? correlativas = null, string? categoria = null, int? listadoCarrerasID = null)
        {
            try
            {
                if (listadoAsignaturasID != null)
                {
                    db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(la => la.ListadoAsignaturasId == listadoAsignaturasID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoAsignaturas con ID {listadoAsignaturasID} ha sido borrado correctamente.";
                }
                else if (codigo != null)
                {
                    db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(c => c.Codigo == codigo).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoAsignaturas con Codigo {codigo} ha sido borrado correctamente.";
                }
                else if (nombre != null)
                {
                    db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(n => n.Nombre == nombre).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoAsignaturas con Nombre {nombre} ha sido borrado correctamente.";
                }
                else if (creditos != null)
                {
                    db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(c => c.Creditos == creditos).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoAsignaturas con Creditos {creditos} ha sido borrado correctamente.";
                }
                else if (horas != null)
                {
                    db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(h => h.Horas == horas).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoAsignaturas con Horas {horas} ha sido borrado correctamente.";
                }
                else if (correlativas != null)
                {
                    db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(c => c.Correlativas == correlativas).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoAsignaturas con Correlativas {correlativas} ha sido borrado correctamente.";
                }
                else if (categoria != null)
                {
                    db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(c => c.Categoria == categoria).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoAsignaturas con Categoria {categoria} ha sido borrado correctamente.";
                }
                db.ListadoAsignaturas.Remove(db.ListadoAsignaturas.Where(lc => lc.ListadoCarrerasId == listadoCarrerasID).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento del ListadoAsignaturas con ListadoCarrerasID {listadoCarrerasID} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento del ListadoAsignaturas con ID {listadoAsignaturasID} no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento del ListadoAsignaturas con ID {listadoAsignaturasID} no ha sido eliminado debido a excepcion: {e}";
            }
        }
#nullable disable
    }
}
