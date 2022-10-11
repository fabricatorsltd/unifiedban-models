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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using Unifiedban.Next.Models.Discord;
using Unifiedban.Next.Models.Telegram;
using Unifiedban.Next.Models.Twitch;

namespace Unifiedban.Next.Models;

[Table("UBChat", Schema = "dbo")]
public class UBChat
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [MaxLength(40)]
    public string UBChatId { get; set; }
    
    public string ConfigurationJson
    {
        get => JsonConvert.SerializeObject(configuration);
        set =>
            configuration = JsonConvert.DeserializeObject<List<ConfigurationParameter>>(value) ??
                            new List<ConfigurationParameter>();
    }

    [NotMapped]
    private List<ConfigurationParameter> configuration { get; set; }
    [NotMapped]
    public List<ConfigurationParameter> Configuration
    {
        get => configuration;
        set => ConfigurationJson = JsonConvert.SerializeObject(value); 
    }
        
    public virtual TGChat TGChat { get; set; }
    public virtual DGuild DGuild { get; set; }
    public virtual TBroadcaster TBroadcaster { get; set; }

    public UBChatConfigurationParameter<T> GetConfigParam<T>(string name, T defaultValue)
    {
        var config = Configuration.FirstOrDefault(x => x.ConfigurationParameterId == name);
        if (config == null)
            return new UBChatConfigurationParameter<T>(defaultValue)
            {
                ConfigurationParameterId = name
            };

        return (UBChatConfigurationParameter<T>)config;
    }
}