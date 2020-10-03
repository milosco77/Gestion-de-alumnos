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
        public Notas Notas { get; set; }
        public int Comision { get; set; }
        public Asignatura Materia { get; set; }

    }
}
