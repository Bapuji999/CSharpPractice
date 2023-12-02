using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore3.Migrations
{
    public partial class Departmentadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "DepartmentId", "CollegeId", "DepartmentHead", "DepartmentName", "NuumberOfClass" },
                values: new object[,]
                {
                    { 1, 1, "Prof. Muktesh", "Computer Science", 5 },
                    { 2, 1, "Prof. Resav", "Mech", 3 },
                    { 3, 2, "Prof. John", "ETC", 4 },
                    { 4, 2, "Prof. Rekha", "Civil", 5 },
                    { 5, 3, "Prof. Albert", "Computer Science", 5 },
                    { 6, 3, "Prof. Rohit", "Mech", 5 },
                    { 7, 4, "Prof. Jadu", "ETC", 5 },
                    { 8, 4, "Prof. Ramnesh", "Civil", 5 },
                    { 9, 5, "Prof. Rghav", "Computer Science", 5 },
                    { 10, 6, "Prof. Jignesh", "Computer Science", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "department",
                keyColumn: "DepartmentId",
                keyValue: 10);
        }
    }
}
