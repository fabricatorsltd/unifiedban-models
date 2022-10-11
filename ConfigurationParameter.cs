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

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Unifiedban.Next.Common;

namespace Unifiedban.Next.Models;

[Table("ConfigurationParameter", Schema = "dbo")]
public class ConfigurationParameter
{
    [MaxLength(50)]
    public string ConfigurationParameterId { get; set; }

    [Column(TypeName = "tinyint")]
    public Enums.Overrides Override { get; set; }

    [MaxLength(50)]
    public string Category { get; set; }

    [MaxLength(50)]
    public string DefaultValue { get; set; }
    
    public string[] AcceptedValues { get; set; } // EF conversion, ; separated

    public string[] Platforms { get; set; } // EF conversion, ; separated
    
    [MaxLength(50)]
    public string Value { get; set; }

    public ConfigurationParameter(){}
    public ConfigurationParameter(string name, string value)
    {
        ConfigurationParameterId = name;
        Value = value;
    }
    
    public void SetDefault()
    {
        Value = DefaultValue;
    }
    
    public bool SetValue(string newValue)
    {
        if (!IsInRange(newValue)) return false;
        Value = newValue;
        return true;
    }
    
    private bool IsInRange(string? newValue)
    {
        if (AcceptedValues.Length == 0) return true;
        if (newValue == null) return true;
        
        var valueType = newValue.GetType();
        foreach (var acceptedValue in AcceptedValues)
        {
            if (acceptedValue.Contains('-') && valueType == typeof(int))
            {
                var valueAsInt = (int)Convert.ChangeType(newValue, typeof(int));
                var ranges = acceptedValue.Split('-');
                if (int.Parse(ranges[0]) <= valueAsInt && int.Parse(ranges[1]) >= valueAsInt)
                    return false;
            }

            if (acceptedValue == newValue) return true;
        }

        return false;
    }
}

