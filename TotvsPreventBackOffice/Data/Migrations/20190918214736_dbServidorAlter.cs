using Microsoft.EntityFrameworkCore.Migrations;

namespace TotvsPreventBackOffice.Data.Migrations
{
    public partial class dbServidorAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servidor_MetodoApi_MetodoApiID",
                table: "Servidor");

            migrationBuilder.DropIndex(
                name: "IX_Servidor_MetodoApiID",
                table: "Servidor");

            migrationBuilder.DropColumn(
                name: "MetodoApiID",
                table: "Servidor");

            migrationBuilder.AddColumn<int>(
                name: "ServidorId",
                table: "MetodoApi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetodoApi_ServidorId",
                table: "MetodoApi",
                column: "ServidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetodoApi_Servidor_ServidorId",
                table: "MetodoApi",
                column: "ServidorId",
                principalTable: "Servidor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetodoApi_Servidor_ServidorId",
                table: "MetodoApi");

            migrationBuilder.DropIndex(
                name: "IX_MetodoApi_ServidorId",
                table: "MetodoApi");

            migrationBuilder.DropColumn(
                name: "ServidorId",
                table: "MetodoApi");

            migrationBuilder.AddColumn<int>(
                name: "MetodoApiID",
                table: "Servidor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servidor_MetodoApiID",
                table: "Servidor",
                column: "MetodoApiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Servidor_MetodoApi_MetodoApiID",
                table: "Servidor",
                column: "MetodoApiID",
                principalTable: "MetodoApi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
