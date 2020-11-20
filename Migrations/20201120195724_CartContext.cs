using Microsoft.EntityFrameworkCore.Migrations;

namespace Satish.Migrations
{
    public partial class CartContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    CartProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartId, x.ProductId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");
        }
    }
}
