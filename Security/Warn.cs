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

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unifiedban.Next.Models.Security;

[Table("Warn", Schema = "security")]
public class Warn
{
    [MaxLength(40)]
    public string UBUserId { get; set; }
    public virtual UBUser UBUser { get; set; }

    [MaxLength(30)]
    public string Platform { get; set; }
    [MaxLength(40)]
    public string PlatformChatId { get; set; }

    [MaxLength(30)]
    public string Reason { get; set; }

    public DateTime AssignedOn { get; set; }
    public DateTime? Expiry { get; set; }

    public int Points { get; set; }

    public string ActionId { get; set; }
    public virtual Log.Action Action { get; set; }
}