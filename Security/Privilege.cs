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
using Unifiedban.Next.Models.Translation;

namespace Unifiedban.Next.Models.Security;

[Table("Privilege", Schema = "security")]
public class Privilege
{
    [Key] [MaxLength(40)] public string PrivilegeId { get; set; }

    [MaxLength(150)] public string TranslationKeyId { get; set; }
    public virtual Key TranslationKey { get; set; }
}