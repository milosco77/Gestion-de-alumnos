using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Asignaturas
    {
        public Asignaturas()
        {
            Notas = new HashSet<Notas>();
        }

        public int AsignaturaId { get; set; }
        public int ListadoAsignaturasId { get; set; }
        public int AlumnoId { get; set; }
        public int CarreraId { get; set; }
        public int Comision { get; set; }
        public TimeSpan HorarioEntrada { get; set; }
        public TimeSpan HorarioSalida { get; set; }
        public string Dias { get; set; }

        public virtual Carreras Carrera { get; set; }
        public virtual ListadoAsignaturas ListadoAsignaturas { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
    }
}
