using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;

// TODO implementar explicacion correcta de intellisense para los metodos
// TODO implementar asistencia de alumnos
// TODO ingreso de profesores/Ayudante de catedra
// TODO implementar manejo de excepciones
// TODO cambiar variables a sus variables reducidas en espacio solo cuando empieze a usar DB

namespace ConsolaNetCore
{
    public class Consola
    {
        public static Entidades.Staff staff = new Entidades.Staff();
        public static Entidades.Alumno alumno = new Entidades.Alumno();
        public static Entidades.Carrera carrera = new Entidades.Carrera();
        public static Entidades.Asignatura asignatura = new Entidades.Asignatura();
        public static Entidades.Notas notas = new Entidades.Notas();
        public static List<Entidades.Asignatura> asignaturas = new List<Entidades.Asignatura>();
        public static Logica.Alumno objLogica = new Logica.Alumno();

        static void Main(string[] args)
        {
            // Titulo en de la ventana.
            Console.Title = "Programa de Gestion de Notas de Alumnos";
            Bienvenida();
            //ElegirOpciones();
            int cantidad = IngresoAlumnos();
            for (int i = 0; i < cantidad; i++)
            {
                objLogica.Agregar(alumno: AgregarAlumno(cantidad) );
            }
            

            //InformarAlumnos();
            //RendirExamen();
            //AprobacionExamen();
            //InformarNotas();
            //Promocion();
            Salir();
        }

        public static void Bienvenida()
        {
            Console.WriteLine(value: "\nBienvenido al Programa de Gestion de Notas de Alumnos\n\nEste programa le permitira ingresar los datos de los alumnos de su clase.\nPermitiendole mantener un registro de los mismos.\n\nPresione una tecla para continuar...");
            Console.ReadKey(intercept: true);
            Console.Clear();
        }

        public static void Salir()
        {
            Console.WriteLine(value: "\nFin del programa\n\nPresione cualquier tecla para finalizar");
            Console.ReadKey(intercept: true);
            System.Environment.Exit(exitCode: 0);
        }

        public static int IngresoAlumnos()
        {
            return ValidacionNumerica(mensajeIngreso: "\nCuantos alumnos quiere ingresar? (1-100)", mensajeError: "\nUsted introdujo un valor que no esta entre 1 y 100", titulo: "\n---INGRESO DE ALUMNOS---", colorError: ConsoleColor.Red, minimoValorInput: 1, maximoValorInput: 100);
        }

        // TODO Hacer un metodo que permita agregar 1 o mas alumnos
        public static Entidades.Alumno AgregarAlumno()
        {
            throw new NotImplementedException();
        }

        public static Entidades.Alumno AgregarAlumno(int cantidad)
        {
            // Se pone alumno.IdAlumno = 0 en este scope ya que la instancia static de alumno en la clase Consola, los datos ingresados la primera vez permanecen, haciendo que la 2da, vez el id pasado a la base de datos sea el mismo que el primero. Dando una excepcion de: sqlexception: no se puede insertar un valor explícito en la columna de identidad de la tabla '' cuando identity_insert es off.

            alumno.IdAlumno = 0;
            alumno.Nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de su alumno: ", mensajeError: "\nIngrese un nombre solo con caracteres alfabeticos.");
            alumno.Apellido = ValidacionTexto(mensajeIngreso: "\nIngrese el apellido de su alumno: ", mensajeError: "\nIngrese un apellido solo con caracteres alfabeticos.");
            alumno.Edad = ValidacionNumerica(mensajeIngreso: "\nIngrese la edad de su alumno entre 13 y 99 años: ", mensajeError: "\nIngrese una edad solo con caracteres numericos entre 13 y 99.", minimoValorInput: 13, maximoValorInput: 99);
            alumno.DNI = ValidacionNumerica(mensajeIngreso: "\nIngrese el DNI de su alumno: ", mensajeError: "\nIngrese un DNI solo con caracteres numericos entre 1 y 99.999.999", minimoValorInput: 1, maximoValorInput: 99999999);

            switch (ValidacionNumerica(mensajeIngreso: "\nIngrese el numero de la facultad de su alumno (Ingenieria = 0, CienciasExactas = 1, Agronomia = 2): ", mensajeError: "\nIngrese una edad solo con caracteres numericos entre 0 y 2 (Ingenieria = 0, CienciasExactas = 1, Agronomia = 2)", minimoValorInput: 0, maximoValorInput: 2))
            {
                case 0:
                    carrera.Facultad = Enumeraciones.Facultades.Ingenieria;
                    break;
                case 1:
                    carrera.Facultad = Enumeraciones.Facultades.CienciasExactas;
                    break;
                case 2:
                    carrera.Facultad = Enumeraciones.Facultades.Agronomia;
                    break;
                default:
                    break;
            }

            carrera.Titulo = ValidacionTexto(mensajeIngreso: "\nIngrese el titulo de la carrera de su alumno: ", mensajeError: "\nIngrese un titulo solo con caracteres alfabeticos.");

            switch (ValidacionNumerica(mensajeIngreso: "\nIngrese la materia de su alumno (Matematica = 0, Ingles = 1, Algebra = 2): ", mensajeError: "\nIngrese un valor solo con caracteres numericos entre 0 y 2 (Matematica = 0, Ingles = 1, Algebra = 2)", minimoValorInput: 0 ,maximoValorInput: 2))
            {
                case 0:
                    asignatura.NombreAsignatura = Enumeraciones.Materias.Matematica;
                    break;
                case 1:
                    asignatura.NombreAsignatura = Enumeraciones.Materias.Ingles;
                    break;
                case 2:
                    asignatura.NombreAsignatura = Enumeraciones.Materias.Algebra;
                    break;
                default:
                    break;
            }
            
            asignatura.Codigo = ValidacionNumerica(mensajeIngreso: $"\nIngrese el codigo de la materia ({asignatura.NombreAsignatura}): ", mensajeError: "\nIngrese un codigo solo con caracteres numericos mayor a 0", minimoValorInput: 1);
            asignatura.Comision = ValidacionNumerica(mensajeIngreso: $"\nIngrese la comision de la materia ({asignatura.NombreAsignatura}): ", mensajeError: "\nIngrese una comision solo con caracteres numericos mayor a 0", minimoValorInput: 1);
            asignatura.Horario = ValidacionNumerica(mensajeIngreso: $"\nIngrese el horario de la materia ({asignatura.NombreAsignatura}): ", mensajeError: "\nIngrese una horario solo con caracteres numericos mayor a 0", minimoValorInput: 1);
            asignaturas.Add(item: asignatura);
            carrera.Materias = asignaturas;
            alumno.Carrera = carrera;

            return alumno;
        }

