using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayEpCHADesktopApp.Core.Migrations
{
    public partial class Update_ConfigurationInShift_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfigurationInShift",
                table: "Configurations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfigurationInShift",
                table: "Configurations");
        }
    }
}
