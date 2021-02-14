using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Asignaturas
    {
        public Asignaturas()
        {
            Nota = new HashSet<Notas>();
        }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("ID")]
        public int AsignaturaId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Asignatura")]
        public int ListadoAsignaturasId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Alumno")]
        public int AlumnoId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Carrera")]
        public int CarreraId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), Range(1,999999, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public int Comision { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Horario entrada")]
        public TimeSpan HorarioEntrada { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Horario salida")]
        public TimeSpan HorarioSalida { get; set; }
        [Required(ErrorMessage = "Debe seleccionar como minimo un dia.")]
        public string Dias { get; set; }

        public virtual Alumnos Alumno { get; set; }
        public virtual Carreras Carrera { get; set; }
        [DisplayName("Asignatura")]
        public virtual ListadoAsignaturas ListadoAsignaturas { get; set; }
        public virtual ICollection<Notas> Nota { get; set; }
    }
}
