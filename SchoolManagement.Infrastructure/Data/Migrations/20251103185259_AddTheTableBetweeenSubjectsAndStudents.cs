using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTheTableBetweeenSubjectsAndStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsSubjects_Students_StudentsId",
                table: "StudentsSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsSubjects_Subjects_SubjectsId",
                table: "StudentsSubjects");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "StudentsSubjects",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "StudentsSubjects",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsSubjects_SubjectsId",
                table: "StudentsSubjects",
                newName: "IX_StudentsSubjects_SubjectId");

            migrationBuilder.AddColumn<decimal>(
                name: "grade",
                table: "StudentsSubjects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "InsManagerId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ENameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorsSubjects",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorsSubjects", x => new { x.SubjectsId, x.SupervisorId });
                    table.ForeignKey(
                        name: "FK_InstructorsSubjects_Instructors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorsSubjects_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsManagerId",
                table: "Departments",
                column: "InsManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorsSubjects_SupervisorId",
                table: "InstructorsSubjects",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_InsManagerId",
                table: "Departments",
                column: "InsManagerId",
                principalTable: "Instructors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsSubjects_Students_StudentId",
                table: "StudentsSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsSubjects_Subjects_SubjectId",
                table: "StudentsSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_InsManagerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsSubjects_Students_StudentId",
                table: "StudentsSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsSubjects_Subjects_SubjectId",
                table: "StudentsSubjects");

            migrationBuilder.DropTable(
                name: "InstructorsSubjects");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InsManagerId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "StudentsSubjects");

            migrationBuilder.DropColumn(
                name: "InsManagerId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "StudentsSubjects",
                newName: "SubjectsId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentsSubjects",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsSubjects_SubjectId",
                table: "StudentsSubjects",
                newName: "IX_StudentsSubjects_SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsSubjects_Students_StudentsId",
                table: "StudentsSubjects",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsSubjects_Subjects_SubjectsId",
                table: "StudentsSubjects",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
