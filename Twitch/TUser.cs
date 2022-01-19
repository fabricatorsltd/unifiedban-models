/* unified/ban - Management and protection systems

© fabricators SRL, https://fabricators.ltd , https://unifiedban.solutions

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License with our addition
to Section 7 as published in unified/ban's the GitHub repository.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License and the
additional terms along with this program. 
If not, see <https://docs.fabricators.ltd/docs/licenses/unifiedban>.

For more information, see Licensing FAQ: 

https://docs.fabricators.ltd/docs/licenses/faq */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifiedban.Next.Models.Twitch;

[Table("TUser", Schema = "twitch")]
public class TUser
{
    public enum UserLevels
    {
        User = 0,
        Subscriber = 1,
        VIP = 2,
        Mod = 3,
        Admin = 4
    }
        
    [Key]
    [MaxLength(40)]
    [ForeignKey("UBUser")]
    public string UBUserId { get; set; }
    public virtual UBUser UBUser { get; set; }

    [Column(TypeName = "tinyint")]
    public UserLevels TgUserLevel { get; set; }

    [Column(TypeName = "tinyint")]
    public int TrustFactor { get; set; } = 100;

    [NotMapped]
    public List<Security.Warn> Warnings { get; set; }
}