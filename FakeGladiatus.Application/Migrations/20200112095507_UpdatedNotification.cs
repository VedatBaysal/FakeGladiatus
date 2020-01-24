using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeGladiatus.Application.Migrations
{
    public partial class UpdatedNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetCharId",
                table: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "TargetUserId",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttackerUserId",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttackerCharId",
                table: "Notifications",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TargetCharIdId",
                table: "Notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AttackerCharId",
                table: "Notifications",
                column: "AttackerCharId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AttackerUserId",
                table: "Notifications",
                column: "AttackerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetCharIdId",
                table: "Notifications",
                column: "TargetCharIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetUserId",
                table: "Notifications",
                column: "TargetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Characters_AttackerCharId",
                table: "Notifications",
                column: "AttackerCharId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_AttackerUserId",
                table: "Notifications",
                column: "AttackerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Characters_TargetCharIdId",
                table: "Notifications",
                column: "TargetCharIdId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_TargetUserId",
                table: "Notifications",
                column: "TargetUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Characters_AttackerCharId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_AttackerUserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Characters_TargetCharIdId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_TargetUserId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AttackerCharId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AttackerUserId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TargetCharIdId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TargetUserId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TargetCharIdId",
                table: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "TargetUserId",
                table: "Notifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttackerUserId",
                table: "Notifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttackerCharId",
                table: "Notifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TargetCharId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
