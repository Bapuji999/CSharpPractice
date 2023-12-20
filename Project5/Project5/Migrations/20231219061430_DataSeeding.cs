using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project5.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "UserRolls",
                columns: new[] { "RollId", "RollType" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Vendor" },
                    { 3, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsActive", "Password", "Phone", "RollId", "UserName" },
                values: new object[,]
                {
                    { 1, "admin999@gmail.com", true, "Admin1", "9874563210", 1, "Admin1" },
                    { 2, "vendor999@gmail.com", true, "vendor1", "7896543210", 2, "vendor1" },
                    { 3, "vendor99@gmail.com", true, "vendor2", "6985741237", 2, "vendor2" },
                    { 4, "vendor9@gmail.com", true, "vendor3", "6985231475", 2, "vendor3" },
                    { 5, "bipin@gmail.com", true, "customer1", "7458963215", 3, "Bipin" },
                    { 6, "harsha@gmail.com", true, "customer2", "8596741235", 3, "Harsha" },
                    { 7, "laxman@gmail.com", true, "customer3", "9632587451", 3, "Laxman" },
                    { 8, "nihar@gmail.com", true, "customer4", "8574963214", 3, "Nihar" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRolls",
                keyColumn: "RollId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRolls",
                keyColumn: "RollId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRolls",
                keyColumn: "RollId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }
    }
}
