using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class BookMyRoom_UserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Type",
                table: "UserProfiles",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Type",
                table: "UserProfiles");
        }
    }
}
