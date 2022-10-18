using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProyecto.Migrations
{
    public partial class fixtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_tasks_TaskId",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_TaskId",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "materials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_materials_TaskId",
                table: "materials",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_tasks_TaskId",
                table: "materials",
                column: "TaskId",
                principalTable: "tasks",
                principalColumn: "Id");
        }
    }
}
