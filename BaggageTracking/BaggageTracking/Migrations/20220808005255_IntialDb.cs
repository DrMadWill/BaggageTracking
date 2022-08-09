using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaggageTracking.Migrations
{
    public partial class IntialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ClassName = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BaggageOutPoint = table.Column<string>(type: "TEXT", nullable: false),
                    AirportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platforms_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FromAirportId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToAirportId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlyDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FlyCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Airports_FromAirportId",
                        column: x => x.FromAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Airports_ToAirportId",
                        column: x => x.ToAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baggages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    LoadingId = table.Column<int>(type: "INTEGER", nullable: false),
                    LandedId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsOutId = table.Column<int>(type: "INTEGER", nullable: false),
                    OutPlatformId = table.Column<int>(type: "INTEGER", nullable: true),
                    Weight = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baggages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baggages_Platforms_OutPlatformId",
                        column: x => x.OutPlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baggages_Status_IsOutId",
                        column: x => x.IsOutId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baggages_Status_LandedId",
                        column: x => x.LandedId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baggages_Status_LoadingId",
                        column: x => x.LoadingId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baggages_Tickets_Id",
                        column: x => x.Id,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "HEYDAR ALIYEV INTERNATIONAL AIRPORT" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Ataturk Airport" });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Antalya Airport" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "ClassName", "Icon", "Name" },
                values: new object[] { 1, "btn-secondary", "fa-solid fa-hand", "Waiting" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "ClassName", "Icon", "Name" },
                values: new object[] { 2, "btn-warning", "fa-solid fa-spinner fa-spin", "Expected" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "ClassName", "Icon", "Name" },
                values: new object[] { 3, "btn-success", "fa-solid fa-circle-check", "Success" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 1, 1, "Comes to A1 platform", "A1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 2, 1, "Comes to B1 platform", "B1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 3, 1, "Comes to A2 platform", "A2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 4, 1, "Comes to B2 platform", "B2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 5, 1, "Comes to C1 platform", "C1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 6, 1, "Comes to C2 platform", "C2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 7, 2, "Comes to A1 platform", "A1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 8, 2, "Comes to B1 platform", "B1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 9, 2, "Comes to A2 platform", "A2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 10, 2, "Comes to B2 platform", "B2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 11, 2, "Comes to C1 platform", "C1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 12, 2, "Comes to C2 platform", "C2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 13, 3, "Comes to A1 platform", "A1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 14, 3, "Comes to B1 platform", "B1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 15, 3, "Comes to A2 platform", "A2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 16, 3, "Comes to B2 platform", "B2" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 17, 3, "Comes to C1 platform", "C1" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AirportId", "BaggageOutPoint", "Name" },
                values: new object[] { 18, 3, "Comes to C2 platform", "C2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 1, "ASCSDDF11223232", new DateTime(2022, 8, 9, 4, 52, 54, 936, DateTimeKind.Local).AddTicks(775), 1, "Orxan Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 2, "ASCSEEF11223232", new DateTime(2022, 8, 9, 4, 52, 54, 936, DateTimeKind.Local).AddTicks(783), 1, "Əli Ocaqverdiyev", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 3, "DDCSDDF11223232", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(785), 1, "Ehmed Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 4, "VVCSDDF11223232", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(787), 1, "Veli Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 5, "CCCSDDF11223232", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(788), 1, "Cavad Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 6, "MMCSDDF11223232", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(789), 1, "Mahmud Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 7, "MMCSFFDDF11223232", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(791), 1, "Mahmud Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 8, "MMCSDSSDF11223232", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(792), 1, "Mahmud Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 9, "MMCSDDFDD11223232", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(794), 1, "Vasif Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "FlyCode", "FlyDate", "FromAirportId", "Name", "ToAirportId" },
                values: new object[] { 10, "MMCSDDF11223232SS", new DateTime(2022, 8, 8, 4, 55, 54, 936, DateTimeKind.Local).AddTicks(795), 3, "Vidadi Salahov", 2 });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 3, 1, 1, 1, null, 26.56f });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 4, 1, 1, 1, null, 26.56f });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 5, 1, 1, 1, null, 26.56f });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 6, 1, 1, 2, null, 26.56f });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 7, 1, 2, 3, null, 26.56f });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 8, 1, 2, 3, null, 26.56f });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 9, 2, 3, 3, null, 26.56f });

            migrationBuilder.InsertData(
                table: "Baggages",
                columns: new[] { "Id", "IsOutId", "LandedId", "LoadingId", "OutPlatformId", "Weight" },
                values: new object[] { 10, 3, 3, 3, 7, 26.56f });

            migrationBuilder.CreateIndex(
                name: "IX_Baggages_IsOutId",
                table: "Baggages",
                column: "IsOutId");

            migrationBuilder.CreateIndex(
                name: "IX_Baggages_LandedId",
                table: "Baggages",
                column: "LandedId");

            migrationBuilder.CreateIndex(
                name: "IX_Baggages_LoadingId",
                table: "Baggages",
                column: "LoadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Baggages_OutPlatformId",
                table: "Baggages",
                column: "OutPlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_AirportId",
                table: "Platforms",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FromAirportId",
                table: "Tickets",
                column: "FromAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ToAirportId",
                table: "Tickets",
                column: "ToAirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baggages");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
