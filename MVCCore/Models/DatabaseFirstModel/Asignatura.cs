using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            Nota = new HashSet<Nota>();
        }
        [DisplayName("ID")]
        public int AsignaturaId { get; set; }
        [DisplayName("Asignatura")]
        public int ListadoAsignaturasId { get; set; }
        public int AlumnoId { get; set; }
        public int CarreraId { get; set; }
        public int Comision { get; set; }
        [DisplayName("Horario de Entrada")]
        public TimeSpan HorarioEntrada { get; set; }
        [DisplayName("Horario de Salida")]
        public TimeSpan HorarioSalida { get; set; }
        public string Dias { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ListadoAsignatura ListadoAsignaturas { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
