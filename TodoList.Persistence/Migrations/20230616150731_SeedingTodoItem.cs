using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoList.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTodoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "Done", "DueDate", "Tags", "Title" },
                values: new object[,]
                {
                    { new Guid("446dbd7e-6564-43fb-82cc-eb2ba631736b"), "Content2", "a58633c9-3c6a-4580-8ad1-0720b582094f", new DateTime(2023, 6, 16, 18, 37, 31, 890, DateTimeKind.Local).AddTicks(586), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "Title2" },
                    { new Guid("f7cabd24-da8d-4ae6-92fb-87ba0ef5c298"), "Content1", "a58633c9-3c6a-4580-8ad1-0720b582094f", new DateTime(2023, 6, 16, 18, 37, 31, 890, DateTimeKind.Local).AddTicks(543), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daily", "Title1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("446dbd7e-6564-43fb-82cc-eb2ba631736b"));

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: new Guid("f7cabd24-da8d-4ae6-92fb-87ba0ef5c298"));
        }
    }
}
