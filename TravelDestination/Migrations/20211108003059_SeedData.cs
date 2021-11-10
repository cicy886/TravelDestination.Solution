using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelDestination.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "City", "Country", "Destination", "Rating" },
                values: new object[,]
                {
                    { 1, "Ocean", "Atlantic", "Bermuda Triangle", 10 },
                    { 2, "Giza", "Egypt", "Great Pyramids", 9 },
                    { 3, "Beijing", "China", "Great Wall", 10 },
                    { 4, "Yellowstone", "USA", "Old Faithful", 9 },
                    { 5, "Portland", "USA", "Rocky Butte", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 5);
        }
    }
}
