using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public static class Alumno
    {
#nullable enable
        public static Entidades.Alumnos ListarUno(string? nombre = null, string? apellido = null, int? id = null, int? edad = null, int? dni = null)
        {
            if (nombre != null)
            {
                return Datos.Alumno.ListarUno(nombre: nombre);
            }
            else if (apellido != null)
            {
                return Datos.Alumno.ListarUno(apellido: apellido);

            }
            else if (id != null)
            {
                return Datos.Alumno.ListarUno(id: id);

            }
            else if (edad != null)
            {
                return Datos.Alumno.ListarUno(edad: edad);

            }
            return Datos.Alumno.ListarUno(dni: dni);
        }

        public static List<Entidades.Alumnos> ListarVarios(string? nombre = null, string? apellido = null, int? id = null, int? edad = null, int? dni = null)
        {
            if (nombre != null)
            {
                return Datos.Alumno.ListarVarios(nombre: nombre);
            }
            else if (apellido != null)
            {
                return Datos.Alumno.ListarVarios(apellido: apellido);

            }
            else if (id != null)
            {
                return Datos.Alumno.ListarVarios(id: id);

            }
            else if (edad != null)
            {
                return Datos.Alumno.ListarVarios(edad: edad);

            }
            return Datos.Alumno.ListarVarios(dni: dni);
        }

#nullable disable

        public static List<Entidades.Alumnos> ListarVarios(int edad)
        {
            return Datos.Alumno.ListarVarios(edad: edad);
        }

        public static List<Entidades.Alumnos> ListarTodos()
        {
            return Datos.Alumno.ListarTodos();
        }

        public static void Agregar(Entidades.Alumnos alumno)
        {
            Datos.Alumno.Agregar(alumno: alumno);
        }

        public static void Editar(Entidades.Alumnos alumno)
        {
            Datos.Alumno.Editar(alumno: alumno);
        }

        public static void Eliminar(int id)
        {
            Datos.Alumno.Eliminar(id: id);
        }


    }
}
