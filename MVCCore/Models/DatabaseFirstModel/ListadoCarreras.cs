using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Required, DisplayName("ID")]
        public int ListadoCarrerasId { get; set; }
        [DisplayName("Facultad")]
        public int FacultadId { get; set; }
        [Required, StringLength(50, ErrorMessage = "El campo {0} no puede superar los 50 caracteres.")]
        public string Nombre { get; set; }
        [Required, StringLength(50, ErrorMessage = "El campo {0} no puede superar los 50 caracteres.")]
        public string Titulo { get; set; }
        [DisplayName("Duracion estimada"), Range(0.1, 20.0, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public double? DuracionEstimadaAnios { get; set; }

        public virtual Facultades Facultad { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
        public virtual ICollection<ListadoAsignaturas> ListadoAsignaturas { get; set; }
    }
}
