using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class RoomHotelsReady : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Amenities_AmenityID",
                table: "Amenities");

            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Room_RoomID",
                table: "Amenities");

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

            migrationBuilder.CreateTable(
                name: "HotelRoom",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => new { x.HotelID, x.RoomID });
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

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoom");

            migrationBuilder.AddColumn<int>(
                name: "AmenityID",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_AmenityID",
                table: "Amenities",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomID",
                table: "Amenities",
                column: "RoomID");

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
    }
}
