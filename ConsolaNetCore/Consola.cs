using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;

// TODO implementar explicacion correcta de intellisense para los metodos.
// TODO ingreso de profesores/Ayudante de catedra.
// TODO implementar manejo de excepciones.
// TODO cambiar variables a sus variables reducidas en espacio solo cuando empieze a usar DB.
// TODO Resolver problema de System.NullReferenceException: 'Object reference not set to an instance of an object.' cuando se quiere mostrar parametros null en metodos GET.

namespace ConsolaNetCore
{
    public static class Consola
    {
        public static List<Entidades.Asignatura> asignaturas = new List<Entidades.Asignatura>();

        static void Main(string[] args)
        {
            Console.Title = "Programa de Gestion de Notas de Alumnos";
            Bienvenida();
            ElegirOpciones();
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

        public static void AgregarAlumno()
        {
            int cantidad = ValidacionNumerica(mensajeIngreso: "\nCuantos alumnos quiere ingresar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
            for (int i = 0; i < cantidad; i++)
            {
                Entidades.Alumno alumno = new Entidades.Alumno();
                Entidades.Asignatura asignatura;
                Entidades.Carrera carrera = new Entidades.Carrera();
                Entidades.Notas notas = new Entidades.Notas();

                alumno = AgregarDatosAlumno(alumno);
                carrera = AgregarDatosCarrera(carrera);
                asignatura = AgregarDatosAsignatura();
                notas = AgregarDatosNotas(notas);

                asignatura.Nota = notas;
                asignaturas.Add(item: asignatura);
                carrera.MateriasId = asignaturas;
                alumno.Carrera = carrera;

                Logica.Alumno.Agregar(alumno: alumno);
            }
        }

        public static Entidades.Alumno AgregarDatosAlumno(Entidades.Alumno pAlumno)
        {
            pAlumno.Nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de su alumno: ", mensajeError: "\nIngrese un nombre solo con caracteres alfabeticos.");
            pAlumno.Apellido = ValidacionTexto(mensajeIngreso: "\nIngrese el apellido de su alumno: ", mensajeError: "\nIngrese un apellido solo con caracteres alfabeticos.");
            pAlumno.Edad = ValidacionNumerica(mensajeIngreso: "\nIngrese la edad de su alumno entre 13 y 99 años: ", mensajeError: "\nIngrese una edad solo con caracteres numericos entre 13 y 99.", minimoValorInput: 13, maximoValorInput: 99);
            pAlumno.DNI = ValidacionNumerica(mensajeIngreso: "\nIngrese el DNI de su alumno: ", mensajeError: "\nIngrese un DNI solo con caracteres numericos entre 1 y 99.999.999.", minimoValorInput: 1, maximoValorInput: 99999999);
            return pAlumno;
        }

        // Se crea nueva entidad de alumno dentro del metodo para evitar que mande un id que no corresponde causando una excepcion.
        public static Entidades.Alumno ModificarDatosAlumno(Entidades.Alumno pAlumno = null)
        {
            if (pAlumno != null)
            {
                pAlumno = AgregarDatosAlumno(pAlumno);
            }

            return pAlumno;
        }
        public static Entidades.Carrera AgregarDatosCarrera(Entidades.Carrera pCarrera)
        {
            switch (ValidacionNumerica(mensajeIngreso: "\nIngrese el numero de la facultad de su alumno (Ingenieria = 0 | CienciasExactas = 1 | Agronomia = 2): ", mensajeError: "\nIngrese una edad solo con caracteres numericos entre 0 y 2 (Ingenieria = 0 | CienciasExactas = 1 | Agronomia = 2)", minimoValorInput: 0, maximoValorInput: 2))
            {
                case 0:
                    pCarrera.Facultad = Enumeraciones.Facultades.Ingenieria;
                    break;
                case 1:
                    pCarrera.Facultad = Enumeraciones.Facultades.CienciasExactas;
                    break;
                case 2:
                    pCarrera.Facultad = Enumeraciones.Facultades.Agronomia;
                    break;
                default:
                    break;
            }

            pCarrera.Titulo = ValidacionTexto(mensajeIngreso: "\nIngrese el titulo de la carrera de su alumno: ", mensajeError: "\nIngrese un titulo solo con caracteres alfabeticos.");
            return pCarrera;
        }

        public static Entidades.Alumno ModicarDatosCarrera(Entidades.Alumno pAlumno = null)
        {
            if (pAlumno != null)
            {
                pAlumno.Carrera = AgregarDatosCarrera(pAlumno.Carrera);
            }
            return pAlumno;
        }

        public static Entidades.Asignatura AgregarDatosAsignatura()
        {
            Entidades.Asignatura asignatura = new Entidades.Asignatura();
            switch (ValidacionNumerica(mensajeIngreso: "\nIngrese la materia de su alumno (Matematica = 0 | Ingles = 1 | Algebra = 2): ", mensajeError: "\nIngrese un valor solo con caracteres numericos entre 0 y 2 (Matematica = 0 | Ingles = 1 | Algebra = 2)", minimoValorInput: 0, maximoValorInput: 2))
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
            return asignatura;
        }

        public static Entidades.Alumno ModificarDatosAsignatura(Entidades.Alumno pAlumno = null)
        {
            if (pAlumno != null)
            {
                pAlumno.Carrera.MateriasId.Add(AgregarDatosAsignatura());
            }
            return pAlumno;
        }

        public static Entidades.Notas AgregarDatosNotas(Entidades.Notas pNotas)
        {
            pNotas.PrimerParcial = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del primer parcial de la materia ():", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.PrimerRecuperatorio = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del primer recuperatorio de la materia ():", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.SegundoParcial = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del segundo parcial de la materia ():", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.SegundoRecuperatorio = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del segundo recuperatorio de la materia ():", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.Final = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del final de la materia ():", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            return pNotas;
        }

        public static Entidades.Notas ModificarDatosNotas(Entidades.Notas pNotas = null)
        {
            
            if (pNotas != null)
            {
                pNotas = AgregarDatosNotas(pNotas: pNotas);
            }
            return pNotas;
        }

        public static void EliminarAlumno(int id)
        {
            Logica.Alumno.Eliminar(id: id);
        }
        // TODO Completar completamente todos los otros metodos antes de este, sin hardcodear.
        // TODO Verificar correcciones en caso de ser NULL.
        public static void EditarAlumno()
        {
            Entidades.Asignatura asignatura = new Entidades.Asignatura();
            Entidades.Notas notas = new Entidades.Notas();
            Entidades.Carrera carrera = new Entidades.Carrera();
            InformarTodosAlumnos();
            int id = ValidacionNumerica(mensajeIngreso: "\nColoque el ID del alumno a editar", mensajeError: "El valor ingresado no puede ser 0 o menor", minimoValorInput: 0);
            Entidades.Alumno alumno = Logica.Alumno.ListarUno(id: id);
            switch (ValidacionNumerica(mensajeIngreso: "\nElija que parametros quiere editar (Alumno = 1 | Carrera = 2 | Asignatura = 3 | Notas = 4 | Todos = 0)"))
            {
                case 1:
                    Console.WriteLine($"\nLos datos del alumno son Nombre: {alumno.Nombre} Apellido: {alumno.Apellido} Edad: {alumno.Edad} DNI: {alumno.DNI}");
                    alumno = ModificarDatosAlumno(alumno);
                    Logica.Alumno.Editar(alumno);
                    break;
                case 2:
                    Console.WriteLine("");
                    alumno = ModicarDatosCarrera(alumno);
                    Logica.Alumno.Editar(alumno);
                    break;
                case 3:
                    alumno = ModificarDatosAsignatura(alumno);
                    Logica.Alumno.Editar(alumno);
                    break;
                case 4:
                    notas = ModificarDatosNotas(notas);
                    asignatura.Nota = notas;
                    asignaturas.Add(item: asignatura);
                    carrera.MateriasId = asignaturas;
                    alumno.Carrera = carrera;
                    Logica.Alumno.Editar(alumno);
                    break;
                case 5:
                    alumno = ModificarDatosAlumno(alumno);
                    alumno = ModicarDatosCarrera(alumno);
                    alumno = ModificarDatosAsignatura();
                    notas = ModificarDatosNotas(notas);
                    asignatura.Nota = notas;
                    asignaturas.Add(item: asignatura);
                    carrera.MateriasId = asignaturas;
                    alumno.Carrera = carrera;
                    Logica.Alumno.Editar(alumno);
                    break;
                default:
                    break;
            }
        }
        public static void InformarUnAlumno()
        {
            string nombre, apellido;
            int id, edad, dni;
            Entidades.Alumno alumno;
            switch (ValidacionNumerica(mensajeIngreso: "\nIndique por cual tipo de valor quiere buscar (ID = 1 | Nombre = 2 | Apellido = 3 | Edad = 4 | DNI = 5)", mensajeError: "\nEl valor no esta dentro de 1 y 5.", minimoValorInput: 1, maximoValorInput: 5))
            {
                case 1:
                    id = ValidacionNumerica(mensajeIngreso: "\nIngrese el id por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumno = Logica.Alumno.ListarUno(id: id);
                    Console.WriteLine(value: $"\nEl alumno con id {id} es\n");

                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                    }
                    break;
                case 2:
                    nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre por el cual quiere buscar:");

                    alumno = Logica.Alumno.ListarUno(nombre: nombre);
                    Console.WriteLine(value: $"\nEl alumno con nombre {nombre} es\n");

                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                    }
                    break;
                case 3:
                    apellido = ValidacionTexto(mensajeIngreso: "\nIngrese el apellido por el cual quiere buscar:");

                    alumno = Logica.Alumno.ListarUno(apellido: apellido);
                    Console.WriteLine(value: $"\nEl alumno con apellido {apellido} es\n");

                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                    }
                    break;
                case 4:
                    edad = ValidacionNumerica(mensajeIngreso: "\nIngrese el edad por el cual quiere buscar:", mensajeError: "El valor no puede ser 12 o menor.", minimoValorInput: 12);

                    alumno = Logica.Alumno.ListarUno(edad: edad);
                    Console.WriteLine(value: $"\nEl alumno con edad {edad} es\n");

                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                    }

                    break;
                case 5:
                    dni = ValidacionNumerica(mensajeIngreso: "\nIngrese el dni por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumno = Logica.Alumno.ListarUno(dni: dni);
                    Console.WriteLine(value: $"\nEl alumno con dni {dni} es\n");

                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                    }
                    break;
                default:
                    break;
            }
        }

