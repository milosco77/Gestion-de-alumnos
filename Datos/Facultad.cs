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
#nullable enable
        public static Entidades.Facultades ListarUna(int? facultadID = null, string? nombre = null, string? direccion = null, int? telefono = null, string? departamentoAlumnos = null, string? facebook = null, string? instagram = null, string? twitter = null, string? paginaWeb = null, string? email = null, string? recorridoVirtual = null)
        {
            if (facultadID != null)
            {
                return db.Facultades.Where(a => a.FacultadId == facultadID).FirstOrDefault();
            }
            else if (direccion != null)
            {
                return db.Facultades.Where(a => a.Direccion == direccion).FirstOrDefault();
            }
            else if (telefono != null)
            {
                return db.Facultades.Where(a => a.Telefono == telefono).FirstOrDefault();
            }
            else if (departamentoAlumnos != null)
            {
                return db.Facultades.Where(a => a.DepartamentoAlumnos == departamentoAlumnos).FirstOrDefault();
            }
            else if (nombre != null)
            {
                return db.Facultades.Where(a => a.Nombre == nombre).FirstOrDefault();
            }
            else if (facebook != null)
            {
                return db.Facultades.Where(a => a.Facebook == facebook).FirstOrDefault();
            }
            else if (instagram != null)
            {
                return db.Facultades.Where(a => a.Instagram == instagram).FirstOrDefault();
            }
            else if (twitter != null)
            {
                return db.Facultades.Where(a => a.Twitter == twitter).FirstOrDefault();
            }
            else if (paginaWeb != null)
            {
                return db.Facultades.Where(a => a.PaginaWeb == paginaWeb).FirstOrDefault();
            }
            else if (email != null)
            {
                return db.Facultades.Where(a => a.Email == email).FirstOrDefault();
            }
            return db.Facultades.Where(a => a.RecorridoVirtual == recorridoVirtual).FirstOrDefault();
        }

        public static List<Entidades.Facultades> ListarVarias(int? facultadID = null, string? nombre = null, string? direccion = null, int? telefono = null, string? departamentoAlumnos = null, string? facebook = null, string? instagram = null, string? twitter = null, string? paginaWeb = null, string? email = null, string? recorridoVirtual = null)
        {
            if (facultadID != null)
            {
                return db.Facultades.Where(a => a.FacultadId == facultadID).ToList();
            }
            else if (direccion != null)
            {
                return db.Facultades.Where(a => a.Direccion == direccion).ToList();
            }
            else if (telefono != null)
            {
                return db.Facultades.Where(a => a.Telefono == telefono).ToList();
            }
            else if (departamentoAlumnos != null)
            {
                return db.Facultades.Where(a => a.DepartamentoAlumnos == departamentoAlumnos).ToList();
            }
            else if (nombre != null)
            {
                return db.Facultades.Where(a => a.Nombre == nombre).ToList();
            }
            else if (facebook != null)
            {
                return db.Facultades.Where(a => a.Facebook == facebook).ToList();
            }
            else if (instagram != null)
            {
                return db.Facultades.Where(a => a.Instagram == instagram).ToList();
            }
            else if (twitter != null)
            {
                return db.Facultades.Where(a => a.Twitter == twitter).ToList();
            }
            else if (paginaWeb != null)
            {
                return db.Facultades.Where(a => a.PaginaWeb == paginaWeb).ToList();
            }
            else if (email != null)
            {
                return db.Facultades.Where(a => a.Email == email).ToList();
            }
            return db.Facultades.Where(a => a.RecorridoVirtual == recorridoVirtual).ToList();
        }
#nullable disable
        public static List<Entidades.Facultades> ListarTodas()
        {
            return db.Facultades.ToList();
        }

        public static string Agregar(Entidades.Facultades facultad)
        {
            try
            {
                db.Facultades.Add(facultad);
                db.SaveChanges();
                return $"La facultad con FacultadID: {facultad.FacultadId} Nombre: {facultad.Nombre} ha sido agregado.";
            }
            catch (Exception e)
            {
                return $"La facultad con FacultadID: {facultad.FacultadId} Nombre: {facultad.Nombre} no ha sido agregado debido a excepcion: {e.Message}";
            }
        }

        public static void Editar(Entidades.Facultades pFacultad)
        {
            Entidades.Facultades facultad = db.Facultades.Where(f => f.FacultadId == pFacultad.FacultadId).SingleOrDefault();
            facultad.FacultadId = pFacultad.FacultadId;
            facultad.Nombre = pFacultad.Nombre;
            facultad.Direccion = pFacultad.Direccion;
            facultad.Telefono = pFacultad.Telefono;
            facultad.DepartamentoAlumnos = pFacultad.DepartamentoAlumnos;
            facultad.Facebook = pFacultad.Facebook;
            facultad.Instagram = pFacultad.Instagram;
            facultad.Twitter = pFacultad.Twitter;
            facultad.PaginaWeb = pFacultad.PaginaWeb;
            facultad.Email = pFacultad.Email;
            facultad.RecorridoVirtual = pFacultad.RecorridoVirtual;
            db.SaveChanges();
        }

        public static string Eliminar(int facultadID)
        {
            try
            {
                db.Facultades.Remove(db.Facultades.Where(f => f.FacultadId == facultadID).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Facultad con ID {facultadID} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Facultad con ID {facultadID} no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Facultad con ID {facultadID} no ha sido eliminado debido a excepcion: {e.Message}";
            }
        }
    }
}
