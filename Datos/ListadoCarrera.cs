using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class ListadoCarrera
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();
#nullable enable
        public static Entidades.ListadoCarreras ListarUna(int? listadoCarrerasID = null, int? facultadID = null, string? nombre = null, string? titulo = null, int? duracionEstimadaAnios = null)
        {
            if (listadoCarrerasID != null)
            {
                return db.ListadoCarreras.Where(lc => lc.ListadoCarrerasId == listadoCarrerasID).FirstOrDefault();
            }
            else if (facultadID != null)
            {
                return db.ListadoCarreras.Where(lc => lc.FacultadId == facultadID).FirstOrDefault();
            }
            else if (nombre != null)
            {
                return db.ListadoCarreras.Where(lc => lc.Nombre == nombre).FirstOrDefault();
            }
            else if (titulo != null)
            {
                return db.ListadoCarreras.Where(lc => lc.Titulo == titulo).FirstOrDefault();
            }
            return db.ListadoCarreras.Where(lc => lc.DuracionEstimadaAnios == duracionEstimadaAnios).FirstOrDefault();
        }

        public static List<Entidades.ListadoCarreras> ListarVarias(int? listadoCarrerasID = null, int? facultadID = null, string? nombre = null, string? titulo = null, int? duracionEstimadaAnios = null)
        {
            if (listadoCarrerasID != null)
            {
                return db.ListadoCarreras.Where(lc => lc.ListadoCarrerasId == listadoCarrerasID).ToList();
            }
            else if (facultadID != null)
            {
                return db.ListadoCarreras.Where(lc => lc.FacultadId == facultadID).ToList();
            }
            else if (nombre != null)
            {
                return db.ListadoCarreras.Where(lc => lc.Nombre == nombre).ToList();
            }
            else if (titulo != null)
            {
                return db.ListadoCarreras.Where(lc => lc.Titulo == titulo).ToList();
            }
            return db.ListadoCarreras.Where(lc => lc.DuracionEstimadaAnios == duracionEstimadaAnios).ToList();
        }
#nullable disable
        public static List<Entidades.ListadoCarreras> ListarTodas()
        {
            return db.ListadoCarreras.ToList();
        }

        public static string Agregar(Entidades.ListadoCarreras listadoCarrera)
        {
            try
            {
                db.ListadoCarreras.Add(listadoCarrera);
                db.SaveChanges();
                return $"El listadoCarrera con ListadoCarrerasID: {listadoCarrera.ListadoCarrerasId} Nombre: {listadoCarrera.Nombre} ha sido agregado.";
            }
            catch (DbUpdateException e)
            {
                return $"La asignatura con ListadoCarrerasID: {listadoCarrera.ListadoCarrerasId} Nombre: {listadoCarrera.Nombre} no ha sido agregado debido a excepcion:\n{e}\n\nIndicando que se realizo una infraccion a una de las restricciones de la tabla. Lea el detalle de la excepcion.";
            }
            catch (Exception e)
            {
                return $"El listadoCarrera con ListadoCarrerasID: {listadoCarrera.ListadoCarrerasId} Nombre: {listadoCarrera.Nombre} no ha sido agregado debido a excepcion: {e}";
            }
        }

        public static void Editar(Entidades.ListadoCarreras pListadoCarrera)
        {
            Entidades.ListadoCarreras listadoCarrera = db.ListadoCarreras.Where(lc => lc.ListadoCarrerasId == pListadoCarrera.ListadoCarrerasId).SingleOrDefault();
            listadoCarrera.ListadoCarrerasId = pListadoCarrera.ListadoCarrerasId;
            listadoCarrera.FacultadId = pListadoCarrera.FacultadId;
            listadoCarrera.Nombre = pListadoCarrera.Nombre;
            listadoCarrera.Titulo = pListadoCarrera.Titulo;
            listadoCarrera.DuracionEstimadaAnios = pListadoCarrera.DuracionEstimadaAnios;
            db.SaveChanges();
        }
#nullable enable
        public static string Eliminar(int? listadoCarrerasID = null, int? facultadID = null, string? nombre = null, string? titulo = null, int? duracionEstimadaAnios = null)
        {
            try
            {
                if (listadoCarrerasID != null)
                {
                    db.ListadoCarreras.Remove(db.ListadoCarreras.Where(lc => lc.ListadoCarrerasId == listadoCarrerasID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoCarreras con ID {listadoCarrerasID} ha sido borrado correctamente.";
                }
                else if (facultadID != null)
                {
                    db.ListadoCarreras.Remove(db.ListadoCarreras.Where(f => f.FacultadId == facultadID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoCarreras con FacultadID {facultadID} ha sido borrado correctamente.";
                }
                else if (nombre != null)
                {
                    db.ListadoCarreras.Remove(db.ListadoCarreras.Where(n => n.Nombre == nombre).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoCarreras con Nombre {nombre} ha sido borrado correctamente.";
                }
                else if (titulo != null)
                {
                    db.ListadoCarreras.Remove(db.ListadoCarreras.Where(t => t.Titulo == titulo).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento del ListadoCarreras con Titulo {titulo} ha sido borrado correctamente.";
                }
                db.ListadoCarreras.Remove(db.ListadoCarreras.Where(dea => dea.DuracionEstimadaAnios == duracionEstimadaAnios).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento del ListadoCarreras con Duracion Estimada en Años {duracionEstimadaAnios} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento del ListadoCarreras no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento del ListadoCarreras no ha sido eliminado debido a excepcion: {e}";
            }
#nullable disable
        }
    }
}
