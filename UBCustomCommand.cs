/* unified/ban - Management and protection systems

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

namespace Unifiedban.Next.Models;

[Table("UBCustomCommand", Schema = "dbo")]
public class UBCustomCommand
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string UBCustomCommandId { get; set; }

    [MaxLength(40)]
    public string ChatId { get; set; }
    public virtual UBChat Chat { get; set; }
    
    public string[] Platforms { get; set; } // EF conversion, ; separated

    [Column(TypeName = "tinyint")]
    public UBCommand.AnswerTypes AnswerType { get; set; }
        
    public bool Enabled { get; set; }

    [Column(TypeName = "tinyint")]
    public Enums.UserLevels TgUserLevel { get; set; }

    public long[] DiscordRoles { get; set; } // EF conversion, ; separated

    public string[] TwitchUserLevel { get; set; } // EF conversion, ; separated

    [MaxLength(10)]
    public string Command { get; set; }

    [MaxLength(200)]
    public string Content { get; set; }

    [MaxLength(150)]
    public string MediaUrl { get; set; }

    [MaxLength(50)]
    public string TelegramMediaId { get; set; }
}