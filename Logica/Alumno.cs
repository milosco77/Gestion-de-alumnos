using System;
using System.Collections.Generic;

namespace Logica
{
    public class Alumno
    {
        Datos.Alumno objAlumno = new Datos.Alumno();
        public Entidades.Alumno ListarUno(int DNI)
        {
            return objAlumno.ListarUno(DNI);
        }

        public List<Entidades.Alumno> ListarTodos()
        {
            return objAlumno.ListarTodos();
        }

        public void Agregar()
        {
            objAlumno.Agregar();
        }

        public void Eliminar()
        {
            objAlumno.Eliminar();
        }

        public void Editar()
        {
            objAlumno.Editar();
        }
    }
}
