using Microsoft.EntityFrameworkCore.Migrations;

namespace API_EntityFramework.Migrations
{
    public partial class PrimaryKeyCorrectName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "plan",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "client",
                newName: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "plan",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "client",
                newName: "Id");
        }
    }
}
