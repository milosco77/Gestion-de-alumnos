using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Facultad
    {
        public static Entidades.Facultades ListarUna(int ID)
        {
            return Datos.Facultad.ListarUna(ID);
        }

        public static List<Entidades.Facultades> ListarVarias(int ID)
        {
            return Datos.Facultad.ListarVarias(ID);
        }

        public static List<Entidades.Facultades> ListarTodas()
        {
            return Datos.Facultad.ListarTodas();
        }
    }
}
