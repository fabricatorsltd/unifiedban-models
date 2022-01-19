﻿/* unified/ban - Management and protection systems

© fabricators SRL, https://fabricators.ltd , https://unifiedban.solutions

This program is free software: you can redistribute it and/or modify
it under the terms of the fabricator's FOSS License.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the fabricator's FOSS License
along with this program.  If not, see <https://fabricators.ltd/FOSSLicense>. */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unifiedban.Next.Common;

namespace Unifiedban.Next.Models.Discord;

[Table("DGuild", Schema = "discord")]
public class DGuild : IUBChat
{
    [Key]
    [MaxLength(40)]
    public string ChatId { get; set; }
    public virtual UBChat Chat { get; set; }

    public Enums.Platforms Platform { get; } = Enums.Platforms.Discord;

    [Column(TypeName = "tinyint")]
    public Enums.ChatStates Status { get; set; }

    public long GuildId { get; set; }
        
    [MaxLength(40)]
    public string OwnerId { get; set; }
    public virtual UBUser UBUser { get; set; }
        
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(400)]
    public string WelcomeText { get; set; }
    [MaxLength(400)]
    public string RulesText { get; set; }

    [MaxLength(5)]
    public string SettingsLanguage { get; set; } = "en";

    public string Configuration { get; set; }

    [MaxLength(5)]
    public string CommandPrefix { get; set; } = "/";

    public long ReportChanneltId { get; set; }
        
    [Column(TypeName = "tinyint")]
    public Enums.EnabledCommandsTypes EnabledCommandsType { get; set; }

    public string[] DisabledCommands { get; set; } // EF conversion, ; separated
}