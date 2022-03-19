using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifiedban.Next.Models.Migrations
{
    public partial class ubnextRenameTGConfigColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Configuration",
                schema: "telegram",
                table: "TGChat",
                newName: "ConfigurationJson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfigurationJson",
                schema: "telegram",
                table: "TGChat",
                newName: "Configuration");
        }
    }
}
