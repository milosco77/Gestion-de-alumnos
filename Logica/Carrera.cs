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
            try
            {
                if (carreraID != null)
                {
                    return Datos.Carrera.ListarUna(carreraID: carreraID);
                }
                else if (alumnoID != null)
                {
                    return Datos.Carrera.ListarUna(alumnoID: alumnoID);
                }
                return Datos.Carrera.ListarUna(listadoCarrerasID: listadoCarrerasID);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }
        public static List<Entidades.Carreras> ListarVarias(int? carreraID = null, int? alumnoID = null, int? listadoCarrerasID = null)
        {
            if (carreraID != null)
            {
                return Datos.Carrera.ListarVarias(carreraID: carreraID);
            }
            else if (alumnoID != null)
            {
                return Datos.Carrera.ListarVarias(alumnoID: alumnoID);
            }
            return Datos.Carrera.ListarVarias(listadoCarrerasID: listadoCarrerasID);
        }
#nullable disable
        public static List<Entidades.Carreras> ListarTodas()
        {
            return Datos.Carrera.ListarTodas();
        }

        public static string Agregar(Entidades.Carreras carrera)
        {
            return Datos.Carrera.Agregar(carrera);
        }

        public static string Editar(Entidades.Carreras carrera)
        {
            return Datos.Carrera.Editar(carrera);
        }
#nullable enable
        public static string Eliminar(int? carreraID = null, int? alumnoID = null, int? listadoCarrerasID = null)
        {
            if (carreraID != null)
            {
                return Datos.Carrera.Eliminar(carreraID: carreraID);
            }
            else if (alumnoID != null)
            {
                return Datos.Carrera.Eliminar(alumnoID: alumnoID);
            }
            return Datos.Carrera.Eliminar(listadoCarrerasID: listadoCarrerasID);
        }
#nullable disable
    }
}
