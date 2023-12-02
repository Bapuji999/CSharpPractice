using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "universitie",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UniversityName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnversityType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnvesrsityGrade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnversityAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universitie", x => x.UniversityId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "college",
                columns: table => new
                {
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CollegeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CollegeType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CollegeAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_college", x => x.CollegeId);
                    table.ForeignKey(
                        name: "FK_college_universitie_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "universitie",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NuumberOfClass = table.Column<int>(type: "int", nullable: false),
                    DepartmentHead = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_department_college_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "college",
                        principalColumn: "CollegeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfessorName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfessorAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfessorAge = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.ProfessorId);
                    table.ForeignKey(
                        name: "FK_professor_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    StudentPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    StudentMarks = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    StudentResult = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_student_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "universitie",
                columns: new[] { "UniversityId", "UniversityName", "UnversityAddress", "UnversityType", "UnvesrsityGrade" },
                values: new object[] { 1, "Harvard University", "Cambridge, Massachusetts", "Private", "A+" });

            migrationBuilder.InsertData(
                table: "universitie",
                columns: new[] { "UniversityId", "UniversityName", "UnversityAddress", "UnversityType", "UnvesrsityGrade" },
                values: new object[] { 2, "MIT", "Cambridge, Massachusetts", "Private", "A" });

            migrationBuilder.InsertData(
                table: "universitie",
                columns: new[] { "UniversityId", "UniversityName", "UnversityAddress", "UnversityType", "UnvesrsityGrade" },
                values: new object[] { 3, "Stanford University", "Stanford, California", "Private", "A+" });

            migrationBuilder.InsertData(
                table: "college",
                columns: new[] { "CollegeId", "CollegeAddress", "CollegeName", "CollegeType", "UniversityId" },
                values: new object[,]
                {
                    { 1, "123 College Street 1", "Engineering College 1", "Technical", 1 },
                    { 2, "123 College Street 2", "Engineering College 2", "Technical", 1 },
                    { 3, "123 College Street 3", "Engineering College 3", "Technical", 2 },
                    { 4, "123 College Street 4", "Engineering College 4", "Technical", 2 },
                    { 5, "123 College Street 5", "Engineering College 5", "Technical", 3 },
                    { 6, "123 College Street 6", "Engineering College 6", "Technical", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_college_UniversityId",
                table: "college",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_department_CollegeId",
                table: "department",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_professor_DepartmentId",
                table: "professor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_student_DepartmentId",
                table: "student",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "professor");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "college");

            migrationBuilder.DropTable(
                name: "universitie");
        }
    }
}
