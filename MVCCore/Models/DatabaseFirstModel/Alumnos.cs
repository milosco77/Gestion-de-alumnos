using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Asignaturas = new HashSet<Asignaturas>();
            Carreras = new HashSet<Carreras>();
        }
        [DisplayName("ID")]
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Edad { get; set; }
        [DisplayName("DNI")]
        public int Dni { get; set; }

        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
