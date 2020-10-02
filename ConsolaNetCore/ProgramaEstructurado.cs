using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsolaNetCore
{
    public class ProgramaEstructurado
    {
        //enum Opciones
        //{
        //    ModoAutomatico = 1,
        //    ModoManual = 2,
        //    Salir = 3
        //}

        static void Estructurado(string[] args)
        {
            //Programa de gestion de notas de alumnos

            //Hacer un programa que pida el ingreso de una lista de alumnos con sus respectivas notas de:
            //1er parcial, 2do parcial, recuperatorios y final.
            //Se promociona con nota minima total 13, cada parcial se aprueba con 4, la maxima discrepancia es un parcial 4 y otro parcial 9 para promocionar.
            //Se pueden recuperar los 2 parciales.
            //Promedio menor a 13 se va a final. Se necesitan tener los 2 parciales aprobados para ir a final.
            //Indicar si se promociona o reprueba. Cada uno de los examanes y materia.

            //TODO implementar explicacion correcta de intellisense para los metodos *POO*
            //TODO implementar enumeracion de opciones *POO*
            //TODO implementar asistencia de alumnos *POO*
            //TODO ingreso de profesores/Ayudante de catedra *POO*
            //TODO implementar manejo de excepciones
            //TODO talvez implementar nota de AUSENTE y DNI*
            //TODO empezar Programacion Orientada a Objetos
            //TODO cambiar variables a sus variables reducidas en espacio solo cuando empieze a usar DB*

            //inicializando variables

            int parcial1, parcial2, final, notaTotal, inputAlumnos, inputOpcion, inputParcial1, inputParcial2, inputRecuperatorio1 = 0, inputRecuperatorio2 = 0, inputFinal;

            string nombre, apellido, respuestaIngreso;
            bool parcial1Reprobado, parcial2Reprobado;

            Random rnd = new Random();
            List<string> alumnos = new List<string>();

            //titulo en de la ventana
            Console.Title = "Programa de Gestion de Notas de Alumnos";

            //comienza programa
            do
            {
                Console.WriteLine("\nQue desea hacer? Elija la opcion deseada:");
                Console.WriteLine("\n1 = Modo Automatico - 2 = Modo Manual - 3 = Salir");
                respuestaIngreso = Console.ReadLine();
                Console.Clear();

                //convierte el valor respuesta que es string a un numero equivalente en int32 y devuelve la conversion
                //en la variable input, si falla la conversion la variable es 0
                int.TryParse(respuestaIngreso, out inputOpcion);

                switch (inputOpcion)
                {
                    //Opcion MODO AUTOMATICO
                    case 1:
                        Console.Clear();
                        for (int i = 0; i < 20; i++)
                        {
                            alumnos.Add("alumno" + i);
                        }

                        Console.WriteLine("\nIngresar alumnos");

                        for (int i = 0; i < 10; i++)
                        {
                            MensajeColor($"\nSu alumno Nº {i} es: {alumnos[i]}", ConsoleColor.Green);
                        }

                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("\nIngresando notas...");

                        //ingresando notas del alumno

                        for (int i = 0; i < 10; i++)
                        {
                            parcial1Reprobado = false;
                            parcial2Reprobado = false;
                            parcial1 = rnd.Next(0, 10);
                            parcial2 = rnd.Next(0, 10);
                            MensajeColor("\n---NOTAS DEL ALUMNO---", ConsoleColor.Green);
                            Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumnos[i]} es: {parcial1}");
                            Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumnos[i]} es: {parcial2}");
                            MensajeColor("\n----------------------", ConsoleColor.Green);

                            //se verifica si debe recuperar el parcial
                            if (parcial1 < 4)
                            {
                                MensajeColor($"El alumno {alumnos[i]} debe recuperar el primer parcial", ConsoleColor.Red);
                                parcial1Reprobado = true;
                            }
                            if (parcial2 < 4)
                            {
                                MensajeColor($"El alumno {alumnos[i]} debe recuperar el segundo parcial", ConsoleColor.Red);
                                parcial2Reprobado = true;
                            }

                            //se recuperan parciales
                            if (parcial1Reprobado == true)
                            {
                                MensajeColor("\n---INSTANCIA DEL PRIMER RECUPERATORIO---", ConsoleColor.Green);
                                parcial1 = rnd.Next(0, 10);
                                Console.WriteLine($"\nEl {alumnos[i]} recupera el primer parcial");
                                if (parcial1 >= 4)
                                {
                                    parcial1Reprobado = false;
                                    MensajeColor($"\nEl {alumnos[i]} aprobo el recuperatorio del primer parcial", ConsoleColor.Yellow, "\n--------------------------------", ConsoleColor.Green);
                                }
                                else
                                {
                                    MensajeColor($"\nEl {alumnos[i]} reprobo el recuperatorio del primer parcial", ConsoleColor.Red, "\n--------------------------------", ConsoleColor.Green);
                                    Console.ResetColor();

                                }
                            }

                            if (parcial2Reprobado == true)
                            {
                                MensajeColor("\n---INSTANCIA DEL SEGUNDO RECUPERATORIO---", ConsoleColor.Green);
                                parcial2 = rnd.Next(0, 10);
                                Console.WriteLine($"\nEl {alumnos[i]} recupera el segundo parcial");
                                if (parcial2 >= 4)
                                {
                                    MensajeColor($"\nEl {alumnos[i]} aprobo el recuperatorio del segundo parcial", ConsoleColor.Yellow, "\n--------------------------------", ConsoleColor.Green);
                                    parcial2Reprobado = false;
                                }
                                else
                                {
                                    MensajeColor($"\nEl {alumnos[i]} reprobo el recuperatorio del segundo parcial", ConsoleColor.Red, "\n--------------------------------", ConsoleColor.Green);
                                }
                            }

                            if (parcial1Reprobado == true || parcial2Reprobado == true)
                            {
                                MensajeColor("\n---NOTAS DEL ALUMNO---", ConsoleColor.Green);
                                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumnos[i]} es: {parcial1}");
                                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumnos[i]} es: {parcial2}");
                                MensajeColor("\n----------------------", ConsoleColor.Green);
                            }

                            notaTotal = parcial1 + parcial2;

                            //indicando si promociono la materia
                            if (notaTotal >= 13)
                            {
                                MensajeColor($"\nEl alumno {alumnos[i]} promociono con promedio {notaTotal / 2}!", ConsoleColor.Yellow);
                            }
                            else if (parcial1Reprobado == false && parcial2Reprobado == false)
                            {
                                MensajeColor($"\nEl {alumnos[i]} obtuvo {notaTotal}, no alcanzo la nota para promocionar (13), va a instancia de final", ConsoleColor.Red);
                                final = rnd.Next(0, 10);

                                if (final >= 4)
                                {
                                    MensajeColor("\n---INSTANCIA DE FINAL---", ConsoleColor.Green);
                                    Console.WriteLine($"\nLa nota del final del alumno {alumnos[i]} es: {final}");
                                    MensajeColor("\n-------------------------", ConsoleColor.Green, $"\nPromociono con promedio {final}!", ConsoleColor.Yellow);
                                }
                                else
                                {
                                    MensajeColor("\n---INSTANCIA DE FINAL---", ConsoleColor.Green);
                                    Console.WriteLine($"\nLa nota del final del alumno {alumnos[i]} es: {final}");
                                    MensajeColor("\n-------------------------", ConsoleColor.Green, $"\nSu alumno {alumnos[i]} debe recursar la materia", ConsoleColor.Red);
                                }
                            }
                            else
                            {
                                MensajeColor($"\nSu alumno {alumnos[i]} no tiene los 2 parciales aprobados con minimo (4) para ingresar a instancia de final\ndebe recursar la materia", ConsoleColor.Red);
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }

                        Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    //Opcion MODO MANUAL
                    case 2:
                        Console.Clear();
                        MensajeColor("\n---INGRESO DE ALUMNOS---", ConsoleColor.Green);

                        //se valida datos y se informa dato incorrecto
                        inputAlumnos = ValidacionNumerica("\nCuantos alumnos quiere ingresar? (1-100)", "\nUsted introdujo un valor que no esta entre 1 y 100", "\n---INGRESO DE ALUMNOS---", ConsoleColor.Red, 100);

                        for (int i = 1; i <= inputAlumnos; i++)
                        {
                            nombre = ValidacionTexto($"\nIngrese el nombre de su alumno Nº {i}:", "\nEl campo nombre debe contener solo letras y no puede estar vacio, ingrese un nombre por favor", "\n---INGRESO DE ALUMNOS---", ConsoleColor.Red);

                            apellido = ValidacionTexto($"\nIngrese el apellido de su alumno Nº {i}:", "\nEl campo nombre debe contener solo letras y no puede estar vacio, ingrese un apellido por favor", "\n---INGRESO DE ALUMNOS---", ConsoleColor.Red);

                            alumnos.Add($"Nº {i} - Nombre: {nombre} Apellido: {apellido}");
                            Console.Clear();
                        }

                        foreach (var alumno in alumnos)
                        {
                            MensajeColor("\n---INGRESO DE ALUMNOS---", ConsoleColor.Green);
                            MensajeColor($"\nSu alumno es: {alumno}", ConsoleColor.Green);
                        }

                        Console.ReadKey();
                        Console.Clear();

                        foreach (var alumno in alumnos)
                        {
                            parcial1Reprobado = false;
                            parcial2Reprobado = false;
                            notaTotal = 0;

                            MensajeColor($"\n---NOTAS DEL ALUMNO {alumno}---", ConsoleColor.Green);
                            //se valida datos del primer parcial
                            inputParcial1 = ValidacionNumerica("\nIngrese la nota del primer parcial (1-10):", "\nUsted introdujo un valor que no esta entre 1 y 10", $"\n---NOTAS DEL ALUMNO {alumno}---", ConsoleColor.Red, 10);

                            //se valida datos del segundo parcial
                            inputParcial2 = ValidacionNumerica("\nIngrese la nota del segundo parcial (1-10):", "\nUsted introdujo un valor que no esta entre 1 y 10", $"\n---NOTAS DEL ALUMNO {alumno}---", ConsoleColor.Red, 10);

                            Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {inputParcial1}");
                            Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {inputParcial2}");

                            //se verifica si debe recuperar el parcial
                            if (inputParcial1 < 4)
                            {
                                MensajeColor($"\nEl alumno {alumno} debe recuperar el primer parcial", ConsoleColor.Red);
                                parcial1Reprobado = true;
                            }
                            if (inputParcial2 < 4)
                            {
                                MensajeColor($"\nEl alumno {alumno} debe recuperar el segundo parcial", ConsoleColor.Red);
                                parcial2Reprobado = true;
                            }

                            Console.ReadKey();
                            Console.Clear();

                            //se recupera el parcial
                            if (parcial1Reprobado == true)
                            {
                                MensajeColor("\n---INSTANCIA DEL PRIMER RECUPERATORIO---", ConsoleColor.Green);
                                Console.WriteLine($"\nEl {alumno} recupera el primer parcial");

                                //se valida datos del primer recuperatorio
                                inputRecuperatorio1 = ValidacionNumerica("\nIngrese la nota del recuperatorio del primer parcial (1-10):", "\nUsted introdujo un valor que no esta entre 1 y 10", "\n---INSTANCIA DEL PRIMER RECUPERATORIO---", ConsoleColor.Red, 10);

                                if (inputRecuperatorio1 >= 4)
                                {
                                    parcial1Reprobado = false;
                                    MensajeColor($"\nEl {alumno} aprobo el recuperatorio del primer parcial", ConsoleColor.Yellow);
                                }
                                else
                                {
                                    MensajeColor($"\nEl {alumno} reprobo el recuperatorio del primer parcial", ConsoleColor.Red);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                inputParcial1 = inputRecuperatorio1;
                            }

                            if (parcial2Reprobado == true)
                            {
                                MensajeColor("\n---INSTANCIA DEL SEGUNDO RECUPERATORIO---", ConsoleColor.Green);
                                Console.WriteLine($"\nEl {alumno} recupera el segundo parcial");

                                //se valida datos del segundo recuperatorio
                                inputRecuperatorio2 = ValidacionNumerica("\nIngrese la nota del recuperatorio del segundo parcial (1-10):", "\nUsted introdujo un valor que no esta entre 1 y 10", "\n---INSTANCIA DEL SEGUNDO RECUPERATORIO---", ConsoleColor.Red, 10);

                                if (inputRecuperatorio2 >= 4)
                                {
                                    MensajeColor($"\nEl {alumno} aprobo el recuperatorio del segundo parcial", ConsoleColor.Yellow);
                                    parcial2Reprobado = false;
                                }
                                else
                                {
                                    MensajeColor($"\nEl {alumno} reprobo el recuperatorio del segundo parcial", ConsoleColor.Red);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                inputParcial2 = inputRecuperatorio2;
                            }

                            if (parcial1Reprobado == true || parcial2Reprobado == true)
                            {
                                MensajeColor("\n---NOTAS DEL ALUMNO---", ConsoleColor.Green);
                                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {inputRecuperatorio1}");
                                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {inputRecuperatorio2}");
                            }

                            //se genera nota total con la nota del parcial, la cual puede estar reemplazada por la del recuperatorio
                            notaTotal = inputParcial1 + inputParcial2;

                            //indicando si promociono la materia
                            if (notaTotal >= 13)
                            {
                                Console.Clear();
                                MensajeColor("\n---PROMOCION DE LA MATERIA---", ConsoleColor.Green);
                                MensajeColor($"\nEl alumno {alumno} promociono con promedio {notaTotal / 2}!", ConsoleColor.Yellow);
                            }
                            else if (parcial1Reprobado == false && parcial2Reprobado == false)
                            {
                                MensajeColor($"\nEl {alumno} obtuvo {notaTotal}, no alcanzo la nota para promocionar (13), va a instancia de final", ConsoleColor.Red);
                                //se valida datos y se informa dato incorrecto
                                inputFinal = ValidacionNumerica("\nIngrese la nota del final (1-10):", "\nUsted introdujo un valor que no esta entre 1 y 10", ConsoleColor.Red, 10);

                                if (inputFinal >= 4)
                                {
                                    MensajeColor("\n---INSTANCIA DE FINAL---", ConsoleColor.Green);
                                    Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {inputFinal}");
                                    MensajeColor($"\nPromociono con promedio {inputFinal}!", ConsoleColor.Yellow);
                                }
                                else
                                {
                                    MensajeColor("\n---INSTANCIA DE FINAL---", ConsoleColor.Green);
                                    Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {inputFinal}");
                                    MensajeColor($"\nSu alumno {alumno} debe recursar la materia", ConsoleColor.Red);
                                }
                            }
                            else
                            {
                                MensajeColor($"\nSu alumno {alumno}\n\nTiene nota total ({notaTotal}) y no tiene los 2 parciales aprobados con minimo (4) para ingresar a instancia de final debe recursar la materia", ConsoleColor.Red);
                            }

                            Console.ReadKey();
                            Console.Clear();
                        }
                        Console.ResetColor();
                        Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    //Opcion MODO SALIR
                    case 3:
                        Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                MensajeColor("\nUsted puso un caracter que no es 1, 2 o 3", ConsoleColor.Red);
            } while (inputOpcion == 0 || inputOpcion > 3);
        }
        //METODOS: FUNCIONES(RETURN) Y PROCEDIMIENTOS (VOID)
        //los metodos tienen que pertenecer a una clase

        /// <summary>
        /// Muestra en pantalla el mensaje indicado, le cambia al color deseado y reinicia al valor por defecto de color del texto de consola.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="color"></param>
        public static void MensajeColor(string mensaje, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{mensaje}");
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra en pantalla los mensajes indicados, les cambia el color y reinicia el valor por defecto de color del texto de consola.
        /// </summary>
        /// <param name="primerMensaje"></param>
        /// <param name="primerColor"></param>
        /// <param name="segundoMensaje"></param>
        /// <param name="segundoColor"></param>
        public static void MensajeColor(string primerMensaje, ConsoleColor primerColor, string segundoMensaje, ConsoleColor segundoColor)
        {
            Console.ForegroundColor = primerColor;
            Console.WriteLine($"{primerMensaje}");
            Console.ForegroundColor = segundoColor;
            Console.WriteLine($"{segundoMensaje}");
            Console.ResetColor();
        }

        /// <summary>
        /// Valida si el ingreso es un numero.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <param name="maximoValorInput"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static int ValidacionNumerica(string mensajeIngreso, string mensajeError, ConsoleColor colorError, int maximoValorInput)
        {
            string validarIngreso;
            int outputIngreso;
            do
            {
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();
                int.TryParse(validarIngreso, out outputIngreso);
                if (outputIngreso == 0 || outputIngreso > maximoValorInput)
                {
                    Console.Clear();
                    MensajeColor(mensajeError, colorError);
                }
            } while (outputIngreso == 0 || outputIngreso > maximoValorInput);
            Console.Clear();
            return outputIngreso;
        }

        /// <summary>
        /// Valida si el ingreso es un numero.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="titulo"></param>
        /// <param name="colorError"></param>
        /// <param name="maximoValorInput"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static int ValidacionNumerica(string mensajeIngreso, string mensajeError, string titulo, ConsoleColor colorError, int maximoValorInput)
        {
            string validarIngreso;
            int outputIngreso;
            do
            {
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();
                int.TryParse(validarIngreso, out outputIngreso);
                if (outputIngreso == 0 || outputIngreso > maximoValorInput)
                {
                    Console.Clear();
                    MensajeColor(titulo, ConsoleColor.Green);
                    MensajeColor(mensajeError, colorError);
                }
            } while (outputIngreso == 0 || outputIngreso > maximoValorInput);
            Console.Clear();
            MensajeColor(titulo, ConsoleColor.Green);
            return outputIngreso;
        }
        //LINQ ES MAS RAPIDO QUE USAR REGEX https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp/1181426
        /// <summary>
        /// Valida si el ingreso de texto esta vacio o nulo. Y si son solo letras.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static string ValidacionTexto(string mensajeIngreso, string mensajeError, ConsoleColor colorError)
        {
            string validarIngreso;
            do
            {
                do
                {
                    Console.WriteLine(mensajeIngreso);
                    validarIngreso = Console.ReadLine();
                    if (string.IsNullOrEmpty(validarIngreso))
                    {
                        Console.Clear();
                        MensajeColor(mensajeError, colorError);
                    }
                } while (string.IsNullOrEmpty(validarIngreso));

                if (!validarIngreso.All(Char.IsLetter))
                {
                    Console.Clear();
                    MensajeColor(mensajeError, colorError);
                }

            } while (!validarIngreso.All(Char.IsLetter));

            Console.Clear();
            return validarIngreso;
        }

        /// <summary>
        /// Valida si el ingreso de texto esta vacio o nulo. Y si son solo letras.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="titulo"></param>
        /// <param name="colorError"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static string ValidacionTexto(string mensajeIngreso, string mensajeError, string titulo, ConsoleColor colorError)
        {
            string validarIngreso;
            do
            {
                do
                {
                    Console.WriteLine(mensajeIngreso);
                    validarIngreso = Console.ReadLine();
                    if (string.IsNullOrEmpty(validarIngreso))
                    {
                        Console.Clear();
                        MensajeColor(titulo, ConsoleColor.Green);
                        MensajeColor(mensajeError, colorError);
                    }
                } while (string.IsNullOrEmpty(validarIngreso));

                if (!validarIngreso.All(Char.IsLetter))
                {
                    Console.Clear();
                    MensajeColor(titulo, ConsoleColor.Green);
                    MensajeColor(mensajeError, colorError);
                }

            } while (!validarIngreso.All(Char.IsLetter));

            Console.Clear();
            MensajeColor(titulo, ConsoleColor.Green);
            return validarIngreso;
        }
    }
}