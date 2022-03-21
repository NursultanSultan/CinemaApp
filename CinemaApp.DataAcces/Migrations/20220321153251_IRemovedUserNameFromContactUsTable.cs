using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.DataAcces.Migrations
{
    public partial class IRemovedUserNameFromContactUsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ContactUs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
