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
using Unifiedban.Next.Models.Discord;
using Unifiedban.Next.Models.Telegram;
using Unifiedban.Next.Models.Twitch;

namespace Unifiedban.Next.Models;

[Table("UBChat", Schema = "dbo")]
public class UBChat
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string UBChatId { get; set; }
        
    public virtual TGChat TGChat { get; set; }
    public virtual DGuild DGuild { get; set; }
    public virtual TBroadcaster TBroadcaster { get; set; }
}