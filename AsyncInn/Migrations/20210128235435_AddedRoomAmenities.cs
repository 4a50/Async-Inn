using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
  public partial class AddedRoomAmenities : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<int>(
          name: "AmenityID",
          table: "Amenities",
          nullable: true);

      migrationBuilder.AddColumn<int>(
          name: "RoomID",
          table: "Amenities",
          nullable: true);

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

      migrationBuilder.CreateIndex(
          name: "IX_Amenities_AmenityID",
          table: "Amenities",
          column: "AmenityID");

      migrationBuilder.CreateIndex(
          name: "IX_Amenities_RoomID",
          table: "Amenities",
          column: "RoomID");

      migrationBuilder.CreateIndex(
          name: "IX_RoomAmenities_RoomId",
          table: "RoomAmenities",
          column: "RoomId");

      migrationBuilder.AddForeignKey(
          name: "FK_Amenities_Amenities_AmenityID",
          table: "Amenities",
          column: "AmenityID",
          principalTable: "Amenities",
          principalColumn: "ID",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_Amenities_Room_RoomID",
          table: "Amenities",
          column: "RoomID",
          principalTable: "Room",
          principalColumn: "ID",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Amenities_Amenities_AmenityID",
          table: "Amenities");

      migrationBuilder.DropForeignKey(
          name: "FK_Amenities_Room_RoomID",
          table: "Amenities");

      migrationBuilder.DropTable(
          name: "RoomAmenities");

      migrationBuilder.DropIndex(
          name: "IX_Amenities_AmenityID",
          table: "Amenities");

      migrationBuilder.DropIndex(
          name: "IX_Amenities_RoomID",
          table: "Amenities");

      migrationBuilder.DropColumn(
          name: "AmenityID",
          table: "Amenities");

      migrationBuilder.DropColumn(
          name: "RoomID",
          table: "Amenities");
    }
  }
}
