using Entidades;
using System;

namespace ClasesNetCore
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int DNI { get; set; }
        public Notas notas { get; set; }
    }
}
