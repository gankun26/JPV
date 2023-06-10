using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProjectJpv.Migrations
{
    /// <inheritdoc />
    public partial class CadastroPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastroPessoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataNascimento = table.Column<int>(type: "int", nullable: false),
                    valorRenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cpf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroPessoa", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastroPessoa");
        }
    }
}
