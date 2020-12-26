using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaNetCore
{
    public static class MetodosEditar
    {
        public static void EditarAlumno()
        {
            if (Logica.Alumno.ListarTodos().Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de Alumnos esta vacia.", color: ConsoleColor.Red);
                MetodosComunes.Continuar();
            }
            else
            {
                int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantos alumnos quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
                Entidades.Alumnos alumno;
                int ID;
                string devolucionEditar;
                for (int i = 0; i < cantidad; i++)
                {
                    MetodosInformar.InformarTodosAlumnos();
                    do
                    {
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del Alumno a editar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        alumno = Logica.Alumno.ListarUno(alumnoID: ID);
                        if (alumno == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nEl alumno no existe.", color: ConsoleColor.Red);
                        }
                    } while (alumno == null);
                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Nombre: {alumno.Nombre}");
                    alumno.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNuevo Nombre:");
                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Apellido: {alumno.Apellido}");
                    alumno.Apellido = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNuevo Apellido:");
                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Edad: {alumno.Edad}");
                    alumno.Edad = (byte)MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNueva Edad:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 1.");
                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior DNI: {alumno.Dni}");
                    alumno.Dni = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNuevo DNI:", minimoValorInput: 11111111, mensajeError: "\nEl valor debe ser mayor a 11.111.111");
                    devolucionEditar = Logica.Alumno.Editar(alumno);
                    if (devolucionEditar.Contains("correctamente"))
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nEl alumno con ID: {alumno.AlumnoId} Nombre: {alumno.Nombre} Apellido: {alumno.Apellido} ha sido editado correctamente.");
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEditar}", color: ConsoleColor.Red);
                    }
                }
            }
        }

        public static void EditarAsignatura()
        {
            if (Logica.Asignatura.ListarTodas().Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de Asignaturas esta vacia", color: ConsoleColor.Red);
                MetodosComunes.Continuar();
            }
            else
            {
                int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantas asignaturas quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
                Entidades.Asignaturas asignatura;
                Entidades.ListadoAsignaturas listadoAsignatura;
                Entidades.Alumnos alumno;
                Entidades.Carreras carrera;
                int ID, horas, minutos;
                string devolucionAgregar;
                for (int i = 0; i < cantidad; i++)
                {
                    do
                    {
                        MetodosInformar.InformarTodasAsignaturas();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID de la Asignatura a editar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        asignatura = Logica.Asignatura.ListarUna(asignaturaID: ID);
                        if (asignatura == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa Asignatura no existe.", color: ConsoleColor.Red);
                        }
                    } while (asignatura == null);
                    MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Asignaturas, tablaAsociada: Enumeraciones.Tablas.Notas, id: ID);
                    if (MetodosInformar.InformarListadoAsignaturas() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nEl listado de Asignaturas esta vacio. Se debe tener al menos una asignatura en la tabla ListadoAsignaturas.", color: ConsoleColor.Red);
                        MetodosComunes.Continuar();
                    }
                    else
                    {
                        do
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\nAnterior ListadoAsignaturasID: {asignatura.ListadoAsignaturasId}");
                            ID = asignatura.ListadoAsignaturasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNuevo ListadoAsignaturasID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor que 1", borrarInformacion: false);
                            listadoAsignatura = Logica.ListadoAsignatura.ListarUna(listadoAsignaturasID: ID);
                            if (listadoAsignatura == null)
                            {
                                MetodosComunes.MensajeColor(mensaje: "\nLa Asignatura del listado no existe.", color: ConsoleColor.Red);
                            }
                        } while (listadoAsignatura == null);

                        if (MetodosInformar.InformarTodosAlumnos() == 0)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa lista de Alumnos esta vacia. Se debe tener al menos una asignatura en la tabla Alumnos.", color: ConsoleColor.Red);
                            MetodosComunes.Continuar();
                        }
                        else
                        {
                            do
                            {
                                MetodosComunes.MensajeColor(mensaje: $"\nAnterior AlumnoID: {asignatura.AlumnoId}");
                                ID = asignatura.AlumnoId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNuevo AlumnoID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor que 1", borrarInformacion: false);
                                alumno = Logica.Alumno.ListarUno(alumnoID: ID);
                                if (alumno == null)
                                {
                                    MetodosComunes.MensajeColor(mensaje: "\nEl alumno no existe.", color: ConsoleColor.Red);
                                }
                            } while (alumno == null);

                            if (MetodosInformar.InformarTodasCarreras() == 0)
                            {
                                MetodosComunes.MensajeColor(mensaje: "\nLa lista de Alumnos esta vacia. Se debe tener al menos una asignatura en la tabla Carreras.", color: ConsoleColor.Red);
                                MetodosComunes.Continuar();
                            }
                            else
                            {
                                do
                                {
                                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior CarreraID: {asignatura.CarreraId}");
                                    ID = asignatura.CarreraId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNueva CarreraID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 1.", borrarInformacion: false);
                                    carrera = Logica.Carrera.ListarUna(carreraID: ID);
                                    if (carrera == null)
                                    {
                                        MetodosComunes.MensajeColor(mensaje: "\nLa carrera no existe.", color: ConsoleColor.Red);
                                    }

                                } while (carrera == null);
                                MetodosComunes.MensajeColor(mensaje: $"\nAnterior Comision: {asignatura.Comision}");
                                asignatura.Comision = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNueva Comision:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 1.");

                                Console.WriteLine("\nIngrese el nuevo horario de entrada de la materia");
                                MetodosComunes.MensajeColor(mensaje: $"\nAnterior Hora de entrada: {asignatura.HorarioEntrada.Hours}");
                                horas = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique la nueva hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);
                                MetodosComunes.MensajeColor(mensaje: $"\nAnterior Minutos de entrada: {asignatura.HorarioEntrada.Minutes}");
                                minutos = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique los nuevos minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);
                                asignatura.HorarioEntrada = new TimeSpan(hours: horas, minutes: minutos, seconds: 0);

                                Console.WriteLine("\nIngrese el nuevo horario de salida de la materia");
                                MetodosComunes.MensajeColor(mensaje: $"\nAnterior Hora de salida: {asignatura.HorarioSalida.Hours}");
                                horas = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese la hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);
                                MetodosComunes.MensajeColor(mensaje: $"\nAnterior Minutos de salida: {asignatura.HorarioSalida.Minutes}");
                                minutos = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese los minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);

                                asignatura.HorarioSalida = new TimeSpan(hours: horas, minutes: minutos, seconds: 0);
                                MetodosComunes.MensajeColor(mensaje: $"\nAnteriores Dias: {asignatura.Dias}");
                                asignatura.Dias = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNuevos Dias:", mensajeError: "\nEl valor debe estar comprendido en Lunes-Martes-Miercoles-Jueves-Viernes-Sabado-Domingo");
                                asignatura.AsignaturaId = 0;
                                devolucionAgregar = Logica.Asignatura.Agregar(asignatura);
                                if (devolucionAgregar.Contains("no ha sido agregado"))
                                {
                                    MetodosComunes.MensajeColor(mensaje: $"\n{devolucionAgregar}", color: ConsoleColor.Red);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void EditarNota()
        {
            if (Logica.Nota.ListarTodas().Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de Notas esta vacia.", color: ConsoleColor.Red);
                MetodosComunes.Continuar();
            }
            else
            {
                int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantas notas quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
                int ID;
                string devolucionEditar;
                Entidades.Notas nota;
                for (int i = 0; i < cantidad; i++)
                {
                    do
                    {
                        MetodosInformar.InformarTodasNotas();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nElija el ID de la nota de la cual desea editar:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                        nota = Logica.Nota.ListarUna(notasID: ID);
                        if (nota == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa nota seleccionada no existe.", color: ConsoleColor.Red);
                        }
                    } while (nota == null);
                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior nota del Primer Parcial: {(nota.PrimerParcial == null ? "NULL" : nota.PrimerParcial.ToString())}");
                    nota.PrimerParcial = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nNueva nota del primer parcial (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior nota del Primer recuperatorio: {(nota.PrimerRecuperatorio == null ? "NULL" : nota.PrimerRecuperatorio.ToString())}");
                    nota.PrimerRecuperatorio = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nNueva nota del primer recuperatorio (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior nota del Segundo Parcial: {(nota.SegundoParcial == null ? "NULL" : nota.SegundoParcial.ToString())}");
                    nota.SegundoParcial = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nNueva nota del segundo parcial (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior nota del Segundo recuperatorio: {(nota.SegundoRecuperatorio == null ? "NULL" : nota.SegundoRecuperatorio.ToString())}");
                    nota.SegundoRecuperatorio = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nNueva nota del segundo recuperatorio (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior nota del Final: {(nota.Final == null ? "NULL" : nota.Final.ToString())}");
                    nota.Final = MetodosComunes.ValidacionNumericaFloat(mensajeIngreso: "\nNueva nota del final (1-10/null) Ej: 5,5:", minimoValorInput: 0, maximoValorInput: 10, mensajeError: "\nEl valor debe estar comprendido entre 1 a 10 o ser null.", borrarInformacion: false);
                    devolucionEditar = Logica.Nota.Editar(nota);
                    if (devolucionEditar.Contains("correctamente"))
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nLa nota con ID: {nota.NotasId} de la asignatura con ID: {nota.AsignaturaId} ha sido editada correctamente.");
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEditar}", color: ConsoleColor.Red);
                    }
                }
            }
        }
        public static void EditarListadoCarrera()
        {
            if (Logica.ListadoCarrera.ListarTodas().Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nEl listado de carreras esta vacio.", color: ConsoleColor.Red);
                MetodosComunes.Continuar();
            }
            else
            {
                int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantas carreras del listado quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
                int ID;
                string devolucionEditar;
                Entidades.ListadoCarreras listadoCarrera;
                for (int i = 0; i < cantidad; i++)
                {
                    do
                    {
                        MetodosInformar.InformarListadoCarreras();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nElija el ID de la carrera del listado de la cual desea editar:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                        listadoCarrera = Logica.ListadoCarrera.ListarUna(listadoCarrerasID: ID);
                        if (listadoCarrera == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa carrera del listado seleccionada no existe.", color: ConsoleColor.Red);
                        }
                    } while (listadoCarrera == null);

                    do
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nAnterior FacultadID: {listadoCarrera.FacultadId}");
                        MetodosInformar.InformarTodasFacultades();
                        listadoCarrera.FacultadId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese el ID de la facultad de la carrera", minimoValorInput: 1, maximoValorInput: 13, mensajeError: "\nEl valor debe estar comprendido entre 1 y 13.", borrarInformacion: false);
                        listadoCarrera = Logica.ListadoCarrera.ListarUna(listadoCarrerasID: ID);
                        if (listadoCarrera == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa carrera del listado seleccionada no existe.", color: ConsoleColor.Red);
                        }
                    } while (listadoCarrera == null);

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Nombre: {listadoCarrera.Nombre}");
                    listadoCarrera.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el nombre de la carrera:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Titulo: {listadoCarrera.Titulo}");
                    listadoCarrera.Titulo = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIngrese el titulo de la carrera:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Duracion Estimada en Años: {(listadoCarrera.DuracionEstimadaAnios == null ? "NULL" : listadoCarrera.DuracionEstimadaAnios.ToString())}");

                    listadoCarrera.DuracionEstimadaAnios = MetodosComunes.ValidacionNumericaFloatNull(mensajeIngreso: "\nIngrese la duracion estimada en años en formato decimal o null:", maximoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 0 y en formato decimal Ej: 5,5 o ser null");

                    devolucionEditar = Logica.ListadoCarrera.Editar(listadoCarrera);
                    if (devolucionEditar.Contains("correctamente"))
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nLa carrera del listado con ID: {listadoCarrera.ListadoCarrerasId} y con Nombre: {listadoCarrera.Nombre} ha sido editada correctamente.");
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEditar}", color: ConsoleColor.Red);
                    }
                }
            }

        }
        public static void EditarListadoAsignatura()
        {
            if (Logica.ListadoAsignatura.ListarTodas().Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nEl listado de asignaturas esta vacio.", color: ConsoleColor.Red);
                MetodosComunes.Continuar();
            }
            else
            {
                int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantas asignaturas del listado quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
                int ID;
                string devolucionEditar;
                Entidades.ListadoAsignaturas listadoAsignatura;
                for (int i = 0; i < cantidad; i++)
                {
                    Entidades.ListadoCarreras listadoCarrera = new Entidades.ListadoCarreras();
                    do
                    {
                        MetodosInformar.InformarListadoCarreras();
                        listadoCarrera.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nElija el ID de la carrera a la cual pertenece la asignatura a editar:", mensajeError: "\nEl valor debe ser mayor a 0.", borrarInformacion: false);
                        listadoCarrera = Logica.ListadoCarrera.ListarUna(listadoCarrera.ListadoCarrerasId);
                        if (listadoCarrera == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa carrera seleccionada del listado no existe.", color: ConsoleColor.Red);
                        }
                    } while (listadoCarrera == null);
                    do
                    {
                        MetodosInformar.InformarListadoAsignaturas();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nElija el ID de la asignatura del listado de la cual desea editar:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                        listadoAsignatura = Logica.ListadoAsignatura.ListarUna(listadoAsignaturasID: ID);
                        if (listadoAsignatura == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa asignatura del listado seleccionada no existe.", color: ConsoleColor.Red);
                        }
                    } while (listadoAsignatura == null);
                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Codigo: {listadoAsignatura.Codigo}");
                    listadoAsignatura.Codigo = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNuevo codigo de la asignatura:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Nombre: {listadoAsignatura.Nombre}");
                    listadoAsignatura.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNuevo nombre de la asignatura:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Creditos: {(listadoAsignatura.Creditos == null ? "NULL" : listadoAsignatura.Creditos.ToString())}");
                    listadoAsignatura.Creditos = (byte)MetodosComunes.ValidacionNumericaIntNull(mensajeIngreso: "\nNuevos creditos de la asignatura (0-255/null):", minimoValorInput: 0, maximoValorInput: 255, mensajeError: "\nEl valor debe estar comprendido entre 0 y 255 o ser null.");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Horas: {(listadoAsignatura.Horas == null ? "NULL" : listadoAsignatura.Horas.ToString())}");
                    listadoAsignatura.Horas = (short)MetodosComunes.ValidacionNumericaIntNull(mensajeIngreso: "\nNueva cantidad de horas de la asignatura (1-32767/null):", minimoValorInput: 1, maximoValorInput: 32767, mensajeError: "\nEl valor debe estar comprendido entre 1 y 32767 o ser null.");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Correlativas: {(listadoAsignatura.Correlativas == null ? "NULL" : listadoAsignatura.Correlativas.ToString())}");
                    listadoAsignatura.Correlativas = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNuevos codigos de las asignaturas correlativas (ej: 75.10/null):");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Categoria: {listadoAsignatura.Categoria}");
                    listadoAsignatura.Categoria = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNueva categoria de la asignatura (ej: Segundo Ciclo):");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior ListadoCarrerasId: {listadoAsignatura.ListadoCarrerasId}");
                    listadoAsignatura.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNuevo el ID de la carrera:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 1.");

                    devolucionEditar = Logica.ListadoAsignatura.Editar(listadoAsignatura);
                    if (devolucionEditar.Contains("correctamente"))
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nLa asignatura del listado con ID: {listadoAsignatura.ListadoAsignaturasId} y con Nombre: {listadoAsignatura.Nombre} ha sido editada correctamente.");
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEditar}", color: ConsoleColor.Red);
                    }
                }
            }
        }
        public static void EditarFacultad()
        {
            if (Logica.Facultad.ListarTodas().Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de Facultades esta vacia.", color: ConsoleColor.Red);
                MetodosComunes.Continuar();
            }
            else
            {
                int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantas facultades quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
                int ID;
                string devolucionEditar;
                Entidades.Facultades facultad;
                for (int i = 0; i < cantidad; i++)
                {
                    do
                    {
                        MetodosInformar.InformarTodasFacultades();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nElija el ID de la facultad de la cual desea editar:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                        facultad = Logica.Facultad.ListarUna(facultadID: ID);
                        if (facultad == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa facultad seleccionada no existe.", color: ConsoleColor.Red);
                        }
                    } while (facultad == null);
                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Nombre: {facultad.Nombre}");
                    facultad.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNuevo nombre de la facultad:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Direccion: {facultad.Direccion}");
                    facultad.Direccion = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nNueva direccion de la facultad:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Telefono: {(facultad.Telefono == null ? "NULL" : facultad.Telefono.ToString())}");
                    facultad.Telefono = MetodosComunes.ValidacionNumericaIntNull(mensajeIngreso: "\nNuevo telefono de la facultad o null:", minimoValorInput: 111111, mensajeError: "\nEl valor debe ser mayor que 111111");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior DepartamentoAlumnos: {(facultad.DepartamentoAlumnos == null ? "NULL" : facultad.DepartamentoAlumnos.ToString())}");
                    facultad.DepartamentoAlumnos = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNuevo email del departamento de alumnos de la facultad o null:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Facebook: {(facultad.Facebook == null ? "NULL" : facultad.Facebook.ToString())}");
                    facultad.Facebook = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNueva pagina web del Facebook de la facultad o null:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Instagram: {(facultad.Instagram == null ? "NULL" : facultad.Instagram.ToString())}");
                    facultad.Instagram = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNueva pagina web del Instagram de la facultad o null:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Twitter: {(facultad.Twitter == null ? "NULL" : facultad.Twitter.ToString())}");
                    facultad.Twitter = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNueva pagina web del Twitter de la facultad o null:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Pagina Web: {(facultad.PaginaWeb == null ? "NULL" : facultad.PaginaWeb.ToString())}");
                    facultad.PaginaWeb = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNueva pagina web de la facultad o null:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Email: {(facultad.Email == null ? "NULL" : facultad.Email.ToString())}");
                    facultad.Email = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNuevo email de la facultad o null:");

                    MetodosComunes.MensajeColor(mensaje: $"\nAnterior Recorrido Virtual: {(facultad.RecorridoVirtual == null ? "NULL" : facultad.RecorridoVirtual.ToString())}");
                    facultad.RecorridoVirtual = MetodosComunes.ValidacionTextoNull(mensajeIngreso: "\nNuevo pagina web del recorrido virtual de la facultad o null:");
                    devolucionEditar = Logica.Facultad.Editar(facultad);
                    if (devolucionEditar.Contains("correctamente"))
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nLa facultad con ID: {facultad.FacultadId} y con Nombre: {facultad.Nombre} ha sido editada correctamente.");
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEditar}", color: ConsoleColor.Red);
                    }
                }
            }
        }
        public static void EditarCarrera()
        {
            if (Logica.Carrera.ListarTodas().Count == 0)
            {
                MetodosComunes.MensajeColor(mensaje: "\nLa lista de Carreras esta vacia", color: ConsoleColor.Red);
                MetodosComunes.Continuar();
            }
            else
            {
                string devolucionEditar;
                int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantas carreras quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
                Entidades.Alumnos alumno;
                Entidades.Carreras carrera = new Entidades.Carreras();
                Entidades.ListadoCarreras listadoCarrera = new Entidades.ListadoCarreras();
                for (int i = 0; i < cantidad; i++)
                {
                    do
                    {
                        MetodosInformar.InformarTodasCarreras();
                        carrera.CarreraId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nElija el ID de la carrera a editar:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                        carrera = Logica.Carrera.ListarUna(carreraID: carrera.CarreraId);
                        if (carrera == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa carrera seleccionado no existe.", color: ConsoleColor.Red);
                        }
                    } while (carrera == null);
                    do
                    {
                        MetodosInformar.InformarTodosAlumnos();
                        carrera.AlumnoId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNuevo ID del alumno del cual desea agregar la carrera:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser 1 o mayor.", borrarInformacion: false);
                        alumno = Logica.Alumno.ListarUno(alumnoID: carrera.AlumnoId);
                        if (alumno == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nEl alumno seleccionado no existe.", color: ConsoleColor.Red);
                        }
                    } while (alumno == null);
                    do
                    {
                        MetodosInformar.InformarListadoCarreras();
                        listadoCarrera.ListadoCarrerasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nNuevo ID de la listadoCarrera del listado del alumno:", minimoValorInput: 1, maximoValorInput: 12, mensajeError: "\nEl valor debe estar comprendido entre 1 y 12.", borrarInformacion: false);
                        listadoCarrera = Logica.ListadoCarrera.ListarUna(listadoCarrerasID: listadoCarrera.ListadoCarrerasId);
                        if (listadoCarrera == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa listadoCarrera del listado seleccionado no existe.", color: ConsoleColor.Red);
                        }
                    } while (listadoCarrera == null);
                    devolucionEditar = Logica.ListadoCarrera.Editar(listadoCarrera: listadoCarrera);
                    if (devolucionEditar.Contains("correctamente"))
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nLa carrera con CarreraID: {carrera.CarreraId} y con ListadoCarreraID: {carrera.ListadoCarrerasId} ha sido editada correctamente.");
                    }
                    else
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEditar}", color: ConsoleColor.Red);
                    }
                }
            }
        }
    }
}
