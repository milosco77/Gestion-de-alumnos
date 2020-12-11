using Entidades;
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
            Console.WriteLine("\nFin del programa.");
            Continuar();
            System.Environment.Exit(exitCode: 0);
        }

        public static void AgregarRegistro(Enumeraciones.Tablas elementoAgregar)
        {
            int cantidad = ValidacionNumerica(mensajeIngreso: $"\nCuantos elementos de {elementoAgregar} quiere ingresar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
            string devolucionAgregar;
            switch (elementoAgregar)
            {
                case Enumeraciones.Tablas.Alumnos:
                    Entidades.Alumnos alumno;
                    for (int i = 0; i < cantidad; i++)
                    {
                        alumno = new Entidades.Alumnos();
                        alumno = AgregarDatosAlumno(alumno);
                        devolucionAgregar = Logica.Alumno.Agregar(alumno);
                        if (!devolucionAgregar.Contains("no ha sido agregado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                case Enumeraciones.Tablas.Asignaturas:
                    Entidades.Asignaturas asignatura;
                    for (int i = 0; i < cantidad; i++)
                    {
                        asignatura = new Entidades.Asignaturas();
                        asignatura = AgregarDatosAsignatura(asignatura);
                        devolucionAgregar = Logica.Asignatura.Agregar(asignatura);
                        if (!devolucionAgregar.Contains("no ha sido agregado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                case Enumeraciones.Tablas.Carreras:
                    Entidades.Carreras carrera;
                    for (int i = 0; i < cantidad; i++)
                    {
                        carrera = new Entidades.Carreras();
                        carrera = AgregarDatosCarrera(carrera);
                        devolucionAgregar = Logica.Carrera.Agregar(carrera);
                        if (!devolucionAgregar.Contains("no ha sido agregado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                case Enumeraciones.Tablas.Facultades:
                    Entidades.Facultades facultad;
                    for (int i = 0; i < cantidad; i++)
                    {
                        facultad = new Entidades.Facultades();
                        facultad = AgregarDatosFacultad(facultad);
                        devolucionAgregar = Logica.Facultad.Agregar(facultad);
                        if (!devolucionAgregar.Contains("no ha sido agregado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                case Enumeraciones.Tablas.ListadoAsignaturas:
                    Entidades.ListadoAsignaturas listadoAsignatura;
                    for (int i = 0; i < cantidad; i++)
                    {
                        listadoAsignatura = new Entidades.ListadoAsignaturas();
                        listadoAsignatura = AgregarDatosListadoAsignatura(listadoAsignatura);
                        devolucionAgregar = Logica.ListadoAsignatura.Agregar(listadoAsignatura);
                        if (!devolucionAgregar.Contains("no ha sido agregado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                case Enumeraciones.Tablas.ListadoCarreras:
                    Entidades.ListadoCarreras listadoCarrera;
                    for (int i = 0; i < cantidad; i++)
                    {
                        listadoCarrera = new Entidades.ListadoCarreras();
                        listadoCarrera = AgregarDatosListadoCarrera(listadoCarrera);
                        devolucionAgregar = Logica.ListadoCarrera.Agregar(listadoCarrera);
                        if (!devolucionAgregar.Contains("no ha sido agregado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                case Enumeraciones.Tablas.Notas:
                    Entidades.Notas nota;
                    for (int i = 0; i < cantidad; i++)
                    {
                        nota = new Entidades.Notas();
                        nota = AgregarDatosNota(nota);
                        devolucionAgregar = Logica.Nota.Agregar(nota);
                        if (!devolucionAgregar.Contains("no ha sido agregado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public static Notas AgregarDatosNota(Notas pNota)
        {
            InformarTodasAsignaturas();
            pNota.AsignaturaId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la asignatura de la cual desea agregar la nota:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", BorrarInformacion: false);
            pNota.PrimerParcial = ValidacionNumerica(mensajeIngreso: "\nIngrese la nota del primer parcial (1-10):", minimoValorInput: 1, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10.", BorrarInformacion: false);
            pNota.PrimerRecuperatorio = ValidacionNumerica(mensajeIngreso: "\nIngrese la nota del primer recuperatorio (1-10):", minimoValorInput: 1, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10.", BorrarInformacion: false);
            pNota.SegundoParcial = ValidacionNumerica(mensajeIngreso: "\nIngrese la nota del segundo parcial (1-10):", minimoValorInput: 1, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10.", BorrarInformacion: false);
            pNota.SegundoRecuperatorio = ValidacionNumerica(mensajeIngreso: "\nIngrese la nota del segundo recuperatorio (1-10):", minimoValorInput: 1, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10.", BorrarInformacion: false);
            pNota.Final = ValidacionNumerica(mensajeIngreso: "\nIngrese la nota del final (1-10):", minimoValorInput: 1, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10.", BorrarInformacion: false);
            return pNota;
        }

        public static ListadoCarreras AgregarDatosListadoCarrera(ListadoCarreras pListadoCarrera)
        {
            InformarTodasFacultades();
            pListadoCarrera.FacultadId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la facultad de la carrera", minimoValorInput: 1, maximoValorInput: 13, mensajeError: "\nEl valor debe estar comprendido entre 1 y 13.", BorrarInformacion: false);
            pListadoCarrera.Nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la carrera:");
            pListadoCarrera.Titulo = ValidacionTexto(mensajeIngreso: "\nIngrese el titulo de la carrera:");
            pListadoCarrera.DuracionEstimadaAnios = ValidacionNumerica(mensajeIngreso: "\nIngrese la duracion estimada en años en formato decimal:", maximoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 0 y en formato decimal Ej: 5.5.");
            return pListadoCarrera;
        }

        public static ListadoAsignaturas AgregarDatosListadoAsignatura(ListadoAsignaturas pListadoAsignatura)
        {
            InformarListadoCarreras();
            pListadoAsignatura.ListadoCarrerasId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la carrera a la cual pertenece la asignatura:", mensajeError: "\nEl valor debe ser mayor a 0.", BorrarInformacion: false);
            pListadoAsignatura.Codigo = ValidacionTexto(mensajeIngreso: "\nIngrese el codigo de la asignatura:");
            pListadoAsignatura.Nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la asignatura:");
            pListadoAsignatura.Creditos = (byte)ValidacionNumerica(mensajeIngreso: "\nIngrese los creditos de la asignatura:", minimoValorInput: 0, maximoValorInput: 255, mensajeError: "\nEl valor debe estar comprendido entre 0 y 255.");
            pListadoAsignatura.Horas = (short)ValidacionNumerica(mensajeIngreso: "\nIngrese la cantidad de horas de la asignatura:", minimoValorInput: 1, maximoValorInput: 32767, mensajeError: "\nEl valor debe estar comprendido entre 1 y 32767.");
            pListadoAsignatura.Correlativas = ValidacionTexto(mensajeIngreso: "\nIngrese los codigos de las asignaturas correlativas (ej: 75.10):");
            pListadoAsignatura.Categoria = ValidacionTexto(mensajeIngreso: "\nIngrese la categoria de la asignatura (ej: Segundo Ciclo):");
            return pListadoAsignatura;
        }

        public static Facultades AgregarDatosFacultad(Facultades pFacultad)
        {
            pFacultad.Nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la facultad:");
            pFacultad.Direccion = ValidacionTexto(mensajeIngreso: "\nIngrese la direccion de la facultad:");
            pFacultad.Telefono = ValidacionNumerica(mensajeIngreso: "\nIngrese el telefono de la facultad:", minimoValorInput: 111111, mensajeError: "\nEl valor debe ser mayor que 111111");
            pFacultad.DepartamentoAlumnos = ValidacionTexto(mensajeIngreso: "\nIngrese el email del departamento de alumnos de la facultad:");
            pFacultad.Facebook = ValidacionTexto(mensajeIngreso: "\nIngrese el la pagina web del Facebook de la facultad:");
            pFacultad.Instagram = ValidacionTexto(mensajeIngreso: "\nIngrese el la pagina web del Instagram de la facultad:");
            pFacultad.Twitter = ValidacionTexto(mensajeIngreso: "\nIngrese el la pagina web del Twitter de la facultad:");
            pFacultad.PaginaWeb = ValidacionTexto(mensajeIngreso: "\nIngrese la pagina web de la facultad:");
            pFacultad.Email = ValidacionTexto(mensajeIngreso: "\nIngrese el email de la facultad:");
            pFacultad.RecorridoVirtual = ValidacionTexto(mensajeIngreso: "\nIngrese la pagina web del recorrido virtual de la facultad:");
            return pFacultad;
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

        public static Entidades.Carreras AgregarDatosCarrera(Entidades.Carreras pCarrera)
        {
            InformarTodosAlumnos();
            pCarrera.AlumnoId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID del alumno del cual desea agregar la carrera:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", BorrarInformacion: false);
            InformarListadoCarreras();
            pCarrera.ListadoCarrerasId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la carrera del alumno:", minimoValorInput: 1, maximoValorInput: 12, mensajeError: "\nEl valor debe estar comprendido entre 1 y 12.", BorrarInformacion: false);
            return pCarrera;
        }

        public static void AgregarAsignatura()
        {
            //InformarTodosAlumnos();

            //int cantidad = ValidacionNumerica(mensajeIngreso: "\nCuantos asignaturas quiere ingresar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
            //Entidades.Asignaturas asignatura = new Entidades.Asignaturas();

            //for (int i = 0; i < cantidad; i++)
            //{
            //    asignatura = AgregarDatosAsignatura(asignatura);
            //    Logica.Asignatura.Agregar(asignatura);
            //    AgregarNota(asignatura, notaNula: true);
            //}
        }

        public static Entidades.Asignaturas AgregarDatosAsignatura(Entidades.Asignaturas pAsignatura)
        {
            InformarTodasCarreras();

            pAsignatura.CarreraId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la carrera de su alumno: ", mensajeError: $"\nValor debe ser mayor a 1.", minimoValorInput: 1, BorrarInformacion: false);
            // TODO Atrapar NullReferenceException de todos los metodos GET de todas las clases y atrapar en todos los metodos Agregar de todas las clases DbUpdateException.
            pAsignatura.AlumnoId = Logica.Carrera.ListarUna(carreraID: pAsignatura.CarreraId).AlumnoId;

            InformarListadoAsignaturas();

            pAsignatura.ListadoAsignaturasId = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID de la asignatura de su alumno: ", mensajeError: $"\nValor no comprendido entre 1 y 109", minimoValorInput: 1, maximoValorInput: 109, BorrarInformacion: false);

            pAsignatura.Comision = ValidacionNumerica(mensajeIngreso: $"\nIngrese la comision de la asignatura ({Logica.ListadoAsignatura.ListarUna(pAsignatura.ListadoAsignaturasId).Nombre}): ", mensajeError: "\nIngrese una comision solo con caracteres numericos mayor a 0", minimoValorInput: 1);

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

        public static Entidades.Asignaturas ModificarDatosAsignatura(int alumnoID, Entidades.Asignaturas pAsignatura)
        {
            if (pAsignatura != null)
            {
                pAsignatura = AgregarDatosAsignatura(pAsignatura);
            }
            return pAsignatura;
        }
#nullable enable
        public static void AgregarNota(Entidades.Asignaturas pAsignatura, bool notaNula = false)
        {
            Entidades.Notas nota = new Entidades.Notas();
            if (notaNula)
            {
                nota = AgregarDatosNotas(nota, pAsignatura, notaNula: true);
                Logica.Nota.Agregar(nota);
            }
            else
            {
                nota = AgregarDatosNotas(nota, pAsignatura);
                Logica.Nota.Agregar(nota);
            }
        }

        // TODO Desglosar que nota agregar si primer parcial, segundo, recuperatorio, etc.
        public static Entidades.Notas AgregarDatosNotas(Entidades.Notas pNotas, Entidades.Asignaturas pAsignatura, bool notaNula = false)
        {
            // TODO Resolver problema de que da un error de SQLException por conflicto con AsignaturaId
            pNotas.AsignaturaId = pAsignatura.AsignaturaId;
            if (notaNula)
            {
                pNotas.PrimerParcial = null;
                pNotas.PrimerRecuperatorio = null;
                pNotas.SegundoParcial = null;
                pNotas.SegundoRecuperatorio = null;
                pNotas.Final = null;
                return pNotas;
            }
            else
            {
                pNotas.PrimerParcial = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del primer parcial:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
                pNotas.PrimerRecuperatorio = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del primer recuperatorio:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
                pNotas.SegundoParcial = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del segundo parcial:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
                pNotas.SegundoRecuperatorio = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del segundo recuperatorio:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
                pNotas.Final = ValidacionNumerica(mensajeIngreso: $"\nIngrese la nota del final:", mensajeError: "\nEl valor de nota debe estar comprendido entre 0 y 10.", minimoValorInput: 0, maximoValorInput: 10);
                return pNotas;
            }
        }
#nullable disable
        public static Entidades.Notas ModificarDatosNotas(Entidades.Notas pNotas = null, Entidades.Asignaturas pAsignatura = null)
        {
            
            if (pNotas != null)
            {
                pNotas = AgregarDatosNotas(pNotas, pAsignatura);
            }
            return pNotas;
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

                    alumno = Logica.Alumno.ListarUno(alumnoID: id);
                    Console.WriteLine($"\nEl alumno con id {id} es\n");
                    if (alumno == null)
                    {
                        Console.WriteLine("No se encuentra el alumno con ese valor.");
                        Continuar();
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
                        Continuar();
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
            switch (ValidacionNumerica(mensajeIngreso: "\nIndique por cual tipo de valor quiere buscar (ID = 1 | Nombre = 2 | Apellido = 3 | Edad = 4 | DNI = 5)", mensajeError: "\nEl valor no esta dentro de 1 y 6.", minimoValorInput: 1, maximoValorInput: 5))
            {
                case 1:
                    id = ValidacionNumerica(mensajeIngreso: "\nIngrese el ID por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumnos = Logica.Alumno.ListarVarios(alumnoID: id);
                    Console.WriteLine($"\nLos alumno con ID {id} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Continuar();
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
                    nombre = ValidacionTexto(mensajeIngreso: "\nIngrese el nombre por el cual quiere buscar:");

                    alumnos = Logica.Alumno.ListarVarios(nombre: nombre);
                    Console.WriteLine($"\nLos alumno con nombre {nombre} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Continuar();
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
                    apellido = ValidacionTexto(mensajeIngreso: "\nIngrese el apellido por el cual quiere buscar:");

                    alumnos = Logica.Alumno.ListarVarios(apellido: apellido);
                    Console.WriteLine($"\nLos alumno con apellido {apellido} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Continuar();
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
                    edad = ValidacionNumerica(mensajeIngreso: "\nIngrese el edad por el cual quiere buscar:", mensajeError: "El valor no puede ser 12 o menor.", minimoValorInput: 12);

                    alumnos = Logica.Alumno.ListarVarios(edad: edad);
                    Console.WriteLine($"\nLos alumno con edad {edad} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Continuar();
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
                    dni = ValidacionNumerica(mensajeIngreso: "\nIngrese el dni por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

                    alumnos = Logica.Alumno.ListarVarios(dni: dni);
                    Console.WriteLine($"\nLos alumno con dni {dni} son:\n");

                    if (alumnos.Count == 0)
                    {
                        Console.WriteLine("La lista de alumno esta vacia");
                        Continuar();
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
            int contador = 0;
            List<Entidades.Alumnos> alumnos = Logica.Alumno.ListarTodos();
            Console.WriteLine("\nTodos los alumnos:");
            if (alumnos.Count == 0)
            {
                Console.WriteLine("La lista de alumno esta vacia");
                Continuar();
            }
            else
            {
                foreach (Entidades.Alumnos alumno in Logica.Alumno.ListarTodos())
                {
                    Console.WriteLine($"\nAlumno Nº {(contador++)+1}");

                    MensajeColor(mensaje: $"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni}");
                }
            }
        }
        // TODO Continuar desglose de metodos informar.

        public static void InformarUnaAsignatura()
        {
            throw new NotImplementedException();
        }

        public static void InformarVariasAsignaturas(Entidades.Alumnos alumno)
        {
            List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarVarias(alumno.AlumnoId);

            Console.WriteLine($"\nAsignaturas del alumno - Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido}:");
            foreach (Entidades.Asignaturas asignatura in asignaturas)
            {
                MensajeColor(mensaje: $"\nNombre: {Logica.ListadoAsignatura.ListarUna(asignatura.ListadoAsignaturasId).Nombre} | Comision: {asignatura.Comision} | Horario de entrada: {asignatura.HorarioEntrada} | Horario de salida: {asignatura.HorarioSalida} | Dias: {asignatura.Dias}");
                InformarUnaNota(asignatura);
            }

        }

        public static void InformarTodasAsignaturas()
        {
            List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarTodas();
            Console.WriteLine("\nTodos las asignaturas:");

            if (asignaturas.Count == 0)
            {
                MensajeColor(mensaje: "\nLa lista de alumno esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Asignaturas asignatura in asignaturas)
                {
                    MensajeColor(mensaje: $"\nAsignaturaID: {asignatura.AsignaturaId} | ListadoAsignaturasID: {asignatura.ListadoAsignaturasId} | AlumnoID: {asignatura.AlumnoId} | CarreraID: {asignatura.CarreraId} | Comision: {asignatura.Comision} | HorarioEntrada: {asignatura.HorarioEntrada} | HorarioSalida: {asignatura.HorarioSalida} | Dias: {asignatura.Dias}");
                }
            }

        }

        public static void InformarUnaNota(Entidades.Asignaturas asignatura)
        {
            Console.WriteLine($"\nNotas de la asignatura - Nombre: {Logica.ListadoAsignatura.ListarUna(asignatura.ListadoAsignaturasId).Nombre}:");
            Entidades.Notas nota = Logica.Nota.ListarUna(asignatura.AsignaturaId);
            if (nota == null)
            {
                MensajeColor(mensaje: "\nNo hay notas para esta asignatura.", color: ConsoleColor.Red);
            }
            else
            {
                MensajeColor(mensaje: $"\nPrimer parcial: {nota.PrimerParcial} | Primer recuperatorio: {nota.PrimerRecuperatorio} | Segundo parcial: {nota.SegundoParcial} | Segundo recuperatorio: {nota.SegundoRecuperatorio} | Final: {nota.Final}");
            }
        }

        public static void InformarVariasNotas()
        {
            throw new NotImplementedException();
        }

        public static void InformarTodasNotas()
        {
            List<Entidades.Notas> notas = Logica.Nota.ListarTodas();
            Console.WriteLine("\nTodos las notas:");

            if (notas.Count == 0)
            {
                MensajeColor(mensaje: "\nLa lista de notas esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Notas nota in notas)
                {
                    MensajeColor(mensaje: $"\nNotaID: {nota.NotasId} | AsignaturaID: {nota.AsignaturaId} | Primer parcial: {nota.PrimerParcial} | Primer recuperatorio: {nota.PrimerRecuperatorio} | Segundo parcial: {nota.SegundoParcial} | Segundo recuperatorio: {nota.SegundoRecuperatorio} | Final: {nota.Final}");
                }
            }
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
            List<Entidades.Carreras> carreras = Logica.Carrera.ListarTodas();
            Console.WriteLine("\nTodos las carreras:");

            if (carreras.Count == 0)
            {
                MensajeColor(mensaje: "\nLa lista de carreras esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Carreras carrera in carreras)
                {
                    MensajeColor(mensaje: $"\nCarreraID: {carrera.CarreraId} | AlumnoID: {carrera.AlumnoId} | ListadoCarrerasID: {carrera.ListadoCarrerasId}");
                }
            }
        }

        public static void InformarTodasFacultades()
        {
            List<Entidades.Facultades> facultades = Logica.Facultad.ListarTodas();
            Console.WriteLine("\nTodos las facultades:");

            if (facultades.Count == 0)
            {
                MensajeColor(mensaje: "\nLa lista de facultades esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Facultades facultad in facultades)
                {
                    MensajeColor(mensaje: $"\nFacultadID: {facultad.FacultadId} | Nombre: {facultad.Nombre} | Direccion: {facultad.Direccion} | Telefono: {facultad.Telefono} | Departamento de Alumnos: {facultad.DepartamentoAlumnos} | Facebook: {facultad.Facebook} | Instagram: {facultad.Instagram} | Twitter: {facultad.Twitter} | Pagina Web: {facultad.PaginaWeb} | Email: {facultad.Email} | Recorrido Virtual: {facultad.RecorridoVirtual}");
                }
            }
        }

        public static void InformarListadoCarreras()
        {
            List<Entidades.ListadoCarreras> carreras = Logica.ListadoCarrera.ListarTodas();
            Console.WriteLine("\nListado de carreras:");

            if (carreras.Count == 0)
            {
                MensajeColor(mensaje: "\nEl listado de carreras esta vacio", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.ListadoCarreras carrera in carreras)
                {
                    MensajeColor(mensaje: $"\nListadoCarrerasID: {carrera.ListadoCarrerasId} | FacultadID: {carrera.FacultadId} | Nombre: {carrera.Nombre} | Titulo: {carrera.Titulo} | Duracion Estimada en Años: {carrera.DuracionEstimadaAnios}");
                }
            }
        }

        public static void InformarListadoAsignaturas()
        {
            List<Entidades.ListadoAsignaturas> asignaturas = Logica.ListadoAsignatura.ListarTodas();
            Console.WriteLine("\nListado de asignaturas:");

            if (asignaturas.Count == 0)
            {
                MensajeColor(mensaje: "\nEl listado de asignaturas esta vacio", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.ListadoAsignaturas asignatura in asignaturas)
                {
                    MensajeColor(mensaje: $"\nListadoAsignaturasID: {asignatura.ListadoAsignaturasId} | Codigo: {asignatura.Codigo} | Nombre: {asignatura.Nombre} | Creditos: {asignatura.Creditos} | Horas: {asignatura.Horas} | Correlativas: {asignatura.Correlativas} | Categoria: {asignatura.Categoria} | ListadoCarrerasID: {asignatura.ListadoCarrerasId}");
                }
            }
        }

        public static void AgregarFacultad()
        {

        }

        public static void AgregarAsignaturaListado()
        {

        }

        public static void AgregarCarreraListado()
        {

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
                    Continuar();
                    Console.Clear();
                }
                primeraVez = true;
                switch (ValidacionNumerica(mensajeIngreso: "\nQue desea hacer? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Agregar.\n\n2 = Editar.\n\n3 = Eliminar.\n\n4 = Mostrar.\n\n5 = Salir.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 5.", minimoValorInput: 1, maximoValorInput: 5))
                {
                    case 1:
                        switch (ValidacionNumerica(mensajeIngreso: "\nQue desea agregar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumno.\n\n2 = Asignatura.\n\n3 = Carrera.\n\n4 = Facultad.\n\n5 = Asignatura al listado.\n\n6 = Carrera al listado.\n\n7 = Nota.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
                            {
                            case 1:
                                AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Alumnos);
                                break;
                            case 2:
                                AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Asignaturas);
                                break;
                            case 3:
                                AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Carreras);
                                break;
                            case 4:
                                AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Facultades);
                                break;
                            case 5:
                                AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.ListadoAsignaturas);
                                break;
                            case 6:
                                AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.ListadoCarreras);
                                break;
                            case 7:
                                AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Notas);
                                break;
                            default:
                                primeraVez = false;
                                break;
                        }
                        break;
                    case 2:
                        switch (ValidacionNumerica(mensajeIngreso: "\nQue desea editar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumno.\n\n2 = Asignatura.\n\n3 = Carrera.\n\n4 = Facultad.\n\n5 = Asignatura del listado.\n\n6 = Carrera del listado.\n\n7 = Nota.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
                        {
                            case 1:
                                EditarAlumno();
                                break;
                            case 2:
                                EditarAsignatura();
                                break;
                            case 3:
                                EditarCarrera();
                                break;
                            case 4:
                                EditarFacultad();
                                break;
                            case 5:
                                EditarAsignaturaListado();
                                break;
                            case 6:
                                EditarCarreraListado();
                                break;
                            case 7:
                                EditarNota();
                                break;
                            default:
                                primeraVez = false;
                                break;
                        }
                        break;
                    case 3:
                        switch (ValidacionNumerica(mensajeIngreso: "\nQue desea eliminar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumno.\n\n2 = Asignatura.\n\n3 = Carrera.\n\n4 = Facultad.\n\n5 = Asignatura del listado.\n\n6 = Carrera del listado.\n\n7 = Nota.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
                        {
                            case 1:
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Alumnos, tablaAsociada: Enumeraciones.Tablas.Carreras);
                                break;
                            case 2:
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Asignaturas);
                                break;
                            case 3:
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Carreras);
                                break;
                            case 4:
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Facultades);
                                break;
                            case 5:
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.ListadoAsignaturas);
                                break;
                            case 6:
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.ListadoCarreras);
                                break;
                            case 7:
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Notas);
                                break;
                            default:
                                primeraVez = false;
                                break;
                        }
                        break;
                    case 4:
                        switch (ValidacionNumerica(mensajeIngreso: "\nQue desea mostrar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumnos.\n\n2 = Asignaturas.\n\n3 = Carreras.\n\n4 = Facultades.\n\n5 = Asignaturas del listado.\n\n6 = Carreras del listado.\n\n7 = Notas.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
                        {
                            case 1:
                                InformarTodosAlumnos();
                                break;
                            case 2:
                                InformarTodasAsignaturas();
                                break;
                            case 3:
                                InformarTodasCarreras();
                                break;
                            case 4:
                                InformarTodasFacultades();
                                break;
                            case 5:
                                InformarListadoAsignaturas();
                                break;
                            case 6:
                                InformarListadoCarreras();
                                break;
                            case 7:
                                InformarTodasNotas();
                                break;
                            default:
                                primeraVez = false;
                                break;
                        }
                        break;
                    default:
                        salir = false;
                        break;
                }

            } while (salir);
        }

        public static void EditarNota()
        {
            throw new NotImplementedException();
        }

        public static void EditarCarreraListado()
        {
            throw new NotImplementedException();
        }

        public static void EditarAsignaturaListado()
        {
            throw new NotImplementedException();
        }

        public static void EditarFacultad()
        {
            throw new NotImplementedException();
        }

        public static void EditarCarrera()
        {
            throw new NotImplementedException();
        }

        public static void EditarAsignatura()
        {
            throw new NotImplementedException();
        }

        public static void EliminarRegistro(Enumeraciones.Tablas elementoABorrar, Enumeraciones.Tablas? tablaAsociada = null)
        {
            int ID, alerta;
            string devolucionEliminar;
            switch (elementoABorrar)
            {
                case Enumeraciones.Tablas.Alumnos:
                    InformarTodosAlumnos();
                    ID = ValidacionNumerica(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, BorrarInformacion: false);
                    if (tablaAsociada != null)
                    {
                        MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = ValidacionNumerica(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Carrera.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                        devolucionEliminar = Logica.Alumno.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Asignaturas:
                    InformarTodasAsignaturas();
                    ID = ValidacionNumerica(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, BorrarInformacion: false);
                    if (tablaAsociada != null)
                    {
                        MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = ValidacionNumerica(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Asignatura.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Carreras:
                    InformarTodasCarreras();
                    ID = ValidacionNumerica(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, BorrarInformacion: false);
                    if (tablaAsociada != null)
                    {
                        MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = ValidacionNumerica(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Carrera.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Facultades:
                    InformarTodasFacultades();
                    ID = ValidacionNumerica(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, BorrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = ValidacionNumerica(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Facultad.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.ListadoAsignaturas:
                    InformarListadoAsignaturas();
                    ID = ValidacionNumerica(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, BorrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = ValidacionNumerica(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.ListadoAsignatura.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.ListadoCarreras:
                    InformarListadoCarreras();
                    ID = ValidacionNumerica(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, BorrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = ValidacionNumerica(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.ListadoCarrera.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Notas:
                    InformarTodasNotas();
                    ID = ValidacionNumerica(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, BorrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = ValidacionNumerica(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Nota.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
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
        // TODO Arreglar inclusion de float en el metodo
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
        // TODO Arreglar inclusion de caso en el que se incluya una direccion que toma valor numerico o simbolo al final
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