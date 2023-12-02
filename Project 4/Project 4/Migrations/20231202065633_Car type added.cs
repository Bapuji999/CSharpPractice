using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_4.Migrations
{
    public partial class Cartypeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "VehicleTypeId", "VehicleTypeName" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "Jeep" },
                    { 3, "Van" },
                    { 4, "Wagon" },
                    { 5, "Coupe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "VehicleTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "VehicleTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "VehicleTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "VehicleTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "VehicleTypeId",
                keyValue: 5);
        }
    }
}
