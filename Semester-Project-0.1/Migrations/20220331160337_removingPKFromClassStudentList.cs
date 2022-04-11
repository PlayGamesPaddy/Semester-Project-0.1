using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class removingPKFromClassStudentList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_RecurringClasses_recurringClassInstentId",
                table: "classStudentList");

            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_Students_studentId",
                table: "classStudentList");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "classStudentList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "recurringClassInstentId",
                table: "classStudentList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_classStudentList_RecurringClasses_recurringClassInstentId",
                table: "classStudentList",
                column: "recurringClassInstentId",
                principalTable: "RecurringClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_classStudentList_Students_studentId",
                table: "classStudentList",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_RecurringClasses_recurringClassInstentId",
                table: "classStudentList");

            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_Students_studentId",
                table: "classStudentList");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "classStudentList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "recurringClassInstentId",
                table: "classStudentList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_classStudentList_RecurringClasses_recurringClassInstentId",
                table: "classStudentList",
                column: "recurringClassInstentId",
                principalTable: "RecurringClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_classStudentList_Students_studentId",
                table: "classStudentList",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
