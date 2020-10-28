using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class Alumno
    {
        Datos.Alumno objDatos = new Datos.Alumno();
#nullable enable
        public Entidades.Alumno ListarUno(string? nombre = null, string? apellido = null, int? id = null, int? edad = null, int? dni = null)
        {
            if (nombre != null)
            {
                return objDatos.ListarUno(nombre: nombre);
            }
            else if (apellido != null)
            {
                return objDatos.ListarUno(apellido: apellido);

            }
            else if (id != null)
            {
                return objDatos.ListarUno(id: id);

            }
            else if (edad != null)
            {
                return objDatos.ListarUno(edad: edad);

            }
            return objDatos.ListarUno(dni: dni);
        }

        public List<Entidades.Alumno> ListarVarios(string? nombre = null, string? apellido = null, int? id = null, int? edad = null, int? dni = null)
        {
            if (nombre != null)
            {
                return objDatos.ListarVarios(nombre: nombre);
            }
            else if (apellido != null)
            {
                return objDatos.ListarVarios(apellido: apellido);

            }
            else if (id != null)
            {
                return objDatos.ListarVarios(id: id);

            }
            else if (edad != null)
            {
                return objDatos.ListarVarios(edad: edad);

            }
            return objDatos.ListarVarios(dni: dni);
        }

#nullable disable

        public List<Entidades.Alumno> ListarVarios(int edad)
        {
            return objDatos.ListarVarios(edad: edad);
        }

        public List<Entidades.Alumno> ListarTodos()
        {
            return objDatos.ListarTodos();
        }

        public void Agregar(Entidades.Alumno alumno)
        {
            objDatos.Agregar(alumno: alumno);
        }

        public void Editar(Entidades.Alumno alumno)
        {
            objDatos.Editar(alumno: alumno);
        }

        public void Eliminar(int id)
        {
            objDatos.Eliminar(id: id);
        }


    }
}
