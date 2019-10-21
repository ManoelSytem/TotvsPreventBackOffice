using Microsoft.EntityFrameworkCore.Migrations;

namespace TotvsPreventBackOffice.Data.Migrations
{
    public partial class dbUpdateFilialColigada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "FilialColigada",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "FilialColigada",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
