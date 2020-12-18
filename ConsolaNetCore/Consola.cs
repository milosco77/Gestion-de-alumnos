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
// TODO implementar manejo de excepciones..
// https://trycatch.me/c-optional-parameters-vs-method-overloading/ por que en projectos publicos es mejor usar sobrecarga de metodos y no parametros opcionales.

namespace ConsolaNetCore
{
    public static class Consola
    {
        public static List<Entidades.Asignaturas> asignaturas = new List<Entidades.Asignaturas>();

        static void Main(string[] args)
        {
            Console.Title = "Programa de Gestion de Notas de Alumnos";
            MetodosComunes.Bienvenida();
            ElegirOpciones();
            MetodosComunes.Salir();
        }

        public static void RendirExamen()
        {
            throw new NotImplementedException();
        }

        public static void AprobacionExamen()
        {
            throw new NotImplementedException();
        }

        public static void Promocion()
        {
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
                    MetodosComunes.Continuar();
                    Console.Clear();
                }
                primeraVez = true;
                switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nQue desea hacer? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Agregar.\n\n2 = Editar.\n\n3 = Eliminar.\n\n4 = Mostrar todos.\n\n5 = Salir.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 5.", minimoValorInput: 1, maximoValorInput: 5))
                {
                    case 1:
                        switch (MetodosComunes.ValidacionNumericaInt(mensajeIngreso: "\nQue desea agregar? Elija la opcion deseada para realizar con:\nAlumnos | Asignatura | Carreras | Facultades | Listado de asignaturas | Listado de carreras | Notas\n\n1 = Alumno.\n\n2 = Asignatura.\n\n3 = Carrera.\n\n4 = Facultad.\n\n5 = Asignatura al listado.\n\n6 = Carrera al listado.\n\n7 = Nota.\n\n8 = Volver al menu anterior.\n\n---\n", mensajeError: "El valor ingresado no esta comprendido entre 1 y 8.", minimoValorInput: 1, maximoValorInput: 8))
                            {
                            case 1:
                                MetodosAgregar.AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Alumnos);
                                break;
                            case 2:
                                MetodosAgregar.AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Asignaturas);
                                break;
                            case 3:
                                MetodosAgregar.AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Carreras);
                                break;
                            case 4:
                                MetodosAgregar.AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Facultades);
                                break;
                            case 5:
                                MetodosAgregar.AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.ListadoAsignaturas);
                                break;
                            case 6:
                                MetodosAgregar.AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.ListadoCarreras);
                                break;
                            case 7:
                                MetodosAgregar.AgregarRegistro(elementoAgregar: Enumeraciones.Tablas.Notas);
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
                                MetodosEditar.EditarAlumno();
                                break;
                            case 2:
                                MetodosEditar.EditarAsignatura();
                                break;
                            case 3:
                                MetodosEditar.EditarCarrera();
                                break;
                            case 4:
                                MetodosEditar.EditarFacultad();
                                break;
                            case 5:
                                MetodosEditar.EditarAsignaturaListado();
                                break;
                            case 6:
                                MetodosEditar.EditarCarreraListado();
                                break;
                            case 7:
                                MetodosEditar.EditarNota();
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
                                MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Alumnos, tablaAsociada: Enumeraciones.Tablas.Carreras);
                                break;
                            case 2:
                                MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Asignaturas, tablaAsociada: Enumeraciones.Tablas.Notas);
                                break;
                            case 3:
                                MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Carreras, tablaAsociada: Enumeraciones.Tablas.Asignaturas);
                                break;
                            case 4:
                                MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Facultades);
                                break;
                            case 5:
                                MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.ListadoAsignaturas, tablaAsociada: Enumeraciones.Tablas.Asignaturas);
                                break;
                            case 6:
                                MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.ListadoCarreras);
                                break;
                            case 7:
                                MetodosEliminar.EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.Notas);
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
                                if (MetodosInformar.InformarTodosAlumnos() == 0) MetodosComunes.MensajeColor(mensaje: "\nLa lista de alumnos esta vacia", color: ConsoleColor.Red);
                                break;
                            case 2:
                                if (MetodosInformar.InformarTodasAsignaturas() == 0) MetodosComunes.MensajeColor(mensaje: "\nLa lista de asignaturas esta vacia", color: ConsoleColor.Red);
                                break;
                            case 3:
                                if (MetodosInformar.InformarTodasCarreras() == 0) MetodosComunes.MensajeColor(mensaje: "\nLa lista de carreras esta vacia", color: ConsoleColor.Red);
                                break;
                            case 4:
                                if (MetodosInformar.InformarTodasFacultades() == 0) MetodosComunes.MensajeColor(mensaje: "\nLa lista de facultades esta vacia", color: ConsoleColor.Red);
                                break;
                            case 5:
                                if (MetodosInformar.InformarListadoAsignaturas() == 0) MetodosComunes.MensajeColor(mensaje: "\nEl listado de asignaturas esta vacio", color: ConsoleColor.Red);
                                break;
                            case 6:
                                if (MetodosInformar.InformarListadoCarreras() == 0) MetodosComunes.MensajeColor(mensaje: "\nEl listado de carreras esta vacio", color: ConsoleColor.Red);
                                break;
                            case 7:
                                if (MetodosInformar.InformarTodasNotas() == 0) MetodosComunes.MensajeColor(mensaje: "\nLa lista de notas esta vacia", color: ConsoleColor.Red);
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

    }
}