using Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class CFAlumno : CFPersona
    {
        public CFAlumno(){}
        public CFAlumno(string pNombre, string pApellido, int pEdad, int pDNI, CFCarrera pCarrera)
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
        public CFCarrera Carrera { get; set; }
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
