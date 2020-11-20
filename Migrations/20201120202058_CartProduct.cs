using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Satish.Migrations
{
    public partial class CartProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "CartProduct",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Product_ProductId",
                table: "CartProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Product_ProductId",
                table: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "CartProduct");
        }
    }
}
