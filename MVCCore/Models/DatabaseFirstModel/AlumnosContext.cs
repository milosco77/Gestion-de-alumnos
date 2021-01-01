using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVCCore.DatabaseFirstModel
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

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Facultade> Facultades { get; set; }
        public virtual DbSet<ListadoAsignatura> ListadoAsignaturas { get; set; }
        public virtual DbSet<ListadoCarrera> ListadoCarreras { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Alumnos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => new { e.ListadoAsignaturasId, e.AlumnoId })
                    .HasName("PK_Asignaturas_1");

                entity.HasIndex(e => e.AsignaturaId, "UK_Asignaturas")
                    .IsUnique();

                entity.Property(e => e.ListadoAsignaturasId).HasColumnName("ListadoAsignaturasID");

                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.AsignaturaId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AsignaturaID");

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

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => new { e.AlumnoId, e.ListadoCarrerasId })
                    .HasName("PK_Carreras_2");

                entity.HasIndex(e => e.CarreraId, "UK_Carreras")
                    .IsUnique();

                entity.Property(e => e.AlumnoId).HasColumnName("AlumnoID");

                entity.Property(e => e.ListadoCarrerasId).HasColumnName("ListadoCarrerasID");

                entity.Property(e => e.CarreraId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CarreraID");

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ListadoCarreras)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.ListadoCarrerasId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Facultade>(entity =>
            {
                entity.HasKey(e => e.FacultadId);

                entity.Property(e => e.FacultadId).HasColumnName("FacultadID");

                entity.Property(e => e.Direccion).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<ListadoAsignatura>(entity =>
            {
                entity.HasKey(e => e.ListadoAsignaturasId)
                    .HasName("PK_Materia");

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

            modelBuilder.Entity<ListadoCarrera>(entity =>
            {
                entity.HasKey(e => e.ListadoCarrerasId)
                    .HasName("PK_Carreras");

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

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(e => e.NotasId);

                entity.Property(e => e.NotasId).HasColumnName("NotasID");

                entity.Property(e => e.AsignaturaId).HasColumnName("AsignaturaID");

                entity.HasOne(d => d.Asignatura)
                    .WithMany(p => p.Nota)
                    .HasPrincipalKey(p => p.AsignaturaId)
                    .HasForeignKey(d => d.AsignaturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
