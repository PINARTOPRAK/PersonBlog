using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogModelReview",
                columns: table => new
                {
                    BlogModelsId = table.Column<int>(type: "int", nullable: false),
                    ReviewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogModelReview", x => new { x.BlogModelsId, x.ReviewsId });
                    table.ForeignKey(
                        name: "FK_BlogModelReview_Blogs_BlogModelsId",
                        column: x => x.BlogModelsId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogModelReview_Reviews_ReviewsId",
                        column: x => x.ReviewsId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogModelReview_ReviewsId",
                table: "BlogModelReview",
                column: "ReviewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogModelReview");
        }
    }
}
