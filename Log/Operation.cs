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

[Table("Operation", Schema = "log")]
public class Operation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string OperationId { get; set; }

    [MaxLength(40)] public string ActionTypeId { get; set; }
    public virtual ActionType ActionType { get; set; }

    [MaxLength(40)] public string UBUserId { get; set; }
    public virtual UBUser UBUser { get; set; }

    [MaxLength(50)] public string Action { get; set; }

    [MaxLength(150)] public string Parameters { get; set; }
    public DateTime UtcDate { get; set; }

    [MaxLength(40)] public string InstanceId { get; set; }
    public virtual Instance Instance { get; set; }
}