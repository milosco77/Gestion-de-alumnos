using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Carrera
    {
        public static List<Entidades.Carreras> ListarTodas()
        {
            return Datos.Carrera.ListarTodas();
        }

        public static Entidades.Carreras ListarUna(int ID)
        {
            return Datos.Carrera.ListarUna(ID);
        }
    }

}
