using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public interface IPersona
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
        int Edad { get; set; }
        int DNI { get; set; }
    }
}
