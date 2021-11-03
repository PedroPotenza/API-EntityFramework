using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_EntityFramework.Migrations
{
    public partial class Create_Contract_History_Registers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_contract_plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "plan",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_history_contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historyRegister",
                columns: table => new
                {
                    HistoryRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryId = table.Column<int>(type: "int", nullable: true),
                    WatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StopTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historyRegister", x => x.HistoryRegisterId);
                    table.ForeignKey(
                        name: "FK_historyRegister_history_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "history",
                        principalColumn: "HistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_historyRegister_movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contract_PlanId",
                table: "contract",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_history_ContractId",
                table: "history",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_historyRegister_HistoryId",
                table: "historyRegister",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_historyRegister_MovieId",
                table: "historyRegister",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historyRegister");

            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "contract");
        }
    }
}
