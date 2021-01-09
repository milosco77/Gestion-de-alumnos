using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class ListadoCarreras
    {
        public ListadoCarreras()
        {
            Carreras = new HashSet<Carreras>();
            ListadoAsignaturas = new HashSet<ListadoAsignaturas>();
        }
        [DisplayName("ID")]
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
