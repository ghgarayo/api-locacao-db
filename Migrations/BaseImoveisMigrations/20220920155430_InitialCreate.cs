using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLocacaoComDB.Migrations.BaseImoveisMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    endereco = table.Column<string>(type: "TEXT", nullable: true),
                    numero = table.Column<string>(type: "TEXT", nullable: true),
                    complemento = table.Column<string>(type: "TEXT", nullable: true),
                    bairro = table.Column<string>(type: "TEXT", nullable: true),
                    cidade = table.Column<string>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: true),
                    proprietario = table.Column<string>(type: "TEXT", nullable: true),
                    valorAluguel = table.Column<string>(type: "TEXT", nullable: true),
                    disponivel = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imoveis");
        }
    }
}
