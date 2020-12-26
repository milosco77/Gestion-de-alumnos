using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaNetCore
{
    public static class MetodosEliminar
    {
        public static void EliminarRegistro(Enumeraciones.Tablas elementoABorrar, Enumeraciones.Tablas? tablaAsociada = null, int? id = null)
        {
            int? ID, alerta;
            string devolucionEliminar;
            switch (elementoABorrar)
            {
                case Enumeraciones.Tablas.Alumnos:
                    if (MetodosInformar.InformarTodosAlumnos() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nLa lista de alumnos esta vacia", color: ConsoleColor.Red);
                    }
                    else
                    {
                        do
                        {
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
                            List<Entidades.Carreras> carreras = Logica.Carrera.ListarVarias(alumnoID: ID);
                            if (carreras == null)
                            {
                                MetodosComunes.MensajeColor(mensaje: "\nNo hay carreras asociadas.");
                            }
                            else
                            {
                                foreach (Entidades.Carreras carrera in carreras)
                                {
                                    List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarVarias(carreraID: carrera.CarreraId);
                                    if (asignaturas == null)
                                    {
                                        MetodosComunes.MensajeColor(mensaje: "\nNo hay asignaturas asociadas.");
                                    }
                                    else
                                    {
                                        foreach (Entidades.Asignaturas asignatura in asignaturas)
                                        {
                                            devolucionEliminar = Logica.Nota.Eliminar(asignaturasID: asignatura.AsignaturaId);

                                            if (devolucionEliminar.Contains("borrado"))
                                            {
                                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                                            }
                                            else
                                            {
                                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                                            }
                                            devolucionEliminar = Logica.Asignatura.Eliminar(asignaturaID: asignatura.AsignaturaId);
                                            if (devolucionEliminar.Contains("borrado"))
                                            {
                                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                                            }
                                            else
                                            {
                                                MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                                            }
                                        }
                                    }
                                    devolucionEliminar = Logica.Carrera.Eliminar(carreraID: carrera.CarreraId);
                                    if (devolucionEliminar.Contains("borrado"))
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                                    }
                                    else
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                                    }
                                }
                            }
                            devolucionEliminar = Logica.Alumno.Eliminar(alumnoID: ID);
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
                    }
                    break;
                case Enumeraciones.Tablas.Asignaturas:
                    if (MetodosInformar.InformarTodasAsignaturas() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nLa lista de asignaturas esta vacia", color: ConsoleColor.Red);
                    }
                    else
                    {
                        if (id == null)
                        {
                            do
                            {
                                ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                                if (Logica.Asignatura.ListarUna(asignaturaID: ID) == null)
                                {
                                    MetodosComunes.MensajeColor(mensaje: "\nLa asignatura no existe.", color: ConsoleColor.Red);
                                }
                            } while (Logica.Asignatura.ListarUna(asignaturaID: ID) == null);
                        }
                        else
                        {
                            ID = id;
                        }
                        if (tablaAsociada != null)
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada}.", color: ConsoleColor.Red);
                        }
                        alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                        if (alerta == 1)
                        {
                            List<Entidades.Notas> notas = Logica.Nota.ListarVarias(asignaturasID: ID);

                            if (notas == null)
                            {
                                MetodosComunes.MensajeColor(mensaje: "\nNo hay notas asociadas.");
                            }
                            else
                            {
                                foreach (Entidades.Notas nota in notas)
                                {
                                    devolucionEliminar = Logica.Nota.Eliminar(asignaturasID: ID);
                                    if (devolucionEliminar.Contains("borrado"))
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                                    }
                                    else
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                                    }
                                }
                            }
                            devolucionEliminar = Logica.Asignatura.Eliminar(asignaturaID: ID);
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
                    }
                    break;
                case Enumeraciones.Tablas.Carreras:
                    if (MetodosInformar.InformarTodasCarreras() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nLa lista de carreras esta vacia", color: ConsoleColor.Red);
                    }
                    else
                    {
                        do
                        {
                            ID = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nElija el ID del elemento {elementoABorrar} a eliminar:", mensajeError: "\nEl ID no puede ser 0 o menor.", minimoValorInput: 1, borrarInformacion: false);
                            if (Logica.Carrera.ListarUna(carreraID: ID) == null)
                            {
                                MetodosComunes.MensajeColor(mensaje: "\nLa carrera no existe.", color: ConsoleColor.Red);
                            }
                        } while (Logica.Carrera.ListarUna(carreraID: ID) == null);
                        if (tablaAsociada != null)
                        {
                            MetodosComunes.MensajeColor(mensaje: $"\nSe eliminaran los registros asociado de la tabla {tablaAsociada} y los de {Enumeraciones.Tablas.Notas} a esta ultima.", color: ConsoleColor.Red);
                        }
                        alerta = MetodosComunes.ValidacionNumericaInt(mensajeIngreso: $"\nEsta seguro de querer eliminar {elementoABorrar} con ID: {ID} (SI = 1 | NO = 0)", minimoValorInput: 0, maximoValorInput: 1, mensajeError: "\nEl valor ingresado debe ser (SI = 1 | NO = 0).");
                        if (alerta == 1)
                        {
                            List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarVarias(carreraID: ID);
                            if (asignaturas == null)
                            {
                                MetodosComunes.MensajeColor(mensaje: "\nNo hay asignaturas asociadas.");
                            }
                            else
                            {
                                foreach (Entidades.Asignaturas asignatura in asignaturas)
                                {
                                    devolucionEliminar = Logica.Nota.Eliminar(asignaturasID: asignatura.AsignaturaId);

                                    if (devolucionEliminar.Contains("borrado"))
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                                    }
                                    else
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                                    }
                                    devolucionEliminar = Logica.Asignatura.Eliminar(asignaturaID: asignatura.AsignaturaId);
                                    if (devolucionEliminar.Contains("borrado"))
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}");
                                    }
                                    else
                                    {
                                        MetodosComunes.MensajeColor(mensaje: $"\n{devolucionEliminar}", color: ConsoleColor.Red);
                                    }
                                }
                            }
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
                    }
                    break;
                case Enumeraciones.Tablas.Facultades:
                    if (MetodosInformar.InformarTodasFacultades() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nLa lista de facultades esta vacia", color: ConsoleColor.Red);
                    }
                    else
                    {
                        do
                        {

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

                    }
                    break;
                case Enumeraciones.Tablas.ListadoAsignaturas:
                    if (MetodosInformar.InformarListadoAsignaturas() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nEl listado de asignaturas esta vacio", color: ConsoleColor.Red);
                    }
                    else
                    {
                        do
                        {

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
                            devolucionEliminar = Logica.Asignatura.Eliminar(ID);
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
                    }
                    break;
                case Enumeraciones.Tablas.ListadoCarreras:
                    if (MetodosInformar.InformarListadoCarreras() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nEl listado de carreras esta vacio", color: ConsoleColor.Red);
                    }
                    else
                    {
                        do
                        {
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

                    }
                    break;
                case Enumeraciones.Tablas.Notas:
                    if (MetodosInformar.InformarTodasNotas() == 0)
                    {
                        MetodosComunes.MensajeColor(mensaje: "\nLa lista de notas esta vacia", color: ConsoleColor.Red);
                    }
                    else
                    {
                        do
                        {
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
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
