using System;
using System.Collections.Generic;

namespace ConsolaNetCore.Models
{
    public partial class Alumnos
    {
        public int IdAlumno { get; set; }
        public int CarreraIdCarrera { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int Dni { get; set; }

        public virtual Carreras CarreraIdCarreraNavigation { get; set; }
    }
}
