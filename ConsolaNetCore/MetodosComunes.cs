using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolaNetCore
{
    public static class MetodosComunes
    {
        /// <summary>
        /// Muestra en pantalla el mensaje indicado, le cambia al color deseado y reinicia al valor por defecto de color del texto de consola.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="color"></param>
        public static void MensajeColor(string mensaje, ConsoleColor color = ConsoleColor.Green)
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
        public static void MensajeColor(string primerMensaje, string segundoMensaje, ConsoleColor primerColor = ConsoleColor.Green, ConsoleColor segundoColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = primerColor;
            Console.WriteLine($"{primerMensaje}");
            Console.ForegroundColor = segundoColor;
            Console.WriteLine($"{segundoMensaje}");
            Console.ResetColor();
        }
        /// <summary>
        /// Valida si el valor es un numero entero.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <param name="maximoValorInput"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static int ValidacionNumericaInt(string mensajeIngreso, string mensajeError = "Valor no comprendido entre -2147483648 y 2147483647", ConsoleColor colorError = ConsoleColor.Red, int minimoValorInput = int.MinValue, int maximoValorInput = int.MaxValue, bool borrarInformacion = true)
        {
            string validarIngreso;
            int outputIngreso;
            do
            {
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();
                int.TryParse(s: validarIngreso, result: out outputIngreso);
                if (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput)
                {
                    if (borrarInformacion)
                    {
                        Console.Clear();
                    }
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }
            } while (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput);
            if (borrarInformacion)
            {
                Console.Clear();
            }
            return outputIngreso;
        }
        /// <summary>
        /// Valida si el valor ingresa es un numero entero o null.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <param name="minimoValorInput"></param>
        /// <param name="maximoValorInput"></param>
        /// <param name="borrarInformacion"></param>
        /// <param name="valorNull"></param>
        /// <returns></returns>
        public static int? ValidacionNumericaIntNull(string mensajeIngreso, string mensajeError = "Valor no comprendido entre -2147483648 y 2147483647", ConsoleColor colorError = ConsoleColor.Red, int minimoValorInput = int.MinValue, int maximoValorInput = int.MaxValue, bool borrarInformacion = true, bool valorNull = false)
        {
            string validarIngreso;
            int outputIngreso;
            do
            {
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();
                if (validarIngreso == "null" && valorNull == true)
                {
                    return null;
                }
                int.TryParse(s: validarIngreso, result: out outputIngreso);
                if (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput)
                {
                    if (borrarInformacion)
                    {
                        Console.Clear();
                    }
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }
            } while (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput);
            if (borrarInformacion)
            {
                Console.Clear();
            }
            return outputIngreso;
        }
        /// <summary>
        /// Valida si el valor ingresado es un numero float.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <param name="minimoValorInput"></param>
        /// <param name="maximoValorInput"></param>
        /// <param name="borrarInformacion"></param>
        /// <returns></returns>
        public static float? ValidacionNumericaFloat(string mensajeIngreso, string mensajeError = "Valor no comprendido en 3.40282347E+38", ConsoleColor colorError = ConsoleColor.Red, float minimoValorInput = float.MinValue, float maximoValorInput = float.MaxValue, bool borrarInformacion = true)
        {
            string validarIngreso;
            float outputIngreso;
            do
            {
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();

                float.TryParse(s: validarIngreso, result: out outputIngreso);
                if (outputIngreso <= minimoValorInput || outputIngreso > maximoValorInput)
                {
                    if (borrarInformacion)
                    {
                        Console.Clear();
                    }
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }
            } while (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput);
            if (borrarInformacion)
            {
                Console.Clear();
            }
            return outputIngreso;
        }
        /// <summary>
        /// Valida si el valor ingresado es un numero float o null.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <param name="minimoValorInput"></param>
        /// <param name="maximoValorInput"></param>
        /// <param name="borrarInformacion"></param>
        /// <returns></returns>
        public static float? ValidacionNumericaFloatNull(string mensajeIngreso, string mensajeError = "Valor no comprendido en 3.40282347E+38", ConsoleColor colorError = ConsoleColor.Red, float minimoValorInput = float.MinValue, float maximoValorInput = float.MaxValue, bool borrarInformacion = true)
        {
            string validarIngreso;
            float outputIngreso;
            do
            {
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();
                if (validarIngreso == "null")
                {
                    return null;
                }
                float.TryParse(s: validarIngreso, result: out outputIngreso);
                if (outputIngreso <= minimoValorInput || outputIngreso > maximoValorInput)
                {
                    if (borrarInformacion)
                    {
                        Console.Clear();
                    }
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }
            } while (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput);
            if (borrarInformacion)
            {
                Console.Clear();
            }
            return outputIngreso;
        }

        // TODO Arreglar inclusion de caso en el que se incluya una direccion que toma valor numerico o simbolo al final
        // Linq es mas rapido que usar RegEx https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp/1181426.
        /// <summary>
        /// Valida el texto ingresado verificando si contiene numeros, si empieza o termina con espacio vacio. O si es enteramente espacio vacio.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static string ValidacionTexto(string mensajeIngreso, string mensajeError = "El valor ingresado esta vacio, empieza o termina con un espacio o contiene un caracter no alfabetico", ConsoleColor colorError = ConsoleColor.Red)
        {
            bool invalido;
            string validarIngreso;
            do
            {
                invalido = false;
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();

                if (validarIngreso.All(predicate: char.IsWhiteSpace) || validarIngreso.Any(predicate: char.IsDigit) || validarIngreso.StartsWith(" ") || validarIngreso.EndsWith(" ") || string.IsNullOrEmpty(validarIngreso) || (!validarIngreso.Any(char.IsLetter) && !validarIngreso.Any(char.IsWhiteSpace)))
                {
                    Console.Clear();
                    MensajeColor(mensaje: mensajeError, color: colorError);
                    invalido = true;
                }

            } while (invalido == true);

            Console.Clear();
            return validarIngreso;
        }
#nullable enable
        /// <summary>
        /// Valida el texto ingresado verificando si es nulo, contiene numeros, si empieza o termina con espacio vacio. O si es enteramente espacio vacio.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <returns></returns>
        public static string? ValidacionTextoNull(string mensajeIngreso, string mensajeError = "El valor ingresado esta vacio, empieza o termina con un espacio o contiene un caracter no alfabetico", ConsoleColor colorError = ConsoleColor.Red)
        {
            bool invalido;
            string validarIngreso;
            do
            {
                invalido = false;
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();
                if (validarIngreso == "null")
                {
                    return null;
                }
                if (validarIngreso.All(predicate: char.IsWhiteSpace) || validarIngreso.Any(predicate: char.IsDigit) || validarIngreso.StartsWith(" ") || validarIngreso.EndsWith(" ") || string.IsNullOrWhiteSpace(validarIngreso) || (!validarIngreso.Any(char.IsLetter) && !validarIngreso.Any(char.IsWhiteSpace)))
                {
                    Console.Clear();
                    MensajeColor(mensaje: mensajeError, color: colorError);
                    invalido = true;
                }

            } while (invalido == true);

            Console.Clear();
            return validarIngreso;
        }
#nullable disable
        /// <summary>
        /// Valida el texto ingresado verificando si es nulo, contiene numeros, si empieza o termina con espacio vacio. O si es enteramente espacio vacio.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="titulo"></param>
        /// <param name="colorError"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static string ValidacionTexto(string mensajeIngreso, string titulo, string mensajeError = "El valor ingresado esta vacio, empieza o termina con un espacio o contiene un caracter no alfabetico", ConsoleColor colorError = ConsoleColor.Red)
        {
            bool invalido;
            string validarIngreso;
            do
            {
                invalido = false;
                Console.WriteLine(mensajeIngreso);
                validarIngreso = Console.ReadLine();

                if (validarIngreso.All(predicate: char.IsWhiteSpace) || validarIngreso.Any(predicate: char.IsDigit) || validarIngreso.StartsWith(" ") || validarIngreso.EndsWith(" ") || string.IsNullOrEmpty(validarIngreso) || (!validarIngreso.Any(char.IsLetter) && !validarIngreso.Any(char.IsWhiteSpace)))
                {
                    Console.Clear();
                    MensajeColor(mensaje: titulo);
                    MensajeColor(mensaje: mensajeError, color: colorError);
                    invalido = true;
                }

            } while (invalido == true);

            Console.Clear();
            MensajeColor(mensaje: titulo);
            return validarIngreso;
        }

    }
}
