using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGE.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UsuarioLogin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "DataCadastro", "Nome", "Senha", "UsuarioLogin" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 1, 5, 10, 11, 48, 693, DateTimeKind.Utc).AddTicks(8169), "Elias Santos", "123456", "EliasS" },
                    { 2, true, new DateTime(2025, 1, 5, 10, 11, 48, 693, DateTimeKind.Utc).AddTicks(8830), "Nilton Santos", "654321", "NiltonP" }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "Complemento", "Logradouro", "Numero", "Uf", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Centro", "12345-678", "Cidade Exemplo", "Apto 101", "Rua Principal", "100", "SP", 1 },
                    { 2, "Bairro Exemplo", "98765-432", "Cidade Exemplo", "Casa 20", "Avenida Secundária", "200", "RJ", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
