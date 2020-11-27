using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Notas
    {
        public Notas()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }

        public int NotasId { get; set; }
        public double? PrimerParcial { get; set; }
        public double? PrimerRecuperatorio { get; set; }
        public double? SegundoParcial { get; set; }
        public double? SegundoRecuperatorio { get; set; }
        public double? Final { get; set; }

        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
