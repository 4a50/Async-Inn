using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
  public partial class addedRoomLayoutEnumAndSeedData : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "Amenities",
          columns: new[] { "ID", "Name" },
          values: new object[,]
          {
                    { 1, "Replicator" },
                    { 2, "Mini-Bar" },
                    { 3, "Coffee Pot" }
          });

      migrationBuilder.InsertData(
          table: "Hotel",
          columns: new[] { "Id", "City", "Country", "Name", "Phone", "State", "StreetAddress" },
          values: new object[,]
          {
                    { 1, "New York", "USA", "Spook Central", "(555) 123-4566", "New York", "1234 Gozer Blvd" },
                    { 2, "Orlando", "USA", "Tower Of Terror", "(224) 478-2231", "Florida", "1 Twilight Zone Dr." },
                    { 3, "San Francisco", "UFP", "Starfleet Officer Quarter", "(333) 333-3333", "California", "1 Cochran Way" }
          });

      migrationBuilder.InsertData(
          table: "Room",
          columns: new[] { "ID", "Layout", "Name" },
          values: new object[,]
          {
                    { 1, 0, "Ivo Shandor Suite" },
                    { 2, 1, "Admiral Picard Ready Room" },
                    { 3, 2, "Fox McCloud Suite" }
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "Amenities",
          keyColumn: "ID",
          keyValue: 1);

      migrationBuilder.DeleteData(
          table: "Amenities",
          keyColumn: "ID",
          keyValue: 2);

      migrationBuilder.DeleteData(
          table: "Amenities",
          keyColumn: "ID",
          keyValue: 3);

      migrationBuilder.DeleteData(
          table: "Hotel",
          keyColumn: "Id",
          keyValue: 1);

      migrationBuilder.DeleteData(
          table: "Hotel",
          keyColumn: "Id",
          keyValue: 2);

      migrationBuilder.DeleteData(
          table: "Hotel",
          keyColumn: "Id",
          keyValue: 3);

      migrationBuilder.DeleteData(
          table: "Room",
          keyColumn: "ID",
          keyValue: 1);

      migrationBuilder.DeleteData(
          table: "Room",
          keyColumn: "ID",
          keyValue: 2);

      migrationBuilder.DeleteData(
          table: "Room",
          keyColumn: "ID",
          keyValue: 3);
    }
  }
}
