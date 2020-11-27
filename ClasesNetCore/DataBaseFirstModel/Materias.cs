using System;
using System.Collections.Generic;

namespace Entidades
{
    public partial class Materias
    {
        public Materias()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }

        public int MateriaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public byte? Creditos { get; set; }
        public short? Horas { get; set; }
        public string Correlativas { get; set; }
        public string Categoria { get; set; }
        public int CarreraId { get; set; }

        public virtual Carreras Carrera { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
