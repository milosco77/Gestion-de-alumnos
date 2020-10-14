using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsolaNetCore
{
    public class Consola
    {
        public static Logica.Alumno objLogica = new Logica.Alumno();

        static void Main(string[] args)
        {
            
            // TODO incorporar capa logica.
            // Titulo en de la ventana.
            Console.Title = "Programa de Gestion de Notas de Alumnos";
            
            Bienvenida();
            //ElegirOpciones();
            //IngresoAlumnos();
            InformarAlumnos();
            //RendirExamen();
            //AprobacionExamen();
            //InformarNotas();
            //Promocion();
            Salir();
        }

        public static void Bienvenida()
        {
            Console.WriteLine("\nBienvenido al Programa de Gestion de Notas de Alumnos\n\nEste programa le permitira ingresar los datos de los alumnos de su clase. Permitiendole mantener un registro de los mismos.\n\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        public static void Salir()
        {
            Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");
            Console.ReadKey();
            System.Environment.Exit(0);
        }

        public static int IngresoAlumnos()
        {
            // TODO ingreso de alumnos.
            return ValidacionNumerica("\nCuantos alumnos quiere ingresar? (1-100)", "\nUsted introdujo un valor que no esta entre 1 y 100", "\n---INGRESO DE ALUMNOS---", ConsoleColor.Red, 100);
        }

        public static void InformarAlumnos()
        {
            foreach (Entidades.Alumno alumno in objLogica.ListarTodos() )
            {
                Console.WriteLine($"\nNombre: {alumno.Nombre} Apellido: {alumno.Apellido} Edad: {alumno.Edad} DNI: {alumno.DNI} Comision: {alumno.Carrera.Materias[1].Comision} Materia (codigo): {alumno.Carrera.Materias[1].Codigo} Materia (nombre): {alumno.Carrera.Materias[1].NombreAsignatura} Materia (horario): {alumno.Carrera.Materias[1].Horario}");
            } // TODO
            
        }

        public static void RendirExamen()
        {
            // TODO mesa de examen parcial, recuperatorio y final. Validar inout de nota de examen.
        }

        public static void AprobacionExamen()
        {
            // TODO indicar si se aprueba o no examen.
        }

        public static void InformarNotas()
        {
            // TODO informar notas.
        }

        public static void Promocion()
        {
            // TODO indicar si promociono la materia.
        }

        public static void ElegirOpciones()
        {
            string respuestaIngreso;
            int inputOpcion;
            Console.WriteLine("\nQue desea hacer? Elija la opcion deseada:");
            Console.WriteLine("\n1 = Modo Automatico - 2 = Modo Manual - 3 = Salir");
            do
            {
                respuestaIngreso = Console.ReadLine();
                Console.Clear();

                // Convierte el valor respuesta que es string a un numero equivalente en int32 y devuelve la conversion
                // en la variable input, si falla la conversion la variable es 0.
                int.TryParse(respuestaIngreso, out inputOpcion);

                switch (inputOpcion)
                {
                    // Modo Automatico.
                    case 1:
                        break;
                    // Modo Manual.
                    case 2:
                        

                        break;
                    // Salir.
                    case 3:
                        Salir();
                        break;
                    default:
                        break;
                }
            } while (inputOpcion == 0 || inputOpcion > 3);
            Console.ReadLine();
        }

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
        // LINQ ES MAS RAPIDO QUE USAR REGEX https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp/1181426
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
