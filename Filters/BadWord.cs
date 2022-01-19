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

namespace Unifiedban.Next.Models.Filters;

[Table("BadWord", Schema = "filter")]
public class BadWord
{
    public enum State
    {
        Disabled = 0,
        Experimental = 1,
        Active = 2
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string BadWordId { get; set; }

    [MaxLength(40)]
    public string? ChatId { get; set; }
    public virtual UBChat Chat { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(400)]
    public string Regex { get; set; }

    [Column(TypeName = "tinyint")]
    public State Status { get; set; }

    public DateTime LastUpdate { get; set; }

    public int Match { get; set; } // number of times this rule had match
}