        public static void EliminarAlumno(int id)
        {
            objLogica.Eliminar(id: id);
        }

        public static void InformarAlumnos()
        {
            //Console.WriteLine(value: "\nUn alumno");
            //Console.WriteLine(value: objLogica.ListarUno(1).Nombre);
            //Console.WriteLine(value: "\nVarios alumnos usando 1 como DNI, devolviendo nombre");
            //foreach (Entidades.Alumno alumno in objLogica.ListarVarios(1))
            //{
            //    Console.WriteLine(value: alumno.Nombre);
            //}
            //Console.ReadLine();

            //Console.WriteLine(value: "\nVarios alumnos usando Jose como nombre, devolviendo DNI");
            //foreach (Entidades.Alumno alumno in objLogica.ListarVarios("Jose"))
            //{
            //    Console.WriteLine(value: alumno.DNI);
            //}
            //Console.ReadLine();

            //Console.WriteLine(value: "\nTodos los alumnos");
            //foreach (Entidades.Alumno alumno in objLogica.ListarTodos() )
            //{
            //    Console.WriteLine(value: $"\nNombre: {alumno.Nombre} Apellido: {alumno.Apellido} Edad: {alumno.Edad} DNI: {alumno.DNI} Comision: {alumno.Carrera.Materias[0].Comision} Materia (codigo): {alumno.Carrera.Materias[0].Codigo} Materia (nombre): {alumno.Carrera.Materias[0].NombreAsignatura} Materia (horario): {alumno.Carrera.Materias[0].Horario}");
            //}
            //Entidades.Alumno alumno1 = new Entidades.Alumno(
            //    pNombre: "puta",
            //    pApellido: "trola",
            //    pEdad: 14, pDNI: 123,
            //    new Entidades.Carrera(
            //        pTitulo: "nada",
            //        pMaterias: new List<Entidades.Asignatura>() {
            //            new Entidades.Asignatura(
            //                pCodigo: 321,
            //                pComision: 343,
            //                pHorario: 2321,
            //                pNombreAsignatura: Enumeraciones.Materias.Ingles,
            //                pNota: new Entidades.Notas(
            //                    pPrimerParcial: 1,
            //                    pPrimerRecuperatorio: 2,
            //                    pSegundoParcial: 3,
            //                    pSegundoRecuperatorio: 4,
            //                    pFinal: 5
            //                    )
            //                )
            //        }, pFacultad: Enumeraciones.Facultades.Agronomia)
            //    );
            //objLogica.Agregar(alumno1);
            //Console.WriteLine(value: $"\nSe agrega alumno {alumno1.Nombre}, {alumno1.Apellido}, {alumno1.Carrera.Materias[0].Nota.Final}");
            //Entidades.Alumno alumno2 = alumno1;
            //alumno2.Apellido = "putasa";
            //objLogica.Editar(alumno2);
            //Console.WriteLine(value: $"\nSe edita alumno {alumno1.Nombre}, {alumno1.Apellido}, {alumno1.Carrera.Materias[0].Nota.Final}");
            //objLogica.Eliminar(1);
            //Console.WriteLine(value: "\nSe elimina alumno con DNI 1");
            throw new NotImplementedException();
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
            Console.WriteLine(value: "\nQue desea hacer? Elija la opcion deseada:");
            Console.WriteLine(value: "\n1 = Modo Automatico - 2 = Modo Manual - 3 = Salir");
            do
            {
                respuestaIngreso = Console.ReadLine();
                Console.Clear();

                // Convierte el valor respuesta que es string a un numero equivalente en int32 y devuelve la conversion
                // en la variable input, si falla la conversion la variable es 0.
                int.TryParse(s: respuestaIngreso, result: out inputOpcion);

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
            Console.ReadKey(intercept: true);
        }

        /// <summary>
        /// Muestra en pantalla el mensaje indicado, le cambia al color deseado y reinicia al valor por defecto de color del texto de consola.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="color"></param>
        public static void MensajeColor(string mensaje, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value: $"{mensaje}");
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
            Console.WriteLine(value: $"{primerMensaje}");
            Console.ForegroundColor = segundoColor;
            Console.WriteLine(value: $"{segundoMensaje}");
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
        public static int ValidacionNumerica(string mensajeIngreso, string mensajeError, ConsoleColor colorError = ConsoleColor.Red, int minimoValorInput = int.MinValue, int maximoValorInput = int.MaxValue)
        {
            string validarIngreso;
            int outputIngreso;
            do
            {
                Console.WriteLine(value: mensajeIngreso);
                validarIngreso = Console.ReadLine();
                int.TryParse(s: validarIngreso, result: out outputIngreso);
                if (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput)
                {
                    Console.Clear();
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }
            } while (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput);
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
        public static int ValidacionNumerica(string mensajeIngreso, string mensajeError, string titulo, ConsoleColor colorError = ConsoleColor.Red, int minimoValorInput = int.MinValue, int maximoValorInput = int.MaxValue)
        {
            string validarIngreso;
            int outputIngreso;
            do
            {
                Console.WriteLine(value: mensajeIngreso);
                validarIngreso = Console.ReadLine();
                int.TryParse(s: validarIngreso, result: out outputIngreso);
                if (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput)
                {
                    Console.Clear();
                    MensajeColor(mensaje: titulo, color: ConsoleColor.Green);
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }
            } while (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput);
            Console.Clear();
            MensajeColor(mensaje: titulo, color: ConsoleColor.Green);
            return outputIngreso;
        }
        // Linq es mas rapido que usar RegEx https://stackoverflow.com/questions/1181419/verifying-that-a-string-contains-only-letters-in-c-sharp/1181426.
        /// <summary>
        /// Valida si el ingreso de texto esta vacio o nulo. Y si son solo letras.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static string ValidacionTexto(string mensajeIngreso, string mensajeError, ConsoleColor colorError = ConsoleColor.Red)
        {
            string validarIngreso;
            do
            {
                do
                {
                    Console.WriteLine(value: mensajeIngreso);
                    validarIngreso = Console.ReadLine();
                    if (string.IsNullOrEmpty(value: validarIngreso))
                    {
                        Console.Clear();
                        MensajeColor(mensaje: mensajeError, color: colorError);
                    }
                } while (string.IsNullOrEmpty(value: validarIngreso));

                if (!validarIngreso.All(predicate: Char.IsLetter))
                {
                    Console.Clear();
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }

            } while (!validarIngreso.All(predicate: Char.IsLetter));

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
        public static string ValidacionTexto(string mensajeIngreso, string mensajeError, string titulo, ConsoleColor colorError = ConsoleColor.Red)
        {
            string validarIngreso;
            do
            {
                do
                {
                    Console.WriteLine(value: mensajeIngreso);
                    validarIngreso = Console.ReadLine();
                    if (string.IsNullOrEmpty(value: validarIngreso))
                    {
                        Console.Clear();
                        MensajeColor(mensaje: titulo, color: ConsoleColor.Green);
                        MensajeColor(mensaje: mensajeError, color: colorError);
                    }
                } while (string.IsNullOrEmpty(value: validarIngreso));

                if (!validarIngreso.All(predicate: Char.IsLetter))
                {
                    Console.Clear();
                    MensajeColor(mensaje: titulo, color: ConsoleColor.Green);
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }

            } while (!validarIngreso.All(predicate: Char.IsLetter));

            Console.Clear();
            MensajeColor(mensaje: titulo, color: ConsoleColor.Green);
            return validarIngreso;
        }
    }
}
