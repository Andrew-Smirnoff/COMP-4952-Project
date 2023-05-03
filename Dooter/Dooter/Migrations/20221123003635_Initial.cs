using Microsoft.EntityFrameworkCore.Migrations;

namespace Dooter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationID", "Name", "Rating", "latitude", "longitude" },
                values: new object[] { 3, "Gothic tree 3 how many gothic trees are there?", 3.5, 1.0, 1.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationID",
                keyValue: 3);
        }
    }
}
