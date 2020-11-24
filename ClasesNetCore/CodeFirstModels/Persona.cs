using System;
using System.Collections.Generic;
using System.Text;

// Fue necesario hacer las propiedades de la super clase Persona, virtual, para poder usar DataAnnotations en ellas.
namespace Entidades
{
    public abstract class Persona : IPersona
    {
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual int Edad { get; set; }
        public virtual int DNI { get; set; }
    }
}
