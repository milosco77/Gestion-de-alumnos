using Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Alumno : Persona
    {
        public Alumno()
        {

        }
        public Alumno(string pNombre, string pApellido, int pEdad, int pDNI, Carrera pCarrera)
        {
            Nombre = pNombre;
            Apellido = pApellido;
            Edad = pEdad;
            DNI = pDNI;
            Carrera = pCarrera;
        }
        [Key]
        public int idAlumno { get; set; }
        public Carrera Carrera { get; set; }

    }
}
