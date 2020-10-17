using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Carrera
    {
        public Carrera(string pTitulo, List<Asignatura> pMaterias, Facultades pFacultad)
        {
            Titulo = pTitulo;
            Materias = pMaterias;
            Facultad = pFacultad;
        }
        public string Titulo { get; set; }
        public List<Asignatura> Materias { get; set; }
        public Facultades Facultad { get; set; }
    }
}
