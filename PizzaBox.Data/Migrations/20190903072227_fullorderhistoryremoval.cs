using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Migrations
{
    public partial class fullorderhistoryremoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_AddressedOrders_UserId",
                table: "AddressedOrders");

            migrationBuilder.AddColumn<int>(
                name: "LatestOrderAddressedOrderId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LatestOrderAddressedOrderId",
                table: "Users",
                column: "LatestOrderAddressedOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressedOrders_UserId",
                table: "AddressedOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AddressedOrders_LatestOrderAddressedOrderId",
                table: "Users",
                column: "LatestOrderAddressedOrderId",
                principalTable: "AddressedOrders",
                principalColumn: "AddressedOrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AddressedOrders_LatestOrderAddressedOrderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LatestOrderAddressedOrderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_AddressedOrders_UserId",
                table: "AddressedOrders");

            migrationBuilder.DropColumn(
                name: "LatestOrderAddressedOrderId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_UserId",
                table: "OrderHistory",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressedOrders_UserId",
                table: "AddressedOrders",
                column: "UserId",
                unique: true);
        }
    }
}
