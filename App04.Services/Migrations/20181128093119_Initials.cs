using Microsoft.EntityFrameworkCore.Migrations;

namespace App04.Services.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultDriverName",
                table: "Trucks",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultDriverName",
                table: "Trucks");
        }
    }
}
