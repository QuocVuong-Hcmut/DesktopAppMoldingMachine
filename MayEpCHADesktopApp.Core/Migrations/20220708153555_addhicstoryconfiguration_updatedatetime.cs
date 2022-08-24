using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MayEpCHADesktopApp.Core.Migrations
{
    public partial class addhicstoryconfiguration_updatedatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "HistoryCofigurations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "HistoryCofigurations");
        }
    }
}
