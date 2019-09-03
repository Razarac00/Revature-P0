using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Migrations
{
    public partial class dbrelationsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressedOrders_OrderHistories_OrderHistoryId",
                table: "AddressedOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_Stores_StoreId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Stores_StoreId",
                table: "OrderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Users_UserId",
                table: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItem_StoreId",
                table: "InventoryItem");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "InventoryItem");

            migrationBuilder.RenameTable(
                name: "OrderHistories",
                newName: "OrderHistory");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_UserId",
                table: "OrderHistory",
                newName: "IX_OrderHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_StoreId",
                table: "OrderHistory",
                newName: "IX_OrderHistory_StoreId");

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory",
                column: "OrderHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryItemId",
                table: "Inventories",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AItems_Name",
                table: "AItems",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressedOrders_OrderHistory_OrderHistoryId",
                table: "AddressedOrders",
                column: "OrderHistoryId",
                principalTable: "OrderHistory",
                principalColumn: "OrderHistoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryItem_InventoryItemId",
                table: "Inventories",
                column: "InventoryItemId",
                principalTable: "InventoryItem",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistory_Stores_StoreId",
                table: "OrderHistory",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistory_Users_UserId",
                table: "OrderHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressedOrders_OrderHistory_OrderHistoryId",
                table: "AddressedOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryItem_InventoryItemId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistory_Stores_StoreId",
                table: "OrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistory_Users_UserId",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryItemId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_AItems_Name",
                table: "AItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "Inventories");

            migrationBuilder.RenameTable(
                name: "OrderHistory",
                newName: "OrderHistories");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistory_StoreId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_StoreId");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "InventoryItem",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AItems",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories",
                column: "OrderHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_StoreId",
                table: "InventoryItem",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressedOrders_OrderHistories_OrderHistoryId",
                table: "AddressedOrders",
                column: "OrderHistoryId",
                principalTable: "OrderHistories",
                principalColumn: "OrderHistoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_Stores_StoreId",
                table: "InventoryItem",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_Stores_StoreId",
                table: "OrderHistories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_Users_UserId",
                table: "OrderHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
