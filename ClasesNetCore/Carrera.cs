using Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Carrera
    {
        public Carrera(){}
        public Carrera(string pTitulo, List<Asignatura> pMaterias, Facultades pFacultad)
        {
            Titulo = pTitulo;
            Materias = pMaterias;
            Facultad = pFacultad;
        }
        [Key]
        public int idCarrera { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public List<Asignatura> Materias { get; set; }
        [Required]
        public Facultades Facultad { get; set; }
    }
}
