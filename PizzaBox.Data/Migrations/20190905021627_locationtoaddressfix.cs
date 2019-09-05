using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Migrations
{
    public partial class locationtoaddressfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Addresses_AddressId1",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_AddressId1",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AddressId",
                table: "Stores",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_AddressId",
                table: "Stores",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Addresses_AddressId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_AddressId",
                table: "Stores");

            migrationBuilder.AddColumn<int>(
                name: "AddressId1",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AddressId1",
                table: "Stores",
                column: "AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_AddressId1",
                table: "Stores",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
