using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaNetCore
{
    public static class MetodosAgregar
    {
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
            MetodosInformar.InformarTodasAsignaturas();
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
            MetodosInformar.InformarTodasFacultades();
            pListadoCarrera.FacultadId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la facultad de la carrera", minimoValorInput: 1, maximoValorInput: 13, mensajeError: "\nEl valor debe estar comprendido entre 1 y 13.", borrarInformacion: false);
            pListadoCarrera.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la carrera:");
            pListadoCarrera.Titulo = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el titulo de la carrera:");
            pListadoCarrera.DuracionEstimadaAnios = MetodosComunes.ValidacionNumericaFloatNull(mensajeIngreso: "\nIngrese la duracion estimada en años en formato decimal o null:", maximoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 0 y en formato decimal Ej: 5,5 o ser null");
            return pListadoCarrera;
        }

        public static ListadoAsignaturas AgregarDatosListadoAsignatura(ListadoAsignaturas pListadoAsignatura)
        {
            MetodosInformar.InformarListadoCarreras();
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
            MetodosInformar.InformarTodosAlumnos();
            pCarrera.AlumnoId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID del alumno del cual desea agregar la carrera:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
            MetodosInformar.InformarListadoCarreras();
            pCarrera.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera del alumno:", minimoValorInput: 1, maximoValorInput: 12, mensajeError: "\nEl valor debe estar comprendido entre 1 y 12.", borrarInformacion: false);
            return pCarrera;
        }

        public static Entidades.Asignaturas AgregarDatosAsignatura(Entidades.Asignaturas pAsignatura)
        {
            MetodosInformar.InformarTodasCarreras();

            pAsignatura.CarreraId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera de su alumno: ", mensajeError: $"\nValor debe ser mayor a 1.", minimoValorInput: 1, borrarInformacion: false);
            // TODO Atrapar NullReferenceException de todos los metodos GET de todas las clases y atrapar en todos los metodos Agregar de todas las clases DbUpdateException.
            pAsignatura.AlumnoId = Logica.Carrera.ListarUna(carreraID: pAsignatura.CarreraId).AlumnoId;

            MetodosInformar.InformarListadoAsignaturas();

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

        public static void AgregarFacultad()
        {

        }

        public static void AgregarAsignaturaListado()
        {

        }

        public static void AgregarCarreraListado()
        {

        }

    }
}
