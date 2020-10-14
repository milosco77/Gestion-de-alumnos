using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Carrera
    {
        public Carrera(string _Titulo, List<Asignatura> _Materias, Facultades _Facultad)
        {
            Titulo = _Titulo;
            Materias = _Materias;
            Facultad = _Facultad;
        }
        public string Titulo { get; set; }
        public List<Asignatura> Materias { get; set; }
        public Facultades Facultad { get; set; }
    }
}
