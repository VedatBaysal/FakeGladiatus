using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeGladiatus.Application.Migrations
{
    public partial class levelSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Exp",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Characters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exp",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Characters");
        }
    }
}
