using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class ListadoAsignatura
    {
#nullable enable
        public static Entidades.ListadoAsignaturas ListarUna(int? listadoAsignaturasID = null, string? codigo = null, string? nombre = null, int? creditos = null, int? horas = null, string? correlativas = null, string? categoria = null, int? listadoCarrerasID = null)
        {
            if (listadoAsignaturasID != null)
            {
                return Datos.ListadoAsignatura.ListarUna(listadoAsignaturasID: listadoAsignaturasID);
            }
            else if (codigo != null)
            {
                return Datos.ListadoAsignatura.ListarUna(codigo: codigo);
            }
            else if (nombre != null)
            {
                return Datos.ListadoAsignatura.ListarUna(nombre: nombre);
            }
            else if (creditos != null)
            {
                return Datos.ListadoAsignatura.ListarUna(creditos: creditos);
            }
            else if (horas != null)
            {
                return Datos.ListadoAsignatura.ListarUna(horas: horas);
            }
            else if (correlativas != null)
            {
                return Datos.ListadoAsignatura.ListarUna(correlativas: correlativas);
            }
            else if (categoria != null)
            {
                return Datos.ListadoAsignatura.ListarUna(categoria: categoria);
            }
            return Datos.ListadoAsignatura.ListarUna(listadoCarrerasID: listadoCarrerasID);
        }

        public static List<Entidades.ListadoAsignaturas> ListarVarias(int? listadoAsignaturasID = null, string? codigo = null, string? nombre = null, int? creditos = null, int? horas = null, string? correlativas = null, string? categoria = null, int? listadoCarrerasID = null)
        {
            if (listadoAsignaturasID != null)
            {
                return Datos.ListadoAsignatura.ListarVarias(listadoAsignaturasID: listadoAsignaturasID);
            }
            else if (codigo != null)
            {
                return Datos.ListadoAsignatura.ListarVarias(codigo: codigo);
            }
            else if (nombre != null)
            {
                return Datos.ListadoAsignatura.ListarVarias(nombre: nombre);
            }
            else if (creditos != null)
            {
                return Datos.ListadoAsignatura.ListarVarias(creditos: creditos);
            }
            else if (horas != null)
            {
                return Datos.ListadoAsignatura.ListarVarias(horas: horas);
            }
            else if (correlativas != null)
            {
                return Datos.ListadoAsignatura.ListarVarias(correlativas: correlativas);
            }
            else if (categoria != null)
            {
                return Datos.ListadoAsignatura.ListarVarias(categoria: categoria);
            }
            return Datos.ListadoAsignatura.ListarVarias(listadoCarrerasID: listadoCarrerasID);
        }
#nullable disable
        public static List<Entidades.ListadoAsignaturas> ListarTodas()
        {
            return Datos.ListadoAsignatura.ListarTodas();
        }

        public static string Agregar(Entidades.ListadoAsignaturas listadoAsignatura)
        {
            return Datos.ListadoAsignatura.Agregar(listadoAsignatura);
        }

        public static void Editar(Entidades.ListadoAsignaturas listadoAsignatura)
        {
            Datos.ListadoAsignatura.Editar(listadoAsignatura);
        }

        public static string Eliminar(int listadoAsignaturaID)
        {
            return Datos.ListadoAsignatura.Eliminar(listadoAsignaturaID);
        }
    }
}
