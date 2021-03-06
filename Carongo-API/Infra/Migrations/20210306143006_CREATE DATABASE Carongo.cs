using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CREATEDATABASECarongo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UrlFoto = table.Column<string>(type: "VARCHAR(8000)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Codigo = table.Column<string>(type: "VARCHAR(12)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Instituicoes_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosInstituicoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "INT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosInstituicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosInstituicoes_Instituicoes_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosInstituicoes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosTurmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosTurmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CPF",
                table: "Alunos",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Email",
                table: "Alunos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Nome",
                table: "Alunos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UrlFoto",
                table: "Alunos",
                column: "UrlFoto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlunosTurmas_IdAluno",
                table: "AlunosTurmas",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosTurmas_IdTurma",
                table: "AlunosTurmas",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicoes_Codigo",
                table: "Instituicoes",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_IdInstituicao",
                table: "Turmas",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosInstituicoes_IdInstituicao",
                table: "UsuariosInstituicoes",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosInstituicoes_IdUsuario",
                table: "UsuariosInstituicoes",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosTurmas");

            migrationBuilder.DropTable(
                name: "UsuariosInstituicoes");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Instituicoes");
        }
    }
}
