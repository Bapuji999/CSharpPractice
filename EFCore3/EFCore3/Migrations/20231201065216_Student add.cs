using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore3.Migrations
{
    public partial class Studentadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "StudentPercentage",
                table: "student",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "StudentMarks",
                table: "student",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "StudentId", "Age", "DepartmentId", "StudentAddress", "StudentMarks", "StudentName", "StudentPercentage", "StudentResult" },
                values: new object[] { 1, 18, 1, "Prakash Nagar 2589", 980.0, "Prasad", 0.0, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "StudentPercentage",
                table: "student",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "StudentMarks",
                table: "student",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
