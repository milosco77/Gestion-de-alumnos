using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


// Para poder hacer la migracion fue necesario crear un constructor vacio para cada clase de la cual tenia uno parametrisado.
namespace Entidades
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PC\SQLEXPRESS;Database=Alumnos;Integrated Security=True");
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
