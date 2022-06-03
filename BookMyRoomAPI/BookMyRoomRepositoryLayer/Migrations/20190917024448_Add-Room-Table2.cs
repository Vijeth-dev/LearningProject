using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class AddRoomTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTable",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomTypeId = table.Column<int>(nullable: false),
                    AC = table.Column<bool>(nullable: false),
                    RoomService = table.Column<bool>(nullable: false),
                    WIFI = table.Column<bool>(nullable: false),
                    TV = table.Column<bool>(nullable: false),
                    Geyser = table.Column<bool>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    HotelID = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTable");
        }
    }
}
