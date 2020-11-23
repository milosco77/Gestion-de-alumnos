using System;
using System.Collections.Generic;

namespace ConsolaNetCore.Models
{
    public partial class Carreras
    {
        public Carreras()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public int IdCarrera { get; set; }
        public int AsignaturaIdAsignatura { get; set; }
        public string Titulo { get; set; }
        public int Facultad { get; set; }

        public virtual Asignaturas AsignaturaIdAsignaturaNavigation { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
