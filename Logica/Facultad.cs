using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public static class Facultad
    {
#nullable enable
        public static Entidades.Facultades ListarUna(int? facultadID = null, string? nombre = null, string? direccion = null, int? telefono = null, string? departamentoAlumnos = null, string? facebook = null, string? instagram = null, string? twitter = null, string? paginaWeb = null, string? email = null, string? recorridoVirtual = null)
        {
            if (facultadID != null)
            {
                return Datos.Facultad.ListarUna(facultadID: facultadID);
            }
            else if (direccion != null)
            {
                return Datos.Facultad.ListarUna(direccion: direccion);
            }
            else if (telefono != null)
            {
                return Datos.Facultad.ListarUna(telefono: telefono);
            }
            else if (departamentoAlumnos != null)
            {
                return Datos.Facultad.ListarUna(departamentoAlumnos: departamentoAlumnos);
            }
            else if (nombre != null)
            {
                return Datos.Facultad.ListarUna(nombre: nombre);
            }
            else if (facebook != null)
            {
                return Datos.Facultad.ListarUna(facebook: facebook);
            }
            else if (instagram != null)
            {
                return Datos.Facultad.ListarUna(instagram: instagram);
            }
            else if (twitter != null)
            {
                return Datos.Facultad.ListarUna(twitter: twitter);
            }
            else if (paginaWeb != null)
            {
                return Datos.Facultad.ListarUna(paginaWeb: paginaWeb);
            }
            else if (email != null)
            {
                return Datos.Facultad.ListarUna(email: email);
            }
            return Datos.Facultad.ListarUna(recorridoVirtual: recorridoVirtual);
        }

        public static List<Entidades.Facultades> ListarVarias(int? facultadID = null, string? nombre = null, string? direccion = null, int? telefono = null, string? departamentoAlumnos = null, string? facebook = null, string? instagram = null, string? twitter = null, string? paginaWeb = null, string? email = null, string? recorridoVirtual = null)
        {
            if (facultadID != null)
            {
                return Datos.Facultad.ListarVarias(facultadID: facultadID);
            }
            else if (direccion != null)
            {
                return Datos.Facultad.ListarVarias(direccion: direccion);
            }
            else if (telefono != null)
            {
                return Datos.Facultad.ListarVarias(telefono: telefono);
            }
            else if (departamentoAlumnos != null)
            {
                return Datos.Facultad.ListarVarias(departamentoAlumnos: departamentoAlumnos);
            }
            else if (nombre != null)
            {
                return Datos.Facultad.ListarVarias(nombre: nombre);
            }
            else if (facebook != null)
            {
                return Datos.Facultad.ListarVarias(facebook: facebook);
            }
            else if (instagram != null)
            {
                return Datos.Facultad.ListarVarias(instagram: instagram);
            }
            else if (twitter != null)
            {
                return Datos.Facultad.ListarVarias(twitter: twitter);
            }
            else if (paginaWeb != null)
            {
                return Datos.Facultad.ListarVarias(paginaWeb: paginaWeb);
            }
            else if (email != null)
            {
                return Datos.Facultad.ListarVarias(email: email);
            }
            return Datos.Facultad.ListarVarias(recorridoVirtual: recorridoVirtual);
        }
#nullable disable
        public static List<Entidades.Facultades> ListarTodas()
        {
            return Datos.Facultad.ListarTodas();
        }

        public static void Agregar(Entidades.Facultades facultad)
        {
            Datos.Facultad.Agregar(facultad);
        }

        public static void Editar(Entidades.Facultades facultad)
        {
            Datos.Facultad.Editar(facultad);
        }

        public static void Eliminar(int facultadID)
        {
            Datos.Facultad.Eliminar(facultadID);
        }
    }
}
