using System;
using System.Collections.Generic;

namespace ConsolaNetCore.Models
{
    public partial class Asignaturas
    {
        public Asignaturas()
        {
            Carreras = new HashSet<Carreras>();
        }

        public int IdAsignatura { get; set; }
        public int NotaIdNotas { get; set; }
        public int Codigo { get; set; }
        public int Comision { get; set; }
        public int Horario { get; set; }
        public int Nombre { get; set; }

        public virtual Notas NotaIdNotasNavigation { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
