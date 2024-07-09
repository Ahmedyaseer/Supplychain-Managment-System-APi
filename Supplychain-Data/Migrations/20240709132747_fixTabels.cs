using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supplychain_Data.Migrations
{
    /// <inheritdoc />
    public partial class fixTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "WarehouseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickingListTime",
                table: "PickingLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderSupplyDate",
                table: "OrderSupply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "WarehouseItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickingListTime",
                table: "PickingLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationTime",
                table: "OrderSupplyItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderSupplyDate",
                table: "OrderSupply",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 7, 9, 16, 27, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
