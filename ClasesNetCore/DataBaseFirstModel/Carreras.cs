using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Carreras
    {
        public Carreras()
        {
            Materias = new HashSet<Materias>();
        }

        public int CarreraId { get; set; }
        public int FacultadId { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public double DuracionEstimadaAnios { get; set; }

        public virtual Facultades Facultad { get; set; }
        public virtual ICollection<Materias> Materias { get; set; }
    }
}
