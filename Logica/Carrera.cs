using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Carrera
    {
        public static Entidades.Carreras ListarUna(int ID)
        {
            return Datos.Carrera.ListarUna(ID);
        }
        // TODO Implementar que el alumno pueda tener mas de una carrera.
        public static List<Entidades.Carreras> ListarVarias(int ID)
        {
            return Datos.Carrera.ListarVarias(ID);
        }

        public static List<Entidades.Carreras> ListarTodas()
        {
            return Datos.Carrera.ListarTodas();
        }
    }
}
