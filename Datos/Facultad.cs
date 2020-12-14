using Entidades;
using Microsoft.EntityFrameworkCore;
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
            catch (DbUpdateException e)
            {
                return $"La asignatura con FacultadID: {facultad.FacultadId} Nombre: {facultad.Nombre} no ha sido agregado debido a excepcion:\n{e}\n\nIndicando que se realizo una infraccion a una de las restricciones de la tabla. Lea el detalle de la excepcion.";
            }
            catch (Exception e)
            {
                return $"La facultad con FacultadID: {facultad.FacultadId} Nombre: {facultad.Nombre} no ha sido agregado debido a excepcion: {e}";
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
#nullable enable
        public static string Eliminar(int? facultadID = null, string? nombre = null, string? direccion = null, int? telefono = null, string? departamentoAlumnos = null, string? facebook = null, string? instagram = null, string? twitter = null, string? paginaWeb = null, string? email = null, string? recorridoVirtual = null)
        {
            try
            {
                if (facultadID != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(f => f.FacultadId == facultadID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con ID {facultadID} ha sido borrado correctamente.";
                }
                else if (nombre != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(n => n.Nombre == nombre).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Nombre {nombre} ha sido borrado correctamente.";
                }
                else if (direccion != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(d => d.Direccion == direccion).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Direccion {direccion} ha sido borrado correctamente.";
                }
                else if (telefono != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(t => t.Telefono == telefono).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Telefono {telefono} ha sido borrado correctamente.";
                }
                else if (departamentoAlumnos != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(da => da.DepartamentoAlumnos == departamentoAlumnos).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Departamento de Alumnos {departamentoAlumnos} ha sido borrado correctamente.";
                }
                else if (facebook != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(f => f.Facebook == facebook).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Facebook {facebook} ha sido borrado correctamente.";
                }
                else if (instagram != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(i => i.Instagram == instagram).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Instagram {instagram} ha sido borrado correctamente.";
                }
                else if (twitter != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(t => t.Twitter == twitter).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Twitter {twitter} ha sido borrado correctamente.";
                }
                else if (paginaWeb != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(pw => pw.PaginaWeb == paginaWeb).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con PaginaWeb {paginaWeb} ha sido borrado correctamente.";
                }
                else if (email != null)
                {
                    db.Facultades.Remove(db.Facultades.Where(e => e.Email == email).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Facultad con Email {email} ha sido borrado correctamente.";
                }
                db.Facultades.Remove(db.Facultades.Where(rv => rv.RecorridoVirtual == recorridoVirtual).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Facultad con RecorridoVirtual {recorridoVirtual} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Facultad no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Facultad no ha sido eliminado debido a excepcion: {e}";
            }
        }
#nullable disable
    }
}
