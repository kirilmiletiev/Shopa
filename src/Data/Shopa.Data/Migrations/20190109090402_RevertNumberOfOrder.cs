using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopa.Data.Migrations
{
    public partial class RevertNumberOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfOrderedItems",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfOrderedItems",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
