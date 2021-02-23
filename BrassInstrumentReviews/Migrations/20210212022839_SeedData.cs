using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrassInstrumentReviews.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ReviewerName",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommenterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentReviewReviewID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_CommentReviewReviewID",
                        column: x => x.CommentReviewReviewID,
                        principalTable: "Reviews",
                        principalColumn: "ReviewID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentReviewReviewID",
                table: "Comments",
                column: "CommentReviewReviewID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "ReviewerName",
                table: "Reviews",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

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
    }
}
