using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIHouses.Data.Migrations
{
    public partial class adduserstoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Landlords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Agreements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agreements");
        }
    }
}
