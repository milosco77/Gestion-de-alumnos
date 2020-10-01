using Entidades;
using System;

namespace ClasesNetCore
{
    public class Alumno : Persona
    {
        public override void Hola()
        {
            base.Hola();
        }
        public int DNI { get; set; }
        public Notas notas { get; set; }
    }
}
