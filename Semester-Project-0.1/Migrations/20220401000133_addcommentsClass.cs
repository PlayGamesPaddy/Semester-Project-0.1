using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class addcommentsClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_RecurringClasses_recurringClassInstentId",
                table: "classStudentList");

            migrationBuilder.DropForeignKey(
                name: "FK_classStudentList_Students_studentId",
                table: "classStudentList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_classStudentList",
                table: "classStudentList");

            migrationBuilder.RenameTable(
                name: "classStudentList",
                newName: "ClassStudentList");

            migrationBuilder.RenameIndex(
                name: "IX_classStudentList_studentId",
                table: "ClassStudentList",
                newName: "IX_ClassStudentList_studentId");

            migrationBuilder.RenameIndex(
                name: "IX_classStudentList_recurringClassInstentId",
                table: "ClassStudentList",
                newName: "IX_ClassStudentList_recurringClassInstentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStudentList",
                table: "ClassStudentList",
                column: "id");

            migrationBuilder.CreateTable(
                name: "ClassStudentComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassStudentListid = table.Column<int>(type: "int", nullable: true),
                    commentatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudentComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudentComment_AspNetUsers_commentatorId",
                        column: x => x.commentatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassStudentComment_ClassStudentList_ClassStudentListid",
                        column: x => x.ClassStudentListid,
                        principalTable: "ClassStudentList",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentComment_ClassStudentListid",
                table: "ClassStudentComment",
                column: "ClassStudentListid");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentComment_commentatorId",
                table: "ClassStudentComment",
                column: "commentatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudentList_RecurringClasses_recurringClassInstentId",
                table: "ClassStudentList",
                column: "recurringClassInstentId",
                principalTable: "RecurringClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudentList_Students_studentId",
                table: "ClassStudentList",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudentList_RecurringClasses_recurringClassInstentId",
                table: "ClassStudentList");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudentList_Students_studentId",
                table: "ClassStudentList");

            migrationBuilder.DropTable(
                name: "ClassStudentComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStudentList",
                table: "ClassStudentList");

            migrationBuilder.RenameTable(
                name: "ClassStudentList",
                newName: "classStudentList");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudentList_studentId",
                table: "classStudentList",
                newName: "IX_classStudentList_studentId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudentList_recurringClassInstentId",
                table: "classStudentList",
                newName: "IX_classStudentList_recurringClassInstentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classStudentList",
                table: "classStudentList",
                column: "id");

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
    }
}
