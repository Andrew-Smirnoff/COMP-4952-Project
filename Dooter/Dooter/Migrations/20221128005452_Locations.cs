using Microsoft.EntityFrameworkCore.Migrations;

namespace Dooter.Migrations
{
    public partial class Locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "Name", "Rating", "latitude", "longitude" },
                values: new object[] { 1, "Gothic tree", 3.5, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "Name", "Rating", "latitude", "longitude" },
                values: new object[] { 2, "Gothic tree 2 electric boogaloo", 3.5, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "Name", "Rating", "latitude", "longitude" },
                values: new object[] { 3, "Gothic tree 3 how many gothic trees are there?", 3.5, 1.0, 1.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
