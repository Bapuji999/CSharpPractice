using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_4.Migrations
{
    public partial class keychanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleIssue_PaymentDetails_VehicleIssueId",
                table: "VehicleIssue");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleIssueId",
                table: "VehicleIssue",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_VehicleIssueId",
                table: "PaymentDetails",
                column: "VehicleIssueId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_VehicleIssue_VehicleIssueId",
                table: "PaymentDetails",
                column: "VehicleIssueId",
                principalTable: "VehicleIssue",
                principalColumn: "VehicleIssueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_VehicleIssue_VehicleIssueId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_VehicleIssueId",
                table: "PaymentDetails");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleIssueId",
                table: "VehicleIssue",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleIssue_PaymentDetails_VehicleIssueId",
                table: "VehicleIssue",
                column: "VehicleIssueId",
                principalTable: "PaymentDetails",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
