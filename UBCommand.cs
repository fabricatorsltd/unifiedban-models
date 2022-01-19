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

[Table("UBCommand", Schema = "dbo")]
public class UBCommand
{
    public enum AnswerTypes
    {
        Text = 0,
        Image = 1,
        Gif = 2,
        Video = 3,
        Audio = 4,
        Link = 5
    }

    [MaxLength(20)]
    public string Command { get; set; }

    [MaxLength(20)]
    public string Platform { get; set; }

    [Column(TypeName = "tinyint")]
    public AnswerTypes AnswerType { get; set; }

    [Column(TypeName = "tinyint")]
    public Enums.UserLevels TgUserLevel { get; set; }

    public Enums.UserLevels DiscordUserLevel { get; set; }

    public string[] TwitchUserLevel { get; set; }
}