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
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("ID")]
        public int AlumnoId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), StringLength(50, ErrorMessage = "El campo {0} no puede superar los 50 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), StringLength(50, ErrorMessage = "El campo {0} no puede superar los 50 caracteres.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), Range(13, 99, ErrorMessage = "El campo {0} debe estar comprendido entre 13 a 99.")]
        public byte Edad { get; set; }
        [DisplayName("DNI"), Required(ErrorMessage = "El campo {0} no puede estar vacio."), Range(11111111, 99999999, ErrorMessage = "El DNI debe estar comprendido entre 11.111.111 a 99.999.999.")]
        public int Dni { get; set; }

        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
