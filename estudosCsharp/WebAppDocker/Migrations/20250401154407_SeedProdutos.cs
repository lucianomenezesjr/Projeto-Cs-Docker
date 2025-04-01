using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppDocker.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Produtos",
            columns: new[] { "Nome", "Preco", "Descricao" },
            values: new object[,]
        {
            { "Notebook Dell", 4299.90m, "Notebook Dell Inspiron 15, 16GB RAM" },
            { "Smartphone Samsung", 1999.99m, "Galaxy S23, 128GB" },
            { "Tablet Lenovo", 899.50m, "Tab M10, 64GB" }
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Produtos\" WHERE \"Nome\" IN ('Notebook Dell', 'Smartphone Samsung', 'Tablet Lenovo')");
        }
    }
}
