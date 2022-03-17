using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class updateRClassModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfStudents",
                table: "RecurringClasses",
                newName: "MaxNumberOfStudents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxNumberOfStudents",
                table: "RecurringClasses",
                newName: "NumberOfStudents");
        }
    }
}
