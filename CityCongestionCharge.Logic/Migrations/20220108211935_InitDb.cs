using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityCongestionCharge.Logic.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetectionSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectionSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnerSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    IsElectricOrHybrid = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarSet_OwnerSet_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "OwnerSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDetection",
                columns: table => new
                {
                    DetectedCarsId = table.Column<int>(type: "int", nullable: false),
                    DetectionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetection", x => new { x.DetectedCarsId, x.DetectionsId });
                    table.ForeignKey(
                        name: "FK_CarDetection_CarSet_DetectedCarsId",
                        column: x => x.DetectedCarsId,
                        principalTable: "CarSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDetection_DetectionSet_DetectionsId",
                        column: x => x.DetectionsId,
                        principalTable: "DetectionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PaidForDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    PayingPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentSet_CarSet_CarId",
                        column: x => x.CarId,
                        principalTable: "CarSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDetection_DetectionsId",
                table: "CarDetection",
                column: "DetectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarSet_LicensePlate",
                table: "CarSet",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarSet_OwnerId",
                table: "CarSet",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSet_CarId",
                table: "PaymentSet",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDetection");

            migrationBuilder.DropTable(
                name: "PaymentSet");

            migrationBuilder.DropTable(
                name: "DetectionSet");

            migrationBuilder.DropTable(
                name: "CarSet");

            migrationBuilder.DropTable(
                name: "OwnerSet");
        }
    }
}
