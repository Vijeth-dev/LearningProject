using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class AddRoomTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTable",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AC = table.Column<bool>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Geyser = table.Column<bool>(nullable: false),
                    HotelID = table.Column<int>(nullable: true),
                    RoomService = table.Column<bool>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false),
                    TV = table.Column<bool>(nullable: false),
                    WIFI = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTable", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_RoomTable_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTable_HotelID",
                table: "RoomTable",
                column: "HotelID");
        }
    }
}
