using System;
using System.Collections.Generic;

namespace ConsolaNetCore.DatabaseFirstModel
{
    public partial class Carreras
    {
        public Carreras()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }

        public int CarreraId { get; set; }
        public int AlumnoId { get; set; }
        public int ListadoCarrerasId { get; set; }

        public virtual Alumnos Alumno { get; set; }
        public virtual ListadoCarreras ListadoCarreras { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
