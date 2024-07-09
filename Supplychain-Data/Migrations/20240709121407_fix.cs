using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supplychain_Data.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSupplyItems_Items_itemId",
                table: "OrderSupplyItems");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "OrderSupplyItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSupplyItems_itemId",
                table: "OrderSupplyItems",
                newName: "IX_OrderSupplyItems_ItemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickingListTime",
                table: "PickingLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Sequence",
                table: "OrderSupply",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderSupplyDate",
                table: "OrderSupply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSupplyItems_Items_ItemId",
                table: "OrderSupplyItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSupplyItems_Items_ItemId",
                table: "OrderSupplyItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "OrderSupplyItems",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSupplyItems_ItemId",
                table: "OrderSupplyItems",
                newName: "IX_OrderSupplyItems_itemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickingListTime",
                table: "PickingLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "Sequence",
                table: "OrderSupply",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderSupplyDate",
                table: "OrderSupply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 8, 16, 28, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSupplyItems_Items_itemId",
                table: "OrderSupplyItems",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
