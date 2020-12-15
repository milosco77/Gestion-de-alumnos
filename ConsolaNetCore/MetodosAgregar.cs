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
                    Entidades.Alumnos alumno = new Entidades.Alumnos();
                    for (int i = 0; i < cantidad; i++)
                    {
                        do
                        {
                            alumno.AlumnoId = 0;
                            alumno = AgregarDatosAlumno(alumno);
                            devolucionAgregar = Logica.Alumno.Agregar(alumno);
                            if (devolucionAgregar.Contains("no ha sido agregado"))
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                            }
                        } while (devolucionAgregar.Contains("no ha sido agregado"));
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                    }
                    break;
                case Enumeraciones.Tablas.Asignaturas:
                    Entidades.Asignaturas asignatura = new Entidades.Asignaturas(); ;
                    for (int i = 0; i < cantidad; i++)
                    {
                        do
                        {
                            asignatura.AsignaturaId = 0;
                            asignatura = AgregarDatosAsignatura(asignatura);
                            devolucionAgregar = Logica.Asignatura.Agregar(asignatura);
                            if (devolucionAgregar.Contains("no ha sido agregado"))
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                            }
                        } while (devolucionAgregar.Contains("no ha sido agregado"));
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                    }
                    break;
                case Enumeraciones.Tablas.Carreras:
                    Entidades.Carreras carrera = new Carreras();
                    for (int i = 0; i < cantidad; i++)
                    {
                        do
                        {
                            carrera.CarreraId = 0;
                            carrera = AgregarDatosCarrera(carrera);
                            devolucionAgregar = Logica.Carrera.Agregar(carrera);
                            if (devolucionAgregar.Contains("no ha sido agregado"))
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                            }
                        } while (devolucionAgregar.Contains("no ha sido agregado"));
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                    }
                    break;
                case Enumeraciones.Tablas.Facultades:
                    Entidades.Facultades facultad = new Facultades();
                    for (int i = 0; i < cantidad; i++)
                    {
                        do
                        {
                            facultad.FacultadId = 0;
                            facultad = AgregarDatosFacultad(facultad);
                            devolucionAgregar = Logica.Facultad.Agregar(facultad);
                            if (devolucionAgregar.Contains("no ha sido agregado"))
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                            }
                        } while (devolucionAgregar.Contains("no ha sido agregado"));
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");                    }
                    break;
                case Enumeraciones.Tablas.ListadoAsignaturas:
                    Entidades.ListadoAsignaturas listadoAsignatura = new ListadoAsignaturas();
                    for (int i = 0; i < cantidad; i++)
                    {
                        do
                        {
                            listadoAsignatura.ListadoAsignaturasId = 0;
                            listadoAsignatura = AgregarDatosListadoAsignatura(listadoAsignatura);
                            devolucionAgregar = Logica.ListadoAsignatura.Agregar(listadoAsignatura);
                            if (devolucionAgregar.Contains("no ha sido agregado"))
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                            }
                        } while (devolucionAgregar.Contains("no ha sido agregado"));
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                    }
                    break;
                case Enumeraciones.Tablas.ListadoCarreras:
                    Entidades.ListadoCarreras listadoCarrera = new ListadoCarreras();
                    for (int i = 0; i < cantidad; i++)
                    {
                        do
                        {
                            listadoCarrera.ListadoCarrerasId = 0;
                            listadoCarrera = AgregarDatosListadoCarrera(listadoCarrera);
                            devolucionAgregar = Logica.ListadoCarrera.Agregar(listadoCarrera);
                            if (devolucionAgregar.Contains("no ha sido agregado"))
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                            }
                        } while (devolucionAgregar.Contains("no ha sido agregado"));
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                    }
                    break;
                case Enumeraciones.Tablas.Notas:
                    Entidades.Notas nota = new Notas();
                    for (int i = 0; i < cantidad; i++)
                    {
                        do
                        {
                            nota.NotasId = 0;
                            nota = AgregarDatosNota(nota);
                            devolucionAgregar = Logica.Nota.Agregar(nota);
                            if (devolucionAgregar.Contains("no ha sido agregado"))
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                            }
                        } while (devolucionAgregar.Contains("no ha sido agregado"));
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}");
                    }
                    break;
                default:
                    break;
            }
        }
        // TODO Desglosar que nota agregar si primer parcial, segundo, recuperatorio, etc.
        public static Notas AgregarDatosNota(Notas pNota)
        {
            Entidades.Asignaturas asignatura;
            do
            {
                MetodosInformar.InformarTodasAsignaturas();
                pNota.AsignaturaId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la asignatura de la cual desea agregar la nota:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                asignatura = Logica.Asignatura.ListarUna(pNota.AsignaturaId);
                if (asignatura == null)
                {
                    MetodosComunes.MensajeColor(mensaje: "\nLa nota seleccionada no existe.", color: ConsoleColor.Red);
                }
            } while (asignatura == null);
            pNota.PrimerParcial = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del primer parcial (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.PrimerRecuperatorio = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del primer recuperatorio (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.SegundoParcial = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del segundo parcial (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.SegundoRecuperatorio = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del segundo recuperatorio (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            pNota.Final = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nIngrese la nota del final (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
            return pNota;
        }

        public static ListadoCarreras AgregarDatosListadoCarrera(ListadoCarreras pListadoCarrera)
        {
            Entidades.Facultades facultad;
            do
            {
                MetodosInformar.InformarTodasFacultades();
                pListadoCarrera.FacultadId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la facultad de la carrera", minimoValorInput: 1, maximoValorInput: 13, mensajeError: "\nEl valor debe estar comprendido entre 1 y 13.", borrarInformacion: false);
                facultad = Logica.Facultad.ListarUna(pListadoCarrera.FacultadId);
                if (facultad == null)
                {
                    MetodosComunes.MensajeColor(mensaje: "\nLa facultad seleccionada del listado no existe.", color: ConsoleColor.Red);
                }
            } while (facultad == null);
            pListadoCarrera.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la carrera:");
            pListadoCarrera.Titulo = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el titulo de la carrera:");
            pListadoCarrera.DuracionEstimadaAnios = MetodosComunes.ValidacionNumericaFloatNull(mensajeIngreso: "\nIngrese la duracion estimada en años en formato decimal o null:", maximoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 0 y en formato decimal Ej: 5,5 o ser null");
            return pListadoCarrera;
        }

        public static ListadoAsignaturas AgregarDatosListadoAsignatura(ListadoAsignaturas pListadoAsignatura)
        {
            Entidades.ListadoCarreras listadoCarrera;
            do
            {
                MetodosInformar.InformarListadoCarreras();
                pListadoAsignatura.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera a la cual pertenece la asignatura:", mensajeError: "\nEl valor debe ser mayor a 0.", borrarInformacion: false);
                listadoCarrera = Logica.ListadoCarrera.ListarUna(pListadoAsignatura.ListadoCarrerasId);
                if (listadoCarrera == null)
                {
                    MetodosComunes.MensajeColor(mensaje: "\nLa carrera seleccionada del listado no existe.", color: ConsoleColor.Red);
                }
            } while (listadoCarrera == null);
            
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
            Entidades.Alumnos alumno;
            do
            {
                MetodosInformar.InformarTodosAlumnos();
                pCarrera.AlumnoId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID del alumno del cual desea agregar la carrera:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                alumno = Logica.Alumno.ListarUno(alumnoID: pCarrera.AlumnoId);
                if (alumno == null)
                {
                    MetodosComunes.MensajeColor(mensaje: "\nEl alumno seleccionado no existe.", color: ConsoleColor.Red);
                }
            } while (alumno == null);
            MetodosInformar.InformarListadoCarreras();
            pCarrera.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera del alumno:", minimoValorInput: 1, maximoValorInput: 12, mensajeError: "\nEl valor debe estar comprendido entre 1 y 12.", borrarInformacion: false);
            return pCarrera;
        }

        public static Entidades.Asignaturas AgregarDatosAsignatura(Entidades.Asignaturas pAsignatura)
        {
            Entidades.Carreras carrera;
            do
            {
                MetodosInformar.InformarTodasCarreras();
                pAsignatura.CarreraId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la carrera de su alumno: ", mensajeError: $"\nValor debe ser mayor a 1.", minimoValorInput: 1, borrarInformacion: false);
                carrera = Logica.Carrera.ListarUna(carreraID: pAsignatura.CarreraId);
                if (carrera == null)
                {
                    MetodosComunes.MensajeColor(mensaje: "\nLa carrera seleccionada no existe.", color: ConsoleColor.Red);
                }
            } while (carrera == null);

            pAsignatura.AlumnoId = carrera.AlumnoId;
            MetodosInformar.InformarListadoAsignaturas();

            pAsignatura.ListadoAsignaturasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la asignatura de su alumno: ", mensajeError: $"\nValor debe ser 1 o mayor", minimoValorInput: 1, borrarInformacion: false);

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
    }
}
