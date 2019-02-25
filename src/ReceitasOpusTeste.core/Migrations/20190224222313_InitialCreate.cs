using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReceitasOpusTeste.core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IdIngrediente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IdIngrediente);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    IdReceita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Porcoes = table.Column<int>(nullable: false),
                    Calorias = table.Column<float>(nullable: false),
                    ModoDePreparo = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.IdReceita);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteReceitas",
                columns: table => new
                {
                    IdReceita = table.Column<int>(nullable: false),
                    IdIngrediente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteReceitas", x => new { x.IdReceita, x.IdIngrediente });
                    table.ForeignKey(
                        name: "FK_IngredienteReceitas_Ingredientes_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteReceitas_Receitas_IdReceita",
                        column: x => x.IdReceita,
                        principalTable: "Receitas",
                        principalColumn: "IdReceita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "IdIngrediente", "Nome" },
                values: new object[,]
                {
                    { 1, "Leite" },
                    { 2, "Sal" },
                    { 3, "Pimenta" },
                    { 4, "Óleo" },
                    { 5, "Azeite" },
                    { 6, "Farinha de trigo" },
                    { 7, "Ovo" },
                    { 8, "Manteiga" },
                    { 9, "Queijo" },
                    { 10, "Noz-moscada" },
                    { 11, "Baunilha" },
                    { 12, "Leite de coco" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceitas_IdIngrediente",
                table: "IngredienteReceitas",
                column: "IdIngrediente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredienteReceitas");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
