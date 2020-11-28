using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Asignatura
    {
        public static void Agregar(Entidades.Asignaturas asignatura)
        {
            Datos.Asignatura.Agregar(asignatura);
        }

        public static List<Entidades.Asignaturas> ListarVarias(int ID)
        {
            return Datos.Asignatura.ListarVarias(ID);
        }

        public static List<Entidades.Asignaturas> ListarTodas()
        {
            return Datos.Asignatura.ListarTodas();
        }
    }
}
