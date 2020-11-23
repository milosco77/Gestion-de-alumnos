using System;
using System.Collections.Generic;

namespace ConsolaNetCore.Models
{
    public partial class Notas
    {
        public Notas()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }

        public int IdNotas { get; set; }
        public float PrimerParcial { get; set; }
        public float PrimerRecuperatorio { get; set; }
        public float SegundoParcial { get; set; }
        public float SegundoRecuperatorio { get; set; }
        public float Final { get; set; }

        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
