using Microsoft.EntityFrameworkCore.Migrations;

namespace TotvsPreventBackOffice.Data.Migrations
{
    public partial class newModelsReferennceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModuloPerfil",
                table: "UserModuloPerfil");

            migrationBuilder.RenameTable(
                name: "UserModuloPerfil",
                newName: "UserModuloPerfil");

            migrationBuilder.AlterColumn<int>(
                name: "CodModulo",
                table: "UserModuloPerfil",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModuloPerfil",
                table: "UserModuloPerfil",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModuloPerfil",
                table: "UserModuloPerfil");

            migrationBuilder.RenameTable(
                name: "UserModuloPerfil",
                newName: "UserModuloPerfil");

            migrationBuilder.AlterColumn<string>(
                name: "CodModulo",
                table: "UserServicePerfil",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModuloPerfil",
                table: "UserModuloPerfil",
                column: "Id");
        }
    }
}
