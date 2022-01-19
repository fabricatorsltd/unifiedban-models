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

[Table("UBUser", Schema = "dbo")]
public class UBUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string UBUserId { get; set; }

    [MaxLength(40)]
    public string? FabUserId { get; set; }
    [Column(TypeName = "tinyint")]
        
    public Enums.UserStates State { get; set; }

    [Column(TypeName = "tinyint")]
    public int TrustFactor { get; set; } = 100;

    public long? TelegramId { get; set; }
    public long? DiscordId { get; set; }
    public long? TwitchId { get; set; }
}