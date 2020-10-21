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
        public int idAlumno { get; set; }
        [Timestamp, Column("MarcaTemporal"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Byte[] TimeStamp { get; set; }
        [Required]
        public Carrera Carrera { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public override string Nombre { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public override string Apellido { get; set; }
        [Required, MaxLength(2)]
        public override int Edad { get; set; }
        [Required]
        [MinLength(8)]
        public override int DNI { get; set; }
    }
}
