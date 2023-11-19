using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sibers.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditedTypeOfProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AuthorizerId",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "MiddleName", "UserId" },
                values: new object[,]
                {
                    { 1L, "admin@gmail.com", "AdminFirstName", "AdminLastName", "AdminMiddleName", 1L },
                    { 2L, "ProjectManager@gmail.com", "ProjectManager", "ProjectManager", "ProjectManager", 2L },
                    { 3L, "FreeProjectManager@gmail.com", "FreeProjectManager", "FreeProjectManager", "FreeProjectManager", 3L },
                    { 4L, "Employee@gmail.com", "Employee", "Employee", "Employee", 4L },
                    { 5L, "FreeEmployee@gmail.com", "FreeEmployee", "FreeEmployee", "FreeEmployee", 5L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CustomerName", "EndDate", "Name", "PerformerName", "Priority", "ProjectManagerId", "StartDate" },
                values: new object[,]
                {
                    { 1L, "SibersCompany", new DateTime(2023, 11, 26, 23, 54, 3, 366, DateTimeKind.Local).AddTicks(376), "SibersTestApi", "GTEXCorp", 1, 2L, new DateTime(2023, 11, 19, 23, 54, 3, 366, DateTimeKind.Local).AddTicks(366) },
                    { 2L, "WithoutEmployees", new DateTime(2023, 11, 26, 23, 54, 3, 366, DateTimeKind.Local).AddTicks(395), "FreeProject", "WithoutJobs", 1, 2L, new DateTime(2023, 11, 19, 23, 54, 3, 366, DateTimeKind.Local).AddTicks(395) }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AuthorizerId", "Comment", "JobStatus", "Name", "PerformerId", "Priority", "ProjectId" },
                values: new object[,]
                {
                    { 1L, 2L, "Job - Project #1", 3, "Job - Sibers Project", 4L, 5, 1L },
                    { 2L, 1L, "Job - Project #2", 1, "Job - GTEX Project", 4L, 10, 1L }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[] { 4L, 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProjectEmployee",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 4L, 1L });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorizerId",
                table: "Jobs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
