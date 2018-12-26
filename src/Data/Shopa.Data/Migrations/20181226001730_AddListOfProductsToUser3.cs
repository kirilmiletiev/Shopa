using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopa.Data.Migrations
{
    public partial class AddListOfProductsToUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ShopaUserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ShopaUserId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopaUserId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "ShopaUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_ShopaUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ShopaUserId",
                table: "Products",
                column: "ShopaUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
