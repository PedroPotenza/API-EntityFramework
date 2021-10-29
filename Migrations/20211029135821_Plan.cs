using Microsoft.EntityFrameworkCore.Migrations;

namespace API_EntityFramework.Migrations
{
    public partial class Plan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    MaxQuality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxSimultaneousDevices = table.Column<int>(type: "int", nullable: false),
                    LoyaltyFine = table.Column<double>(type: "float", nullable: false),
                    LoyaltyFineTime = table.Column<int>(type: "int", nullable: false),
                    MaxMovies = table.Column<int>(type: "int", nullable: false),
                    Download = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plan");
        }
    }
}
