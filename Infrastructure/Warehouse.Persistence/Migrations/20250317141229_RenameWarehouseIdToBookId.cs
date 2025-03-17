using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameWarehouseIdToBookId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_operation_items_base_operations_base_operation_id",
                table: "operation_items");

            migrationBuilder.DropForeignKey(
                name: "fk_operation_items_warehouse_items_warehouse_item_id",
                table: "operation_items");

            migrationBuilder.DropIndex(
                name: "ix_operation_items_base_operation_id",
                table: "operation_items");

            migrationBuilder.RenameColumn(
                name: "warehouse_item_id",
                table: "operation_items",
                newName: "book_id");

            migrationBuilder.RenameColumn(
                name: "base_operation_id",
                table: "operation_items",
                newName: "operation_id");

            migrationBuilder.RenameIndex(
                name: "ix_operation_items_warehouse_item_id",
                table: "operation_items",
                newName: "ix_operation_items_operation_id");

            migrationBuilder.AddForeignKey(
                name: "fk_operation_items_base_operations_operation_id",
                table: "operation_items",
                column: "operation_id",
                principalTable: "operations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_operation_items_base_operations_operation_id",
                table: "operation_items");

            migrationBuilder.RenameColumn(
                name: "operation_id",
                table: "operation_items",
                newName: "warehouse_item_id");

            migrationBuilder.RenameColumn(
                name: "book_id",
                table: "operation_items",
                newName: "base_operation_id");

            migrationBuilder.RenameIndex(
                name: "ix_operation_items_operation_id",
                table: "operation_items",
                newName: "ix_operation_items_warehouse_item_id");

            migrationBuilder.CreateIndex(
                name: "ix_operation_items_base_operation_id",
                table: "operation_items",
                column: "base_operation_id");

            migrationBuilder.AddForeignKey(
                name: "fk_operation_items_base_operations_base_operation_id",
                table: "operation_items",
                column: "base_operation_id",
                principalTable: "operations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_operation_items_warehouse_items_warehouse_item_id",
                table: "operation_items",
                column: "warehouse_item_id",
                principalTable: "warehouse_items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
