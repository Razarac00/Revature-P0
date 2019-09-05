using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Migrations
{
    public partial class latestordernomore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AddressedOrders_LatestOrderAddressedOrderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LatestOrderAddressedOrderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LatestOrderAddressedOrderId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LatestOrderAddressedOrderId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LatestOrderAddressedOrderId",
                table: "Users",
                column: "LatestOrderAddressedOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AddressedOrders_LatestOrderAddressedOrderId",
                table: "Users",
                column: "LatestOrderAddressedOrderId",
                principalTable: "AddressedOrders",
                principalColumn: "AddressedOrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
