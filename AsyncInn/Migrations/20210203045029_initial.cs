using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
  public partial class initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Hotel",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(nullable: false),
            StreetAddress = table.Column<string>(nullable: true),
            City = table.Column<string>(nullable: false),
            State = table.Column<string>(nullable: false),
            Country = table.Column<string>(nullable: true),
            Phone = table.Column<string>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Hotel", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Room",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(nullable: false),
            Layout = table.Column<int>(nullable: false),
            RoomID = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Room", x => x.ID);
            table.ForeignKey(
                      name: "FK_Room_Room_RoomID",
                      column: x => x.RoomID,
                      principalTable: "Room",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Amenities",
          columns: table => new
          {
            ID = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(nullable: false),
            RoomID = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Amenities", x => x.ID);
            table.ForeignKey(
                      name: "FK_Amenities_Room_RoomID",
                      column: x => x.RoomID,
                      principalTable: "Room",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "HotelRoom",
          columns: table => new
          {
            HotelID = table.Column<int>(nullable: false),
            RoomNumber = table.Column<int>(nullable: false),
            RoomID = table.Column<int>(nullable: false),
            Rate = table.Column<decimal>(nullable: false),
            PetFriendly = table.Column<bool>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_HotelRoom", x => new { x.RoomNumber, x.HotelID });
            table.ForeignKey(
                      name: "FK_HotelRoom_Hotel_HotelID",
                      column: x => x.HotelID,
                      principalTable: "Hotel",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_HotelRoom_Room_RoomID",
                      column: x => x.RoomID,
                      principalTable: "Room",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "RoomAmenities",
          columns: table => new
          {
            RoomId = table.Column<int>(nullable: false),
            AmenityId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RoomAmenities", x => new { x.AmenityId, x.RoomId });
            table.ForeignKey(
                      name: "FK_RoomAmenities_Amenities_AmenityId",
                      column: x => x.AmenityId,
                      principalTable: "Amenities",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_RoomAmenities_Room_RoomId",
                      column: x => x.RoomId,
                      principalTable: "Room",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.InsertData(
          table: "Amenities",
          columns: new[] { "ID", "Name", "RoomID" },
          values: new object[,]
          {
                    { 1, "Replicator", null },
                    { 2, "Mini-Bar", null },
                    { 3, "Coffee Pot", null }
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
          columns: new[] { "ID", "Layout", "Name", "RoomID" },
          values: new object[,]
          {
                    { 1, 0, "Ivo Shandor Suite", null },
                    { 2, 1, "Admiral Picard Ready Room", null },
                    { 3, 2, "Fox McCloud Suite", null }
          });

      migrationBuilder.InsertData(
          table: "HotelRoom",
          columns: new[] { "RoomNumber", "HotelID", "PetFriendly", "Rate", "RoomID" },
          values: new object[] { 1001, 1, true, 120.22m, 1 });

      migrationBuilder.CreateIndex(
          name: "IX_Amenities_RoomID",
          table: "Amenities",
          column: "RoomID");

      migrationBuilder.CreateIndex(
          name: "IX_HotelRoom_HotelID",
          table: "HotelRoom",
          column: "HotelID");

      migrationBuilder.CreateIndex(
          name: "IX_HotelRoom_RoomID",
          table: "HotelRoom",
          column: "RoomID");

      migrationBuilder.CreateIndex(
          name: "IX_Room_RoomID",
          table: "Room",
          column: "RoomID");

      migrationBuilder.CreateIndex(
          name: "IX_RoomAmenities_RoomId",
          table: "RoomAmenities",
          column: "RoomId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "HotelRoom");

      migrationBuilder.DropTable(
          name: "RoomAmenities");

      migrationBuilder.DropTable(
          name: "Hotel");

      migrationBuilder.DropTable(
          name: "Amenities");

      migrationBuilder.DropTable(
          name: "Room");
    }
  }
}
