using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Carrera
    {
        public string Titulo { get; set; }
        public List<Asignatura> Materia { get; set; }
        public Facultades Facultad { get; set; }
    }
}
