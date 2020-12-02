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
                return Logica.Asignatura.ListarUna(asignaturaID: asignaturaID);
            }
            else if (listadoAsignaturasID != null)
            {
                return Logica.Asignatura.ListarUna(listadoAsignaturasID: listadoAsignaturasID);

            }
            else if (alumnoID != null)
            {
                return Logica.Asignatura.ListarUna(alumnoID: alumnoID);

            }
            else if (carreraID != null)
            {
                return Logica.Asignatura.ListarUna(carreraID: carreraID);

            }
            else if (comision != null)
            {
                return Logica.Asignatura.ListarUna(comision: comision);

            }
            else if (horarioEntrada != null)
            {
                return Logica.Asignatura.ListarUna(horarioEntrada: horarioEntrada);

            }
            else if (horarioSalida != null)
            {
                return Logica.Asignatura.ListarUna(horarioSalida: horarioSalida);

            }
            return Logica.Asignatura.ListarUna(dias: dias);
        }

        public static List<Entidades.Asignaturas> ListarVarias(int? asignaturaID = null, int? listadoAsignaturasID = null, int? alumnoID = null, int? carreraID = null, int? comision = null, TimeSpan? horarioEntrada = null, TimeSpan? horarioSalida = null, string? dias = null)
        {
            if (asignaturaID != null)
            {
                return Logica.Asignatura.ListarVarias(asignaturaID: asignaturaID);
            }
            else if (listadoAsignaturasID != null)
            {
                return Logica.Asignatura.ListarVarias(listadoAsignaturasID: listadoAsignaturasID);

            }
            else if (alumnoID != null)
            {
                return Logica.Asignatura.ListarVarias(alumnoID: alumnoID);

            }
            else if (carreraID != null)
            {
                return Logica.Asignatura.ListarVarias(carreraID: carreraID);

            }
            else if (comision != null)
            {
                return Logica.Asignatura.ListarVarias(comision: comision);

            }
            else if (horarioEntrada != null)
            {
                return Logica.Asignatura.ListarVarias(horarioEntrada: horarioEntrada);

            }
            else if (horarioSalida != null)
            {
                return Logica.Asignatura.ListarVarias(horarioSalida: horarioSalida);

            }
            return Logica.Asignatura.ListarVarias(dias: dias);
        }
#nullable disable
        public static List<Entidades.Asignaturas> ListarTodas()
        {
            return Datos.Asignatura.ListarTodas();
        }

        public static void Agregar(Entidades.Asignaturas asignatura)
        {
            Datos.Asignatura.Agregar(asignatura);
        }

        public static void Editar (Entidades.Asignaturas asignatura)
        {
            Datos.Asignatura.Editar(asignatura);
        }

        public static void Eliminar(int asignaturaID)
        {
            Datos.Asignatura.Eliminar(asignaturaID);
        }
    }
}
