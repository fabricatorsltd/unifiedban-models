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

[Table("System", Schema = "log")]
public class SystemLog
{
    public enum Levels
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }

    public enum ErrorCodes
    {
        OK,
        Error
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string SystemLogId { get; set; }

    [MaxLength(30)] public string LoggerName { get; set; }

    [MaxLength(50)] public string Function { get; set; }

    [MaxLength(400)] public string Message { get; set; }

    [Column(TypeName = "tinyint")] public Levels Level { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(40)] public string InstanceId { get; set; }
    public virtual Instance Instance { get; set; }
}