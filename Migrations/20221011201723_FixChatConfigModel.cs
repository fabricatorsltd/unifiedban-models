using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifiedban.Next.Models.Migrations
{
    public partial class FixChatConfigModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                schema: "dbo",
                table: "ConfigurationParameter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                schema: "dbo",
                table: "ConfigurationParameter");
        }
    }
}
