using Microsoft.EntityFrameworkCore.Migrations;

namespace Dooter.Migrations.BookmarkDB
{
    public partial class Bookmarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    BookmarkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.BookmarkID);
                });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "BookmarkID", "Name", "Rating", "latitude", "longitude" },
                values: new object[] { 1, "Bookmark 1", 3.5, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "BookmarkID", "Name", "Rating", "latitude", "longitude" },
                values: new object[] { 2, "Bookmark 2", 3.5, 1.0, 1.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmarks");
        }
    }
}
