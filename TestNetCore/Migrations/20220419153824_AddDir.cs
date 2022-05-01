using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestNetCore.Migrations
{
    public partial class AddDir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "tUser",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "tUser");
        }
    }
}
