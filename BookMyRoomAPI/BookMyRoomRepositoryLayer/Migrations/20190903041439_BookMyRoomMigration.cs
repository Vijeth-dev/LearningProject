using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyRoomRepositoryLayer.Migrations
{
    public partial class BookMyRoomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelManager",
                columns: table => new
                {
                    HotelManager_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelManager_Name = table.Column<string>(nullable: false),
                    HotelManager_PhoneNumber = table.Column<string>(nullable: false),
                    _EmailID = table.Column<string>(nullable: false),
                    _Password = table.Column<string>(nullable: false),
                    _Designation = table.Column<string>(nullable: false),
                    _Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelManager", x => x.HotelManager_ID);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_FirstName = table.Column<string>(nullable: false),
                    User_Lastname = table.Column<string>(nullable: false),
                    User_PhoneNumber = table.Column<string>(nullable: false),
                    User_EmailID = table.Column<string>(nullable: false),
                    User_Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: false),
                    StateID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_State_StateID1",
                        column: x => x.StateID1,
                        principalTable: "State",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportName = table.Column<string>(nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportID);
                    table.ForeignKey(
                        name: "FK_Airports_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RailwayStation",
                columns: table => new
                {
                    RailwayStationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RailwayStationName = table.Column<string>(nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailwayStation", x => x.RailwayStationID);
                    table.ForeignKey(
                        name: "FK_RailwayStation_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hotel_Name = table.Column<string>(nullable: false),
                    Hotel_Address = table.Column<string>(nullable: false),
                    Hotel_PhoneNumber = table.Column<string>(nullable: false),
                    Hotel_EmailID = table.Column<string>(nullable: false),
                    Hotel_Status = table.Column<string>(nullable: false),
                    Hotel_Rating = table.Column<float>(nullable: false),
                    Wifi = table.Column<bool>(nullable: false),
                    City = table.Column<int>(nullable: false),
                    HotelManager = table.Column<int>(nullable: false),
                    Pool = table.Column<bool>(nullable: false),
                    Parking = table.Column<bool>(nullable: false),
                    Restaurant = table.Column<bool>(nullable: false),
                    Airports = table.Column<int>(nullable: true),
                    AirportDistance = table.Column<double>(nullable: false),
                    RailwayStation = table.Column<int>(nullable: true),
                    RailwayDistance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelID);
                    table.ForeignKey(
                        name: "FK_Hotels_Airports_Airports",
                        column: x => x.Airports,
                        principalTable: "Airports",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotels_City_City",
                        column: x => x.City,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_HotelManager_HotelManager",
                        column: x => x.HotelManager,
                        principalTable: "HotelManager",
                        principalColumn: "HotelManager_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_RailwayStation_RailwayStation",
                        column: x => x.RailwayStation,
                        principalTable: "RailwayStation",
                        principalColumn: "RailwayStationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Feedback = table.Column<string>(nullable: true),
                    Hotel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Hotels_Hotel",
                        column: x => x.Hotel,
                        principalTable: "Hotels",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PicturesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hotel = table.Column<int>(nullable: false),
                    HotelsHotelID = table.Column<int>(nullable: true),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PicturesID);
                    table.ForeignKey(
                        name: "FK_Pictures_Hotels_HotelsHotelID",
                        column: x => x.HotelsHotelID,
                        principalTable: "Hotels",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CityID",
                table: "Airports",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateID1",
                table: "City",
                column: "StateID1");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_Hotel",
                table: "Feedbacks",
                column: "Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Airports",
                table: "Hotels",
                column: "Airports");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_City",
                table: "Hotels",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelManager",
                table: "Hotels",
                column: "HotelManager");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_RailwayStation",
                table: "Hotels",
                column: "RailwayStation");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_HotelsHotelID",
                table: "Pictures",
                column: "HotelsHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_RailwayStation_CityID",
                table: "RailwayStation",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "HotelManager");

            migrationBuilder.DropTable(
                name: "RailwayStation");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
