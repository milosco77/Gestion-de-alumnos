using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Asignatura
    {
        public Asignatura(int _Codigo, int _Comision, int _Horario, Materias _NombreAsignatura, Notas _Nota)
        {
            Codigo = _Codigo;
            Comision = _Comision;
            Horario = _Horario;
            NombreAsignatura = _NombreAsignatura;
            Nota = _Nota;
        }
        public int Codigo { get; set; }
        public int Comision { get; set; }
        public int Horario { get; set; }
        public Materias NombreAsignatura { get; set; }
        public Notas Nota { get; set; }
    }
}
