using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class changingClassStudentListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_RecurringClasses_RecurringClassInstentId",
                table: "classStudentList");

            migrationBuilder.DropColumn(
                name: "recuringClassId",
                table: "classStudentList");

            migrationBuilder.RenameColumn(
                name: "RecurringClassInstentId",
                table: "classStudentList",
                newName: "recurringClassInstentId");

            migrationBuilder.RenameIndex(
                name: "IX_classStudentList_RecurringClassInstentId",
                table: "classStudentList",
                newName: "IX_classStudentList_recurringClassInstentId");

            migrationBuilder.AlterColumn<int>(
                name: "recurringClassInstentId",
                table: "classStudentList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_classStudentList_studentId",
                table: "classStudentList",
                column: "studentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_RecurringClasses_recurringClassInstentId",
                table: "classStudentList");

            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_Students_studentId",
                table: "classStudentList");

            migrationBuilder.DropIndex(
                name: "IX_classStudentList_studentId",
                table: "classStudentList");

            migrationBuilder.RenameColumn(
                name: "recurringClassInstentId",
                table: "classStudentList",
                newName: "RecurringClassInstentId");

            migrationBuilder.RenameIndex(
                name: "IX_classStudentList_recurringClassInstentId",
                table: "classStudentList",
                newName: "IX_classStudentList_RecurringClassInstentId");

            migrationBuilder.AlterColumn<int>(
                name: "RecurringClassInstentId",
                table: "classStudentList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "recuringClassId",
                table: "classStudentList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_classStudentList_RecurringClasses_RecurringClassInstentId",
                table: "classStudentList",
                column: "RecurringClassInstentId",
                principalTable: "RecurringClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
