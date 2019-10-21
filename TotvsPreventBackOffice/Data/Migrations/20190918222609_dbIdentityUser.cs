using Microsoft.EntityFrameworkCore.Migrations;

namespace TotvsPreventBackOffice.Data.Migrations
{
    public partial class dbIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "UserApi");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserApi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserApi_UserId",
                table: "UserApi",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApi_AspNetUsers_UserId",
                table: "UserApi",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApi_AspNetUsers_UserId",
                table: "UserApi");

            migrationBuilder.DropIndex(
                name: "IX_UserApi_UserId",
                table: "UserApi");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserApi");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "UserApi",
                nullable: false,
                defaultValue: 0);
        }
    }
}
