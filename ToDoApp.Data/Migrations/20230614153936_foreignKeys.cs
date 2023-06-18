using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTask_MainTask_MainTaskDTOId",
                table: "SubTask");

            migrationBuilder.DropIndex(
                name: "IX_SubTask_MainTaskDTOId",
                table: "SubTask");

            migrationBuilder.DropColumn(
                name: "MainTaskDTOId",
                table: "SubTask");

            migrationBuilder.AddColumn<int>(
                name: "MainTaskId",
                table: "SubTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_MainTaskId",
                table: "SubTask",
                column: "MainTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTask_MainTask_MainTaskId",
                table: "SubTask",
                column: "MainTaskId",
                principalTable: "MainTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTask_MainTask_MainTaskId",
                table: "SubTask");

            migrationBuilder.DropIndex(
                name: "IX_SubTask_MainTaskId",
                table: "SubTask");

            migrationBuilder.DropColumn(
                name: "MainTaskId",
                table: "SubTask");

            migrationBuilder.AddColumn<int>(
                name: "MainTaskDTOId",
                table: "SubTask",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_MainTaskDTOId",
                table: "SubTask",
                column: "MainTaskDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTask_MainTask_MainTaskDTOId",
                table: "SubTask",
                column: "MainTaskDTOId",
                principalTable: "MainTask",
                principalColumn: "Id");
        }
    }
}
