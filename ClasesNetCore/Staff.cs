using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Staff : Persona
    {
        public Staff(Cargos _Cargo)
        {
            Cargo = _Cargo;
        }
        public Cargos Cargo { get; set; }
    }
}
