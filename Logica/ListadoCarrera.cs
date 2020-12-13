using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class ListadoCarrera
    {
#nullable enable
        public static Entidades.ListadoCarreras ListarUna(int? listadoCarrerasID = null, int? facultadID = null, string? nombre = null, string? titulo = null, int? duracionEstimadaAnios = null)
        {
            if (listadoCarrerasID != null)
            {
                return Datos.ListadoCarrera.ListarUna(listadoCarrerasID: listadoCarrerasID);
            }
            else if (facultadID != null)
            {
                return Datos.ListadoCarrera.ListarUna(facultadID: facultadID);
            }
            else if (nombre != null)
            {
                return Datos.ListadoCarrera.ListarUna(nombre: nombre);
            }
            else if (titulo != null)
            {
                return Datos.ListadoCarrera.ListarUna(titulo: titulo);
            }
            return Datos.ListadoCarrera.ListarUna(duracionEstimadaAnios: duracionEstimadaAnios);
        }

        public static List<Entidades.ListadoCarreras> ListarVarias(int? listadoCarrerasID = null, int? facultadID = null, string? nombre = null, string? titulo = null, int? duracionEstimadaAnios = null)
        {
            if (listadoCarrerasID != null)
            {
                return Datos.ListadoCarrera.ListarVarias(listadoCarrerasID: listadoCarrerasID);
            }
            else if (facultadID != null)
            {
                return Datos.ListadoCarrera.ListarVarias(facultadID: facultadID);
            }
            else if (nombre != null)
            {
                return Datos.ListadoCarrera.ListarVarias(nombre: nombre);
            }
            else if (titulo != null)
            {
                return Datos.ListadoCarrera.ListarVarias(titulo: titulo);
            }
            return Datos.ListadoCarrera.ListarVarias(duracionEstimadaAnios: duracionEstimadaAnios);
        }
#nullable disable
        public static List<Entidades.ListadoCarreras> ListarTodas()
        {
            return Datos.ListadoCarrera.ListarTodas();
        }

        public static string Agregar(Entidades.ListadoCarreras listadoCarrera)
        {
            return Datos.ListadoCarrera.Agregar(listadoCarrera);
        }

        public static void Editar(Entidades.ListadoCarreras listadoCarrera)
        {
            Datos.ListadoCarrera.Editar(listadoCarrera);
        }
#nullable enable
        public static string Eliminar(int? listadoCarrerasID = null, int? facultadID = null, string? nombre = null, string? titulo = null, int? duracionEstimadaAnios = null)
        {
            if (listadoCarrerasID != null)
            {
                return Datos.ListadoCarrera.Eliminar(listadoCarrerasID: listadoCarrerasID);
            }
            else if (facultadID != null)
            {
                return Datos.ListadoCarrera.Eliminar(facultadID: facultadID);
            }
            else if (nombre != null)
            {
                return Datos.ListadoCarrera.Eliminar(nombre: nombre);
            }
            else if (titulo != null)
            {
                return Datos.ListadoCarrera.Eliminar(titulo: titulo);
            }
            return Datos.ListadoCarrera.Eliminar(duracionEstimadaAnios: duracionEstimadaAnios);
        }
#nullable disable
    }

}
