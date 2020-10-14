using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public abstract class Persona : IPersona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int DNI { get; set; }

        public virtual void Hola()
        {
            throw new NotImplementedException();
        }
    }
}
