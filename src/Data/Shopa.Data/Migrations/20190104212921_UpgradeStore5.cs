using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopa.Data.Migrations
{
    public partial class UpgradeStore5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "QuantityId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ShopaUserId",
                table: "Stores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Stores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Stores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityId",
                table: "Stores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopaUserId",
                table: "Stores",
                nullable: false,
                defaultValue: 0);
        }
    }
}
