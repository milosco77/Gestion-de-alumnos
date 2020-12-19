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
                    MetodosComunes.MensajeColor(mensaje: $"\nNombre: {alumno.Nombre}");
                    alumno.Nombre = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIndique el nuevo nombre:");
                    MetodosComunes.MensajeColor(mensaje: $"\nApellido: {alumno.Apellido}");
                    alumno.Apellido = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIndique el nuevo apellido:");
                    MetodosComunes.MensajeColor(mensaje: $"\nEdad: {alumno.Edad}");
                    alumno.Edad = (byte)MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique la nueva edad:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 1.");
                    MetodosComunes.MensajeColor(mensaje: $"\nDNI: {alumno.Dni}");
                    alumno.Dni = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique el nuevo DNI:", minimoValorInput: 11111111, mensajeError: "\nEl valor debe ser mayor a 11.111.111");
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
                    MetodosComunes.MensajeColor(mensaje: $"\nListadoAsignaturasID: {asignatura.ListadoAsignaturasId}");
                    asignatura.ListadoAsignaturasId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique el nuevo ListadoAsignaturasID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor que 1");
                    MetodosComunes.MensajeColor(mensaje: $"\nAlumnoID: {asignatura.AlumnoId}");
                    asignatura.AlumnoId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique el nuevo AlumnoID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor que 1");
                    MetodosComunes.MensajeColor(mensaje: $"\nCarreraID: {asignatura.CarreraId}");
                    asignatura.CarreraId = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique la nueva CarreraID:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 1.");
                    MetodosComunes.MensajeColor(mensaje: $"\nComision: {asignatura.Comision}");
                    asignatura.Comision = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique la nueva Comision:", minimoValorInput: 1, mensajeError: "\nEl valor debe ser mayor a 1.");

                    Console.WriteLine("\nIngrese el nuevo horario de entrada de la materia");
                    MetodosComunes.MensajeColor(mensaje: $"\nHora: {asignatura.HorarioEntrada.Hours}");
                    horas = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique la nueva hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);
                    MetodosComunes.MensajeColor(mensaje: $"\nMinutos: {asignatura.HorarioEntrada.Minutes}");
                    minutos = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIndique los nuevos minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);
                    asignatura.HorarioEntrada = new TimeSpan(hours: horas, minutes: minutos, seconds: 0);

                    Console.WriteLine("\nIngrese el nuevo horario de salida de la materia");
                    MetodosComunes.MensajeColor(mensaje: $"\nHora: {asignatura.HorarioSalida.Hours}");
                    horas = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese la hora entre 0 y 23:", mensajeError: "\nIngrese un valor entre 0 y 23", minimoValorInput: 0, maximoValorInput: 23);
                    MetodosComunes.MensajeColor(mensaje: $"\nMinutos: {asignatura.HorarioSalida.Minutes}");
                    minutos = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nIngrese los minutos entre 0 y 59:", mensajeError: "\nIngrese un valor entre 0 y 59", minimoValorInput: 0, maximoValorInput: 59);

                    asignatura.HorarioSalida = new TimeSpan(hours: horas, minutes: minutos, seconds: 0);
                    MetodosComunes.MensajeColor(mensaje: $"\nDias: {asignatura.Dias}");
                    asignatura.Dias = MetodosComunes.ValidacionTexto(mensajeIngreso: "\nIndique los nuevos dias:", mensajeError: "\nEl valor debe estar comprendido en Lunes-Martes-Miercoles-Jueves-Viernes-Sabado-Domingo");

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
