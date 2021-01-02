using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace MVCCore.DatabaseFirstModel
{
    public partial class ListadoAsignatura
    {
        public ListadoAsignatura()
        {
            Asignaturas = new HashSet<Asignatura>();
        }
        [DisplayName("ID")]
        public int ListadoAsignaturasId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public byte? Creditos { get; set; }
        public short? Horas { get; set; }
        public string Correlativas { get; set; }
        public string Categoria { get; set; }
        public int ListadoCarrerasId { get; set; }
        [DisplayName("Carrera")]
        public virtual ListadoCarrera ListadoCarreras { get; set; }
        public virtual ICollection<Asignatura> Asignaturas { get; set; }
    }
}