        public static void InformarVariosAlumnos()
        {
            string nombre, apellido;
            int id, edad, dni;
            List<Entidades.Alumno> alumnos;
            switch (ValidacionNumerica(mensajeIngreso: "\nIndique por cual tipo de valor quiere buscar (ID = 1 | Nombre = 2 | Apellido = 3 | Edad = 4 | DNI = 5)", mensajeError: "\nEl valor no esta dentro de 1 y 5.", minimoValorInput: 1, maximoValorInput: 5))
            {
                case 1:
                    id = ValidacionNumerica(mensajeIngreso: "\nIngrese el id por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumnos = Logica.Alumno.ListarVarios(id: id);
                    Console.WriteLine(value: $"\nLos alumno con id {id} son\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumno alumno in alumnos)
                        {
                            Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                        }
                    }
                    break;
                case 2:
                    nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre por el cual quiere buscar:");

                    alumnos = Logica.Alumno.ListarVarios(nombre: nombre);
                    Console.WriteLine(value: $"\nLos alumno con nombre {nombre} son\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumno alumno in alumnos)
                        {
                            Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                        }
                    }
                    break;
                case 3:
                    apellido = ValidacionTexto(mensajeIngreso: "\nIngrese el apellido por el cual quiere buscar:");

                    alumnos = Logica.Alumno.ListarVarios(apellido: apellido);
                    Console.WriteLine(value: $"\nLos alumno con apellido {apellido} son\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumno alumno in alumnos)
                        {
                            Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                        }
                    }
                    break;
                case 4:
                    edad = ValidacionNumerica(mensajeIngreso: "\nIngrese el edad por el cual quiere buscar:", mensajeError: "El valor no puede ser 12 o menor.", minimoValorInput: 12);

                    alumnos = Logica.Alumno.ListarVarios(edad: edad);
                    Console.WriteLine(value: $"\nLos alumno con edad {edad} son\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumno alumno in alumnos)
                        {
                            Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                        }
                    }

                    break;
                case 5:
                    dni = ValidacionNumerica(mensajeIngreso: "\nIngrese el dni por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumnos = Logica.Alumno.ListarVarios(dni: dni);
                    Console.WriteLine(value: $"\nLos alumno con dni {dni} son\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumno alumno in alumnos)
                        {
                            Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera: {alumno.Carrera.Titulo} | Facultad: {alumno.Carrera.Facultad}");
                        }
                    }
                    break;
                default:
                    break;                   
            }
        }

        public static void InformarTodosAlumnos()
        {
            List<Entidades.Alumno> alumnos = Logica.Alumno.ListarTodos();
            Console.WriteLine(value: "\nTodos los alumnos");

            if (alumnos.Count == 0)
            {
                Console.WriteLine("La lista de alumno esta vacia");
                Console.ReadLine();
            }
            else
            {
                foreach (Entidades.Alumno alumno in alumnos)
                {
                    Console.WriteLine(value: $"\nID: {alumno.IdAlumno} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.DNI} | Carrera:  | Facultad: ");

                    Console.WriteLine("\nMaterias:");

                    foreach (var materia in asignaturas)
                    {
                        Console.WriteLine(value: $"\nNombre: {materia.NombreAsignatura} | Codigo : {materia.Codigo} | Comision: {materia.Comision} | Horario: {materia.Horario}");
                        Console.WriteLine($"\nNotas de la materia {materia.NombreAsignatura}:");
                        Console.WriteLine($"\nPrimer parcial: {materia.Nota.PrimerParcial} | Primer recuperatorio: {materia.Nota.PrimerRecuperatorio} | Segundo parcial: {materia.Nota.SegundoParcial} | Segundo recuperatorio: {materia.Nota.SegundoRecuperatorio} | Final: {materia.Nota.Final}");
                    }
                }
            }
        }
        public static void RendirExamen()
        {
            // TODO mesa de examen parcial, recuperatorio y final. Validar inout de nota de examen.
            throw new NotImplementedException();
        }

        public static void AprobacionExamen()
        {
            // TODO indicar si se aprueba o no examen.
            throw new NotImplementedException();
        }

        public static void InformarNotas()
        {
            // TODO informar notas.
            throw new NotImplementedException();
        }

        public static void Promocion()
        {
            // TODO indicar si promociono la materia.
            throw new NotImplementedException();
        }

        public static void ElegirOpciones()
        {
            switch (ValidacionNumerica(mensajeIngreso: "\nQue desea hacer? Elija la opcion deseada:\n\n1 = Mostrar todos los alumnos.\n\n2 = Mostrar alumnos segun parametro.\n\n3 = Mostrar un alumno.\n\n4 = Agregrar un alumno\n\n5 = Editar un alumno.\n\n6 = Eliminar un alumno.\n\n0 = Salir.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 0 y 5", minimoValorInput: 0, maximoValorInput: 5))
            {
                case 1:
                    InformarTodosAlumnos();
                    break;
                case 2:
                    InformarVariosAlumnos();
                    break;
                case 3:
                    InformarUnAlumno();
                    break;
                case 4:
                    AgregarAlumno();
                    break;
                case 5:
                    EditarAlumno();
                    break;
                case 6:
                    //EliminarAlumno();
                    break;
                case 0:
                    Salir();
                    break;
                default:
                    break;
            }
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
        public static int ValidacionNumerica(string mensajeIngreso, string mensajeError = "Valor no comprendido entre -2147483648 y 2147483647", ConsoleColor colorError = ConsoleColor.Red, int minimoValorInput = int.MinValue, int maximoValorInput = int.MaxValue)
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
        public static int ValidacionNumerica(string mensajeIngreso, string titulo, string mensajeError = "Valor no comprendido entre -2147483648 y 2147483647", ConsoleColor colorError = ConsoleColor.Red, int minimoValorInput = int.MinValue, int maximoValorInput = int.MaxValue)
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
        /// Valida el texto ingresado verificando si es nulo, contiene numeros, si empieza o termina con espacio vacio. O si es enteramente espacio vacio.
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
                Console.WriteLine(value: mensajeIngreso);
                validarIngreso = Console.ReadLine();

                if (validarIngreso.All(predicate: char.IsWhiteSpace) || validarIngreso.Any(predicate: char.IsDigit) || validarIngreso.StartsWith(value: " ") || validarIngreso.EndsWith(value: " ") || string.IsNullOrEmpty(value: validarIngreso) || (!validarIngreso.Any(char.IsLetter) && !validarIngreso.Any(char.IsWhiteSpace)))
                {
                    Console.Clear();
                    MensajeColor(mensaje: mensajeError, color: colorError);
                    invalido = true;
                }

            } while (invalido == true);

            Console.Clear();
            return validarIngreso;
        }

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
                Console.WriteLine(value: mensajeIngreso);
                validarIngreso = Console.ReadLine();

                if (validarIngreso.All(predicate: char.IsWhiteSpace) || validarIngreso.Any(predicate: char.IsDigit) || validarIngreso.StartsWith(value: " ") || validarIngreso.EndsWith(value: " ") || string.IsNullOrEmpty(value: validarIngreso) || (!validarIngreso.Any(char.IsLetter) && !validarIngreso.Any(char.IsWhiteSpace)))
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
