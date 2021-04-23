using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Facultades
    {
        public Facultades()
        {
            ListadoCarreras = new HashSet<ListadoCarreras>();
        }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio."), DisplayName("ID")]
        public int FacultadId { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} no puede estar vacio.")]
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        [DisplayName("Departamento de alumnos"), EmailAddress(ErrorMessage = "La direccion de mail no es correcta.")]
        public string DepartamentoAlumnos { get; set; }
        [Url(ErrorMessage = "La URL no es correcta.")]
        public string Facebook { get; set; }
        [Url(ErrorMessage = "La URL no es correcta.")]
        public string Instagram { get; set; }
        [Url(ErrorMessage = "La URL no es correcta.")]
        public string Twitter { get; set; }
        [Url(ErrorMessage = "La URL no es correcta.")]
        public string PaginaWeb { get; set; }
        [DisplayName("Pagina web"), EmailAddress(ErrorMessage = "La direccion de mail no es correcta.")]
        public string Email { get; set; }
        [DisplayName("Recorrido virtual"), Url(ErrorMessage = "La URL no es correcta.")]
        public string RecorridoVirtual { get; set; }

        public virtual ICollection<ListadoCarreras> ListadoCarreras { get; set; }
    }
}
