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
            return db.Notas.ToList();
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

        public static void Editar(Entidades.Notas pNota)
        {
            Entidades.Notas nota = db.Notas.Where(n => n.NotasId == pNota.NotasId).SingleOrDefault();
            nota.NotasId = pNota.NotasId;
            nota.AsignaturaId = pNota.AsignaturaId;
            nota.PrimerParcial = pNota.PrimerParcial;
            nota.PrimerRecuperatorio = pNota.PrimerRecuperatorio;
            nota.SegundoParcial = pNota.SegundoParcial;
            nota.SegundoRecuperatorio = pNota.SegundoRecuperatorio;
            nota.Final = pNota.Final;
            db.SaveChanges();
        }

        public static string Eliminar(int notaID)
        {
            try
            {
                db.Notas.Remove(db.Notas.Where(lc => lc.NotasId == notaID).SingleOrDefault());
                db.SaveChanges();
                return $"El elemento Nota con ID {notaID} ha sido borrado correctamente.";
            }
            catch (ArgumentNullException e)
            {
                return $"El elemento Nota con ID {notaID} no ha sido eliminado debido a excepcion: {e.Message} que indica que no se encontro el elemento para poder eliminarlo.";
            }
            catch (Exception e)
            {
                return $"El elemento Nota con ID {notaID} no ha sido eliminado debido a excepcion: {e}";
            }
        }
    }
}
