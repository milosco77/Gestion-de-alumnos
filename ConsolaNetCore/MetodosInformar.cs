using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaNetCore
{
    public static class MetodosInformar
    {
        // TODO Continuar desglose de metodos informar, ordenar listados por en orden ascendente por ID.
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
                        MetodosComunes.Continuar();
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
                        MetodosComunes.Continuar();
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
                        MetodosComunes.Continuar();
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
                        MetodosComunes.Continuar();
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
                        MetodosComunes.Continuar();
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
                        MetodosComunes.Continuar();
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
                        MetodosComunes.Continuar();
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

        public static int InformarTodosAlumnos()
        {
            List<Entidades.Alumnos> alumnos = Logica.Alumno.ListarTodos();
            if (alumnos.Count == 0)
            {
                return alumnos.Count;
            }
            else
            {
                Console.WriteLine("\nTodos los alumnos:");
                foreach (Entidades.Alumnos alumno in alumnos)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nID: {alumno.AlumnoId} | Nombre: {alumno.Nombre} | Apellido: {alumno.Apellido} | Edad: {alumno.Edad} | DNI: {alumno.Dni}");
                }
                return alumnos.Count;
            }
        }

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

        public static int InformarTodasAsignaturas()
        {
            List<Entidades.Asignaturas> asignaturas = Logica.Asignatura.ListarTodas();
            if (asignaturas.Count == 0)
            {
                return asignaturas.Count;
            }
            else
            {
                Console.WriteLine("\nTodos las asignaturas:");
                foreach (Entidades.Asignaturas asignatura in asignaturas)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nAsignaturaID: {asignatura.AsignaturaId} | ListadoAsignaturasID: {asignatura.ListadoAsignaturasId} | AlumnoID: {asignatura.AlumnoId} | CarreraID: {asignatura.CarreraId} | Comision: {asignatura.Comision} | HorarioEntrada: {asignatura.HorarioEntrada} | HorarioSalida: {asignatura.HorarioSalida} | Dias: {asignatura.Dias}");
                }
                return asignaturas.Count;
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

        public static int InformarTodasNotas()
        {
            List<Entidades.Notas> notas = Logica.Nota.ListarTodas();
            if (notas.Count == 0)
            {
                return notas.Count;
            }
            else
            {
                Console.WriteLine("\nTodos las notas:");
                foreach (Entidades.Notas nota in notas)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nNotaID: {nota.NotasId} | AsignaturaID: {nota.AsignaturaId} | Primer parcial: {(nota.PrimerParcial == null ? "NULL" : nota.PrimerParcial.ToString())} | Primer recuperatorio: {(nota.PrimerRecuperatorio == null ? "NULL" : nota.PrimerRecuperatorio.ToString())} | Segundo parcial: {(nota.SegundoParcial == null ? "NULL" : nota.SegundoParcial.ToString())} | Segundo recuperatorio: {(nota.SegundoRecuperatorio == null ? "NULL" : nota.SegundoRecuperatorio.ToString())} | Final: {(nota.Final == null ? "NULL" : nota.Final.ToString())}");
                }
                return notas.Count;
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

        public static int InformarTodasCarreras()
        {
            List<Entidades.Carreras> carreras = Logica.Carrera.ListarTodas();
            if (carreras.Count == 0)
            {
                return carreras.Count;
            }
            else
            {
                Console.WriteLine("\nTodos las carreras:");
                foreach (Entidades.Carreras carrera in carreras)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nCarreraID: {carrera.CarreraId} | AlumnoID: {carrera.AlumnoId} | ListadoCarrerasID: {carrera.ListadoCarrerasId}");
                }
                return carreras.Count;
            }
        }

        public static int InformarTodasFacultades()
        {
            List<Entidades.Facultades> facultades = Logica.Facultad.ListarTodas();
            if (facultades.Count == 0)
            {
                return facultades.Count;
            }
            else
            {
                Console.WriteLine("\nTodos las facultades:");
                foreach (Entidades.Facultades facultad in facultades)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nFacultadID: {facultad.FacultadId} | Nombre: {facultad.Nombre} | Direccion: {facultad.Direccion} | Telefono: {(facultad.Telefono == null ? "NULL" : facultad.Telefono.ToString())} | Departamento de Alumnos: {(facultad.DepartamentoAlumnos == null ? "NULL" : facultad.DepartamentoAlumnos.ToString())} | Facebook: {(facultad.Facebook == null ? "NULL" : facultad.Facebook.ToString())} | Instagram: {(facultad.Instagram == null ? "NULL" : facultad.Instagram.ToString())} | Twitter: {(facultad.Twitter == null ? "NULL" : facultad.Twitter.ToString())} | Pagina Web: {(facultad.PaginaWeb == null ? "NULL" : facultad.PaginaWeb.ToString())} | Email: {(facultad.Email == null ? "NULL" : facultad.Email.ToString())} | Recorrido Virtual: {(facultad.RecorridoVirtual == null ? "NULL" : facultad.RecorridoVirtual.ToString())}");
                }
                return facultades.Count;
            }
        }

        public static int InformarListadoCarreras()
        {
            List<Entidades.ListadoCarreras> carreras = Logica.ListadoCarrera.ListarTodas();
            if (carreras.Count == 0)
            {
                return carreras.Count;
            }
            else
            {
                Console.WriteLine("\nListado de carreras:");
                foreach (Entidades.ListadoCarreras carrera in carreras)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nListadoCarrerasID: {carrera.ListadoCarrerasId} | FacultadID: {carrera.FacultadId} | Nombre: {carrera.Nombre} | Titulo: {carrera.Titulo} | Duracion Estimada en Años: {(carrera.DuracionEstimadaAnios == null ? "NULL" : carrera.DuracionEstimadaAnios.ToString())}");
                }
                return carreras.Count;
            }
        }

        public static int InformarListadoAsignaturas()
        {
            List<Entidades.ListadoAsignaturas> asignaturas = Logica.ListadoAsignatura.ListarTodas();
            if (asignaturas.Count == 0)
            {
                return asignaturas.Count;
            }
            else
            {
                Console.WriteLine("\nListado de asignaturas:");
                foreach (Entidades.ListadoAsignaturas asignatura in asignaturas)
                {
                    MetodosComunes.MensajeColor(mensaje: $"\nListadoAsignaturasID: {asignatura.ListadoAsignaturasId} | Codigo: {asignatura.Codigo} | Nombre: {asignatura.Nombre} | Creditos: {(asignatura.Creditos == null ? "NULL" : asignatura.Creditos.ToString())} | Horas: {(asignatura.Horas == null ? "NULL" : asignatura.Horas.ToString())} | Correlativas: {(asignatura.Correlativas == null ? "NULL" : asignatura.Correlativas.ToString())} | Categoria: {asignatura.Categoria} | ListadoCarrerasID: {asignatura.ListadoCarrerasId}");
                }
                return asignaturas.Count;
            }
        }
    }
}
