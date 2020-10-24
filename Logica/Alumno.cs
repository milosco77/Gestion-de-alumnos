using System;
using System.Collections.Generic;

namespace Logica
{
    public class Alumno
    {
        Datos.Alumno objDatos = new Datos.Alumno();
        public Entidades.Alumno ListarUno(int pDNI)
        {
            return objDatos.ListarUno(pDNI: pDNI);
        }

        public List<Entidades.Alumno> ListarVarios(string pNombre)
        {
            return objDatos.ListarVarios(pNombre: pNombre);
        }

        public List<Entidades.Alumno> ListarVarios(int pEdad)
        {
            return objDatos.ListarVarios(pEdad: pEdad);
        }

        public List<Entidades.Alumno> ListarTodos()
        {
            return objDatos.ListarTodos();
        }

        public void Agregar(Entidades.Alumno pAlumno)
        {
            objDatos.Agregar(pAlumno: pAlumno);
        }

        public void Editar(Entidades.Alumno pAlumno)
        {
            objDatos.Editar(pAlumno: pAlumno);
        }

        public void Eliminar(int pDNI)
        {
            objDatos.Eliminar(pDNI: pDNI);
        }


    }
}
