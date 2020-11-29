using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class ListadoCarrera
    {
        public static Entidades.ListadoCarreras ListarUna(int ID)
        {
            return Datos.ListadoCarrera.ListarUna(ID);
        }
        // TODO Implementar que el alumno pueda tener mas de una carrera.
        public static List<Entidades.ListadoCarreras> ListarVarias(int ID)
        {
            return Datos.ListadoCarrera.ListarVarias(ID);
        }

        public static List<Entidades.ListadoCarreras> ListarTodas()
        {
            return Datos.ListadoCarrera.ListarTodas();
        }
    }

}
