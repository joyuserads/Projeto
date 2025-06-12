using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proj_webapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroPatrimonio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false)
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
                    NomeTipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoUsuarioNavigationIdTipoUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_IdTipoUsuarioNavigationIdTipoUsuario",
                        column: x => x.IdTipoUsuarioNavigationIdTipoUsuario,
                        principalTable: "TipoUsuarios",
                        principalColumn: "IdTipoUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Andar = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metragem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.IdSala);
                    table.ForeignKey(
                        name: "FK_Salas_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "SalaEquipamentos",
                columns: table => new
                {
                    IdSalaEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSala = table.Column<int>(type: "int", nullable: false),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false),
                    IdEquipamentoNavigationIdEquipamento = table.Column<int>(type: "int", nullable: true),
                    IdSalaNavigationIdSala = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaEquipamentos", x => x.IdSalaEquipamento);
                    table.ForeignKey(
                        name: "FK_SalaEquipamentos_Equipamentos_IdEquipamentoNavigationIdEquipamento",
                        column: x => x.IdEquipamentoNavigationIdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "IdEquipamento");
                    table.ForeignKey(
                        name: "FK_SalaEquipamentos_Salas_IdSalaNavigationIdSala",
                        column: x => x.IdSalaNavigationIdSala,
                        principalTable: "Salas",
                        principalColumn: "IdSala");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaEquipamentos_IdEquipamentoNavigationIdEquipamento",
                table: "SalaEquipamentos",
                column: "IdEquipamentoNavigationIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_SalaEquipamentos_IdSalaNavigationIdSala",
                table: "SalaEquipamentos",
                column: "IdSalaNavigationIdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_UsuarioIdUsuario",
                table: "Salas",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuarioNavigationIdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuarioNavigationIdTipoUsuario");
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
