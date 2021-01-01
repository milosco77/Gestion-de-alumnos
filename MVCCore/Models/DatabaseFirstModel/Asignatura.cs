using System;
using System.Collections.Generic;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Nota = new HashSet<Nota>();
        }

        public int AsignaturaId { get; set; }
        public int ListadoAsignaturasId { get; set; }
        public int AlumnoId { get; set; }
        public int CarreraId { get; set; }
        public int Comision { get; set; }
        public TimeSpan HorarioEntrada { get; set; }
        public TimeSpan HorarioSalida { get; set; }
        public string Dias { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ListadoAsignatura ListadoAsignaturas { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
