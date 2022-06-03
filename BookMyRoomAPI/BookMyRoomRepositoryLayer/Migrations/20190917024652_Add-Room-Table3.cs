using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class AddRoomTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTable_Hotels_HotelID",
                table: "RoomTable");

            migrationBuilder.RenameColumn(
                name: "HotelID",
                table: "RoomTable",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomTable_HotelID",
                table: "RoomTable",
                newName: "IX_RoomTable_HotelId");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "RoomTable",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTable_Hotels_HotelId",
                table: "RoomTable",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTable_Hotels_HotelId",
                table: "RoomTable");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "RoomTable",
                newName: "HotelID");

            migrationBuilder.RenameIndex(
                name: "IX_RoomTable_HotelId",
                table: "RoomTable",
                newName: "IX_RoomTable_HotelID");

            migrationBuilder.AlterColumn<int>(
                name: "HotelID",
                table: "RoomTable",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTable_Hotels_HotelID",
                table: "RoomTable",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
