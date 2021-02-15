using Entidades;
using Enumeraciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// alt+shift+ ` para elegir todas las coincidencias editar.incluirsimbolosdeinsercionentodaslascoincidencias
// TODO Hacer toda la capa de datos.
// TODO Poner correctamente scope de las propiedades de las clases.
// TODO Implementar validacion en la capa de datos.
// TODO Implementar SQLite.

namespace Datos
{
    public static class Alumno
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();
#nullable enable
        public static Entidades.Alumnos ListarUno(int? alumnoID = null, string ? nombre = null, string? apellido = null, int? edad = null, int? dni = null)
        {
            if (alumnoID != null)
            {
                return db.Alumnos.Where(a => a.AlumnoId == alumnoID).FirstOrDefault();
            }
            else if (nombre != null)
            {
                return db.Alumnos.Where(a => a.Nombre == nombre).FirstOrDefault();
            }
            else if (apellido != null)
            {
                return db.Alumnos.Where(a => a.Apellido == apellido).FirstOrDefault();
            }
            else if (edad != null)
            {
                return db.Alumnos.Where(a => a.Edad == edad).FirstOrDefault();
            }
            return db.Alumnos.Where(a => a.Dni == dni).FirstOrDefault();
        }

        public static List<Entidades.Alumnos> ListarVarios(int? alumnoID = null, string? nombre = null, string? apellido = null, int? edad = null, int? dni = null)
        {
            if (alumnoID != null)
            {
                return db.Alumnos.Where(a => a.AlumnoId == alumnoID).ToList();
            }
            else if (nombre != null)
            {
                return db.Alumnos.Where(a => a.Nombre == nombre).ToList();
            }
            else if (apellido != null)
            {
                return db.Alumnos.Where(a => a.Apellido == apellido).ToList();

            }
            else if (edad != null)
            {
                return db.Alumnos.Where(a => a.Edad == edad).ToList();

            }
            return db.Alumnos.Where(a => a.Dni == dni).ToList();

        }
#nullable disable
        public static List<Entidades.Alumnos> ListarTodos()
        {
            return db.Alumnos.OrderBy(a => a.AlumnoId).ToList();
        }

        public static string Agregar(Entidades.Alumnos alumno)
        {
            try
            {
                db.Alumnos.Add(alumno);
                db.SaveChanges();
                return $"El alumno con Nombre: {alumno.Nombre} Apellido: {alumno.Apellido} ha sido agregado.";
            }
            catch (DbUpdateException e)
            {
                return $"La asignatura con Nombre: {alumno.Nombre} Apellido: {alumno.Apellido} no ha sido agregado debido a excepcion:\n{e}\n\nIndicando que se realizo una infraccion a una de las restricciones de la tabla. Lea el detalle de la excepcion.";
            }
            catch (Exception e)
            {
                return $"El alumno con Nombre: {alumno.Nombre} Apellido: {alumno.Apellido} no ha sido agregado debido a excepcion: {e}";
            }
        }

        public static string Editar(Entidades.Alumnos alumno)
        {
            Entidades.Alumnos unAlumno = db.Alumnos.Where(a => a.AlumnoId == alumno.AlumnoId).SingleOrDefault();
            if (unAlumno != null)
            {
                try
                {
                    unAlumno.Nombre = alumno.Nombre;
                    unAlumno.Apellido = alumno.Apellido;
                    unAlumno.Edad = alumno.Edad;
                    unAlumno.Dni = alumno.Dni;
                    db.SaveChanges();
                    return "Editado correctamente.";
                }
                catch (Exception e)
                {
                    return $"No editado debido a {e.Message} | {e.InnerException}";
                }
            }
            return "El alumno no existe";
        }
#nullable enable
        public static string Eliminar(int? alumnoID = null, string? nombre = null, string? apellido = null, int? edad = null, int? dni = null)
        {
            try
            {
                if (alumnoID != null)
                {
                    db.Alumnos.Remove(db.Alumnos.Where(a => a.AlumnoId == alumnoID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Alumno con AlumnoID {alumnoID} ha sido borrado correctamente.";
                }
                else if (nombre != null)
                {
                    db.Alumnos.Remove(db.Alumnos.Where(n => n.Nombre == nombre).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Alumno con Nombre {nombre} ha sido borrado correctamente.";
                }
                else if (apellido != null)
                {
                    db.Alumnos.Remove(db.Alumnos.Where(a => a.Apellido == apellido).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Alumno con Apellido {apellido} ha sido borrado correctamente.";
                }
                else if (edad != null)
                {
                    db.Alumnos.Remove(db.Alumnos.Where(e => e.Edad == edad).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Alumno con Edad {edad} ha sido borrado correctamente.";
                }
                db.Alumnos.Remove(db.Alumnos.Where(d => d.Dni == dni).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Alumno con DNI {dni} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Alumno no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Alumno no ha sido eliminado debido a excepcion: {e}";
            }
        }
#nullable disable
    }
}