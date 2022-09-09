using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaculdadeApi.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DADOSFACULDADE",
                columns: table => new
                {
                    IDALUNO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ALUNO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TURMA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PROFESSOR = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MATERIAS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DADOSFACULDADE", x => x.IDALUNO);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LOGIN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IdUsuario);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_LOGIN",
                table: "USUARIO",
                column: "LOGIN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DADOSFACULDADE");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
