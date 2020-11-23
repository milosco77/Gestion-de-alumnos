using Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class Asignatura
    {
        public Asignatura(){}
        public Asignatura(int pCodigo, int pComision, int pHorario, Materias pNombreAsignatura, Notas pNota)
        {
            Codigo = pCodigo;
            Comision = pComision;
            Horario = pHorario;
            NombreAsignatura = pNombreAsignatura;
            Nota = pNota;
        }
        [Key]
        public int IdAsignatura { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public int Comision { get; set; }
        [Required]
        public int Horario { get; set; }
        [Required, Column("Nombre")]
        public Materias NombreAsignatura { get; set; }
        public Notas Nota { get; set; }
    }
}
