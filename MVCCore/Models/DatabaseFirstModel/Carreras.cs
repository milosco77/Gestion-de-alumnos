using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Carreras
    {
        public Carreras()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("ID")]
        public int CarreraId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Alumno")]
        public int AlumnoId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Carrera del listado")]
        public int ListadoCarrerasId { get; set; }

        public virtual Alumnos Alumno { get; set; }
        [DisplayName("Carrera del listado")]
        public virtual ListadoCarreras ListadoCarreras { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
