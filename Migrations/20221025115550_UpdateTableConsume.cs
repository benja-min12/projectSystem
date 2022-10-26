using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProyecto.Migrations
{
    public partial class UpdateTableConsume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materialConsume_Material_materialId",
                table: "materialConsume");

            migrationBuilder.RenameColumn(
                name: "materialId",
                table: "materialConsume",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsume_materialId",
                table: "materialConsume",
                newName: "IX_materialConsume_MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsume_Material_MaterialId",
                table: "materialConsume",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materialConsume_Material_MaterialId",
                table: "materialConsume");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "materialConsume",
                newName: "materialId");

            migrationBuilder.RenameIndex(
                name: "IX_materialConsume_MaterialId",
                table: "materialConsume",
                newName: "IX_materialConsume_materialId");

            migrationBuilder.AddForeignKey(
                name: "FK_materialConsume_Material_materialId",
                table: "materialConsume",
                column: "materialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
