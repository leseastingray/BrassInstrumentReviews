using Microsoft.EntityFrameworkCore.Migrations;

namespace BrassInstrumentReviews.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_CommentReviewReviewID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommenterName",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CommentReviewReviewID",
                table: "Comments",
                newName: "ReviewID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentReviewReviewID",
                table: "Comments",
                newName: "IX_Comments_ReviewID");

            migrationBuilder.AddColumn<string>(
                name: "CommenterId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommenterId",
                table: "Comments",
                column: "CommenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterId",
                table: "Comments",
                column: "CommenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_ReviewID",
                table: "Comments",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "ReviewID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommenterId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reviews_ReviewID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommenterId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommenterId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ReviewID",
                table: "Comments",
                newName: "CommentReviewReviewID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ReviewID",
                table: "Comments",
                newName: "IX_Comments_CommentReviewReviewID");

            migrationBuilder.AddColumn<string>(
                name: "CommenterName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reviews_CommentReviewReviewID",
                table: "Comments",
                column: "CommentReviewReviewID",
                principalTable: "Reviews",
                principalColumn: "ReviewID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
