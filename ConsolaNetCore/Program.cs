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
            //Indicar si se promociona o reprueba. Se promociona con promedio 13, se aprueba con 4, la maxima discrepancia es un parcial 4 y otro parcial 9 o 10.
            //Se pueden recuperar los 2 parciales
            //Promedio menor a 13 se va a final.
            //TODO agregar mas consignas

            //hardcodeado

            //inicializando lista de alumnos

            int parcial1, parcial2, final, promedio;
            bool parcial1Reprobado = false, parcial2Reprobado = false;
            Random rnd = new Random();

            List<string> alumnos = new List<string>();

            for (int i = 0; i < 20; i++)
            {
                alumnos.Add("alumno" + i);
            }

            Console.WriteLine("\nPrograma de gestion de notas y asistencia de alumnos\n\nA continuacion se le pedira agregar los alumnos y sus notas\n\nPresione cualquier tecla para continuar");

            //TODO ingreso de alumnos por el usuario
            Console.WriteLine("\nIngresar alumnos");

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSu alumno Nº {i} es: " + alumnos[i]);
            }

            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nIngresando notas");

            //ingresando notas del alumno

            for (int i = 0; i < 10; i++)
            {
                parcial1 = rnd.Next(0, 10);
                parcial2 = rnd.Next(0, 10);

                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumnos[i]} es: {parcial1}");
                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumnos[i]} es: {parcial2}");

                //se verifica si debe recuperar el parcial
                if (parcial1 < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl alumno {alumnos[i]} debe recuperar el primer parcial");
                    Console.ForegroundColor = ConsoleColor.White;
                    parcial1Reprobado = true;
                }
                if (parcial2 < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl alumno {alumnos[i]} debe recuperar el segundo parcial");
                    Console.ForegroundColor = ConsoleColor.White;
                    parcial2Reprobado = true;
                }


                //se recupera el parcial
                if (parcial1Reprobado == true)
                {
                    parcial1 = rnd.Next(0, 10);
                    Console.WriteLine($"\nEl {alumnos[i]} recupera el primer parcial");
                    if (parcial1 >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nEl {alumnos[i]} aprobo el recuperatorio");
                        Console.ForegroundColor = ConsoleColor.White;
                        parcial1Reprobado = false;
                    }
                }

                if (parcial2Reprobado == true)
                {
                    parcial2 = rnd.Next(0, 10);
                    Console.WriteLine($"\nEl {alumnos[i]} recupera el segundo parcial");
                    if (parcial2 >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nEl {alumnos[i]} aprobo el recuperatorio");
                        Console.ForegroundColor = ConsoleColor.White;
                        parcial2Reprobado = false;
                    }
                }


                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumnos[i]} es: {parcial1}");
                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumnos[i]} es: {parcial2}");


                promedio = parcial1 + parcial2;

                //indicando si promociono la materia
                if (promedio >= 13)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nEl alumno {alumnos[i]} promociono con promedio {promedio / 2}!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (parcial1Reprobado == false && parcial2Reprobado == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl {alumnos[i]} no alcanzo la nota para promocionar (13), va a instancia de final");
                    Console.ForegroundColor = ConsoleColor.White;

                    final = rnd.Next(0, 10);

                    if (final >= 4)
                    {
                        Console.WriteLine($"\nLa nota del final del alumno {alumnos[i]} es: {final}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nPromociono con promedio {final}!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine($"\nLa nota del final del alumno {alumnos[i]} es: {final}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nSu alumno {alumnos[i]} debe recursar la materia");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }

            //TODO agregar funcionalidad de recuperacion
            //if (parcial1 < 4)
            //{
            //    Console.WriteLine($"\nSu alumno {alumnos[i]} debe recuperar parcial 1");
            //}

            //Console.WriteLine("\nLa nota de su {0} es: {1}", alumnos[i], promedio);

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
