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