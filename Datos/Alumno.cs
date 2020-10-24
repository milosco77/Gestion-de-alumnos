using Entidades;
using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO Hacer toda la capa de datos.
// TODO Poner correctamente scope de las propiedades de las clases.
// TODO Hacer todos los metodos de la capa de datos.
// TODO Implementar validacion en la capa de datos.
// TODO Modificar la propiedad Horario para que sea correcta. Solucionar problema de que en la base de datos se almacena el numero de la enumeracion pero no el nombre.

namespace Datos
{
    public class Alumno
    {
        public static Entidades.Contexto db = new Entidades.Contexto();


        // Hardcodeado.

        //private static Entidades.Notas notas = new Entidades.Notas(pPrimerParcial: 1, pPrimerRecuperatorio: 2, pSegundoParcial: 3, pSegundoRecuperatorio: 4, pFinal: 5);
        //private static Asignatura asignatura = new Asignatura(pCodigo: 1, pComision: 1, pHorario: 1, pNombreAsignatura: Materias.Algebra, pNota: notas);
        //private static List<Asignatura> materias = new List<Asignatura>(){ asignatura };
        //private static Carrera carrera = new Carrera(pTitulo: "Ingenieria", pMaterias: materias, pFacultad: Facultades.Agronomia);

        //private static List<Entidades.Alumno> alumnos = new List<Entidades.Alumno>() {
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 1, pDNI: 1, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 2, pDNI: 2, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 3, pDNI: 3, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 4, pDNI: 4, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 5, pDNI: 5, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 6, pDNI: 6, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 7, pDNI: 7, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 8, pDNI: 8, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 9, pDNI: 9, pCarrera: carrera),
        //    new Entidades.Alumno( pNombre: "Jose", pApellido: "Perez", pEdad: 10, pDNI: 10, pCarrera: carrera),
        //};
        //private static Entidades.Alumno alumno;

        public Entidades.Alumno ListarUno(int pDNI)
        {
            //alumno = alumnos.Find( a => a.DNI == pDNI);
            //return alumno;
            throw new NotImplementedException();
        }

        public List<Entidades.Alumno> ListarVarios(string pNombre)
        {
            //var al = alumnos.Where(a => a.Nombre == pNombre);
            //return al.ToList();
            throw new NotImplementedException();
        }

        public List<Entidades.Alumno> ListarVarios(int pEdad)
        {
            //var al = alumnos.Where(a => a.Edad == pEdad);
            //return al.ToList();
            throw new NotImplementedException();
        }

        public List<Entidades.Alumno> ListarTodos()
        {
            //return alumnos;
            throw new NotImplementedException();
        }

        public void Agregar(Entidades.Alumno pAlumno)
        {
            db.Add(entity: pAlumno);
            db.SaveChanges();
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
            //var al = alumnos.First(a => a.DNI == pAlumno.DNI);
            //var index = alumnos.IndexOf(al);
            //alumnos[alumnos.IndexOf(alumnos.First(a => a.DNI == pAlumno.DNI))] = pAlumno; esta seria otra forma pero no contempla el caso de -1

            //if (index != -1)
            //    alumnos[index] = al;
        }

        public void Eliminar(int pDNI)
        {
            //alumnos.Remove( alumnos.First(a => a.DNI == pDNI) );
            db.Remove(entity: pDNI);
            db.SaveChanges();
        }

    }
}
