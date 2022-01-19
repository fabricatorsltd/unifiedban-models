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

[Table("Action", Schema = "log")]
public class Action
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string ActionId { get; set; }

    [MaxLength(40)]
    public string ActionTypeId { get; set; }
    public virtual ActionType ActionType { get; set; }

    [MaxLength(40)]
    public string ChatId { get; set; }
    public virtual UBChat Chat { get; set; }

    [MaxLength(40)]
    public string Platform { get; set; }

    [MaxLength(150)]
    public string Parameters { get; set; }

    [MaxLength(40)]
    public string TakenByUserId { get; set; }
    public virtual UBUser TakenBy { get; set; }

    public DateTime UtcDate { get; set; }

    [MaxLength(40)]
    public string InstanceId { get; set; }
    public virtual Instance Instance { get; set; }
}