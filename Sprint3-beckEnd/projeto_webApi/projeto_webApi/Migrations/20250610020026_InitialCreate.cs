using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto_webApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPatrimonio = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDeSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.IdEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    TipoUsuarioIdTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_TipoUsuarioIdTipoUsuario",
                        column: x => x.TipoUsuarioIdTipoUsuario,
                        principalTable: "TipoUsuarios",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Andar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metragem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.IdSala);
                    table.ForeignKey(
                        name: "FK_Salas_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaEquipamentos",
                columns: table => new
                {
                    IdSalaEquipamentos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSala = table.Column<int>(type: "int", nullable: false),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false),
                    SalaIdSala = table.Column<int>(type: "int", nullable: false),
                    EquipamentoIdEquipamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaEquipamentos", x => x.IdSalaEquipamentos);
                    table.ForeignKey(
                        name: "FK_SalaEquipamentos_Equipamentos_EquipamentoIdEquipamento",
                        column: x => x.EquipamentoIdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaEquipamentos_Salas_SalaIdSala",
                        column: x => x.SalaIdSala,
                        principalTable: "Salas",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_NumeroPatrimonio",
                table: "Equipamentos",
                column: "NumeroPatrimonio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaEquipamentos_EquipamentoIdEquipamento",
                table: "SalaEquipamentos",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_SalaEquipamentos_IdSala_IdEquipamento",
                table: "SalaEquipamentos",
                columns: new[] { "IdSala", "IdEquipamento" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaEquipamentos_SalaIdSala",
                table: "SalaEquipamentos",
                column: "SalaIdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_UsuarioIdUsuario",
                table: "Salas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuarios_NomeTipo",
                table: "TipoUsuarios",
                column: "NomeTipo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioIdTipoUsuario",
                table: "Usuarios",
                column: "TipoUsuarioIdTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaEquipamentos");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}
