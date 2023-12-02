using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_4.Migrations
{
    public partial class dataadedtoUserType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdvancePaymentDone",
                table: "PaymentDetails",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFullPaymentDone",
                table: "PaymentDetails",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TotalPayment",
                table: "PaymentDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeId", "UserTypeName" },
                values: new object[] { 3, "Platinum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserType",
                keyColumn: "UserTypeId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "IsAdvancePaymentDone",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "IsFullPaymentDone",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "TotalPayment",
                table: "PaymentDetails");
        }
    }
}
