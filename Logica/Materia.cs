using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Materia
    {
        public static Entidades.Materias ListarUna(int ID)
        {
            return Datos.Materia.ListarUna(ID);
        }

        public static List<Entidades.Materias> ListarTodas()
        {
            return Datos.Materia.ListarTodas();
        }
    }

}
