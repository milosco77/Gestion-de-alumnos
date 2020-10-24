using Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace Entidades
{
    [Table("Staff")]
    public class Staff : Persona
    {
        public Staff(){}
        public Staff(Cargos pCargo)
        {
            Cargo = pCargo;
        }
        [Key]
        public int IdStaff { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public override string Nombre { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public override string Apellido { get; set; }
        [Required]
        public override int Edad { get; set; }
        [Required]
        public override int DNI { get; set; }
        [Required]
        public Cargos Cargo { get; set; }
    }
}
