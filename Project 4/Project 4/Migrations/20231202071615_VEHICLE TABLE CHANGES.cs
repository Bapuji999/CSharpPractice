using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_4.Migrations
{
    public partial class VEHICLETABLECHANGES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicle");
        }
    }
}
