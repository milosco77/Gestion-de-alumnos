using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class ListadoAsignatura
    {
        public static Entidades.ListadoAsignaturas ListarUna(int ID)
        {
            return Datos.ListadoAsignatura.ListarUna(ID);
        }

        public static List<Entidades.ListadoAsignaturas> ListarVarias(int ID)
        {
            return Datos.ListadoAsignatura.ListarVarias(ID);
        }

        public static List<Entidades.ListadoAsignaturas> ListarTodas()
        {
            return Datos.ListadoAsignatura.ListarTodas();
        }
    }
}
