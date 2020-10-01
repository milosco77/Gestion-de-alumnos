using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaNetCore
{
    public class Consola
    {
        static void Main(string[] args)
        {
            //titulo en de la ventana
            Console.Title = "Programa de Gestion de Notas de Alumnos";

            Bienvenida();

        }

        public static void Bienvenida()
        {
            Console.WriteLine("\nBienvenido al Programa de Gestion de Notas de Alumnos\n\nEste programa le permitira ingresar los datos de los alumnos de su clase. Permitiendole mantener un registro de los mismos, por ejemplo: saber si promocionaron la asignatura o no.");
            Console.WriteLine("\nQue desea hacer? Elija la opcion deseada:");
        }
    }
}
