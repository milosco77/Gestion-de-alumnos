using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entidades.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    idCarrera = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Facultad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.idCarrera);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    idNotas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerParcial = table.Column<float>(maxLength: 2, nullable: false),
                    PrimerRecuperatorio = table.Column<float>(maxLength: 2, nullable: false),
                    SegundoParcial = table.Column<float>(maxLength: 2, nullable: false),
                    SegundoRecuperatorio = table.Column<float>(maxLength: 2, nullable: false),
                    Final = table.Column<float>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.idNotas);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    idStaff = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Edad = table.Column<int>(maxLength: 2, nullable: false),
                    DNI = table.Column<int>(nullable: false),
                    Cargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.idStaff);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    idAlumno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaTemporal = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CarreraidCarrera = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Edad = table.Column<int>(maxLength: 2, nullable: false),
                    DNI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.idAlumno);
                    table.ForeignKey(
                        name: "FK_Alumnos_Carreras_CarreraidCarrera",
                        column: x => x.CarreraidCarrera,
                        principalTable: "Carreras",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    idAsignatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Comision = table.Column<int>(nullable: false),
                    Horario = table.Column<int>(nullable: false),
                    Nombre = table.Column<int>(nullable: false),
                    NotaidNotas = table.Column<int>(nullable: true),
                    CarreraidCarrera = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.idAsignatura);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Carreras_CarreraidCarrera",
                        column: x => x.CarreraidCarrera,
                        principalTable: "Carreras",
                        principalColumn: "idCarrera",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Notas_NotaidNotas",
                        column: x => x.NotaidNotas,
                        principalTable: "Notas",
                        principalColumn: "idNotas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CarreraidCarrera",
                table: "Alumnos",
                column: "CarreraidCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_CarreraidCarrera",
                table: "Asignaturas",
                column: "CarreraidCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_NotaidNotas",
                table: "Asignaturas",
                column: "NotaidNotas");
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
