using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopa.Data.Migrations
{
    public partial class AddDbSetsAndQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Store_StoreId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Store_StoreId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Store_StoreId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Quantity_Products_ProductId",
                table: "Quantity");

            migrationBuilder.DropForeignKey(
                name: "FK_Quantity_Store_StoreId",
                table: "Quantity");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Balance_BalanceId",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quantity",
                table: "Quantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Balance",
                table: "Balance");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "Quantity",
                newName: "Quantities");

            migrationBuilder.RenameTable(
                name: "Balance",
                newName: "Balances");

            migrationBuilder.RenameIndex(
                name: "IX_Store_BalanceId",
                table: "Stores",
                newName: "IX_Stores_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Quantity_StoreId",
                table: "Quantities",
                newName: "IX_Quantities_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Quantity_ProductId",
                table: "Quantities",
                newName: "IX_Quantities_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quantities",
                table: "Quantities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balances",
                table: "Balances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stores_StoreId",
                table: "AspNetUsers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreId",
                table: "Orders",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantities_Products_ProductId",
                table: "Quantities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantities_Stores_StoreId",
                table: "Quantities",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Balances_BalanceId",
                table: "Stores",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stores_StoreId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Quantities_Products_ProductId",
                table: "Quantities");

            migrationBuilder.DropForeignKey(
                name: "FK_Quantities_Stores_StoreId",
                table: "Quantities");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Balances_BalanceId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quantities",
                table: "Quantities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Balances",
                table: "Balances");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Store");

            migrationBuilder.RenameTable(
                name: "Quantities",
                newName: "Quantity");

            migrationBuilder.RenameTable(
                name: "Balances",
                newName: "Balance");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_BalanceId",
                table: "Store",
                newName: "IX_Store_BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Quantities_StoreId",
                table: "Quantity",
                newName: "IX_Quantity_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Quantities_ProductId",
                table: "Quantity",
                newName: "IX_Quantity_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quantity",
                table: "Quantity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balance",
                table: "Balance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Store_StoreId",
                table: "AspNetUsers",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Store_StoreId",
                table: "Orders",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Store_StoreId",
                table: "Products",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantity_Products_ProductId",
                table: "Quantity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantity_Store_StoreId",
                table: "Quantity",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Balance_BalanceId",
                table: "Store",
                column: "BalanceId",
                principalTable: "Balance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
