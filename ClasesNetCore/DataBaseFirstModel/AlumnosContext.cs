using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entidades
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
        public virtual DbSet<Facultades> Facultades { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
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
                entity.HasKey(e => e.AlumnoId);

                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Asignaturas>(entity =>
            {
                entity.HasKey(e => new { e.MateriaId, e.AlumnoId });

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.Dias)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HorarioEntrada).HasColumnType("time(0)");

                entity.Property(e => e.HorarioSalida).HasColumnType("time(0)");

                entity.Property(e => e.NotasId).HasColumnName("NotasID");

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.AlumnoId);

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.MateriaId);

                entity.HasOne(d => d.Notas)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.NotasId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.HasKey(e => e.CarreraId);

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.FacultadId).HasColumnName("FacultadID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Facultad)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.FacultadId);
            });

            modelBuilder.Entity<Facultades>(entity =>
            {
                entity.HasKey(e => e.FacultadId);

                entity.Property(e => e.FacultadId).HasColumnName("FacultadID");
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.MateriaId)
                    .HasName("PK_Materia");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.Categoria).IsRequired();

                entity.Property(e => e.Codigo).HasMaxLength(5);

                entity.Property(e => e.Correlativas).HasMaxLength(50);

                entity.Property(e => e.Nombre).IsRequired();

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Materias)
                    .HasForeignKey(d => d.CarreraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materias_Carrera_CarreraID");
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.Property(e => e.NotasId).HasColumnName("NotasID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
