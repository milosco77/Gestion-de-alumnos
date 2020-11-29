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
        public static List<Entidades.Asignaturas> asignaturas = new List<Entidades.Asignaturas>();

        static void Main(string[] args)
        {
            Console.Title = "Programa de Gestion de Notas de Alumnos";
            Bienvenida();
            ElegirOpciones();
            Salir();
        }

        public static void Continuar()
        {
            MensajeColor(mensaje: "\nPresione una tecla para continuar...", color: ConsoleColor.Yellow);
            Console.ReadKey(intercept: true);
            Console.Clear();
        }

        public static void Bienvenida()
        {
            Console.WriteLine("\nBienvenido al Programa de Gestion de Notas de Alumnos\n\nEste programa le permitira ingresar los datos de los alumnos de su clase.\nPermitiendole mantener un registro de los mismos.");
            Continuar();
        }

        public static void Salir()
        {
            Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");
            Console.ReadKey(intercept: true);
            System.Environment.Exit(exitCode: 0);
        }

        public static void AgregarAlumno()
        {
            int cantidad = ValidacionNumerica(mensajeIngreso: "\nCuantos alumnos quiere ingresar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
            for (int i = 0; i < cantidad; i++)
            {
                Entidades.Alumnos alumno = new Entidades.Alumnos();

                alumno = AgregarDatosAlumno(alumno);
                Logica.Alumno.Agregar(alumno);

            }
        }

        public static Entidades.Alumnos AgregarDatosAlumno(Entidades.Alumnos pAlumno)
        {
            pAlumno.Nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de su alumno: ", mensajeError: "\nIngrese un nombre solo con caracteres alfabeticos.");
            pAlumno.Apellido = ValidacionTexto(mensajeIngreso: "\nIngrese el apellido de su alumno: ", mensajeError: "\nIngrese un apellido solo con caracteres alfabeticos.");
            pAlumno.Edad = (byte)ValidacionNumerica(mensajeIngreso: "\nIngrese la edad de su alumno entre 13 y 99 años: ", mensajeError: "\nIngrese una edad solo con caracteres numericos entre 13 y 99.", minimoValorInput: 13, maximoValorInput: 99);
            pAlumno.Dni = ValidacionNumerica(mensajeIngreso: "\nIngrese el DNI de su alumno: ", mensajeError: "\nIngrese un DNI solo con caracteres numericos entre 1 y 99.999.999.", minimoValorInput: 1, maximoValorInput: 99999999);
            return pAlumno;
        }

        // Se crea nueva entidad de alumno dentro del metodo para evitar que mande un id que no corresponde causando una excepcion.
        public static Entidades.Alumnos ModificarDatosAlumno(Entidades.Alumnos pAlumno = null)
        {
            if (pAlumno != null)
            {
                pAlumno = AgregarDatosAlumno(pAlumno);
            }

            return pAlumno;
        }

        public static void AgregarCarrera()
        {
            throw new NotImplementedException();
        }

        public static Entidades.Carreras AgregarDatosCarrera()
        {
            //foreach (Entidades.Carreras carreras in Logica.Carrera.ListarTodas())
            //{
            //    MensajeColor(mensaje: $"\nID: {carreras.CarreraId} | Nombre: {carreras.Nombre} | Titulo: {carreras.Titulo} | Duracion estimada: {carreras.DuracionEstimadaAnios} años");
            //}
            //pAlumno.CarreraId = ValidacionNumerica(mensajeIngreso: "\nIngrese la carrera de su alumno:", mensajeError: "\nIngrese una carrera con caracteres numericos entre 0 y 7:", minimoValorInput: 0, maximoValorInput: 7, BorrarInformacion: false);
            throw new NotImplementedException();
        }

        public static void AgregarAsignatura()
        {
            InformarTodosAlumnos();

            int alumnoID = ValidacionNumerica(mensajeIngreso: "\nIndique el ID del alumno del cual quiere ingresar una o varias asignaturas:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", BorrarInformacion: false);

            int cantidad = ValidacionNumerica(mensajeIngreso: "\nCuantos asignaturas quiere ingresar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
            Entidades.Asignaturas asignatura = new Entidades.Asignaturas();

            for (int i = 0; i < cantidad; i++)
            {
                asignatura = AgregarDatosAsignatura(alumnoID, asignatura);
                Logica.Asignatura.Agregar(asignatura);
            }
        }

        public static Entidades.Asignaturas AgregarDatosAsignatura(int alumnoID, Entidades.Asignaturas pAsignatura)
        {
            foreach (Entidades.ListadoAsignaturas asignatura in Logica.ListadoAsignatura.ListarTodas())
            {
                MensajeColor(mensaje: $"\nID: {asignatura.ListadoAsignaturasId} | Codigo: {asignatura.Codigo} | Nombre: {asignatura.Nombre} | Creditos: {asignatura.Creditos} Horas: {asignatura.Horas} | Correlativas: {asignatura.Creditos} | Categoria: {asignatura.Categoria}");
            }

            pAsignatura.ListadoAsignaturasId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la materia de su alumno: ", mensajeError: $"\nValor no comprendido entre 1 y 109", minimoValorInput: 1, maximoValorInput: 109, BorrarInformacion: false);

            pAsignatura.AlumnoId = alumnoID;

            pAsignatura.Comision = ValidacionNumerica(mensajeIngreso: $"\nIngrese la comision de la materia (nombre): ", mensajeError: "\nIngrese una comision solo con caracteres numericos mayor a 0", minimoValorInput: 1);

            Console.WriteLine("\nIngrese el horario de entrada de la materia");

            int Horas = ValidacionNumerica(mensajeIngreso: "\nIngrese la hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);

            int Minutos = ValidacionNumerica(mensajeIngreso: "\nIngrese los minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);


            pAsignatura.HorarioEntrada = new TimeSpan(hours: Horas, minutes: Minutos, seconds: 0);

            Console.WriteLine("\nIngrese el horario de salida de la materia");

            Horas = ValidacionNumerica(mensajeIngreso: "\nIngrese la hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);

            Minutos = ValidacionNumerica(mensajeIngreso: "\nIngrese los minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);

            pAsignatura.HorarioSalida = new TimeSpan(hours: Horas, minutes: Minutos, seconds: 0);

            pAsignatura.Dias = ValidacionTexto(mensajeIngreso: "\nIngrese los dias de cursada de la materia (Ej: Lunes-Miercoles-Viernes):");
            // TODO Mejorar ingreso de dias.
            return pAsignatura;
        }

        public static Entidades.Asignaturas ModificarDatosAsignatura(int alumnoID, Entidades.Asignaturas pAsignatura = null)
        {
            if (pAsignatura != null)
            {
                pAsignatura = AgregarDatosAsignatura(alumnoID, pAsignatura);
            }
            return pAsignatura;
        }

        public static void AgregarNota(Entidades.Asignaturas pAsignatura)
        {
            Entidades.Notas nota = new Entidades.Notas();

            InformarTodosAlumnos();

            int alumnoID = ValidacionNumerica(mensajeIngreso: "\nElija el alumno con su ID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", BorrarInformacion: false);

            

            int asignaturaID = ValidacionNumerica(mensajeIngreso: "\nElija la asignatura con su ID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", BorrarInformacion: false);


            nota = AgregarDatosNotas(nota, pAsignatura);
            Logica.Nota.Agregar(nota);
        }

        // TODO Desglosar que nota agregar si primer parcial, segundo, recuperatorio, etc.
        public static Entidades.Notas AgregarDatosNotas(Entidades.Notas pNotas, Entidades.Asignaturas pAsignatura)
        {
            pNotas.AsignaturaId = pAsignatura.AsignaturaId;
            pNotas.PrimerParcial = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del primer parcial:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.PrimerRecuperatorio = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del primer recuperatorio:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.SegundoParcial = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del segundo parcial:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.SegundoRecuperatorio = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del segundo recuperatorio:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            pNotas.Final = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del final:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
            return pNotas;
        }

        public static Entidades.Notas ModificarDatosNotas(Entidades.Notas pNotas = null, Entidades.Asignaturas pAsignatura = null)
        {
            
            if (pNotas != null)
            {
                pNotas = AgregarDatosNotas(pNotas, pAsignatura);
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
            //Entidades.Asignaturas asignatura = new Entidades.Asignaturas();
            //Entidades.Notas notas = new Entidades.Notas();
            //Entidades.Carreras carrera = new Entidades.Carreras();
            //InformarTodosAlumnos();
            //int id = ValidacionNumerica(mensajeIngreso: "\nColoque el ID del alumno a editar", mensajeError: "El valor ingresado no puede ser 0 o menor", minimoValorInput: 0);
            //Entidades.Alumnos alumno = Logica.Alumno.ListarUno(id: id);
            //switch (ValidacionNumerica(mensajeIngreso: "\nElija que parametros quiere editar (Alumno = 1 | Carrera = 2 | Asignatura = 3 | Notas = 4 | Todos = 0)"))
            //{
            //    case 1:
            //        Console.WriteLine($"\nLos datos del alumno son Nombre: {alumno.Nombre} Apellido: {alumno.Apellido} Edad: {alumno.Edad} DNI: {alumno.DNI}");
            //        alumno = ModificarDatosAlumno(alumno);
            //        Logica.Alumno.Editar(alumno);
            //        break;
            //    case 2:
            //        Console.WriteLine("");
            //        alumno = ModicarDatosCarrera(alumno);
            //        Logica.Alumno.Editar(alumno);
            //        break;
            //    case 3:
            //        alumno = ModificarDatosAsignatura(alumno);
            //        Logica.Alumno.Editar(alumno);
            //        break;
            //    case 4:
            //        notas = ModificarDatosNotas(notas);
            //        asignatura.Nota = notas;
            //        asignaturas.Add(item: asignatura);
            //        carrera.MateriasId = asignaturas;
            //        alumno.Carrera = carrera;
            //        Logica.Alumno.Editar(alumno);
            //        break;
            //    case 5:
            //        alumno = ModificarDatosAlumno(alumno);
            //        alumno = ModicarDatosCarrera(alumno);
            //        alumno = ModificarDatosAsignatura();
            //        notas = ModificarDatosNotas(notas);
            //        asignatura.Nota = notas;
            //        asignaturas.Add(item: asignatura);
            //        carrera.MateriasId = asignaturas;
            //        alumno.Carrera = carrera;
            //        Logica.Alumno.Editar(alumno);
            //        break;
            //    default:
            //        break;
            //}
        }
        public static void InformarUnAlumno()
        {
            int id, dni;
            Entidades.Alumnos alumno;
            switch (ValidacionNumerica(mensajeIngreso: "\nIndique por cual tipo de valor quiere buscar el alumno (ID = 1 | DNI = 2)", mensajeError: "\nEl valor no esta dentro de 1 y 2.", minimoValorInput: 1, maximoValorInput: 2))
            {
                case 1:
                    id = ValidacionNumerica(mensajeIngreso: "\nIngrese el id por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumno = Logica.Alumno.ListarUno(id: id);
                    Console.WriteLine($"\nEl alumno con id {id} es\n");
                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(alumno.AlumnoId).Nombre}");
                    }
                    break;
                case 2:
                    dni = ValidacionNumerica(mensajeIngreso: "\nIngrese el dni por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumno = Logica.Alumno.ListarUno(dni: dni);
                    Console.WriteLine($"\nEl alumno con dni {dni} es\n");
                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(alumno.AlumnoId).Nombre}");
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
            List<Entidades.Alumnos> alumnos;
            switch (ValidacionNumerica(mensajeIngreso: "\nIndique por cual tipo de valor quiere buscar (ID = 1 | Carrera = 2 | Nombre = 3 | Apellido = 4 | Edad = 5 | DNI = 6)", mensajeError: "\nEl valor no esta dentro de 1 y 6.", minimoValorInput: 1, maximoValorInput: 6))
            {
                case 1:
                    id = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumnos = Logica.Alumno.ListarVarios(id: id);
                    Console.WriteLine($"\nLos alumno con ID {id} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumnos alumno in alumnos)
                        {
                            Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(Logica.Carrera.ListarUna(alumno.AlumnoId).ListadoCarrerasId).Nombre}");
                        }
                    }
                    break;
                case 2:
                    foreach (Entidades.ListadoCarreras ca in Logica.ListadoCarrera.ListarTodas())
                    {
                        MensajeColor(mensaje: $"\nID: {ca.ListadoCarrerasId} | Nombre: {ca.Nombre} | Titulo: {ca.Titulo} | Duracion estimada: {ca.DuracionEstimadaAnios} años");
                    }

                    id = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la carrera por la cual quiere buscar:", mensajeError: "El valor debe estar comprendido entre 1 y 12", minimoValorInput: 1, maximoValorInput: 12, BorrarInformacion: false);

                    alumnos = Logica.Alumno.ListarVarios(id: id);
                    Console.WriteLine($"\nLos alumno con carrera {id} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumnos alumno in alumnos)
                        {
                            Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(Logica.Carrera.ListarUna(alumno.AlumnoId).ListadoCarrerasId).Nombre}");
                        }
                    }
                    break;
                case 3:
                    nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre por el cual quiere buscar:");

                    alumnos = Logica.Alumno.ListarVarios(nombre: nombre);
                    Console.WriteLine($"\nLos alumno con nombre {nombre} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumnos alumno in alumnos)
                        {
                            Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(Logica.Carrera.ListarUna(alumno.AlumnoId).ListadoCarrerasId).Nombre}");
                        }
                    }
                    break;
                case 4:
                    apellido = ValidacionTexto(mensajeIngreso: "\nIngrese el apellido por el cual quiere buscar:");

                    alumnos = Logica.Alumno.ListarVarios(apellido: apellido);
                    Console.WriteLine($"\nLos alumno con apellido {apellido} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumnos alumno in alumnos)
                        {
                            Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(Logica.Carrera.ListarUna(alumno.AlumnoId).ListadoCarrerasId).Nombre}");
                        }
                    }
                    break;
                case 5:
                    edad = ValidacionNumerica(mensajeIngreso: "\nIngrese el edad por el cual quiere buscar:", mensajeError: "El valor no puede ser 12 o menor.", minimoValorInput: 12);

                    alumnos = Logica.Alumno.ListarVarios(edad: edad);
                    Console.WriteLine($"\nLos alumno con edad {edad} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumnos alumno in alumnos)
                        {
                            Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(Logica.Carrera.ListarUna(alumno.AlumnoId).ListadoCarrerasId).Nombre}");
                        }
                    }

                    break;
                case 6:
                    dni = ValidacionNumerica(mensajeIngreso: "\nIngrese el dni por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumnos = Logica.Alumno.ListarVarios(dni: dni);
                    Console.WriteLine($"\nLos alumno con dni {dni} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Console.ReadLine();
                    }
                    else
                    {
                        foreach (Entidades.Alumnos alumno in alumnos)
                        {
                            Console.WriteLine($"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(Logica.Carrera.ListarUna(alumno.AlumnoId).ListadoCarrerasId).Nombre}");
                        }
                    }
                    break;
                default:
                    break;                   
            }
        }

        public static void InformarTodosAlumnos()
        {
            List<Entidades.Alumnos> alumnos = Logica.Alumno.ListarTodos();
            Entidades.Notas nota;
            Console.WriteLine("\nTodos los alumnos:");

            if (alumnos.Count == 0)
            {
                Console.WriteLine("La lista de alumno esta vacia");
                Console.ReadLine();
            }
            else
            {
                foreach (Entidades.Alumnos alumno in alumnos)
                {
                    MensajeColor(mensaje: $"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni} | Carrera: {Logica.ListadoCarrera.ListarUna(alumno.AlumnoId).Nombre}");

                    Console.WriteLine("\nAsignaturas del alumno:");
                    foreach (Entidades.Asignaturas asignatura in Logica.Asignatura.ListarVarias(alumno.AlumnoId))
                    {
                        MensajeColor(mensaje: $"\nNombre: {Logica.ListadoAsignatura.ListarUna(asignatura.ListadoAsignaturasId)} | Comision: {asignatura.Comision} | Horario de entrada: {asignatura.HorarioEntrada} | Horario de salida: {asignatura.HorarioSalida} | Dias: {asignatura.Dias}");

                        Console.WriteLine($"\nNotas de la asignatura:");
                        nota = Logica.Nota.ListarUna(asignatura.AsignaturaId);
                        if (nota == null)
                        {
                            MensajeColor(mensaje: "\nNo hay notas para esta asignatura.", color: ConsoleColor.Red);
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\nPrimer parcial: {nota.PrimerParcial} | Primer recuperatorio: {nota.PrimerRecuperatorio} | Segundo parcial: {nota.SegundoParcial} | Segundo recuperatorio: {nota.SegundoRecuperatorio} | Final: {nota.Final}");
                        }
                    }
                }
            }
        }
        // TODO Continuar desglose de metodos informar.

        public static void InformarUnaAsignatura()
        {
            throw new NotImplementedException();
        }

        public static void InformarVariasAsignaturas()
        {
            List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarVarias();

        }

        public static void InformarTodasAsignaturas()
        {
            List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarTodas();
            Console.WriteLine("\nTodos las asignaturas:");

            if (asignaturas.Count == 0)
            {
                MensajeColor(mensaje: "\nLa lista de alumno esta vacia", color: ConsoleColor.Red);
                Console.ReadLine();
            }
            else
            {
                foreach (Entidades.Asignaturas asignatura in asignaturas)
                {
                    MensajeColor(mensaje: $"\nAsignaturaID: {asignatura.AsignaturaId} | ListadoAsignaturasID: {asignatura.ListadoAsignaturasId} | AlumnoID: {asignatura.AlumnoId} | CarreraID: {asignatura.CarreraId} | Comision: {asignatura.Comision} | HorarioEntrada: {asignatura.HorarioEntrada} | HorarioSalida: {asignatura.HorarioSalida} | Dias: {asignatura.Dias}");
                }
            }

        }

        public static void InformarUnaNota()
        {
            throw new NotImplementedException();
        }

        public static void InformarVariasNotas()
        {
            throw new NotImplementedException();
        }

        public static void InformarTodasNotas()
        {
            throw new NotImplementedException();
        }

        public static void InformarUnaCarrera()
        {
            throw new NotImplementedException();
        }

        public static void InformarVariasCarreras()
        {
            throw new NotImplementedException();
        }

        public static void InformarTodasCarreras()
        {
            throw new NotImplementedException();
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
            bool salir = true;
            bool primeraVez = false;
            do
            {
                if (primeraVez)
                {
                    Console.ReadLine();
                    Console.Clear();
                }
                primeraVez = true;
                switch (ValidacionNumerica(mensajeIngreso: "\nQue desea hacer? Elija la opcion deseada:\n\n1 = Agregar alumno.\n\n2 = Mostrar todos los alumnos.\n\n3 = Mostrar alumnos segun parametro.\n\n4 = Mostrar un alumno.\n\n5 = Agregar asignatura.\n\n6 = Mostrar todas las asignaturas.\n\n7 = Agregar nota.\n\n8 = Mostrar todas las notas.\n\n9 = Editar un alumno.\n\n10 = Eliminar un alumno.\n\n11 = Salir.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 11.", minimoValorInput: 1, maximoValorInput: 11))
                {
                    case 1:
                        AgregarAlumno();
                        break;
                    case 2:
                        InformarTodosAlumnos();                        
                        break;
                    case 3:
                        InformarVariosAlumnos();
                        break;
                    case 4:
                        InformarUnAlumno();
                        break;
                    case 5:
                        AgregarAsignatura();
                        break;
                    case 6:
                        InformarTodasAsignaturas();
                        break;
                    case 7:
                        //AgregarNota();  TODO Implementar junto a los metodos de la capa Datos y Logica.
                        break;
                    case 8:
                        InformarTodasNotas();
                        break;
                    case 9:
                        EditarAlumno();
                        break;
                    case 10:
                        //EliminarAlumno();
                        break;
                    case 11:
                        salir = false;
                        break;
                    default:
                        break;
                }

            } while (salir);
        }

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
        /// Valida si el ingreso es un numero.
        /// </summary>
        /// <param name="mensajeIngreso"></param>
        /// <param name="mensajeError"></param>
        /// <param name="colorError"></param>
        /// <param name="maximoValorInput"></param>
        /// <returns>El valor ingresado por el usuario</returns>
        public static int ValidacionNumerica(string mensajeIngreso, string mensajeError = "Valor no comprendido entre -2147483648 y 2147483647", ConsoleColor colorError = ConsoleColor.Red, int minimoValorInput = int.MinValue, int maximoValorInput = int.MaxValue, bool BorrarInformacion = true)
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
                    if (BorrarInformacion)
                    {
                        Console.Clear();
                    }
                    MensajeColor(mensaje: mensajeError, color: colorError);
                }
            } while (outputIngreso < minimoValorInput || outputIngreso > maximoValorInput);
            if (BorrarInformacion)
            {
                Console.Clear();
            }
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
                Console.WriteLine(mensajeIngreso);
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