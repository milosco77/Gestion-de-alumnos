using Entidades;
using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO Hacer toda la capa de datos.
// TODO Primero hardcodeado.
// TODO Segundo con persistencia de datos.
// TODO Tercero con base de datos.
// TODO implementar named arguments = callingMethod(Product = "", etc)

namespace Datos
{
    public class Alumno
    {
        // Hardcodeado.
        private static Entidades.Notas notas = new Entidades.Notas(_PrimerParcial: 1, _PrimerRecuperatorio: 2, _SegundoParcial: 3, _SegundoRecuperatorio: 4, _Final: 5);
        private static Asignatura asignatura = new Asignatura(_Codigo: 1, _Comision: 1, _Horario: 1, _NombreAsignatura: Materias.Algebra, _Nota: notas);
        private static List<Asignatura> materias = new List<Asignatura>(){ asignatura };
        private static Carrera carrera = new Carrera(_Titulo: "Ingenieria", _Materias: materias, _Facultad: Facultades.Agronomia);

        private static List<Entidades.Alumno> alumnos = new List<Entidades.Alumno>() {
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 1, _DNI: 1, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 2, _DNI: 2, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 3, _DNI: 3, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 4, _DNI: 4, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 5, _DNI: 5, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 6, _DNI: 6, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 7, _DNI: 7, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 8, _DNI: 8, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 9, _DNI: 9, _Carrera: carrera),
            new Entidades.Alumno( _Nombre: "Jose", _Apellido: "Perez", _Edad: 10, _DNI: 10, _Carrera: carrera),
        };
        private static Entidades.Alumno alumno;

        public Entidades.Alumno ListarUno(int pDNI)
        {
            alumno = alumnos.Find( a => a.DNI == pDNI);
            return alumno;
        }

        public List<Entidades.Alumno> ListarVarios(string pNombre)
        {
            var al = alumnos.Where(a => a.Nombre == pNombre);
            return al.ToList();
        }

        public List<Entidades.Alumno> ListarVarios(int pEdad)
        {
            var al = alumnos.Where(a => a.Edad == pEdad);
            return al.ToList();
        }

        public List<Entidades.Alumno> ListarTodos()
        {
            return alumnos;
        }

        public void Agregar(Entidades.Alumno pAlumno)
        {
            alumnos.Add(pAlumno);
        }

        public void Editar(Entidades.Alumno pAlumno)
        {
            //var al = alumnos.Find(a => a.DNI == alumno.DNI);
            //al.Nombre = alumno.Nombre;
            //al.Apellido = alumno.Apellido;
            //al.Edad = alumno.Edad;
            //al.DNI = alumno.DNI;
            //al.Carrera = alumno.Carrera;

            // https://stackoverflow.com/questions/26752909/replace-a-object-in-a-list-of-objects
            var al = alumnos.First(a => a.DNI == pAlumno.DNI);
            var index = alumnos.IndexOf(al);
            //alumnos[alumnos.IndexOf(alumnos.First(a => a.DNI == pAlumno.DNI))] = pAlumno; esta seria otra forma pero no contempla el caso de -1

            if (index != -1)
                alumnos[index] = al;
        }

        public void Eliminar(int pDNI)
        {
            alumnos.Remove( alumnos.First(a => a.DNI == pDNI) );
        }

    }
}
