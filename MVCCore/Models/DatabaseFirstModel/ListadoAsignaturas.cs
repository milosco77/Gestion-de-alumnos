using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class ListadoAsignaturas
    {
        public ListadoAsignaturas()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("ID")]
        public int ListadoAsignaturasId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("Listado de Carreras")]
        public int ListadoCarrerasId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio.")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), StringLength(100, ErrorMessage = "El campo {0} no puede superar los {2} caracteres.")]
        public string Nombre { get; set; }
        [Range(1, 255, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public byte? Creditos { get; set; }
        [Range(1, 32767, ErrorMessage = "El campo {0} debe estar comprendido entre {1} a {2}.")]
        public short? Horas { get; set; }
        [StringLength(50, ErrorMessage = "El campo {0} no puede superar los {2} caracteres.")]
        public string Correlativas { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), StringLength(100, ErrorMessage = "El campo {0} no puede superar los {2} caracteres.")]
        public string Categoria { get; set; }

        [DisplayName("Carreras")]
        public virtual ListadoCarreras ListadoCarreras { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
