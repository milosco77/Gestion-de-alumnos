using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class Alumno
    {
        public List<Entidades.Alumno> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Alumno> ListarTodos()
        {
            List<Entidades.Alumno> alumnos = new List<Entidades.Alumno>();
            for (int i = 0; i < 9; i++)
            {
                //alumnos.Add(new Entidades.Alumno("Juan", "Perez", i, i, new Carrera("Titulo", new List<Asignatura>().Add(new Asignatura(i, i, i, Enumeraciones.Materias.Algebra, new Entidades.Notas(1,1,1,1,1) ) ), Enumeraciones.Facultades.Agronomia) ) ); TODO
            }
            return alumnos;
        }

        public void Agregar()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Editar()
        {
            throw new NotImplementedException();
        }

    }
}
