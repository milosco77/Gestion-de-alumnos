using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Notas
    {
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("ID")]
        public int NotasId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Asignatura")]
        public int AsignaturaId { get; set; }
        [DisplayName("Primer Parcial"), Range(0, 10, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public double? PrimerParcial { get; set; }
        [DisplayName("Primer Recuperatorio"), Range(0, 10, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public double? PrimerRecuperatorio { get; set; }
        [DisplayName("Segundo Parcial"), Range(0, 10, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public double? SegundoParcial { get; set; }
        [DisplayName("Segundo Recuperatorio"), Range(0, 10, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public double? SegundoRecuperatorio { get; set; }
        [Range(0, 10, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public double? Final { get; set; }

        public virtual Asignaturas Asignatura { get; set; }
    }
}
