using System;
using System.Collections.Generic;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Carrera
    {
        public Carrera()
        {
            Asignaturas = new HashSet<Asignatura>();
        }

        public int CarreraId { get; set; }
        public int AlumnoId { get; set; }
        public int ListadoCarrerasId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual ListadoCarrera ListadoCarreras { get; set; }
        public virtual ICollection<Asignatura> Asignaturas { get; set; }
    }
}
