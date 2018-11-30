using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App04.Services.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    PlateNo = table.Column<string>(maxLength: 30, nullable: false),
                    Make = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.PlateNo);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DriverName = table.Column<string>(nullable: true),
                    FromLocation = table.Column<string>(maxLength: 250, nullable: true),
                    ToLocation = table.Column<string>(maxLength: 250, nullable: true),
                    TruckPlateNo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Trucks_TruckPlateNo",
                        column: x => x.TruckPlateNo,
                        principalTable: "Trucks",
                        principalColumn: "PlateNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Odometer = table.Column<int>(nullable: false),
                    Liters = table.Column<double>(nullable: false),
                    NextId = table.Column<int>(nullable: true),
                    JobId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillUp_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FillUp_FillUp_NextId",
                        column: x => x.NextId,
                        principalTable: "FillUp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FillUp_JobId",
                table: "FillUp",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_FillUp_NextId",
                table: "FillUp",
                column: "NextId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TruckPlateNo",
                table: "Jobs",
                column: "TruckPlateNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FillUp");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
