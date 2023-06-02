using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MainTaskAndSubTaskTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MainTasks",
                table: "MainTasks");

            migrationBuilder.RenameTable(
                name: "MainTasks",
                newName: "MainTask");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "MainTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "MainTask",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MainTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "MainTask",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PriorityLevel",
                table: "MainTask",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Progress",
                table: "MainTask",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainTask",
                table: "MainTask",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SubTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    MainTaskDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTask_MainTask_MainTaskDTOId",
                        column: x => x.MainTaskDTOId,
                        principalTable: "MainTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_MainTaskDTOId",
                table: "SubTask",
                column: "MainTaskDTOId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainTask",
                table: "MainTask");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "MainTask");

            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "MainTask");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MainTask");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "MainTask");

            migrationBuilder.DropColumn(
                name: "PriorityLevel",
                table: "MainTask");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "MainTask");

            migrationBuilder.RenameTable(
                name: "MainTask",
                newName: "MainTasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainTasks",
                table: "MainTasks",
                column: "Id");
        }
    }
}
