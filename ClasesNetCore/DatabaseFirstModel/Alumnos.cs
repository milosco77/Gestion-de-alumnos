using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Carreras = new HashSet<Carreras>();
        }

        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Edad { get; set; }
        public int Dni { get; set; }

        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
