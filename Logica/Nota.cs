using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Nota
    {
#nullable enable
        public static Entidades.Notas ListarUna(int? notasID = null, int? asignaturasID = null, int? primerParcial = null, int? primerRecuperatorio = null, int? segundoParcial = null, int? segundoRecuperatorio = null, int? final = null)
        {
            if (notasID != null)
            {
                return Datos.Nota.ListarUna(notasID: notasID);
            }
            else if (asignaturasID != null)
            {
                return Datos.Nota.ListarUna(asignaturasID: asignaturasID);
            }
            else if (primerParcial != null)
            {
                return Datos.Nota.ListarUna(primerParcial: primerParcial);
            }
            else if (primerRecuperatorio != null)
            {
                return Datos.Nota.ListarUna(primerRecuperatorio: primerRecuperatorio);
            }
            else if (segundoParcial != null)
            {
                return Datos.Nota.ListarUna(segundoParcial: segundoParcial);
            }
            else if (segundoRecuperatorio != null)
            {
                return Datos.Nota.ListarUna(segundoRecuperatorio: segundoRecuperatorio);
            }
            return Datos.Nota.ListarUna(final: final);
        }

        public static List<Entidades.Notas> ListarVarias(int? notasID = null, int? asignaturasID = null, int? primerParcial = null, int? primerRecuperatorio = null, int? segundoParcial = null, int? segundoRecuperatorio = null, int? final = null)
        {
            if (notasID != null)
            {
                return Datos.Nota.ListarVarias(notasID: notasID);
            }
            else if (asignaturasID != null)
            {
                return Datos.Nota.ListarVarias(asignaturasID: asignaturasID);
            }
            else if (primerParcial != null)
            {
                return Datos.Nota.ListarVarias(primerParcial: primerParcial);
            }
            else if (primerRecuperatorio != null)
            {
                return Datos.Nota.ListarVarias(primerRecuperatorio: primerRecuperatorio);
            }
            else if (segundoParcial != null)
            {
                return Datos.Nota.ListarVarias(segundoParcial: segundoParcial);
            }
            else if (segundoRecuperatorio != null)
            {
                return Datos.Nota.ListarVarias(segundoRecuperatorio: segundoRecuperatorio);
            }
            return Datos.Nota.ListarVarias(final: final);
        }
#nullable disable
        public static List<Entidades.Notas> ListarTodas()
        {
            return Datos.Nota.ListarTodas();
        }

        public static string Agregar(Entidades.Notas nota)
        {
            return Datos.Nota.Agregar(nota);
        }

        public static void Editar(Entidades.Notas nota)
        {
            Datos.Nota.Editar(nota);
        }
#nullable enable
        public static string Eliminar(int? notasID = null, int? asignaturasID = null, int? primerParcial = null, int? primerRecuperatorio = null, int? segundoParcial = null, int? segundoRecuperatorio = null, int? final = null)
        {
            if (notasID != null)
            {
                return Datos.Nota.Eliminar(notasID: notasID);
            }
            else if (asignaturasID != null)
            {
                return Datos.Nota.Eliminar(asignaturasID: asignaturasID);
            }
            else if (primerParcial != null)
            {
                return Datos.Nota.Eliminar(primerParcial: primerParcial);
            }
            else if (primerRecuperatorio != null)
            {
                return Datos.Nota.Eliminar(primerRecuperatorio: primerRecuperatorio);
            }
            else if (segundoParcial != null)
            {
                return Datos.Nota.Eliminar(segundoParcial: segundoParcial);
            }
            else if (segundoRecuperatorio != null)
            {
                return Datos.Nota.Eliminar(segundoRecuperatorio: segundoRecuperatorio);
            }
            return Datos.Nota.Eliminar(final: final);
        }
#nullable disable
    }
}
