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
        public Alumno(string _Nombre, string _Apellido, int _Edad, int _DNI, Carrera _Carrera)
        {
            Nombre = _Nombre;
            Apellido = _Apellido;
            Edad = _Edad;
            DNI = _DNI;
            Carrera = _Carrera;
        }
        public Carrera Carrera { get; set; }

    }
}
