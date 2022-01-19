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

namespace Unifiedban.Next.Models.Log;

[Table("TrustFactor", Schema = "log")]
public class TrustFactor
{
    public enum TrustFactorAction
    {
        Limit = 0,
        Kick = 1,
        Ban = 2,
        Blacklist = 3
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string TrustFactorLogId { get; set; }

    [MaxLength(40)] public string UBUserId { get; set; }
    public virtual UBUser UBUser { get; set; }

    [Column(TypeName = "tinyint")] public TrustFactorAction Action { get; set; }

    [MaxLength(40)] public string RelatedActionId { get; set; }
    public virtual Action RelatedAction { get; set; }

    public DateTime DateTime { get; set; }

    [MaxLength(40)] public string InstanceId { get; set; }
    public virtual Instance Instance { get; set; }
}