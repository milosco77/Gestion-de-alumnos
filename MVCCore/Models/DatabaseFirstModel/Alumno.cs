using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Alumno
    {
        public Alumno()
        {
            Carreras = new HashSet<Carrera>();
        }
        [DisplayName("ID")]
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Edad { get; set; }
        [DisplayName("DNI")]
        public int Dni { get; set; }

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
