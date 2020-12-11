using System;
using System.Collections.Generic;

namespace ConsolaNetCore.DatabaseFirstModel
{
    public partial class ListadoAsignaturas
    {
        public ListadoAsignaturas()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }

        public int ListadoAsignaturasId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public byte? Creditos { get; set; }
        public short? Horas { get; set; }
        public string Correlativas { get; set; }
        public string Categoria { get; set; }
        public int ListadoCarrerasId { get; set; }

        public virtual ListadoCarreras ListadoCarreras { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
