using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class UpdatetableBookingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_UserProfiles_UserIdUser_ID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserIdUser_ID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserIdUser_ID",
                table: "Booking");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBilling",
                table: "Booking",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Deluxe",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Premium",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Booking",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBilling",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Deluxe",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "UserIdUser_ID",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserIdUser_ID",
                table: "Booking",
                column: "UserIdUser_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_UserProfiles_UserIdUser_ID",
                table: "Booking",
                column: "UserIdUser_ID",
                principalTable: "UserProfiles",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
