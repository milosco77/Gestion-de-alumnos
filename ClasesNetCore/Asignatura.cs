using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Asignatura
    {
        public int Codigo { get; set; }
        public int Horario { get; set; }
        public Materias NombreAsignatura { get; set; }
        public Notas Nota { get; set; }
    }
}
