using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifiedban.Next.Models.Migrations
{
    public partial class ubnextTrackLastVersionUsedByTGChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastVersion",
                schema: "telegram",
                table: "TGChat",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastVersion",
                schema: "telegram",
                table: "TGChat");
        }
    }
}
