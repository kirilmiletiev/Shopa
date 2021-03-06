﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopa.Data.Migrations
{
    public partial class ProductNumberOfOrderEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfOrderedItems",
                table: "Products",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfOrderedItems",
                table: "Products");
        }
    }
}
