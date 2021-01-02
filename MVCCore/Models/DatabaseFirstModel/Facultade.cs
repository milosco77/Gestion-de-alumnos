using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class Facultade
    {
        public Facultade()
        {
            ListadoCarreras = new HashSet<ListadoCarrera>();
        }
        [DisplayName("ID")]
        public int FacultadId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
        [DisplayName("Departamento de Alumnos")]
        public string DepartamentoAlumnos { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        [DisplayName("Pagina Web")]
        public string PaginaWeb { get; set; }
        public string Email { get; set; }
        [DisplayName("Recorrido Virtual")]
        public string RecorridoVirtual { get; set; }

        public virtual ICollection<ListadoCarrera> ListadoCarreras { get; set; }
    }
}
