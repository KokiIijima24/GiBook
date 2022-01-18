using Microsoft.EntityFrameworkCore.Migrations;

namespace Gibook.API.Migrations
{
    public partial class AddGiBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BiBookId",
                table: "GiBiooks",
                newName: "GiBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiBookId",
                table: "GiBiooks",
                newName: "BiBookId");
        }
    }
}
