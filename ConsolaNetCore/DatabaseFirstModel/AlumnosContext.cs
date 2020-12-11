using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsolaNetCore.DatabaseFirstModel
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
        public virtual DbSet<ListadoAsignaturas> ListadoAsignaturas { get; set; }
        public virtual DbSet<ListadoCarreras> ListadoCarreras { get; set; }
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

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Asignaturas>(entity =>
            {
                entity.HasKey(e => new { e.ListadoAsignaturasId, e.AlumnoId })
                    .HasName("PK_Asignaturas_1");

                entity.HasIndex(e => e.AsignaturaId)
                    .HasName("UK_Asignaturas")
                    .IsUnique();

                entity.Property(e => e.ListadoAsignaturasId).HasColumnName("ListadoAsignaturasID");

                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.AsignaturaId)
                    .HasColumnName("AsignaturaID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.Dias)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HorarioEntrada).HasColumnType("time(0)");

                entity.Property(e => e.HorarioSalida).HasColumnType("time(0)");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Asignaturas)
                    .HasPrincipalKey(p => p.CarreraId)
                    .HasForeignKey(d => d.CarreraId);

                entity.HasOne(d => d.ListadoAsignaturas)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.ListadoAsignaturasId);
            });

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.HasKey(e => new { e.AlumnoId, e.ListadoCarrerasId })
                    .HasName("PK_Carreras_2");

                entity.HasIndex(e => e.CarreraId)
                    .HasName("UK_Carreras")
                    .IsUnique();

                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.ListadoCarrerasId).HasColumnName("ListadoCarrerasID");

                entity.Property(e => e.CarreraId)
                    .HasColumnName("CarreraID")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ListadoCarreras)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.ListadoCarrerasId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Facultades>(entity =>
            {
                entity.HasKey(e => e.FacultadId);

                entity.Property(e => e.FacultadId).HasColumnName("FacultadID");

                entity.Property(e => e.Direccion).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<ListadoAsignaturas>(entity =>
            {
                entity.Property(e => e.ListadoAsignaturasId).HasColumnName("ListadoAsignaturasID");

                entity.Property(e => e.Categoria).IsRequired();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Correlativas).HasMaxLength(50);

                entity.Property(e => e.ListadoCarrerasId).HasColumnName("ListadoCarrerasID");

                entity.Property(e => e.Nombre).IsRequired();

                entity.HasOne(d => d.ListadoCarreras)
                    .WithMany(p => p.ListadoAsignaturas)
                    .HasForeignKey(d => d.ListadoCarrerasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ListadoAsignaturas_Carrera_ListadoCarrerasID");
            });

            modelBuilder.Entity<ListadoCarreras>(entity =>
            {
                entity.Property(e => e.ListadoCarrerasId).HasColumnName("ListadoCarrerasID");

                entity.Property(e => e.FacultadId).HasColumnName("FacultadID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Facultad)
                    .WithMany(p => p.ListadoCarreras)
                    .HasForeignKey(d => d.FacultadId)
                    .HasConstraintName("FK_Carreras_Facultades_FacultadID");
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.Property(e => e.NotasId).HasColumnName("NotasID");

                entity.Property(e => e.AsignaturaId).HasColumnName("AsignaturaID");

                entity.HasOne(d => d.Asignatura)
                    .WithMany(p => p.Notas)
                    .HasPrincipalKey(p => p.AsignaturaId)
                    .HasForeignKey(d => d.AsignaturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
