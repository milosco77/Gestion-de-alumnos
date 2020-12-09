using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Asignatura
    {
#nullable enable
        public static Entidades.Asignaturas ListarUna(int? asignaturaID = null, int? listadoAsignaturasID = null, int? alumnoID = null, int? carreraID = null, int? comision = null, TimeSpan? horarioEntrada = null, TimeSpan? horarioSalida = null, string? dias = null)
        {
            if (asignaturaID != null)
            {
                return Datos.Asignatura.ListarUna(asignaturaID: asignaturaID);
            }
            else if (listadoAsignaturasID != null)
            {
                return Datos.Asignatura.ListarUna(listadoAsignaturasID: listadoAsignaturasID);

            }
            else if (alumnoID != null)
            {
                return Datos.Asignatura.ListarUna(alumnoID: alumnoID);

            }
            else if (carreraID != null)
            {
                return Datos.Asignatura.ListarUna(carreraID: carreraID);

            }
            else if (comision != null)
            {
                return Datos.Asignatura.ListarUna(comision: comision);

            }
            else if (horarioEntrada != null)
            {
                return Datos.Asignatura.ListarUna(horarioEntrada: horarioEntrada);

            }
            else if (horarioSalida != null)
            {
                return Datos.Asignatura.ListarUna(horarioSalida: horarioSalida);

            }
            return Datos.Asignatura.ListarUna(dias: dias);
        }

        public static List<Entidades.Asignaturas> ListarVarias(int? asignaturaID = null, int? listadoAsignaturasID = null, int? alumnoID = null, int? carreraID = null, int? comision = null, TimeSpan? horarioEntrada = null, TimeSpan? horarioSalida = null, string? dias = null)
        {
            if (asignaturaID != null)
            {
                return Datos.Asignatura.ListarVarias(asignaturaID: asignaturaID);
            }
            else if (listadoAsignaturasID != null)
            {
                return Datos.Asignatura.ListarVarias(listadoAsignaturasID: listadoAsignaturasID);

            }
            else if (alumnoID != null)
            {
                return Datos.Asignatura.ListarVarias(alumnoID: alumnoID);

            }
            else if (carreraID != null)
            {
                return Datos.Asignatura.ListarVarias(carreraID: carreraID);

            }
            else if (comision != null)
            {
                return Datos.Asignatura.ListarVarias(comision: comision);

            }
            else if (horarioEntrada != null)
            {
                return Datos.Asignatura.ListarVarias(horarioEntrada: horarioEntrada);

            }
            else if (horarioSalida != null)
            {
                return Datos.Asignatura.ListarVarias(horarioSalida: horarioSalida);

            }
            return Datos.Asignatura.ListarVarias(dias: dias);
        }
#nullable disable
        public static List<Entidades.Asignaturas> ListarTodas()
        {
            return Datos.Asignatura.ListarTodas();
        }

        public static string Agregar(Entidades.Asignaturas asignatura)
        {
            return Datos.Asignatura.Agregar(asignatura);
        }

        public static void Editar (Entidades.Asignaturas asignatura)
        {
            Datos.Asignatura.Editar(asignatura);
        }

        public static string Eliminar(int asignaturaID)
        {
            return Datos.Asignatura.Eliminar(asignaturaID);
        }
    }
}
