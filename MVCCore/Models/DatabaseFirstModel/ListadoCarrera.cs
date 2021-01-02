using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class ListadoCarrera
    {
        public ListadoCarrera()
        {
            Carreras = new HashSet<Carrera>();
            ListadoAsignaturas = new HashSet<ListadoAsignatura>();
        }
        [DisplayName("ID")]
        public int ListadoCarrerasId { get; set; }
        public int FacultadId { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        [DisplayName("Duracion Estimada en Años")]
        public double? DuracionEstimadaAnios { get; set; }

        public virtual Facultade Facultad { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<ListadoAsignatura> ListadoAsignaturas { get; set; }
    }
}
