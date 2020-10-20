using Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Staff : Persona
    {
        public Staff()
        {

        }
        public Staff(Cargos pCargo)
        {
            Cargo = pCargo;
        }
        [Key]
        public int idStaff { get; set; }
        public Cargos Cargo { get; set; }
    }
}
