using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unifiedban.Next.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.EnsureSchema(
                name: "filter");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "discord");

            migrationBuilder.EnsureSchema(
                name: "lang");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.EnsureSchema(
                name: "twitch");

            migrationBuilder.EnsureSchema(
                name: "telegram");

            migrationBuilder.CreateTable(
                name: "ActionType",
                schema: "log",
                columns: table => new
                {
                    ActionTypeId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationParameter",
                schema: "dbo",
                columns: table => new
                {
                    ConfigurationParameterId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Override = table.Column<byte>(type: "tinyint", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcceptedValues = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Platforms = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationParameter", x => x.ConfigurationParameterId);
                });

            migrationBuilder.CreateTable(
                name: "Instance",
                schema: "log",
                columns: table => new
                {
                    InstanceId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stop = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instance", x => x.InstanceId);
                });

            migrationBuilder.CreateTable(
                name: "Key",
                schema: "lang",
                columns: table => new
                {
                    KeyId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.KeyId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "lang",
                columns: table => new
                {
                    LanguageId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UniversalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "dbo",
                columns: table => new
                {
                    ModuleId = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    MessageCategory = table.Column<byte>(type: "tinyint", nullable: false),
                    Exchange = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoutingKey = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    QueueName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ChainPriority = table.Column<int>(type: "int", nullable: false),
                    Platforms = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "SafeTName",
                schema: "filter",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TelegramChatId = table.Column<long>(type: "bigint", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeTName", x => new { x.Username, x.TelegramChatId });
                });

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
                name: "UBChat",
                schema: "dbo",
                columns: table => new
                {
                    UBChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ConfigurationJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UBChat", x => x.UBChatId);
                });

            migrationBuilder.CreateTable(
                name: "UBCommand",
                schema: "dbo",
                columns: table => new
                {
                    Command = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AnswerType = table.Column<byte>(type: "tinyint", nullable: false),
                    TgUserLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscordUserLevel = table.Column<int>(type: "int", nullable: false),
                    TwitchUserLevel = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UBCommand", x => new { x.Command, x.Platform });
                });

            migrationBuilder.CreateTable(
                name: "UBUser",
                schema: "dbo",
                columns: table => new
                {
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FabUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    TrustFactor = table.Column<byte>(type: "tinyint", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: true),
                    DiscordId = table.Column<long>(type: "bigint", nullable: true),
                    TwitchId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UBUser", x => x.UBUserId);
                });

            migrationBuilder.CreateTable(
                name: "System",
                schema: "log",
                columns: table => new
                {
                    SystemLogId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LoggerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Function = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstanceId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System", x => x.SystemLogId);
                    table.ForeignKey(
                        name: "FK_System_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "log",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Privilege",
                schema: "security",
                columns: table => new
                {
                    PrivilegeId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TranslationKeyId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.PrivilegeId);
                    table.ForeignKey(
                        name: "FK_Privilege_Key_TranslationKeyId",
                        column: x => x.TranslationKeyId,
                        principalSchema: "lang",
                        principalTable: "Key",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                schema: "lang",
                columns: table => new
                {
                    LanguageId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => new { x.LanguageId, x.KeyId });
                    table.ForeignKey(
                        name: "FK_Entry_Key_KeyId",
                        column: x => x.KeyId,
                        principalSchema: "lang",
                        principalTable: "Key",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entry_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "lang",
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BadWord",
                schema: "filter",
                columns: table => new
                {
                    BadWordId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Regex = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Match = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadWord", x => x.BadWordId);
                    table.ForeignKey(
                        name: "FK_BadWord_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId");
                });

            migrationBuilder.CreateTable(
                name: "EntryCustom",
                schema: "lang",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryCustom", x => new { x.LanguageId, x.KeyId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_EntryCustom_Key_KeyId",
                        column: x => x.KeyId,
                        principalSchema: "lang",
                        principalTable: "Key",
                        principalColumn: "KeyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryCustom_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "lang",
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryCustom_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportSession",
                schema: "log",
                columns: table => new
                {
                    SupportSessionId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    InstanceId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportSession", x => x.SupportSessionId);
                    table.ForeignKey(
                        name: "FK_SupportSession_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "log",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupportSession_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "UBCustomCommand",
                schema: "dbo",
                columns: table => new
                {
                    UBCustomCommandId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Platforms = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    AnswerType = table.Column<byte>(type: "tinyint", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    TgUserLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscordRoles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitchUserLevel = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Command = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MediaUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TelegramMediaId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UBCustomCommand", x => x.UBCustomCommandId);
                    table.ForeignKey(
                        name: "FK_UBCustomCommand_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "log",
                columns: table => new
                {
                    ActionId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ActionTypeId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TakenByUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TakenByUBUserId = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    UtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstanceId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_Action_ActionType_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalSchema: "log",
                        principalTable: "ActionType",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Action_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "log",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Action_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Action_UBUser_TakenByUBUserId",
                        column: x => x.TakenByUBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId");
                });

            migrationBuilder.CreateTable(
                name: "DGuild",
                schema: "discord",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    GuildId = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WelcomeText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    RulesText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SettingsLanguage = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ReportChanneltId = table.Column<long>(type: "bigint", nullable: false),
                    EnabledCommandsType = table.Column<byte>(type: "tinyint", nullable: false),
                    DisabledCommands = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DGuild", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_DGuild_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DGuild_UBUser_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DGuildMember",
                schema: "discord",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    StaffType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DGuildMember", x => new { x.ChatId, x.UBUserId });
                    table.ForeignKey(
                        name: "FK_DGuildMember_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DGuildMember_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DUser",
                schema: "discord",
                columns: table => new
                {
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TrustFactor = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUser", x => x.UBUserId);
                    table.ForeignKey(
                        name: "FK_DUser_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                schema: "log",
                columns: table => new
                {
                    OperationId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ActionTypeId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Parameters = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstanceId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operation_ActionType_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalSchema: "log",
                        principalTable: "ActionType",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "log",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "security",
                columns: table => new
                {
                    SessionId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastIP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBroadcaster",
                schema: "twitch",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    BroadcasterId = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RulesText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SettingsLanguage = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnabledCommandsType = table.Column<byte>(type: "tinyint", nullable: false),
                    CommandPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DisabledCommands = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBroadcaster", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_TBroadcaster_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBroadcaster_UBUser_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBroadcasterStaff",
                schema: "twitch",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StaffType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBroadcasterStaff", x => new { x.ChatId, x.UBUserId });
                    table.ForeignKey(
                        name: "FK_TBroadcasterStaff_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBroadcasterStaff_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TGChat",
                schema: "telegram",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TelegramChatId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WelcomeText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    RulesText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SettingsLanguage = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ConfigurationJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommandPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ReportChatId = table.Column<long>(type: "bigint", nullable: false),
                    EnabledCommandsType = table.Column<byte>(type: "tinyint", nullable: false),
                    DisabledCommands = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastVersion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGChat", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_TGChat_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TGChat_UBUser_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TGChatMember",
                schema: "telegram",
                columns: table => new
                {
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    StaffType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGChatMember", x => new { x.ChatId, x.UBUserId });
                    table.ForeignKey(
                        name: "FK_TGChatMember_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TGChatMember_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TGUser",
                schema: "telegram",
                columns: table => new
                {
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TrustFactor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGUser", x => x.UBUserId);
                    table.ForeignKey(
                        name: "FK_TGUser_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TUser",
                schema: "twitch",
                columns: table => new
                {
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TgUserLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    TrustFactor = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUser", x => x.UBUserId);
                    table.ForeignKey(
                        name: "FK_TUser_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UBStaff",
                schema: "dbo",
                columns: table => new
                {
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UBStaff", x => new { x.UBUserId, x.Platform });
                    table.ForeignKey(
                        name: "FK_UBStaff_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UBUserPrivilege",
                schema: "security",
                columns: table => new
                {
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PrivilegeId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UBUserPrivilege", x => new { x.UBUserId, x.ChatId, x.PrivilegeId });
                    table.ForeignKey(
                        name: "FK_UBUserPrivilege_Privilege_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalSchema: "security",
                        principalTable: "Privilege",
                        principalColumn: "PrivilegeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UBUserPrivilege_UBChat_ChatId",
                        column: x => x.ChatId,
                        principalSchema: "dbo",
                        principalTable: "UBChat",
                        principalColumn: "UBChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UBUserPrivilege_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportSessionLog",
                schema: "log",
                columns: table => new
                {
                    SupportSessionId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SupportSessionLog_SupportSession_SupportSessionId",
                        column: x => x.SupportSessionId,
                        principalSchema: "log",
                        principalTable: "SupportSession",
                        principalColumn: "SupportSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupportSessionLog_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrustFactor",
                schema: "log",
                columns: table => new
                {
                    TrustFactorLogId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Action = table.Column<byte>(type: "tinyint", nullable: false),
                    RelatedActionId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstanceId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustFactor", x => x.TrustFactorLogId);
                    table.ForeignKey(
                        name: "FK_TrustFactor_Action_RelatedActionId",
                        column: x => x.RelatedActionId,
                        principalSchema: "log",
                        principalTable: "Action",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrustFactor_Instance_InstanceId",
                        column: x => x.InstanceId,
                        principalSchema: "log",
                        principalTable: "Instance",
                        principalColumn: "InstanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrustFactor_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warn",
                schema: "security",
                columns: table => new
                {
                    UBUserId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PlatformChatId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<string>(type: "nvarchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warn", x => new { x.UBUserId, x.Platform, x.PlatformChatId });
                    table.ForeignKey(
                        name: "FK_Warn_Action_ActionId",
                        column: x => x.ActionId,
                        principalSchema: "log",
                        principalTable: "Action",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Warn_UBUser_UBUserId",
                        column: x => x.UBUserId,
                        principalSchema: "dbo",
                        principalTable: "UBUser",
                        principalColumn: "UBUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_ActionTypeId",
                schema: "log",
                table: "Action",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_ChatId",
                schema: "log",
                table: "Action",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_InstanceId",
                schema: "log",
                table: "Action",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_TakenByUBUserId",
                schema: "log",
                table: "Action",
                column: "TakenByUBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BadWord_ChatId",
                schema: "filter",
                table: "BadWord",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_DGuild_OwnerId",
                schema: "discord",
                table: "DGuild",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DGuildMember_UBUserId",
                schema: "discord",
                table: "DGuildMember",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entry_KeyId",
                schema: "lang",
                table: "Entry",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCustom_ChatId",
                schema: "lang",
                table: "EntryCustom",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryCustom_KeyId",
                schema: "lang",
                table: "EntryCustom",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_ActionTypeId",
                schema: "log",
                table: "Operation",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_InstanceId",
                schema: "log",
                table: "Operation",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_UBUserId",
                schema: "log",
                table: "Operation",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_TranslationKeyId",
                schema: "security",
                table: "Privilege",
                column: "TranslationKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_UBUserId",
                schema: "security",
                table: "Session",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSession_ChatId",
                schema: "log",
                table: "SupportSession",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSession_InstanceId",
                schema: "log",
                table: "SupportSession",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSessionLog_SupportSessionId",
                schema: "log",
                table: "SupportSessionLog",
                column: "SupportSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSessionLog_UBUserId",
                schema: "log",
                table: "SupportSessionLog",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_System_InstanceId",
                schema: "log",
                table: "System",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_TBroadcaster_OwnerId",
                schema: "twitch",
                table: "TBroadcaster",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TBroadcasterStaff_UBUserId",
                schema: "twitch",
                table: "TBroadcasterStaff",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TGChat_OwnerId",
                schema: "telegram",
                table: "TGChat",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TGChatMember_UBUserId",
                schema: "telegram",
                table: "TGChatMember",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustFactor_InstanceId",
                schema: "log",
                table: "TrustFactor",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustFactor_RelatedActionId",
                schema: "log",
                table: "TrustFactor",
                column: "RelatedActionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustFactor_UBUserId",
                schema: "log",
                table: "TrustFactor",
                column: "UBUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UBCustomCommand_ChatId",
                schema: "dbo",
                table: "UBCustomCommand",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UBUserPrivilege_ChatId",
                schema: "security",
                table: "UBUserPrivilege",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UBUserPrivilege_PrivilegeId",
                schema: "security",
                table: "UBUserPrivilege",
                column: "PrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Warn_ActionId",
                schema: "security",
                table: "Warn",
                column: "ActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BadWord",
                schema: "filter");

            migrationBuilder.DropTable(
                name: "ConfigurationParameter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DGuild",
                schema: "discord");

            migrationBuilder.DropTable(
                name: "DGuildMember",
                schema: "discord");

            migrationBuilder.DropTable(
                name: "DUser",
                schema: "discord");

            migrationBuilder.DropTable(
                name: "Entry",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "EntryCustom",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Operation",
                schema: "log");

            migrationBuilder.DropTable(
                name: "SafeTName",
                schema: "filter");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Stats",
                schema: "log");

            migrationBuilder.DropTable(
                name: "SupportSessionLog",
                schema: "log");

            migrationBuilder.DropTable(
                name: "System",
                schema: "log");

            migrationBuilder.DropTable(
                name: "TBroadcaster",
                schema: "twitch");

            migrationBuilder.DropTable(
                name: "TBroadcasterStaff",
                schema: "twitch");

            migrationBuilder.DropTable(
                name: "TGChat",
                schema: "telegram");

            migrationBuilder.DropTable(
                name: "TGChatMember",
                schema: "telegram");

            migrationBuilder.DropTable(
                name: "TGStats",
                schema: "telegram");

            migrationBuilder.DropTable(
                name: "TGUser",
                schema: "telegram");

            migrationBuilder.DropTable(
                name: "TrustFactor",
                schema: "log");

            migrationBuilder.DropTable(
                name: "TUser",
                schema: "twitch");

            migrationBuilder.DropTable(
                name: "UBCommand",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UBCustomCommand",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UBStaff",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UBUserPrivilege",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Warn",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "SupportSession",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Privilege",
                schema: "security");

            migrationBuilder.DropTable(
                name: "Action",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Key",
                schema: "lang");

            migrationBuilder.DropTable(
                name: "ActionType",
                schema: "log");

            migrationBuilder.DropTable(
                name: "Instance",
                schema: "log");

            migrationBuilder.DropTable(
                name: "UBChat",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UBUser",
                schema: "dbo");
        }
    }
}
