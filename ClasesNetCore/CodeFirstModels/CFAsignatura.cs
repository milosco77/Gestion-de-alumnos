using Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class CFAsignatura
    {
        public CFAsignatura(){}
        public CFAsignatura(int pCodigo, int pComision, int pHorario, Materias pNombreAsignatura, CFNotas pNota)
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
        public CFNotas Nota { get; set; }
    }
}
