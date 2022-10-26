using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProyecto.Migrations
{
    public partial class UpdateTableConsume1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materialConsume_Task_taskId",
                table: "materialConsume");

            migrationBuilder.RenameColumn(
                name: "taskId",
                table: "materialConsume",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsume_taskId",
                table: "materialConsume",
                newName: "IX_materialConsume_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsume_Task_TaskId",
                table: "materialConsume",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materialConsume_Task_TaskId",
                table: "materialConsume");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "materialConsume",
                newName: "taskId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsume_TaskId",
                table: "materialConsume",
                newName: "IX_materialConsume_taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsume_Task_taskId",
                table: "materialConsume",
                column: "taskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
