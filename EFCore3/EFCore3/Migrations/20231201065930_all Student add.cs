using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore3.Migrations
{
    public partial class allStudentadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "StudentId", "Age", "DepartmentId", "StudentAddress", "StudentMarks", "StudentName", "StudentPercentage", "StudentResult" },
                values: new object[,]
                {
                    { 2, 19, 1, "Prakash Nagar 2589", 680.0, "Aras", 0.0, "" },
                    { 3, 16, 2, "Prakash Nagar 2589", 520.0, "Anubhab", 0.0, "" },
                    { 4, 17, 2, "Prakash Nagar 2589", 750.0, "Pranab", 0.0, "" },
                    { 5, 20, 3, "Some Address", 850.0, "Amit", 0.0, "" },
                    { 6, 18, 3, "Another Address", 720.0, "Sara", 0.0, "" },
                    { 7, 21, 4, "Yet Another Address", 920.0, "Rahul", 0.0, "" },
                    { 8, 22, 4, "One More Address", 630.0, "Neha", 0.0, "" },
                    { 9, 19, 5, "Sunset Avenue", 200.0, "Sandeep", 0.0, "" },
                    { 10, 20, 5, "Maple Street", 720.0, "Monica", 0.0, "" },
                    { 11, 18, 6, "Greenfield Road", 190.0, "Rajesh", 0.0, "" },
                    { 12, 21, 6, "Cypress Lane", 670.0, "Pooja", 0.0, "" },
                    { 13, 22, 7, "Oak Street", 950.0, "Vinay", 0.0, "" },
                    { 14, 19, 7, "Cedar Avenue", 820.0, "Aisha", 0.0, "" },
                    { 15, 20, 7, "Pine Road", 890.0, "Rakesh", 0.0, "" },
                    { 16, 21, 8, "Birch Lane", 750.0, "Nina", 0.0, "" },
                    { 17, 18, 8, "Redwood Boulevard", 910.0, "Kiran", 0.0, "" },
                    { 18, 22, 9, "Fir Street", 680.0, "Aditi", 0.0, "" },
                    { 19, 20, 9, "Willow Lane", 870.0, "Suman", 0.0, "" },
                    { 20, 21, 9, "Magnolia Street", 720.0, "Vikas", 0.0, "" },
                    { 21, 19, 10, "Cherry Avenue", 930.0, "Nisha", 0.0, "" },
                    { 22, 22, 10, "Chestnut Road", 690.0, "Rohit", 0.0, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "StudentId",
                keyValue: 22);
        }
    }
}
