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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifiedban.Next.Models;

[Table("ConfigurationParameter", Schema = "dbo")]
public class ConfigurationParameter
{
    public enum Overrides
    {
        None = 0,
        Global = 1,
        Team = 2
    }
        
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(50)]
    public string ConfigurationParameterId { get; set; }

    [Column(TypeName = "tinyint")]
    public Overrides Override { get; set; }

    [MaxLength(50)]
    public string Category { get; set; }

    [MaxLength(50)]
    public string Value { get; set; }

    [MaxLength(20)]
    public string Type { get; set; } // bool, string, int

    public string[] AcceptedValues { get; set; } // EF conversion, ; separated

    public string[] Platforms { get; set; } // EF conversion, ; separated
}