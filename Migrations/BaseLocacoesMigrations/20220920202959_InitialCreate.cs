using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLocacaoComDB.Migrations.BaseLocacoesMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idImovel = table.Column<int>(type: "INTEGER", nullable: false),
                    idLocatario = table.Column<int>(type: "INTEGER", nullable: false),
                    dataLocacao = table.Column<string>(type: "TEXT", nullable: true),
                    tempoContrato = table.Column<string>(type: "TEXT", nullable: true),
                    proprietarioImovel = table.Column<string>(type: "TEXT", nullable: true),
                    emailLocatario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacoes");
        }
    }
}
