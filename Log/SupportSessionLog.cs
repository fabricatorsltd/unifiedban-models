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
using Microsoft.EntityFrameworkCore;

namespace Unifiedban.Next.Models.Log;

[Keyless]
[Table("SupportSessionLog", Schema = "log")]
public class SupportSessionLog
{
    public enum SenderType
    {
        User = 0,
        Admin = 1,
        Operator = 2
    }

    [MaxLength(40)] public string SupportSessionId { get; set; }
    public virtual SupportSession SupportSession { get; set; }

    [MaxLength(40)] public string UBUserId { get; set; }
    public virtual UBUser UBUser { get; set; }

    public string Text { get; set; }

    public DateTime Timestamp { get; set; }

    [Column(TypeName = "tinyint")] public SenderType Type { get; set; }
}