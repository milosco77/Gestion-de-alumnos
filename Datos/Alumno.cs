using Entidades;
using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// alt+shift+ ` para elegir todas las coincidencias editar.incluirsimbolosdeinsercionentodaslascoincidencias
// TODO Hacer toda la capa de datos.
// TODO Poner correctamente scope de las propiedades de las clases.
// TODO Hacer todos los metodos de la capa de datos.
// TODO Implementar validacion en la capa de datos.
// TODO Modificar la propiedad Horario para que sea correcta. Solucionar problema de que en la base de datos se almacena el numero de la enumeracion pero no el nombre.
// TODO Verificar como conviene eliminar un registro, ya que el siguiente registro que se agrega no ocupa el mismo primary key(id).
// TODO Implementar SQLite.
// TODO Resolver problema de los metodos no devuelven los valores de carrera y queda como null.
// TODO Realizar capa de dato en DataBaseFirst

namespace Datos
{
    public static class Alumno
    {
        public static Entidades.Contexto db = new Entidades.Contexto();
#nullable enable
        public static Entidades.Alumno ListarUno(string? nombre = null, string? apellido = null, int? id = null, int? edad = null, int? dni = null)
        {
            if (nombre != null)
            {
                return db.Alumnos.Where(a => a.Nombre == nombre).FirstOrDefault();
            }
            else if (apellido != null)
            {
                return db.Alumnos.Where(a => a.Apellido == apellido).FirstOrDefault();

            }
            else if (id != null)
            {
                return db.Alumnos.Where(a => a.IdAlumno == id).SingleOrDefault();

            }
            else if (edad != null)
            {
                return db.Alumnos.Where(a => a.Edad == edad).FirstOrDefault();

            }
            return db.Alumnos.Where(a => a.DNI == dni).FirstOrDefault();
        }

        public static List<Entidades.Alumno> ListarVarios(string? nombre = null, string? apellido = null, int? id = null, int? edad = null, int? dni = null)
        {
            if (nombre != null)
            {
                return db.Alumnos.Where(a => a.Nombre == nombre).ToList();
            }
            else if (apellido != null)
            {
                return db.Alumnos.Where(a => a.Apellido == apellido).ToList();

            }
            else if (id != null)
            {
                return db.Alumnos.Where(a => a.IdAlumno == id).ToList();

            }
            else if (edad != null)
            {
                return db.Alumnos.Where(a => a.Edad == edad).ToList();

            }
            return db.Alumnos.Where(a => a.DNI == dni).ToList();
        }
#nullable disable
        public static List<Entidades.Alumno> ListarTodos()
        {
            return db.Alumnos.ToList();
        }

        public static void Agregar(Entidades.Alumno alumno)
        {
            db.Alumnos.Add(entity: alumno);
            db.SaveChanges();
        }

        public static void Editar(Entidades.Alumno alumno)
        {
            Entidades.Alumno unAlumno = db.Alumnos.Where(a => a.IdAlumno == alumno.IdAlumno).SingleOrDefault();

            if (unAlumno != null)
            {
                unAlumno.Nombre = alumno.Nombre;
                unAlumno.Apellido = alumno.Apellido;
                unAlumno.Edad = alumno.Edad;
                unAlumno.DNI = alumno.DNI;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("\nNo hay resultados con ese ID");
            }
        }

        public static void Eliminar(int id)
        {
            db.Alumnos.Remove( db.Alumnos.Find(id) );
            db.SaveChanges();
        }

    }
}
