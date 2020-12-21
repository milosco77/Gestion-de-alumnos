using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaNetCore
{
    public static class MetodosEditar
    {
        public static void EditarAlumno()
        {
            int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantos alumnos quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
            Entidades.Alumnos alumno;
            int ID;
            string devolucionEditar;
            for (int i = 0; i < cantidad; i++)
            {
                if (MetodosInformar.InformarTodosAlumnos() == 0)
                {
                    MetodosComunes.MensajeColor(mensaje: "\nLa lista de Alumnos esta vacia", color: ConsoleColor.Red);
                    MetodosComunes.Continuar();
                }
                else
                {
                    do
                    {
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del Alumno a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
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
                        MetodosComunes.MensajeColor(mensaje: $"\nEl alumno con ID: {alumno.AlumnoId} Nombre: {alumno.Nombre} Apellido: {alumno.Apellido} ha sido editaado correctamente.");
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
            int cantidad = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nCuantas asignaturas quiere editar (1-50):", mensajeError: "Valor no comprendido entre 1 y 50", minimoValorInput: 1, maximoValorInput: 50);
            Entidades.Asignaturas asignatura;
            Entidades.ListadoAsignaturas listadoAsignatura;
            Entidades.Alumnos alumno;
            Entidades.Carreras carrera;
            int ID, horas, minutos;
            string devolucionEditar;
            for (int i = 0; i < cantidad; i++)
            {
                if (MetodosInformar.InformarTodasAsignaturas() == 0)
                {
                    MetodosComunes.MensajeColor(mensaje: "\nLa lista de Asignaturas esta vacia", color: ConsoleColor.Red);
                    MetodosComunes.Continuar();
                }
                else
                {
                    do
                    {
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID de la Asignatura a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        asignatura = Logica.Asignatura.ListarUna(asignaturaID: ID);
                        if (asignatura == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa Asignatura no existe.", color: ConsoleColor.Red);
                        }
                    } while (asignatura == null);
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

                                devolucionEditar = Logica.Asignatura.Editar(asignatura);
                                if (devolucionEditar.Contains("correctamente"))
                                {
                                    MetodosComunes.MensajeColor(mensaje: $"\nLa asignatura con ID: {asignatura.AsignaturaId} AlumnoID: {asignatura.AlumnoId} Comision: {asignatura.Comision} ha sido editaado correctamente.");
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
    }
}
