using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Asignaturas = new HashSet<Asignaturas>();
            Carreras = new HashSet<Carreras>();
        }
        [DisplayName("ID")]
        public int AlumnoId { get; set; }
        [Required, StringLength(50)]
        public string Nombre { get; set; }
        [Required, StringLength(50)]
        public string Apellido { get; set; }
        [Required, Range(13, 99)]
        public byte Edad { get; set; }
        [DisplayName("DNI"), Required, Range(11111111, 99999999)]
        public int Dni { get; set; }

        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
