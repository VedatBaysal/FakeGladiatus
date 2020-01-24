using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeGladiatus.Application.Migrations
{
    public partial class UpdatedNotificationx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Characters_TargetCharIdId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TargetCharIdId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TargetCharIdId",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "TargetCharId",
                table: "Notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetCharId",
                table: "Notifications",
                column: "TargetCharId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Characters_TargetCharId",
                table: "Notifications",
                column: "TargetCharId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Characters_TargetCharId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TargetCharId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TargetCharId",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "TargetCharIdId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetCharIdId",
                table: "Notifications",
                column: "TargetCharIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Characters_TargetCharIdId",
                table: "Notifications",
                column: "TargetCharIdId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
