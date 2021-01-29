using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
  public partial class initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Hotels",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Hotels", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Hotels");
    }
  }
}
