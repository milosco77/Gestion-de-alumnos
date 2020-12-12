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
// https://trycatch.me/c-optional-parameters-vs-method-overloading/ por que en projectos publicos es mejor usar sobrecarga de metodos y no parametros opcionales.

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
            MetodosComunes.MensajeColor(mensaje: "\nPresione una tecla para continuar...", color: ConsoleColor.Yellow);
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
            MetodosComunes.MensajeColor(mensaje: "\nFin del programa.", color: ConsoleColor.Magenta);
            Continuar();
            System.Environment.Exit(exitCode: 0);
        }

        public static void AgregarRegistro(Enumeraciones.Tablas elementoAgregar)
        {
            int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantos elementos de {elementoAgregar} quiere ingresar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
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
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
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
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
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
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
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
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
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
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
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
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
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
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        // TODO Desglosar que nota agregar si primer parcial, segundo, recuperatorio, etc.
        public static Notas AgregarDatosNota(Notas pNota)
        {
            InformarTodasAsignaturas();
            pNota.AsignaturaId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la asignatura de la cual desea agregar la nota:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
            pNota.PrimerParcial = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del primer parcial (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.PrimerRecuperatorio = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del primer recuperatorio (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.SegundoParcial = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del segundo parcial (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.SegundoRecuperatorio = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del segundo recuperatorio (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.Final = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del final (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            return pNota;
        }

        public static ListadoCarreras AgregarDatosListadoCarrera(ListadoCarreras pListadoCarrera)
        {
            InformarTodasFacultades();
            pListadoCarrera.FacultadId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la facultad de la carrera", minimoValorInput: 1, maximoValorInput: 13, mensajeError: "\nEl valor debe estar comprendido entre 1 y 13.", borrarInformacion: false);
            pListadoCarrera.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la carrera:");
            pListadoCarrera.Titulo = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el titulo de la carrera:");
            pListadoCarrera.DuracionEstimadaAnios = MetodosComunes.ValidacionNumericaFloatNull(mensajeIngreso: "\nIngrese la duracion estimada en años en formato decimal o null:", maximoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 0 y en formato decimal Ej: 5,5 o ser null");
            return pListadoCarrera;
        }

        public static ListadoAsignaturas AgregarDatosListadoAsignatura(ListadoAsignaturas pListadoAsignatura)
        {
            InformarListadoCarreras();
            pListadoAsignatura.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera a la cual pertenece la asignatura:", mensajeError: "\nEl valor debe ser mayor a 0.", borrarInformacion: false);
            pListadoAsignatura.Codigo = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el codigo de la asignatura:");
            pListadoAsignatura.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la asignatura:");
            pListadoAsignatura.Creditos = (byte)MetodosComunes.ValidacionNumericaIntNull(mensajeIngreso: "\nIngrese los creditos de la asignatura (0-255/null):", minimoValorInput: 0, maximoValorInput: 255, mensajeError: "\nEl valor debe estar comprendido entre 0 y 255 o ser null.");
            pListadoAsignatura.Horas = (short)MetodosComunes.ValidacionNumericaIntNull(mensajeIngreso: "\nIngrese la cantidad de horas de la asignatura (1-32767/null):", minimoValorInput: 1, maximoValorInput: 32767, mensajeError: "\nEl valor debe estar comprendido entre 1 y 32767 o ser null.");
            pListadoAsignatura.Correlativas = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese los codigos de las asignaturas correlativas (ej: 75.10/null):");
            pListadoAsignatura.Categoria = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese la categoria de la asignatura (ej: Segundo Ciclo):");
            return pListadoAsignatura;
        }

        public static Facultades AgregarDatosFacultad(Facultades pFacultad)
        {
            pFacultad.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la facultad:");
            pFacultad.Direccion = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese la direccion de la facultad:");
            pFacultad.Telefono = MetodosComunes.ValidacionNumericaIntNull(mensajeIngreso: "\nIngrese el telefono de la facultad o null:", minimoValorInput: 111111, mensajeError: "\nEl valor debe ser mayor que 111111");
            pFacultad.DepartamentoAlumnos = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese el email del departamento de alumnos de la facultad o null:");
            pFacultad.Facebook = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese el la pagina web del Facebook de la facultad o null:");
            pFacultad.Instagram = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese el la pagina web del Instagram de la facultad o null:");
            pFacultad.Twitter = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese el la pagina web del Twitter de la facultad o null:");
            pFacultad.PaginaWeb = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese la pagina web de la facultad o null:");
            pFacultad.Email = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese el email de la facultad o null:");
            pFacultad.RecorridoVirtual = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nIngrese la pagina web del recorrido virtual de la facultad o null:");
            return pFacultad;
        }

        public static Entidades.Alumnos AgregarDatosAlumno(Entidades.Alumnos pAlumno)
        {
            pAlumno.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de su alumno: ", mensajeError: "\nIngrese un nombre solo con caracteres alfabeticos.");
            pAlumno.Apellido = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el apellido de su alumno: ", mensajeError: "\nIngrese un apellido solo con caracteres alfabeticos.");
            pAlumno.Edad = (byte)MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese la edad de su alumno entre 13 y 99 años: ", mensajeError: "\nIngrese una edad solo con caracteres numericos entre 13 y 99.", minimoValorInput: 13, maximoValorInput: 99);
            pAlumno.Dni = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el DNI de su alumno: ", mensajeError: "\nIngrese un DNI solo con caracteres numericos entre 1 y 99.999.999.", minimoValorInput: 1, maximoValorInput: 99999999);
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
            pCarrera.AlumnoId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID del alumno del cual desea agregar la carrera:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
            InformarListadoCarreras();
            pCarrera.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera del alumno:", minimoValorInput: 1, maximoValorInput: 12, mensajeError: "\nEl valor debe estar comprendido entre 1 y 12.", borrarInformacion: false);
            return pCarrera;
        }

        public static Entidades.Asignaturas AgregarDatosAsignatura(Entidades.Asignaturas pAsignatura)
        {
            InformarTodasCarreras();

            pAsignatura.CarreraId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera de su alumno: ", mensajeError: $"\nValor debe ser mayor a 1.", minimoValorInput: 1, borrarInformacion: false);
            // TODO Atrapar NullReferenceException de todos los metodos GET de todas las clases y atrapar en todos los metodos Agregar de todas las clases DbUpdateException.
            pAsignatura.AlumnoId = Logica.Carrera.ListarUna(carreraID: pAsignatura.CarreraId).AlumnoId;

            InformarListadoAsignaturas();

            pAsignatura.ListadoAsignaturasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la asignatura de su alumno: ", mensajeError: $"\nValor no comprendido entre 1 y 109", minimoValorInput: 1, maximoValorInput: 109, borrarInformacion: false);

            pAsignatura.Comision = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nIngrese la comision de la asignatura ({Logica.ListadoAsignatura.ListarUna(pAsignatura.ListadoAsignaturasId).Nombre}): ", mensajeError: "\nIngrese una comision solo con caracteres numericos mayor a 0", minimoValorInput: 1);

            Console.WriteLine("\nIngrese el horario de entrada de la materia");

            int Horas = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese la hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);

            int Minutos = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese los minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);

            pAsignatura.HorarioEntrada = new TimeSpan(hours: Horas, minutes: Minutos, seconds: 0);

            Console.WriteLine("\nIngrese el horario de salida de la materia");

            Horas = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese la hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);

            Minutos = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese los minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);

            pAsignatura.HorarioSalida = new TimeSpan(hours: Horas, minutes: Minutos, seconds: 0);

            pAsignatura.Dias = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese los dias de cursada de la materia (Ej: Lunes-Miercoles-Viernes):");
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

        public static Entidades.Notas ModificarDatosNotas(Entidades.Notas pNotas = null, Entidades.Asignaturas pAsignatura = null)
        {
            
            //if (pNotas != null)
            //{
            //    pNotas = AgregarDatosNotas(pNotas, pAsignatura);
            //}
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
            switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique por cual tipo de valor quiere buscar el alumno (ID = 1 | DNI = 2)", mensajeError: "\nEl valor no esta dentro de 1 y 2.", minimoValorInput: 1, maximoValorInput: 2))
            {
                case 1:
                    id = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el id por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

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
                    dni = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el dni por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

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
            switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique por cual tipo de valor quiere buscar (ID = 1 | Nombre = 2 | Apellido = 3 | Edad = 4 | DNI = 5)", mensajeError: "\nEl valor no esta dentro de 1 y 6.", minimoValorInput: 1, maximoValorInput: 5))
            {
                case 1:
                    id = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

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
                    nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre por el cual quiere buscar:");

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
                    apellido = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el apellido por el cual quiere buscar:");

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
                    edad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el edad por el cual quiere buscar:", mensajeError: "El valor no puede ser 12 o menor.", minimoValorInput: 12);

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
                    dni = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el dni por el cual quiere buscar:", mensajeError: "El valor no puede ser 0 o menor.", minimoValorInput: 1);

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

                    MetodosComunes.MensajeColor(mensaje: $"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni}");
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
                MetodosComunes.MensajeColor(mensaje: $"\nNombre: {Logica.ListadoAsignatura.ListarUna(asignatura.ListadoAsignaturasId).Nombre} | Comision: {asignatura.Comision} | Horario de entrada: {asignatura.HorarioEntrada} | Horario de salida: {asignatura.HorarioSalida} | Dias: {asignatura.Dias}");
                InformarUnaNota(asignatura);
            }

        }

        public static void InformarTodasAsignaturas()
        {
            List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarTodas();
            Console.WriteLine("\nTodos las asignaturas:");

            if (asignaturas.Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de alumno esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Asignaturas asignatura in asignaturas)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nAsignaturaID: {asignatura.AsignaturaId} | ListadoAsignaturasID: {asignatura.ListadoAsignaturasId} | AlumnoID: {asignatura.AlumnoId} | CarreraID: {asignatura.CarreraId} | Comision: {asignatura.Comision} | HorarioEntrada: {asignatura.HorarioEntrada} | HorarioSalida: {asignatura.HorarioSalida} | Dias: {asignatura.Dias}");
                }
            }

        }

        public static void InformarUnaNota(Entidades.Asignaturas asignatura)
        {
            Console.WriteLine($"\nNotas de la asignatura - Nombre: {Logica.ListadoAsignatura.ListarUna(asignatura.ListadoAsignaturasId).Nombre}:");
            Entidades.Notas nota = Logica.Nota.ListarUna(asignatura.AsignaturaId);
            if (nota == null)
            {
                MetodosComunes.MensajeColor(mensaje: "\nNo hay notas para esta asignatura.", color: ConsoleColor.Red);
            }
            else
            {
                MetodosComunes.MensajeColor(mensaje: $"\nPrimer parcial: {nota.PrimerParcial} | Primer recuperatorio: {nota.PrimerRecuperatorio} | Segundo parcial: {nota.SegundoParcial} | Segundo recuperatorio: {nota.SegundoRecuperatorio} | Final: {nota.Final}");
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
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de notas esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Notas nota in notas)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nNotaID: {nota.NotasId} | AsignaturaID: {nota.AsignaturaId} | Primer parcial: {(nota.PrimerParcial == null ? "NULL" : nota.PrimerParcial.ToString())} | Primer recuperatorio: {(nota.PrimerRecuperatorio == null ? "NULL" : nota.PrimerRecuperatorio.ToString())} | Segundo parcial: {(nota.SegundoParcial == null ? "NULL" : nota.SegundoParcial.ToString())} | Segundo recuperatorio: {(nota.SegundoRecuperatorio == null ? "NULL" : nota.SegundoRecuperatorio.ToString())} | Final: {(nota.Final == null ? "NULL" : nota.Final.ToString())}");
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
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de carreras esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Carreras carrera in carreras)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nCarreraID: {carrera.CarreraId} | AlumnoID: {carrera.AlumnoId} | ListadoCarrerasID: {carrera.ListadoCarrerasId}");
                }
            }
        }

        public static void InformarTodasFacultades()
        {
            List<Entidades.Facultades> facultades = Logica.Facultad.ListarTodas();
            Console.WriteLine("\nTodos las facultades:");

            if (facultades.Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de facultades esta vacia", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.Facultades facultad in facultades)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nFacultadID: {facultad.FacultadId} | Nombre: {facultad.Nombre} | Direccion: {facultad.Direccion} | Telefono: {(facultad.Telefono == null ? "NULL" : facultad.Telefono.ToString())} | Departamento de Alumnos: {(facultad.DepartamentoAlumnos == null ? "NULL" : facultad.DepartamentoAlumnos.ToString())} | Facebook: {(facultad.Facebook == null ? "NULL" : facultad.Facebook.ToString())} | Instagram: {(facultad.Instagram == null ? "NULL" : facultad.Instagram.ToString())} | Twitter: {(facultad.Twitter == null ? "NULL" : facultad.Twitter.ToString())} | Pagina Web: {(facultad.PaginaWeb == null ? "NULL" : facultad.PaginaWeb.ToString())} | Email: {(facultad.Email == null ? "NULL" : facultad.Email.ToString())} | Recorrido Virtual: {(facultad.RecorridoVirtual == null ? "NULL" : facultad.RecorridoVirtual.ToString())}");
                }
            }
        }

        public static void InformarListadoCarreras()
        {
            List<Entidades.ListadoCarreras> carreras = Logica.ListadoCarrera.ListarTodas();
            Console.WriteLine("\nListado de carreras:");

            if (carreras.Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nEl listado de carreras esta vacio", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.ListadoCarreras carrera in carreras)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nListadoCarrerasID: {carrera.ListadoCarrerasId} | FacultadID: {carrera.FacultadId} | Nombre: {carrera.Nombre} | Titulo: {carrera.Titulo} | Duracion Estimada en Años: {(carrera.DuracionEstimadaAnios == null ? "NULL" : carrera.DuracionEstimadaAnios.ToString())}");
                }
            }
        }

        public static void InformarListadoAsignaturas()
        {
            List<Entidades.ListadoAsignaturas> asignaturas = Logica.ListadoAsignatura.ListarTodas();
            Console.WriteLine("\nListado de asignaturas:");

            if (asignaturas.Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nEl listado de asignaturas esta vacio", color: ConsoleColor.Red);
                Continuar();
            }
            else
            {
                foreach (Entidades.ListadoAsignaturas asignatura in asignaturas)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nListadoAsignaturasID: {asignatura.ListadoAsignaturasId} | Codigo: {asignatura.Codigo} | Nombre: {asignatura.Nombre} | Creditos: {(asignatura.Creditos == null ? "NULL" : asignatura.Creditos.ToString())} | Horas: {(asignatura.Horas == null ? "NULL" : asignatura.Horas.ToString())} | Correlativas: {(asignatura.Correlativas == null ? "NULL" : asignatura.Correlativas.ToString())} | Categoria: {asignatura.Categoria} | ListadoCarrerasID: {asignatura.ListadoCarrerasId}");
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
                switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nQue desea hacer? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Agregar.\n\n2 = Editar.\n\n3 = Eliminar.\n\n4 = Mostrar.\n\n5 = Salir.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 5.", minimoValorInput: 1, maximoValorInput: 5))
                {
                    case 1:
                        switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nQue desea agregar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumno.\n\n2 = Asignatura.\n\n3 = Carrera.\n\n4 = Facultad.\n\n5 = Asignatura al listado.\n\n6 = Carrera al listado.\n\n7 = Nota.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
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
                        switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nQue desea editar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumno.\n\n2 = Asignatura.\n\n3 = Carrera.\n\n4 = Facultad.\n\n5 = Asignatura del listado.\n\n6 = Carrera del listado.\n\n7 = Nota.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
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
                        switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nQue desea eliminar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumno.\n\n2 = Asignatura.\n\n3 = Carrera.\n\n4 = Facultad.\n\n5 = Asignatura del listado.\n\n6 = Carrera del listado.\n\n7 = Nota.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
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
                        switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nQue desea mostrar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumnos.\n\n2 = Asignaturas.\n\n3 = Carreras.\n\n4 = Facultades.\n\n5 = Asignaturas del listado.\n\n6 = Carreras del listado.\n\n7 = Notas.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
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
                    ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Carrera.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                        devolucionEliminar = Logica.Alumno.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Asignaturas:
                    InformarTodasAsignaturas();
                    ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Asignatura.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Carreras:
                    InformarTodasCarreras();
                    ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Carrera.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Facultades:
                    InformarTodasFacultades();
                    ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Facultad.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.ListadoAsignaturas:
                    InformarListadoAsignaturas();
                    ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.ListadoAsignatura.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.ListadoCarreras:
                    InformarListadoCarreras();
                    ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.ListadoCarrera.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                case Enumeraciones.Tablas.Notas:
                    InformarTodasNotas();
                    ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                                        if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asosciado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                    }
                    alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                    if (alerta == 1)
                    {
                        devolucionEliminar = Logica.Nota.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nHa decidido no borrar el registro.", color: ConsoleColor.Yellow);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}