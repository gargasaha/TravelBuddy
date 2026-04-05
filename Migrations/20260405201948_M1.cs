using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBuddy.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatFile",
                columns: table => new
                {
                    chatid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatFile", x => x.chatid);
                });

            migrationBuilder.CreateTable(
                name: "Usr",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    uimage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usr", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cpassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cimage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    cemail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.cid);
                    table.ForeignKey(
                        name: "FK_Community_Usr_cemail",
                        column: x => x.cemail,
                        principalTable: "Usr",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunityChat",
                columns: table => new
                {
                    communityChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    communityId = table.Column<int>(type: "int", nullable: false),
                    usrEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityChat", x => x.communityChatId);
                    table.ForeignKey(
                        name: "FK_CommunityChat_Community_communityId",
                        column: x => x.communityId,
                        principalTable: "Community",
                        principalColumn: "cid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityChat_Usr_usrEmail",
                        column: x => x.usrEmail,
                        principalTable: "Usr",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    rideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rideStartLatitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rideStartLongitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rideEndLatitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rideEndLongitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rideStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rideEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rideGroupLeaderEmail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    communityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.rideId);
                    table.ForeignKey(
                        name: "FK_Ride_Community_communityId",
                        column: x => x.communityId,
                        principalTable: "Community",
                        principalColumn: "cid");
                    table.ForeignKey(
                        name: "FK_Ride_Usr_rideGroupLeaderEmail",
                        column: x => x.rideGroupLeaderEmail,
                        principalTable: "Usr",
                        principalColumn: "email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Community_cemail",
                table: "Community",
                column: "cemail");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityChat_communityId",
                table: "CommunityChat",
                column: "communityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityChat_usrEmail",
                table: "CommunityChat",
                column: "usrEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_communityId",
                table: "Ride",
                column: "communityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_rideGroupLeaderEmail",
                table: "Ride",
                column: "rideGroupLeaderEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatFile");

            migrationBuilder.DropTable(
                name: "CommunityChat");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropTable(
                name: "Usr");
        }
    }
}
