using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore3.Migrations
{
    public partial class Professoradd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salary",
                table: "professor",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.InsertData(
                table: "professor",
                columns: new[] { "ProfessorId", "DepartmentId", "ProfessorAddress", "ProfessorAge", "ProfessorName", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "Muktanagar 1234", 40, "Prof. Muktesh", 50000.120000000003 },
                    { 2, 2, "Resavnagar 1234", 34, "Prof. Resav", 35000.120000000003 },
                    { 3, 3, "JohnNagar 1234", 34, "Prof. John", 15000.34 },
                    { 4, 4, "RekhaNagar 1234", 29, "Prof. Rekha", 25000.459999999999 },
                    { 5, 5, "AlbertNagar 1234", 58, "Prof. Albert", 60000.0 },
                    { 6, 6, "RohitNagar 1234", 28, "Prof. Rohit", 26000.0 },
                    { 7, 7, "JaduNagar 1234", 38, "Prof. Jadu", 58000.0 },
                    { 8, 8, "RamneshNagar 1234", 34, "Prof. Ramnesh", 38000.0 },
                    { 9, 9, "RghavNagar 1234", 41, "Prof. Rghav", 45000.0 },
                    { 10, 10, "JigneshNagar 1234", 46, "Prof. Jignesh", 55000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "professor",
                keyColumn: "ProfessorId",
                keyValue: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "professor",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
