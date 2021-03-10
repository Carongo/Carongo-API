using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class ALTERTABLEInstituicoeseAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Turmas",
                type: "VARCHAR(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Instituicoes",
                type: "VARCHAR(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "VARCHAR(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Turmas",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Instituicoes",
                type: "VARCHAR(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(40)");
        }
    }
}
