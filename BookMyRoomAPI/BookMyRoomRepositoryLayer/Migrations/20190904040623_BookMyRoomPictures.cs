using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class BookMyRoomPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Hotels_HotelsHotelID",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_HotelsHotelID",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "HotelsHotelID",
                table: "Pictures");

            migrationBuilder.RenameColumn(
                name: "Hotel",
                table: "Pictures",
                newName: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_HotelID",
                table: "Pictures",
                column: "HotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Hotels_HotelID",
                table: "Pictures",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Hotels_HotelID",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_HotelID",
                table: "Pictures");

            migrationBuilder.RenameColumn(
                name: "HotelID",
                table: "Pictures",
                newName: "Hotel");

            migrationBuilder.AddColumn<int>(
                name: "HotelsHotelID",
                table: "Pictures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_HotelsHotelID",
                table: "Pictures",
                column: "HotelsHotelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Hotels_HotelsHotelID",
                table: "Pictures",
                column: "HotelsHotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
