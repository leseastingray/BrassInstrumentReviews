using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrassInstrumentReviews.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentID);
                });

            migrationBuilder.CreateTable(
                name: "Reviewers",
                columns: table => new
                {
                    ReviewerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PrimaryInstrument = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewers", x => x.ReviewerID);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InstrumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewerName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "InstrumentName", "InstrumentType", "Rating", "ReviewDate", "ReviewText", "ReviewerName" },
                values: new object[] { 1, "Reynolds Contempora bass trombone", "Trombone", 3, new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stingray" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "InstrumentName", "InstrumentType", "Rating", "ReviewDate", "ReviewText", "ReviewerName" },
                values: new object[] { 2, "Bach Stradivarius Bb trumpet", "Trumpet", 4, new DateTime(2020, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Spot" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "InstrumentName", "InstrumentType", "Rating", "ReviewDate", "ReviewText", "ReviewerName" },
                values: new object[] { 3, "Conn 8D horn", "French horn", 5, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Megan cat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Reviewers");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
