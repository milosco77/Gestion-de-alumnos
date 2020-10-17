using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Asignatura
    {
        public Asignatura(int pCodigo, int pComision, int pHorario, Materias pNombreAsignatura, Notas pNota)
        {
            Codigo = pCodigo;
            Comision = pComision;
            Horario = pHorario;
            NombreAsignatura = pNombreAsignatura;
            Nota = pNota;
        }
        public int Codigo { get; set; }
        public int Comision { get; set; }
        public int Horario { get; set; }
        public Materias NombreAsignatura { get; set; }
        public Notas Nota { get; set; }
    }
}
