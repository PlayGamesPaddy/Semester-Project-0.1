using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class updateRClassModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_RecurringClasses_RecurringClassInstentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RecurringClassInstentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RecurringClassInstentId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStudents",
                table: "RecurringClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "classStudentList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    recuringClassId = table.Column<int>(type: "int", nullable: false),
                    RecurringClassInstentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classStudentList", x => x.id);
                    table.ForeignKey(
                        name: "FK_classStudentList_RecurringClasses_RecurringClassInstentId",
                        column: x => x.RecurringClassInstentId,
                        principalTable: "RecurringClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classStudentList_RecurringClassInstentId",
                table: "classStudentList",
                column: "RecurringClassInstentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classStudentList");

            migrationBuilder.DropColumn(
                name: "NumberOfStudents",
                table: "RecurringClasses");

            migrationBuilder.AddColumn<int>(
                name: "RecurringClassInstentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_RecurringClassInstentId",
                table: "Students",
                column: "RecurringClassInstentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_RecurringClasses_RecurringClassInstentId",
                table: "Students",
                column: "RecurringClassInstentId",
                principalTable: "RecurringClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
