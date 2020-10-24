using Microsoft.EntityFrameworkCore.Migrations;

namespace Entidades.Migrations
{
    public partial class TerceraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Facultad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.IdCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    IdNotas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerParcial = table.Column<float>(maxLength: 2, nullable: false),
                    PrimerRecuperatorio = table.Column<float>(maxLength: 2, nullable: false),
                    SegundoParcial = table.Column<float>(maxLength: 2, nullable: false),
                    SegundoRecuperatorio = table.Column<float>(maxLength: 2, nullable: false),
                    Final = table.Column<float>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.IdNotas);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    IdStaff = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Edad = table.Column<int>(maxLength: 2, nullable: false),
                    DNI = table.Column<int>(nullable: false),
                    Cargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.IdStaff);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarreraIdCarrera = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Edad = table.Column<int>(maxLength: 2, nullable: false),
                    DNI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.IdAlumno);
                    table.ForeignKey(
                        name: "FK_Alumnos_Carreras_CarreraIdCarrera",
                        column: x => x.CarreraIdCarrera,
                        principalTable: "Carreras",
                        principalColumn: "IdCarrera",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    IdAsignatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Comision = table.Column<int>(nullable: false),
                    Horario = table.Column<int>(nullable: false),
                    Nombre = table.Column<int>(nullable: false),
                    NotaIdNotas = table.Column<int>(nullable: true),
                    CarreraIdCarrera = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.IdAsignatura);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Carreras_CarreraIdCarrera",
                        column: x => x.CarreraIdCarrera,
                        principalTable: "Carreras",
                        principalColumn: "IdCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Notas_NotaIdNotas",
                        column: x => x.NotaIdNotas,
                        principalTable: "Notas",
                        principalColumn: "IdNotas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CarreraIdCarrera",
                table: "Alumnos",
                column: "CarreraIdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_CarreraIdCarrera",
                table: "Asignaturas",
                column: "CarreraIdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_NotaIdNotas",
                table: "Asignaturas",
                column: "NotaIdNotas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Notas");
        }
    }
}
