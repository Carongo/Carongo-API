using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class ALTERTABLEInstituicoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituicoes",
                type: "VARCHAR(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Instituicoes",
                type: "VARCHAR(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Instituicoes",
                type: "VARCHAR(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Instituicoes",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(40)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Instituicoes",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Instituicoes",
                type: "VARCHAR(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(6)");
        }
    }
}
