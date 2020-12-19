using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public static class Nota
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();
#nullable enable
        public static Entidades.Notas ListarUna(int? notasID = null, int? asignaturasID = null, int? primerParcial = null, int? primerRecuperatorio = null, int? segundoParcial = null, int? segundoRecuperatorio = null, int? final = null)
        {
            if (notasID != null)
            {
                return db.Notas.Where(n => n.NotasId == notasID).FirstOrDefault();
            }
            else if (asignaturasID != null)
            {
                return db.Notas.Where(n => n.AsignaturaId == asignaturasID).FirstOrDefault();
            }
            else if (primerParcial != null)
            {
                return db.Notas.Where(n => n.PrimerParcial == primerParcial).FirstOrDefault();
            }
            else if (primerRecuperatorio != null)
            {
                return db.Notas.Where(n => n.PrimerRecuperatorio == primerRecuperatorio).FirstOrDefault();
            }
            else if (segundoParcial != null)
            {
                return db.Notas.Where(n => n.SegundoParcial == segundoParcial).FirstOrDefault();
            }
            else if (segundoRecuperatorio != null)
            {
                return db.Notas.Where(n => n.SegundoRecuperatorio == segundoRecuperatorio).FirstOrDefault();
            }
            return db.Notas.Where(n => n.Final == final).FirstOrDefault();
        }

        public static List<Entidades.Notas> ListarVarias(int? notasID = null, int? asignaturasID = null, int? primerParcial = null, int? primerRecuperatorio = null, int? segundoParcial = null, int? segundoRecuperatorio = null, int? final = null)
        {
            if (notasID != null)
            {
                return db.Notas.Where(n => n.NotasId == notasID).ToList();
            }
            else if (asignaturasID != null)
            {
                return db.Notas.Where(n => n.AsignaturaId == asignaturasID).ToList();
            }
            else if (primerParcial != null)
            {
                return db.Notas.Where(n => n.PrimerParcial == primerParcial).ToList();
            }
            else if (primerRecuperatorio != null)
            {
                return db.Notas.Where(n => n.PrimerRecuperatorio == primerRecuperatorio).ToList();
            }
            else if (segundoParcial != null)
            {
                return db.Notas.Where(n => n.SegundoParcial == segundoParcial).ToList();
            }
            else if (segundoRecuperatorio != null)
            {
                return db.Notas.Where(n => n.SegundoRecuperatorio == segundoRecuperatorio).ToList();
            }
            return db.Notas.Where(n => n.Final == final).ToList();
        }
#nullable disable
        public static List<Entidades.Notas> ListarTodas()
        {
            return db.Notas.OrderBy(n => n.NotasId).ToList();
        }

        public static string Agregar(Entidades.Notas nota)
        {
            try
            {
                db.Notas.Add(nota);
                db.SaveChanges();
                return $"La nota con NotasID: {nota.NotasId} ListadoCarrerasID: {nota.AsignaturaId} ha sido agregado.";
            }
            catch (DbUpdateException e)
            {
                return $"La asignatura con NotasID: {nota.NotasId} ListadoCarrerasID: {nota.AsignaturaId} no ha sido agregado debido a excepcion:\n{e}\n\nIndicando que se realizo una infraccion a una de las restricciones de la tabla. Lea el detalle de la excepcion.";
            }
            catch (Exception e)
            {
                return $"La nota con NotasID: {nota.NotasId} ListadoCarrerasID: {nota.AsignaturaId} no ha sido agregado debido a excepcion: {e}";
            }
        }

        public static string Editar(Entidades.Notas pNota)
        {
            Entidades.Notas nota = db.Notas.Where(n => n.NotasId == pNota.NotasId).SingleOrDefault();
            if (nota != null)
            {
                try
                {
                    nota.NotasId = pNota.NotasId;
                    nota.AsignaturaId = pNota.AsignaturaId;
                    nota.PrimerParcial = pNota.PrimerParcial;
                    nota.PrimerRecuperatorio = pNota.PrimerRecuperatorio;
                    nota.SegundoParcial = pNota.SegundoParcial;
                    nota.SegundoRecuperatorio = pNota.SegundoRecuperatorio;
                    nota.Final = pNota.Final;
                    db.SaveChanges();
                    return "Editado correctamente.";
                }
                catch (Exception e)
                {
                    return $"No editado debido a {e.Message} | {e.InnerException}";
                }
            }
            return "La nota no existe";
        }
#nullable enable
        public static string Eliminar(int? notasID = null, int? asignaturasID = null, int? primerParcial = null, int? primerRecuperatorio = null, int? segundoParcial = null, int? segundoRecuperatorio = null, int? final = null)
        {
            try
            {
                if (notasID != null)
                {
                    db.Notas.Remove(db.Notas.Where(n => n.NotasId == notasID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Nota con NotasID {notasID} ha sido borrado correctamente.";
                }
                else if (asignaturasID != null)
                {
                    db.Notas.Remove(db.Notas.Where(a => a.AsignaturaId == asignaturasID).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Nota con AsignaturasID {asignaturasID} ha sido borrado correctamente.";
                }
                else if (primerParcial != null)
                {
                    db.Notas.Remove(db.Notas.Where(pp => pp.PrimerParcial == primerParcial).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Nota con Primer Parcial {primerParcial} ha sido borrado correctamente.";
                }
                else if (primerRecuperatorio != null)
                {
                    db.Notas.Remove(db.Notas.Where(pr => pr.PrimerRecuperatorio == primerRecuperatorio).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Nota con Primer Recuperatorio {primerRecuperatorio} ha sido borrado correctamente.";
                }
                else if (segundoParcial != null)
                {
                    db.Notas.Remove(db.Notas.Where(sp => sp.SegundoParcial == segundoParcial).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Nota con Segundo Parcial {segundoParcial} ha sido borrado correctamente.";
                }
                else if (segundoRecuperatorio != null)
                {
                    db.Notas.Remove(db.Notas.Where(sr => sr.SegundoRecuperatorio == segundoRecuperatorio).SingleOrDefault());
                    db.SaveChanges();
                    return $"El elemento Nota con Segundo Recuperatorio {segundoRecuperatorio} ha sido borrado correctamente.";
                }
                db.Notas.Remove(db.Notas.Where(f => f.Final == final).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Nota con Final {final} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Nota no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Nota no ha sido eliminado debido a excepcion: {e}";
            }
        }
#nullable disable
    }
}
