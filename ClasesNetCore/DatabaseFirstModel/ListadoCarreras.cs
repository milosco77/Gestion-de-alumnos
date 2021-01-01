using System;
using System.Collections.Generic;

#nullable disable

namespace Entidades
{
    public partial class ListadoCarreras
    {
        public ListadoCarreras()
        {
            Carreras = new HashSet<Carreras>();
            ListadoAsignaturas = new HashSet<ListadoAsignaturas>();
        }

        public int ListadoCarrerasId { get; set; }
        public int FacultadId { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public double? DuracionEstimadaAnios { get; set; }

        public virtual Facultades Facultad { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
        public virtual ICollection<ListadoAsignaturas> ListadoAsignaturas { get; set; }
    }
}
