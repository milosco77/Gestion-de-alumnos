using Entidades;
using System;

namespace Entidades
{
    public class Alumno : Persona
    {
        public override void Hola()
        {
            base.Hola();
        }
        public Alumno(string pNombre, string pApellido, int pEdad, int pDNI, Carrera pCarrera)
        {
            Nombre = pNombre;
            Apellido = pApellido;
            Edad = pEdad;
            DNI = pDNI;
            Carrera = pCarrera;
        }
        public Carrera Carrera { get; set; }

    }
}
