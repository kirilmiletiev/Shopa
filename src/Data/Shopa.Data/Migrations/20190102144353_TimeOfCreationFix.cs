﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopa.Data.Migrations
{
    public partial class TimeOfCreationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfCreation",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfCreation",
                table: "Products");
        }
    }
}