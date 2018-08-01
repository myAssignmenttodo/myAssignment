using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myAppService.API.Migrations
{
    public partial class initilaCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FromLocation = table.Column<string>(nullable: true),
                    ToLocation = table.Column<string>(nullable: true),
                    ScheduledDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedulers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArrivalTime = table.Column<string>(nullable: true),
                    DepartureTime = table.Column<string>(nullable: true),
                    TrainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedulers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedulers_Train_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Train",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedulers_TrainId",
                table: "Schedulers",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedulers");

            migrationBuilder.DropTable(
                name: "Train");
        }
    }
}
