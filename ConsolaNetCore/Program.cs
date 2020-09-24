using ClasesNetCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsolaNetCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Programa de gestion de notas y asistencia de alumnos

            //Hacer un programa que ingrese una lista de alumnos, coloque sus notas de:
            //1er parcial, 2do parcial y final.
            //Se promociona con promedio 13, se aprueba con 4, la maxima discrepancia es un parcial 4 y otro parcial 9 o 10.
            //Promedio menor a 13 se va a final.
            //TODO agregar mas consignas

            //primero harcodeado

            //inicializando lista de alumnos
            List<string> alumnos = new List<string>();

            for (int i = 0; i < 20; i++)
            {
                alumnos.Add("alumno" + i);
            }

            Console.WriteLine("\nPrograma de gestion de notas y asistencia de alumnos\n\nA continuacion se le pedira agregar los alumnos y sus notas\n\nPresione cualquier tecla para continuar");

            Console.ReadKey();


            Console.WriteLine("TODO ingresar alumnos");

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSu alumno es: " + alumnos[i]);
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPresione cualquier tecla para continuar");

            Console.ReadKey();
            


            //TODO pedir ingreso de alumnos
            //foreach (var alumno in alumnos)
            //{
            //    Console.WriteLine("");
            //}
        }
    }
}
