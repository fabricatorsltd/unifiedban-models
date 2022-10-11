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
}

[NotMapped]
public class UBChatConfigurationParameter<T> : ConfigurationParameter
{
    [Column(TypeName = "nvarchar(50)")]
    public T Value { get; private set; }

    public UBChatConfigurationParameter()
    {
        Value = (T)Convert.ChangeType(DefaultValue, typeof(T));
    }
    public UBChatConfigurationParameter(T value)
    {
        Value = value;
    }
    
    public void SetDefault()
    {
        Value = (T) Convert.ChangeType(DefaultValue, typeof(T));
    }
    public bool SetValue(T newValue)
    {
        if (!IsInRange(newValue)) return false;
        Value = newValue;
        return true;
    }
    private bool IsInRange(T newValue)
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

            if (acceptedValue == newValue.ToString()) return true;
        }

        return false;
    }
}