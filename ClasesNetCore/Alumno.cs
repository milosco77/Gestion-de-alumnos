using Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Alumno : Persona
    {
        public Alumno(){}
        public Alumno(string pNombre, string pApellido, int pEdad, int pDNI, Carrera pCarrera)
        {
            Nombre = pNombre;
            Apellido = pApellido;
            Edad = pEdad;
            DNI = pDNI;
            Carrera = pCarrera;
        }
        [Key]
        public int IdAlumno { get; set; }
        [Required]
        public Carrera Carrera { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public override string Nombre { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public override string Apellido { get; set; }
        [Required]
        public override int Edad { get; set; }
        [Required]
        public override int DNI { get; set; }
    }
}
