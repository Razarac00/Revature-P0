using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Migrations
{
    public partial class orderhistoryremoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_StoreId",
                table: "OrderHistory");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "AddressedOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_StoreId",
                table: "OrderHistory",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressedOrders_StoreId",
                table: "AddressedOrders",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressedOrders_Stores_StoreId",
                table: "AddressedOrders",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressedOrders_Stores_StoreId",
                table: "AddressedOrders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_StoreId",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_AddressedOrders_StoreId",
                table: "AddressedOrders");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "AddressedOrders");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_StoreId",
                table: "OrderHistory",
                column: "StoreId",
                unique: true);
        }
    }
}
