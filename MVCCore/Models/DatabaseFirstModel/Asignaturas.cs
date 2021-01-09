using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Asignaturas
    {
        public Asignaturas()
        {
            Nota = new HashSet<Notas>();
        }
        [DisplayName("ID")]
        public int AsignaturaId { get; set; }
        [DisplayName("Asignatura")]
        public int ListadoAsignaturasId { get; set; }
        [DisplayName("Alumno")]
        public int AlumnoId { get; set; }
        [DisplayName("Carrera")]
        public int CarreraId { get; set; }
        public int Comision { get; set; }
        [DisplayName("Horario Entrada")]
        public TimeSpan HorarioEntrada { get; set; }
        [DisplayName("Horario Salida")]
        public TimeSpan HorarioSalida { get; set; }
        public string Dias { get; set; }

        public virtual Alumnos Alumno { get; set; }
        public virtual Carreras Carrera { get; set; }
        [DisplayName("Listado Asignaturas")]
        public virtual ListadoAsignaturas ListadoAsignaturas { get; set; }
        public virtual ICollection<Notas> Nota { get; set; }
    }
}
