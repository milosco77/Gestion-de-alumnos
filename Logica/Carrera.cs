using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Carrera
    {
#nullable enable
        public static Entidades.Carreras ListarUna(int? carreraID = null, int? alumnoID = null, int? listadoCarrerasID = null)
        {
            if (carreraID != null)
            {
                return Logica.Carrera.ListarUna(carreraID: carreraID);
            }
            else if (alumnoID != null)
            {
                return Logica.Carrera.ListarUna(alumnoID: alumnoID);
            }
            return Logica.Carrera.ListarUna(listadoCarrerasID: listadoCarrerasID);
        }
        public static List<Entidades.Carreras> ListarVarias(int? carreraID = null, int? alumnoID = null, int? listadoCarrerasID = null)
        {
            if (carreraID != null)
            {
                return Logica.Carrera.ListarVarias(carreraID: carreraID);
            }
            else if (alumnoID != null)
            {
                return Logica.Carrera.ListarVarias(alumnoID: alumnoID);
            }
            return Logica.Carrera.ListarVarias(listadoCarrerasID: listadoCarrerasID);
        }
#nullable disable
        public static List<Entidades.Carreras> ListarTodas()
        {
            return Datos.Carrera.ListarTodas();
        }

        public static void Agregar(Entidades.Carreras carrera)
        {
            Datos.Carrera.Agregar(carrera);
        }

        public static void Editar(Entidades.Carreras carrera)
        {
            Datos.Carrera.Editar(carrera);
        }

        public static string Eliminar(int carreraID)
        {
            return Datos.Carrera.Eliminar(carreraID);
        }
    }
}
