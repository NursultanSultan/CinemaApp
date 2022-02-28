using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.DataAcces.Migrations
{
    public partial class Iaddednewcolomnlanguageandformattable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LangIconUrl",
                table: "Languages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormatIconUrl",
                table: "Formats",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LangIconUrl",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "FormatIconUrl",
                table: "Formats");
        }
    }
}
