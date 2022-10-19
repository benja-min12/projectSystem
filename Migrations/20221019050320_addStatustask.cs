using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProyecto.Migrations
{
    public partial class addStatustask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Task");
        }
    }
}
