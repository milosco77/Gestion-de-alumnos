using System;
using System.Collections.Generic;
using System.ComponentModel;
#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Notas
    {
        [DisplayName("ID")]
        public int NotasId { get; set; }
        public int AsignaturaId { get; set; }
        public double? PrimerParcial { get; set; }
        public double? PrimerRecuperatorio { get; set; }
        public double? SegundoParcial { get; set; }
        public double? SegundoRecuperatorio { get; set; }
        public double? Final { get; set; }

        public virtual Asignaturas Asignatura { get; set; }
    }
}
