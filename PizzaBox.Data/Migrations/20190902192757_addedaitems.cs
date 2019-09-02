using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Data.Migrations
{
    public partial class addedaitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AItem_Pizzas_PizzaId",
                table: "AItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_AItem_ItemAItemId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_AItem_CrustAItemId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_AItem_SizeAItemId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AItem",
                table: "AItem");

            migrationBuilder.RenameTable(
                name: "AItem",
                newName: "AItems");

            migrationBuilder.RenameIndex(
                name: "IX_AItem_PizzaId",
                table: "AItems",
                newName: "IX_AItems_PizzaId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Last",
                table: "Name",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "First",
                table: "Name",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AItems",
                table: "AItems",
                column: "AItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AItems_Pizzas_PizzaId",
                table: "AItems",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "PizzaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_AItems_ItemAItemId",
                table: "InventoryItem",
                column: "ItemAItemId",
                principalTable: "AItems",
                principalColumn: "AItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_AItems_CrustAItemId",
                table: "Pizzas",
                column: "CrustAItemId",
                principalTable: "AItems",
                principalColumn: "AItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_AItems_SizeAItemId",
                table: "Pizzas",
                column: "SizeAItemId",
                principalTable: "AItems",
                principalColumn: "AItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AItems_Pizzas_PizzaId",
                table: "AItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItem_AItems_ItemAItemId",
                table: "InventoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_AItems_CrustAItemId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_AItems_SizeAItemId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AItems",
                table: "AItems");

            migrationBuilder.RenameTable(
                name: "AItems",
                newName: "AItem");

            migrationBuilder.RenameIndex(
                name: "IX_AItems_PizzaId",
                table: "AItem",
                newName: "IX_AItem_PizzaId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Last",
                table: "Name",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "First",
                table: "Name",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AItem",
                table: "AItem",
                column: "AItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AItem_Pizzas_PizzaId",
                table: "AItem",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "PizzaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItem_AItem_ItemAItemId",
                table: "InventoryItem",
                column: "ItemAItemId",
                principalTable: "AItem",
                principalColumn: "AItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_AItem_CrustAItemId",
                table: "Pizzas",
                column: "CrustAItemId",
                principalTable: "AItem",
                principalColumn: "AItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_AItem_SizeAItemId",
                table: "Pizzas",
                column: "SizeAItemId",
                principalTable: "AItem",
                principalColumn: "AItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
