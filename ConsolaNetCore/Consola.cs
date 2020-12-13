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
                                EliminarRegistro(elementoABorrar: Enumeraciones.Tablas.ListadoAsignaturas, tablaAsociada: Enumeraciones.Tablas.Asignaturas);
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
                                MetodosInformar.InformarTodosAlumnos();
                                break;
                            case 2:
                                MetodosInformar.InformarTodasAsignaturas();
                                break;
                            case 3:
                                MetodosInformar.InformarTodasCarreras();
                                break;
                            case 4:
                                MetodosInformar.InformarTodasFacultades();
                                break;
                            case 5:
                                MetodosInformar.InformarListadoAsignaturas();
                                break;
                            case 6:
                                MetodosInformar.InformarListadoCarreras();
                                break;
                            case 7:
                                MetodosInformar.InformarTodasNotas();
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

        public static void EliminarRegistro(Enumeraciones.Tablas elementoABorrar, Enumeraciones.Tablas? tablaAsociada = null)
        {
            int ID, alerta;
            string devolucionEliminar;
            switch (elementoABorrar)
            {
                case Enumeraciones.Tablas.Alumnos:
                    do
                    {
                        MetodosInformar.InformarTodosAlumnos();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        if (Logica.Alumno.ListarUno(alumnoID: ID) == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nEl alumno no existe.", color: ConsoleColor.Red);
                        }
                    } while (Logica.Alumno.ListarUno(alumnoID: ID) == null);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
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
                    do
                    {
                        MetodosInformar.InformarTodasAsignaturas();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        if (Logica.Asignatura.ListarUna(asignaturaID: ID) == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa asignatura no existe.", color: ConsoleColor.Red);
                        }
                    } while (Logica.Asignatura.ListarUna(asignaturaID: ID) == null);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
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
                    do
                    {
                        MetodosInformar.InformarTodasCarreras();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        if (Logica.Carrera.ListarUna(carreraID: ID) == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa carrera no existe.", color: ConsoleColor.Red);
                        }
                    } while (Logica.Carrera.ListarUna(carreraID: ID) == null);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
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
                    do
                    {
                        MetodosInformar.InformarTodasFacultades();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        if (Logica.Facultad.ListarUna(facultadID: ID) == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa facultad no existe.", color: ConsoleColor.Red);
                        }
                    } while (Logica.Facultad.ListarUna(facultadID: ID) == null);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
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
                    do
                    {
                        MetodosInformar.InformarListadoAsignaturas();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        if (Logica.ListadoAsignatura.ListarUna(listadoAsignaturasID: ID) == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa asignatura del listado no existe.", color: ConsoleColor.Red);
                        }
                    } while (Logica.ListadoAsignatura.ListarUna(listadoAsignaturasID: ID) == null);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada} y los de {Enumeraciones.Tablas.Notas} a esta ultima.", color: ConsoleColor.Red);
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
                        devolucionEliminar = Logica.ListadoAsignatura.Eliminar(ID);
                        if (devolucionEliminar.Contains("borrado"))
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                        }
                        else
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                        }
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
                    do
                    {
                        MetodosInformar.InformarListadoCarreras();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        if (Logica.ListadoCarrera.ListarUna(listadoCarrerasID: ID) == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa carrera del listado no existe.", color: ConsoleColor.Red);
                        }
                    } while (Logica.ListadoCarrera.ListarUna(listadoCarrerasID: ID) == null);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
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
                    do
                    {
                        MetodosInformar.InformarTodasNotas();
                        ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                        if (Logica.Nota.ListarUna(notasID: ID) == null)
                        {
                            MetodosComunes.MensajeColor(mensaje: "\nLa nota no existe.", color: ConsoleColor.Red);
                        }
                    } while (Logica.Nota.ListarUna(notasID: ID) == null);
                    if (tablaAsociada != null)
                    {
                        MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
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