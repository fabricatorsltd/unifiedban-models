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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifiedban.Next.Models.Translation;

[Table("Language", Schema = "lang")]
public class Language
{
    public enum State
    {
        NotRready = 0,
        Active = 1,
        Disabled = 2
    }

    [MaxLength(10)]
    [Required]
    public string LanguageId { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    [MaxLength(20)]
    [Required]
    public string UniversalCode { get; set; }

    [Column(TypeName = "tinyint")]
    public State Status { get; set; }
}