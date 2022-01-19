﻿/* unified/ban - Management and protection systems

© fabricators SRL, https://fabricators.ltd , https://unifiedban.solutions

This program is free software: you can redistribute it and/or modify
it under the terms of the fabricator's FOSS License.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the fabricator's FOSS License
along with this program.  If not, see <https://fabricators.ltd/FOSSLicense>. */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifiedban.Next.Models;

[Table("UBChatConfiguration", Schema = "dbo")]
public class UBChatConfiguration
{
    [MaxLength(40)]
    public string ChatId { get; set; }
    public virtual UBChat Chat { get; set; }
    
    [MaxLength(50)]
    public string ConfigurationParameterId { get; set; }

    [Column(TypeName = "tinyint")]
    public ConfigurationParameter.Overrides Override { get; set; }

    [MaxLength(50)]
    public string Category { get; set; }

    [MaxLength(50)]
    public string Value { get; set; }

    [MaxLength(20)]
    public string Type { get; set; } // bool, string, int

    [MaxLength(30)]
    public string[] AcceptedValues { get; set; } // EF conversion, ; separated

    [MaxLength(30)]
    public string[] Platforms { get; set; } // EF conversion, ; separated
}