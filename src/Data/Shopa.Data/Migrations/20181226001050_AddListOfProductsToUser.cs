using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopa.Data.Migrations
{
    public partial class AddListOfProductsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopaUserId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopaUserId",
                table: "Products",
                column: "ShopaUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ShopaUserId",
                table: "Products",
                column: "ShopaUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ShopaUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopaUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShopaUserId",
                table: "Products");
        }
    }
}
