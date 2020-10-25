using Entidades;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class Alumno
    {
        Datos.Alumno objDatos = new Datos.Alumno();
        public Entidades.Alumno ListarUno(int dni)
        {
            return objDatos.ListarUno(dni: dni);
        }

        public List<Entidades.Alumno> ListarVarios(string nombre)
        {
            return objDatos.ListarVarios(nombre: nombre);
        }

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
