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

namespace Unifiedban.Next.Models.Translation;

[Table("Entry", Schema = "lang")]
public class Entry
{
    [MaxLength(10)]
    public string LanguageId { get; set; }
    public virtual Language Language { get; set; }

    [MaxLength(150)]
    public string KeyId { get; set; }
    public virtual Key Key { get; set; }

    public string Translation { get; set; }
}