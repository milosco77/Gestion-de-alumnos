using Entidades;
using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

// TODO Hacer toda la capa de datos.
// TODO Primero hardcodeado.
// TODO Segundo con persistencia de datos.
// TODO Tercero con base de datos.

namespace Datos
{
    public class Alumno
    {
        // Hardcodeado.
        private static Entidades.Notas notas = new Entidades.Notas(1, 2, 3, 4, 5);
        private static Asignatura asignatura = new Asignatura(1, 1, 1, Materias.Algebra, notas);
        private static List<Asignatura> materias = new List<Asignatura>(){ asignatura };
        private static Carrera carrera = new Carrera("Ingenieria", materias, Facultades.Agronomia);

        private static List<Entidades.Alumno> alumnos = new List<Entidades.Alumno>() {
            new Entidades.Alumno("Jose", "Perez", 1, 1, carrera),
            new Entidades.Alumno("Jose", "Perez", 2, 2, carrera),
            new Entidades.Alumno("Jose", "Perez", 3, 3, carrera),
            new Entidades.Alumno("Jose", "Perez", 4, 4, carrera),
            new Entidades.Alumno("Jose", "Perez", 5, 5, carrera),
            new Entidades.Alumno("Jose", "Perez", 6, 6, carrera),
            new Entidades.Alumno("Jose", "Perez", 7, 7, carrera),
            new Entidades.Alumno("Jose", "Perez", 8, 8, carrera),
            new Entidades.Alumno("Jose", "Perez", 9, 9, carrera),
            new Entidades.Alumno("Jose", "Perez", 10, 10, carrera),
        };
        private static Entidades.Alumno alumno;

        public Entidades.Alumno ListarUno(int DNI)
        {
            alumno = alumnos.Find( a => a.DNI == DNI);
            return alumno;
        }

        public List<Entidades.Alumno> ListarVarios()
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Alumno> ListarTodos()
        {
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
