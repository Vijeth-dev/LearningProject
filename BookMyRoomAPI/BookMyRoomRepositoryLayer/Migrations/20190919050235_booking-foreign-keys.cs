using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class bookingforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Hotels_HotelID",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HotelID",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Hotels_HotelID",
                table: "Booking",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Hotels_HotelID",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Booking",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "HotelID",
                table: "Booking",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Hotels_HotelID",
                table: "Booking",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "HotelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
