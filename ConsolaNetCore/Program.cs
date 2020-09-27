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
            //Programa de gestion de notas de alumnos

            //Hacer un programa que pida el ingreso de una lista de alumnos con sus respectivas notas de:
            //1er parcial, 2do parcial, recuperatorios y final.
            //Se promociona con nota minima total 13, cada parcial se aprueba con 4, la maxima discrepancia es un parcial 4 y otro parcial 9 para promocionar.
            //Se pueden recuperar los 2 parciales.
            //Promedio menor a 13 se va a final. Se necesitan tener los 2 parciales aprobados para ir a final.
            //Indicar si se promociona o reprueba. Cada uno de los examanes y materia.
            //Generar validacion de datos para todos los input del usuario

            //inicializando variables

            int parcial1, parcial2, final, total, input, inputAlumnos, inputParcial1, inputParcial2, inputRecuperatorio1, inputRecuperatorio2, inputFinal;
            string nombre, apellido, respuesta, alumnosIngresados, parcial1Ingresado, parcial2Ingresado, recuperatorio1Ingresado, recuperatorio2Ingresado, finalIngresado;
            bool parcial1Reprobado = false, parcial2Reprobado = false;
            Random rnd = new Random();
            List<string> alumnos = new List<string>();

            //se hace invisible el curso
            Console.CursorVisible = false;
            //titulo en de la ventana
            Console.Title = "Programa de Gestion de Notas de Alumnos";
            //comienza programa
            do
            {
                Console.WriteLine("\nQue desea hacer? Elija la opcion deseada:");
                Console.WriteLine("\n1 = Modo Automatico - 2 = Modo Manuel - 3 = Salir");
                respuesta = Console.ReadLine();
                Console.Clear();
                //convierte el valor respuesta que es string a un numero equivalente en int32 y devuelve la converion
                //en la variable input, si falla la conversion la variable es 0
                int.TryParse(respuesta, out input);

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        for (int i = 0; i < 20; i++)
                        {
                            alumnos.Add("alumno" + i);
                        }

                        Console.WriteLine("\nIngresar alumnos");

                        for (int i = 0; i < 10; i++)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nSu alumno Nº {i} es: " + alumnos[i]);
                        }

                        Console.ReadKey();
                        Console.Clear();

                        Console.ResetColor();
                        Console.WriteLine("\nIngresando notas...");

                        //ingresando notas del alumno

                        for (int i = 0; i < 10; i++)
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
                            Console.ResetColor();
                            Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumnos[i]} es: {parcial1}");
                            Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumnos[i]} es: {parcial2}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n----------------------");
                            Console.ResetColor();

                            //se verifica si debe recuperar el parcial
                            if (parcial1 < 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nEl alumno {alumnos[i]} debe recuperar el primer parcial");
                                Console.ResetColor();
                                parcial1Reprobado = true;
                            }
                            if (parcial2 < 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nEl alumno {alumnos[i]} debe recuperar el segundo parcial");
                                Console.ResetColor();
                                parcial2Reprobado = true;
                            }


                            //se recupera el parcial
                            if (parcial1Reprobado == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                                Console.ResetColor();
                                parcial1 = rnd.Next(0, 10);
                                Console.WriteLine($"\nEl {alumnos[i]} recupera el primer parcial");
                                if (parcial1 >= 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"\nEl {alumnos[i]} aprobo el recuperatorio del primer parcial");
                                    parcial1Reprobado = false;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nEl {alumnos[i]} reprobo el recuperatorio del primer parcial");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();

                                }
                            }

                            if (parcial2Reprobado == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                                Console.ResetColor();

                                parcial2 = rnd.Next(0, 10);
                                Console.WriteLine($"\nEl {alumnos[i]} recupera el segundo parcial");
                                if (parcial2 >= 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"\nEl {alumnos[i]} aprobo el recuperatorio del segundo parcial");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();

                                    parcial2Reprobado = false;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nEl {alumnos[i]} reprobo el recuperatorio del segundo parcial");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();

                                }
                            }

                            if (parcial1Reprobado == true || parcial2Reprobado == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n---NOTAS DEL ALUMNO---");
                                Console.ResetColor();
                                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumnos[i]} es: {parcial1}");
                                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumnos[i]} es: {parcial2}");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n----------------------");
                                Console.ResetColor();
                            }


                            total = parcial1 + parcial2;

                            //indicando si promociono la materia
                            if (total >= 13)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"\nEl alumno {alumnos[i]} promociono con promedio {total / 2}!");
                                Console.ResetColor();
                            }
                            else if (parcial1Reprobado == false && parcial2Reprobado == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nEl {alumnos[i]} obtuvo {total}, no alcanzo la nota para promocionar (13), va a instancia de final");
                                Console.ResetColor();

                                final = rnd.Next(0, 10);

                                if (final >= 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n---INSTANCIA DE FINAL---");
                                    Console.ResetColor();
                                    Console.WriteLine($"\nLa nota del final del alumno {alumnos[i]} es: {final}");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n-------------------------");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"\nPromociono con promedio {final}!");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n---INSTANCIA DE FINAL---");
                                    Console.ResetColor();
                                    Console.WriteLine($"\nLa nota del final del alumno {alumnos[i]} es: {final}");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n-------------------------");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nSu alumno {alumnos[i]} debe recursar la materia");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nSu alumno {alumnos[i]} no tiene los 2 parciales aprobados con minimo (4) para ingresar a instancia de final\ndebe recursar la materia");
                                Console.ResetColor();
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }

                        Console.ResetColor();

                        Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nIngresar alumnos");
                        
                        //se valida datos y se informa dato incorrecto
                        do
                        {
                            Console.WriteLine("\nCuantos alumnos quiere ingresar? (1-100)");
                            alumnosIngresados = Console.ReadLine();
                            int.TryParse(alumnosIngresados, out inputAlumnos);
                            if (inputAlumnos == 0 || inputAlumnos > 100)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("\nUsted introdujo un valor que no esta entre 1 y 100");
                                Console.ResetColor();
                            }
                        } while (inputAlumnos == 0 || inputAlumnos > 100);

                            for (int i = 1; i <= inputAlumnos; i++)
                        {
                            Console.WriteLine($"\nIngrese el nombre de su alumno Nº {i}:");
                            nombre = Console.ReadLine();
                            Console.WriteLine($"\nIngrese el apellido de su alumno Nº {i}:");
                            apellido = Console.ReadLine();

                            alumnos.Add($"Nº {i} - {nombre} {apellido}");
                            Console.Clear();
                        }

                        foreach (var alumno in alumnos)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nSu alumno es: {alumno}");
                        }

                        Console.ReadKey();
                        Console.Clear();

                        Console.ResetColor();
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

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n---NOTAS DEL ALUMNO {alumno}---");
                            Console.ResetColor();
                            //se valida datos y se informa dato incorrecto
                            do
                            {
                                Console.WriteLine("\nIngrese la nota del primer parcial (1-10):");
                                parcial1Ingresado = Console.ReadLine();
                                int.TryParse(parcial1Ingresado, out inputParcial1);
                                if (inputParcial1 == 0 || inputParcial1 > 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Clear();
                                    Console.WriteLine("\nUsted introdujo un valor que no esta entre 1 y 100");
                                    Console.ResetColor();
                                }
                            } while (inputParcial1 == 0 || inputParcial1 > 10);
                            //se valida datos y se informa dato incorrecto
                            do
                            {
                                Console.WriteLine("\nIngrese la nota del segundo parcial (1-10):");
                                parcial2Ingresado = Console.ReadLine();
                                int.TryParse(parcial2Ingresado, out inputParcial2);
                                if (inputParcial2 == 0 || inputParcial2 > 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Clear();
                                    Console.WriteLine("\nUsted introdujo un valor que no esta entre 1 y 10");
                                    Console.ResetColor();
                                }
                            } while (inputParcial2 == 0 || inputParcial2 > 10);

                            Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {inputParcial1}");
                            Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {inputParcial2}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n----------------------");
                            Console.ResetColor();

                            //se verifica si debe recuperar el parcial
                            if (inputParcial1 < 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nEl alumno {alumno} debe recuperar el primer parcial");
                                Console.ResetColor();
                                parcial1Reprobado = true;
                            }
                            if (inputParcial2 < 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nEl alumno {alumno} debe recuperar el segundo parcial");
                                Console.ResetColor();
                                parcial2Reprobado = true;
                            }


                            //se recupera el parcial
                            if (parcial1Reprobado == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                                Console.ResetColor();
                                Console.WriteLine($"\nEl {alumno} recupera el primer parcial");
                                //se valida datos y se informa dato incorrecto
                                do
                                {
                                    Console.WriteLine("\nIngrese la nota del recuperatorio del primer parcial (1-10):");
                                    recuperatorio1Ingresado = Console.ReadLine();
                                    int.TryParse(recuperatorio1Ingresado, out inputRecuperatorio1);
                                    if (inputRecuperatorio1 == 0 || inputRecuperatorio1 > 10)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Console.WriteLine("\nUsted introdujo un valor que no esta entre 1 y 10");
                                        Console.ResetColor();
                                    }
                                } while (inputRecuperatorio1 == 0 || inputRecuperatorio1 > 10);

                                if (inputRecuperatorio1 >= 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"\nEl {alumno} aprobo el recuperatorio del primer parcial");
                                    parcial1Reprobado = false;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nEl {alumno} reprobo el recuperatorio del primer parcial");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();

                                }
                            }

                            if (parcial2Reprobado == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                                Console.ResetColor();
                                Console.WriteLine($"\nEl {alumno} recupera el segundo parcial");
                                //se valida datos y se informa dato incorrecto
                                do
                                {
                                    Console.WriteLine("\nIngrese la nota del recuperatorio del segundo parcial (1-10):");
                                    recuperatorio2Ingresado = Console.ReadLine();
                                    int.TryParse(recuperatorio2Ingresado, out inputRecuperatorio2);
                                    if (inputRecuperatorio2 == 0 || inputRecuperatorio2 > 10)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Console.WriteLine("\nUsted introdujo un valor que no esta entre 1 y 10");
                                        Console.ResetColor();
                                    }
                                } while (inputRecuperatorio2 == 0 || inputRecuperatorio2 > 10);

                                if (inputRecuperatorio2 >= 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"\nEl {alumno} aprobo el recuperatorio del segundo parcial");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();

                                    parcial2Reprobado = false;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nEl {alumno} reprobo el recuperatorio del segundo parcial");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n--------------------------------");
                                    Console.ResetColor();

                                }
                            }

                            //TODO resolver problema de que las variables inputParcial1 y inputParcial2 quedan fuera de scope

                            if (parcial1Reprobado == true || parcial2Reprobado == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n---NOTAS DEL ALUMNO---");
                                Console.ResetColor();
                                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {parcial1}");
                                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {parcial2}");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n----------------------");
                                Console.ResetColor();
                            }


                            total = parcial1 + parcial2;

                            //indicando si promociono la materia
                            if (total >= 13)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"\nEl alumno {alumno} promociono con promedio {total / 2}!");
                                Console.ResetColor();
                            }
                            else if (parcial1Reprobado == false && parcial2Reprobado == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nEl {alumno} obtuvo {total}, no alcanzo la nota para promocionar (13), va a instancia de final");
                                Console.ResetColor();
                                //se valida datos y se informa dato incorrecto
                                do
                                {
                                    Console.WriteLine("\nIngrese la nota del final (1-10):");
                                    finalIngresado = Console.ReadLine();
                                    int.TryParse(finalIngresado, out inputFinal);
                                    if (inputFinal == 0 || inputFinal > 10)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Console.WriteLine("\nUsted introdujo un valor que no esta entre 1 y 10");
                                        Console.ResetColor();
                                    }
                                } while (inputFinal == 0 || inputFinal > 10);

                                if (inputFinal >= 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n---INSTANCIA DE FINAL---");
                                    Console.ResetColor();
                                    Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {inputFinal}");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n-------------------------");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"\nPromociono con promedio {inputFinal}!");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n---INSTANCIA DE FINAL---");
                                    Console.ResetColor();
                                    Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {inputFinal}");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n-------------------------");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"\nSu alumno {alumno} debe recursar la materia");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\nSu alumno {alumno} no tiene los 2 parciales aprobados con minimo (4) para ingresar a instancia de final\ndebe recursar la materia");
                                Console.ResetColor();
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }

                        Console.ResetColor();

                        Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    case 3:
                        Console.WriteLine("\nPresione cualquier tecla para salir del programa");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUsted puso un caracter que no es 1, 2 o 3");
                Console.ResetColor();
            } while (input == 0 || input > 3);
        }
    }
}
