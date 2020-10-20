using Microsoft.EntityFrameworkCore.Migrations;

namespace Entidades.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    idTitulo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: true),
                    Facultad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.idTitulo);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    idNotas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerParcial = table.Column<float>(nullable: false),
                    PrimerRecuperatorio = table.Column<float>(nullable: false),
                    SegundoParcial = table.Column<float>(nullable: false),
                    SegundoRecuperatorio = table.Column<float>(nullable: false),
                    Final = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.idNotas);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    idStaff = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    DNI = table.Column<int>(nullable: false),
                    Cargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.idStaff);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    idAlumno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    DNI = table.Column<int>(nullable: false),
                    CarreraidTitulo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.idAlumno);
                    table.ForeignKey(
                        name: "FK_Alumnos_Carreras_CarreraidTitulo",
                        column: x => x.CarreraidTitulo,
                        principalTable: "Carreras",
                        principalColumn: "idTitulo",
                        onDelete: ReferentialAction.Restrict);
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
                    NombreAsignatura = table.Column<int>(nullable: false),
                    NotaidNotas = table.Column<int>(nullable: true),
                    CarreraidTitulo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.idAsignatura);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Carreras_CarreraidTitulo",
                        column: x => x.CarreraidTitulo,
                        principalTable: "Carreras",
                        principalColumn: "idTitulo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Notas_NotaidNotas",
                        column: x => x.NotaidNotas,
                        principalTable: "Notas",
                        principalColumn: "idNotas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CarreraidTitulo",
                table: "Alumnos",
                column: "CarreraidTitulo");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_CarreraidTitulo",
                table: "Asignaturas",
                column: "CarreraidTitulo");

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
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Notas");
        }
    }
}
