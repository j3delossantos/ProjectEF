using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnImpactCategoryInitialDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "Task",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "Category",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Description", "Impact", "Name" },
                values: new object[,]
                {
                    { new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf02"), " All pending activities description", 2, "Pending Activities" },
                    { new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf03"), " Meetings, birthdates and appointments", 5, "Upcoming events" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "CategoryID", "CreationDate", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf50"), new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf02"), new DateTime(2024, 1, 2, 23, 2, 22, 205, DateTimeKind.Local).AddTicks(8910), " Call for a quote on the tenant insurance", 1, "Call the insurance company" },
                    { new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf51"), new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf03"), new DateTime(2024, 1, 2, 23, 2, 22, 205, DateTimeKind.Local).AddTicks(8968), " Job interview at Boeing on Friday ", 2, "Job Interview" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf50"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskID",
                keyValue: new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf51"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf02"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryID",
                keyValue: new Guid("dfd661e0-369b-4f7d-8382-27dd541eaf03"));

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Task",
                newName: "Desciption");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Category",
                newName: "Desciption");
        }
    }
}
