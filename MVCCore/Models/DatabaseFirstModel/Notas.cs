using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Notas
    {
        [DisplayName("ID")]
        public int NotasId { get; set; }
        public int AsignaturaId { get; set; }
        [DisplayName("Primer Parcial"), Range(1, 10, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public double? PrimerParcial { get; set; }
        [DisplayName("Primer Recuperatorio")]
        public double? PrimerRecuperatorio { get; set; }
        [DisplayName("Segundo Parcial")]
        public double? SegundoParcial { get; set; }
        [DisplayName("Segundo Recuperatorio")]
        public double? SegundoRecuperatorio { get; set; }
        public double? Final { get; set; }

        public virtual Asignaturas Asignatura { get; set; }
    }
}
