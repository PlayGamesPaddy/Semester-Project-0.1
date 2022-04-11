using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class updateRCtoinclodenumberOfStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsEnrolled",
                table: "RecurringClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsEnrolled",
                table: "RecurringClasses");
        }
    }
}
