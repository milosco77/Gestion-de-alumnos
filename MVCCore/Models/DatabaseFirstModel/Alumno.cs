using System;
using System.Collections.Generic;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Alumno
    {
        public Alumno()
        {
            Carreras = new HashSet<Carrera>();
        }

        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Edad { get; set; }
        public int Dni { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
