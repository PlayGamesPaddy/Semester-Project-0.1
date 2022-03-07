using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Semester_Project_0._1.Migrations
{
    public partial class addingRecurringClassesToTheDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecurringClassInstentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurringClassInstentId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecurringClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstClassDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastClassDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    InstructerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecurringType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringClasses_AspNetUsers_InstructerId",
                        column: x => x.InstructerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_RecurringClassInstentId",
                table: "Students",
                column: "RecurringClassInstentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_RecurringClassInstentId",
                table: "Classes",
                column: "RecurringClassInstentId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringClasses_InstructerId",
                table: "RecurringClasses",
                column: "InstructerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_RecurringClasses_RecurringClassInstentId",
                table: "Classes",
                column: "RecurringClassInstentId",
                principalTable: "RecurringClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_RecurringClasses_RecurringClassInstentId",
                table: "Students",
                column: "RecurringClassInstentId",
                principalTable: "RecurringClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_RecurringClasses_RecurringClassInstentId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_RecurringClasses_RecurringClassInstentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "RecurringClasses");

            migrationBuilder.DropIndex(
                name: "IX_Students_RecurringClassInstentId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Classes_RecurringClassInstentId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "RecurringClassInstentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RecurringClassInstentId",
                table: "Classes");
        }
    }
}
