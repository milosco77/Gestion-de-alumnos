using System;
using System.Collections.Generic;

namespace Logica
{
    public class Alumno
    {
        Datos.Alumno objAlumno = new Datos.Alumno();
        public Entidades.Alumno ListarUno(int pDNI)
        {
            return objAlumno.ListarUno(pDNI);
        }

        public List<Entidades.Alumno> ListarVarios(string pNombre)
        {
            return objAlumno.ListarVarios(pNombre);
        }

        public List<Entidades.Alumno> ListarVarios(int pEdad)
        {
            return objAlumno.ListarVarios(pEdad);
        }

        public List<Entidades.Alumno> ListarTodos()
        {
            return objAlumno.ListarTodos();
        }

        public void Agregar(Entidades.Alumno pAlumno)
        {
            objAlumno.Agregar(pAlumno);
        }

        public void Editar(Entidades.Alumno pAlumno)
        {
            objAlumno.Editar(pAlumno);
        }

        public void Eliminar(int pDNI)
        {
            objAlumno.Eliminar(pDNI);
        }


    }
}
