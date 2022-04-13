using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifiedban.Next.Models.Migrations
{
    public partial class ubnextFixChatOwnerFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DGuild_UBUser_UBUserId",
                schema: "discord",
                table: "DGuild");

            migrationBuilder.DropForeignKey(
                name: "FK_TBroadcaster_UBUser_UBUserId",
                schema: "twitch",
                table: "TBroadcaster");

            migrationBuilder.DropForeignKey(
                name: "FK_TGChat_UBUser_UBUserId",
                schema: "telegram",
                table: "TGChat");

            migrationBuilder.DropIndex(
                name: "IX_TGChat_UBUserId",
                schema: "telegram",
                table: "TGChat");

            migrationBuilder.DropIndex(
                name: "IX_TBroadcaster_UBUserId",
                schema: "twitch",
                table: "TBroadcaster");

            migrationBuilder.DropIndex(
                name: "IX_DGuild_UBUserId",
                schema: "discord",
                table: "DGuild");

            migrationBuilder.DropColumn(
                name: "UBUserId",
                schema: "telegram",
                table: "TGChat");

            migrationBuilder.DropColumn(
                name: "UBUserId",
                schema: "twitch",
                table: "TBroadcaster");

            migrationBuilder.DropColumn(
                name: "UBUserId",
                schema: "discord",
                table: "DGuild");

            migrationBuilder.AlterColumn<string>(
                name: "AcceptedValues",
                schema: "dbo",
                table: "UBChatConfiguration",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.CreateIndex(
                name: "IX_TGChat_OwnerId",
                schema: "telegram",
                table: "TGChat",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TBroadcaster_OwnerId",
                schema: "twitch",
                table: "TBroadcaster",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DGuild_OwnerId",
                schema: "discord",
                table: "DGuild",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DGuild_UBUser_OwnerId",
                schema: "discord",
                table: "DGuild",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "UBUser",
                principalColumn: "UBUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBroadcaster_UBUser_OwnerId",
                schema: "twitch",
                table: "TBroadcaster",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "UBUser",
                principalColumn: "UBUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TGChat_UBUser_OwnerId",
                schema: "telegram",
                table: "TGChat",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "UBUser",
                principalColumn: "UBUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DGuild_UBUser_OwnerId",
                schema: "discord",
                table: "DGuild");

            migrationBuilder.DropForeignKey(
                name: "FK_TBroadcaster_UBUser_OwnerId",
                schema: "twitch",
                table: "TBroadcaster");

            migrationBuilder.DropForeignKey(
                name: "FK_TGChat_UBUser_OwnerId",
                schema: "telegram",
                table: "TGChat");

            migrationBuilder.DropIndex(
                name: "IX_TGChat_OwnerId",
                schema: "telegram",
                table: "TGChat");

            migrationBuilder.DropIndex(
                name: "IX_TBroadcaster_OwnerId",
                schema: "twitch",
                table: "TBroadcaster");

            migrationBuilder.DropIndex(
                name: "IX_DGuild_OwnerId",
                schema: "discord",
                table: "DGuild");

            migrationBuilder.AlterColumn<string>(
                name: "AcceptedValues",
                schema: "dbo",
                table: "UBChatConfiguration",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "UBUserId",
                schema: "telegram",
                table: "TGChat",
                type: "nvarchar(40)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UBUserId",
                schema: "twitch",
                table: "TBroadcaster",
                type: "nvarchar(40)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UBUserId",
                schema: "discord",
                table: "DGuild",
                type: "nvarchar(40)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TGChat_UBUserId",
                schema: "telegram",
                table: "TGChat",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBroadcaster_UBUserId",
                schema: "twitch",
                table: "TBroadcaster",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DGuild_UBUserId",
                schema: "discord",
                table: "DGuild",
                column: "UBUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DGuild_UBUser_UBUserId",
                schema: "discord",
                table: "DGuild",
                column: "UBUserId",
                principalSchema: "dbo",
                principalTable: "UBUser",
                principalColumn: "UBUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBroadcaster_UBUser_UBUserId",
                schema: "twitch",
                table: "TBroadcaster",
                column: "UBUserId",
                principalSchema: "dbo",
                principalTable: "UBUser",
                principalColumn: "UBUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TGChat_UBUser_UBUserId",
                schema: "telegram",
                table: "TGChat",
                column: "UBUserId",
                principalSchema: "dbo",
                principalTable: "UBUser",
                principalColumn: "UBUserId");
        }
    }
}
