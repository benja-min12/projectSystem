using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProyecto.Migrations
{
    public partial class addStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materialConsumes_materials_materialId",
                table: "materialConsumes");

            migrationBuilder.DropForeignKey(
                name: "FK_materialConsumes_tasks_taskId",
                table: "materialConsumes");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_projects_ProjectId",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materials",
                table: "materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materialConsumes",
                table: "materialConsumes");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "Material");

            migrationBuilder.RenameTable(
                name: "materialConsumes",
                newName: "materialConsume");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_ProjectId",
                table: "Task",
                newName: "IX_Task_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsumes_taskId",
                table: "materialConsume",
                newName: "IX_materialConsume_taskId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsumes_materialId",
                table: "materialConsume",
                newName: "IX_materialConsume_materialId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_materialConsume",
                table: "materialConsume",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsume_Material_materialId",
                table: "materialConsume",
                column: "materialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsume_Task_taskId",
                table: "materialConsume",
                column: "taskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materialConsume_Material_materialId",
                table: "materialConsume");

            migrationBuilder.DropForeignKey(
                name: "FK_materialConsume_Task_taskId",
                table: "materialConsume");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materialConsume",
                table: "materialConsume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "tasks");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "projects");

            migrationBuilder.RenameTable(
                name: "materialConsume",
                newName: "materialConsumes");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "materials");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ProjectId",
                table: "tasks",
                newName: "IX_tasks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsume_taskId",
                table: "materialConsumes",
                newName: "IX_materialConsumes_taskId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsume_materialId",
                table: "materialConsumes",
                newName: "IX_materialConsumes_materialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                table: "tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_materialConsumes",
                table: "materialConsumes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_materials",
                table: "materials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsumes_materials_materialId",
                table: "materialConsumes",
                column: "materialId",
                principalTable: "materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsumes_tasks_taskId",
                table: "materialConsumes",
                column: "taskId",
                principalTable: "tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_projects_ProjectId",
                table: "tasks",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
