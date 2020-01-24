using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeGladiatus.Application.Migrations
{
    public partial class CreatedNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackerUserId = table.Column<int>(nullable: false),
                    AttackerCharId = table.Column<int>(nullable: false),
                    TargetUserId = table.Column<int>(nullable: false),
                    TargetCharId = table.Column<int>(nullable: false),
                    FightTime = table.Column<DateTime>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
