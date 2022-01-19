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

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifiedban.Next.Models.Security;

[Table("Warn", Schema = "security")]
public class Warn
{
    [MaxLength(40)]
    public string UBUserId { get; set; }
    public virtual UBUser UBUser { get; set; }

    [MaxLength(30)]
    public string Platform { get; set; }
    [MaxLength(40)]
    public string PlatformChatId { get; set; }

    [MaxLength(30)]
    public string Reason { get; set; }

    public DateTime AssignedOn { get; set; }
    public DateTime? Expiry { get; set; }

    public int Points { get; set; }

    public string ActionId { get; set; }
    public virtual Log.Action Action { get; set; }
}