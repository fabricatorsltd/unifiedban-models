using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifiedban.Next.Models.Migrations
{
    public partial class ubnextAddGenAndTGStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "log",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => new { x.Date, x.Category });
                });

            migrationBuilder.CreateTable(
                name: "TGStats",
                schema: "telegram",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGStats", x => new { x.ChatId, x.Date, x.Category });
                    table.ForeignKey(
                        name: "FK_TGStats_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stats",
                schema: "log");

            migrationBuilder.DropTable(
                name: "TGStats",
                schema: "telegram");
        }
    }
}
