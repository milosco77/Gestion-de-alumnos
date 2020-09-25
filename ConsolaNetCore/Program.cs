using ClasesNetCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ConsolaNetCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Programa de gestion de notas y asistencia de alumnos

            //Hacer un programa que pida el ingreso de una lista de alumnos con sus respectivas notas de:
            //1er parcial, 2do parcial, recuperatorios y final.
            //Indicar si se promociona o reprueba. Cada uno de los examanes y materia.
            //Se promociona con nota minima total 13, cada parcial se aprueba con 4, la maxima discrepancia es un parcial 4 y otro parcial 9 para promocionar.
            //Se pueden recuperar los 2 parciales.
            //Promedio menor a 13 se va a final. Se necesitan tener los 2 parciales aprobados para ir a final.
            //TODO agregar mas consignas

            //--HARDCODEADO--

            //inicializando lista de alumnos

            int parcial1, parcial2, final, total;
            bool parcial1Reprobado = false, parcial2Reprobado = false;
            Random rnd = new Random();

            List<string> alumnos = new List<string>();

            //TODO ingreso de alumnos por el usuario
            Console.WriteLine("\nIngresar alumnos");

            Console.WriteLine("\nCuantos alumnos quiere ingresar? (0-100)");
            int ingresados = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= ingresados; i++)
            {
                alumnos.Add("alumno" + i);
            }

            Console.WriteLine("\nPrograma de gestion de notas y asistencia de alumnos\n\nA continuacion se le pedira agregar los alumnos y sus notas");

            foreach (var alumno in alumnos)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSu alumno es: " + alumno);
            }

            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nIngresando notas...");

            //ingresando notas del alumno

            foreach (var alumno in alumnos)
            {
                parcial1Reprobado = false;
                parcial2Reprobado = false;
                parcial1 = 0;
                parcial2 = 0;
                total = 0;
                final = 0;

                parcial1 = rnd.Next(0, 10);
                parcial2 = rnd.Next(0, 10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n---NOTAS DEL ALUMNO---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {parcial1}");
                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {parcial2}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n----------------------");
                Console.ForegroundColor = ConsoleColor.White;

                //se verifica si debe recuperar el parcial
                if (parcial1 < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl alumno {alumno} debe recuperar el primer parcial");
                    Console.ForegroundColor = ConsoleColor.White;
                    parcial1Reprobado = true;
                }
                if (parcial2 < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl alumno {alumno} debe recuperar el segundo parcial");
                    Console.ForegroundColor = ConsoleColor.White;
                    parcial2Reprobado = true;
                }


                //se recupera el parcial
                if (parcial1Reprobado == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                    Console.ForegroundColor = ConsoleColor.White;
                    parcial1 = rnd.Next(0, 10);
                    Console.WriteLine($"\nEl {alumno} recupera el primer parcial");
                    if (parcial1 >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nEl {alumno} aprobo el recuperatorio del primer parcial");
                        parcial1Reprobado = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nEl {alumno} reprobo el recuperatorio del primer parcial");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }

                if (parcial2Reprobado == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                    Console.ForegroundColor = ConsoleColor.White;

                    parcial2 = rnd.Next(0, 10);
                    Console.WriteLine($"\nEl {alumno} recupera el segundo parcial");
                    if (parcial2 >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nEl {alumno} aprobo el recuperatorio del segundo parcial");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;

                        parcial2Reprobado = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nEl {alumno} reprobo el recuperatorio del segundo parcial");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }

                if (parcial1Reprobado == true || parcial2Reprobado == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n---NOTAS DEL ALUMNO---");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {parcial1}");
                    Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {parcial2}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n----------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }


                total = parcial1 + parcial2;

                //indicando si promociono la materia
                if (total >= 13)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nEl alumno {alumno} promociono con promedio {total / 2}!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (parcial1Reprobado == false && parcial2Reprobado == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl {alumno} obtuvo {total}, no alcanzo la nota para promocionar (13), va a instancia de final");
                    Console.ForegroundColor = ConsoleColor.White;

                    final = rnd.Next(0, 10);

                    if (final >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n---INSTANCIA DE FINAL---");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {final}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n-------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nPromociono con promedio {final}!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n---INSTANCIA DE FINAL---");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {final}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n-------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nSu alumno {alumno} debe recursar la materia");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSu alumno {alumno} no tiene los 2 parciales aprobados con minimo (4) para ingresar a instancia de final\ndebe recursar la materia");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nPresione cualquier tecla para continuar");

            Console.ReadKey();
        }
    }
}
