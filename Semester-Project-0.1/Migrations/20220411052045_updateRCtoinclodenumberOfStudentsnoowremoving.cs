using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class updateRCtoinclodenumberOfStudentsnoowremoving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsEnrolled",
                table: "RecurringClasses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsEnrolled",
                table: "RecurringClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
