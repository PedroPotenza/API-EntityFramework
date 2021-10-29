using Microsoft.EntityFrameworkCore.Migrations;

namespace API_EntityFramework.Migrations
{
    public partial class RefactoryOfClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "client");

            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "client",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateBirth",
                table: "client",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "client");

            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "client");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "client",
                newName: "Cidade");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
