using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Asignaturas
    {
        public int MateriaId { get; set; }
        public int AlumnoId { get; set; }
        public int NotasId { get; set; }
        public int Comision { get; set; }
        public TimeSpan HorarioEntrada { get; set; }
        public TimeSpan HorarioSalida { get; set; }
        public string Dias { get; set; }

        public virtual Alumnos Alumno { get; set; }
        public virtual Materias Materia { get; set; }
        public virtual Notas Notas { get; set; }
    }
}
