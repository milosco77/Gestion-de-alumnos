using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


// Para poder hacer la migracion fue necesario crear un constructor vacio para cada clase de la cual tenia uno parametrisado.
// No se puede crear tablas apartir de Enumerations, para poder realizarlo hay que hacer una solucion compleja indicanda en
// https://stackoverflow.com/questions/34557574/how-to-create-a-table-corresponding-to-enum-in-ef6-code-first, por lo tanto,
// se hara manualmente temporalmente.
namespace Entidades
{
    public class CFContexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=.\SQLEXPRESS;Database=Alumnos;Integrated Security=True");
        }
        public DbSet<CFAlumno> Alumnos { get; set; }
        public DbSet<CFAsignatura> Asignaturas { get; set; }
        public DbSet<CFCarrera> Carreras { get; set; }
        public DbSet<CFNotas> Notas { get; set; }
        public DbSet<CFStaff> Staffs { get; set; }
    }
}
