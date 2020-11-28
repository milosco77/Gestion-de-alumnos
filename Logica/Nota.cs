using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Nota
    {
        public static void Agregar(Entidades.Notas nota)
        {
            Datos.Nota.Agregar(nota);
        }

        public static Entidades.Notas ListarUna(int ID)
        {
            return Datos.Nota.ListarUna(ID);
        }
    }
}
