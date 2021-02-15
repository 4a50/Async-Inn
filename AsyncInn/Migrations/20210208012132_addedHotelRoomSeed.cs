using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedHotelRoomSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "RoomNumber", "HotelID", "PetFriendly", "Rate", "RoomID" },
                values: new object[] { 667, 1, false, 222.22m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "RoomNumber", "HotelID" },
                keyValues: new object[] { 667, 1 });
        }
    }
}
