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

        public static void Agregar(Entidades.ListadoCarreras listadoCarrera)
        {
            db.ListadoCarreras.Add(listadoCarrera);
            db.SaveChanges();
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

        public static void Eliminar(int listadoCarrerasID)
        {
            db.ListadoCarreras.Remove(db.ListadoCarreras.Find(listadoCarrerasID));
            db.SaveChanges();
        }
    }
}
