using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Migrations
{
    public partial class locationtoaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Addresses_LocationAddressId",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "LocationAddressId",
                table: "Stores",
                newName: "AddressId1");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_LocationAddressId",
                table: "Stores",
                newName: "IX_Stores_AddressId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_AddressId1",
                table: "Stores",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Addresses_AddressId1",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "AddressId1",
                table: "Stores",
                newName: "LocationAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_AddressId1",
                table: "Stores",
                newName: "IX_Stores_LocationAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_LocationAddressId",
                table: "Stores",
                column: "LocationAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
