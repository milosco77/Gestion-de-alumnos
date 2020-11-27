using Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class CFCarrera
    {
        public CFCarrera(){}
        public CFCarrera(string pTitulo, List<CFAsignatura> pMaterias, Facultades pFacultad)
        {
            Titulo = pTitulo;
            MateriasId = pMaterias;
            Facultad = pFacultad;
        }
        [Key]
        public int IdCarrera { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public List<CFAsignatura> MateriasId { get; set; }
        [Required]
        public Facultades Facultad { get; set; }
    }
}
