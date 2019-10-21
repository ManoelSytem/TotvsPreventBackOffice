using Microsoft.EntityFrameworkCore.Migrations;

namespace TotvsPreventBackOffice.Data.Migrations
{
    public partial class newModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModuloId",
                table: "MetodoApi",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuloId",
                table: "MetodoApi");
        }
    }
}
