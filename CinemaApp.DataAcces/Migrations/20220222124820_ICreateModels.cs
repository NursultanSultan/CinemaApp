using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApp.DataAcces.Migrations
{
    public partial class ICreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: false),
                    CategoryImageURL = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false ,defaultValue:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(nullable: false),
                    ShortContent = table.Column<string>(maxLength: 255, nullable: false),
                    OurAdress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EMail = table.Column<string>(nullable: false),
                    WorkingHour = table.Column<string>(nullable: true),
                    MapLocation = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false , defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatType = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false , defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false , defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(maxLength: 255, nullable: false),
                    PosterUrl = table.Column<string>(nullable: false),
                    TrailerUrl = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    InCinemasFrom = table.Column<DateTime>(nullable: false),
                    InCinemasTo = table.Column<DateTime>(nullable: false),
                    AboutContent = table.Column<string>(maxLength: 255, nullable: false),
                    ImdbPoint = table.Column<double>(nullable: false),
                    AgeLimit = table.Column<int>(nullable: false),
                    Country = table.Column<string>(maxLength: 255, nullable: false),
                    Director = table.Column<string>(maxLength: 255, nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false , defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallName = table.Column<string>(maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    CinemaId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false , defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Halls_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCinemas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    CinemaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCinemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCinemas_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCinemas_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieFormats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    FormatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieFormats_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieFormats_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguages_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieSessions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CinemaId",
                table: "Halls",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_CategoryId",
                table: "MovieCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_MovieId",
                table: "MovieCategories",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCinemas_CinemaId",
                table: "MovieCinemas",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCinemas_MovieId",
                table: "MovieCinemas",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFormats_FormatId",
                table: "MovieFormats",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieFormats_MovieId",
                table: "MovieFormats",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguages_LanguageId",
                table: "MovieLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguages_MovieId",
                table: "MovieLanguages",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSessions_MovieId",
                table: "MovieSessions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSessions_SessionId",
                table: "MovieSessions",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.DropTable(
                name: "MovieCinemas");

            migrationBuilder.DropTable(
                name: "MovieFormats");

            migrationBuilder.DropTable(
                name: "MovieLanguages");

            migrationBuilder.DropTable(
                name: "MovieSessions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
