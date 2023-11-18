using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fleet_management.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FleetAndVehicles",
                columns: table => new
                {
                    Fleet = table.Column<string>(type: "text", nullable: true),
                    VehicleName = table.Column<List<string>>(type: "text[]", nullable: true),
                    VehicleCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Seats = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    KmDriven = table.Column<long>(type: "bigint", nullable: false),
                    RunningDoors = table.Column<byte>(type: "smallint", nullable: false),
                    NormalDoors = table.Column<byte>(type: "smallint", nullable: false),
                    FleetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fleet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VehicleModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fleet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fleet_Vehicle_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fleet_VehicleModelId",
                table: "Fleet",
                column: "VehicleModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fleet");

            migrationBuilder.DropTable(
                name: "FleetAndVehicles");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
