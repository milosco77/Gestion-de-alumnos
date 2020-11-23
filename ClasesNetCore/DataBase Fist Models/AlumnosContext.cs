using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsolaNetCore.Models
{
    public partial class AlumnosContext : DbContext
    {
        public AlumnosContext()
        {
        }

        public AlumnosContext(DbContextOptions<AlumnosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Asignaturas> Asignaturas { get; set; }
        public virtual DbSet<Carreras> Carreras { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Alumnos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);

                entity.HasIndex(e => e.CarreraIdCarrera);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CarreraIdCarreraNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.CarreraIdCarrera);
            });

            modelBuilder.Entity<Asignaturas>(entity =>
            {
                entity.HasKey(e => e.IdAsignatura);

                entity.HasIndex(e => e.NotaIdNotas);

                entity.HasOne(d => d.NotaIdNotasNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.NotaIdNotas)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.HasKey(e => e.IdCarrera);

                entity.Property(e => e.Titulo).IsRequired();

                entity.HasOne(d => d.AsignaturaIdAsignaturaNavigation)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.AsignaturaIdAsignatura);
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.HasKey(e => e.IdNotas);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
