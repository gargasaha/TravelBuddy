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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityChat",
                columns: table => new
                {
                    communityChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cid = table.Column<int>(type: "int", nullable: false),
                    communitycid = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usremail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityChat", x => x.communityChatId);
                    table.ForeignKey(
                        name: "FK_CommunityChat_Community_communitycid",
                        column: x => x.communitycid,
                        principalTable: "Community",
                        principalColumn: "cid");
                    table.ForeignKey(
                        name: "FK_CommunityChat_Usr_usremail",
                        column: x => x.usremail,
                        principalTable: "Usr",
                        principalColumn: "email");
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
                    rideGroupLeaderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    communityId = table.Column<int>(type: "int", nullable: true),
                    usremail = table.Column<string>(type: "nvarchar(100)", nullable: true)
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
                        name: "FK_Ride_Usr_usremail",
                        column: x => x.usremail,
                        principalTable: "Usr",
                        principalColumn: "email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Community_cemail",
                table: "Community",
                column: "cemail");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityChat_communitycid",
                table: "CommunityChat",
                column: "communitycid");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityChat_usremail",
                table: "CommunityChat",
                column: "usremail");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_communityId",
                table: "Ride",
                column: "communityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_usremail",
                table: "Ride",
                column: "usremail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
