using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.DataAcces.Migrations
{
    public partial class Iaddednewcolomnnewstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NewsDate",
                table: "News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsDate",
                table: "News");
        }
    }
}
