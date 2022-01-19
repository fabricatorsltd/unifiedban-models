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
using Unifiedban.Next.Common;

namespace Unifiedban.Next.Models;

[Table("Module", Schema = "dbo")]
public class Module
{
    [MaxLength(80)]
    public string ModuleId { get; set; }
    
    [MaxLength(10)]
    public string Version { get; set; }

    [Column(TypeName = "tinyint")] 
    public Enums.States Status { get; set; }

    [Column(TypeName = "tinyint")] 
    public Enums.QueueMessageCategories MessageCategory { get; set; }
    
    [MaxLength(20)]
    public string Exchange { get; set; }
    
    [MaxLength(20)]
    public string RoutingKey { get; set; }
    
    [MaxLength(20)]
    public string QueueName { get; set; }

    public ushort ChainPriority { get; set; } = 50;

    public string[] Platforms { get; set; } // EF conversion, ; separated
}