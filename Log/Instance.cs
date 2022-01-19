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
using Unifiedban.Next.Common;

namespace Unifiedban.Next.Models.Log;

[Table("Instance", Schema = "log")]
public class Instance
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string InstanceId { get; set; }

    [MaxLength(80)]
    public string ModuleId { get; set; }
    [MaxLength(10)]
    public string Version { get; set; }

    public DateTime Start { get; set; }
    public DateTime? Stop { get; set; }

    [Column(TypeName = "tinyint")] 
    public Enums.States Status { get; set; }
}