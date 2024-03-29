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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using Unifiedban.Next.Common;

namespace Unifiedban.Next.Models.Telegram;

[Table("TGChat", Schema = "telegram")]
public class TGChat : Common.IUBChat
{
    [Key]
    [MaxLength(40)]
    public string ChatId { get; set; }
    public virtual UBChat Chat { get; set; }

    public Enums.Platforms Platform { get; } = Enums.Platforms.Telegram;

    [Column(TypeName = "tinyint")]
    public Enums.ChatStates Status { get; set; }
        
    [MaxLength(40)]
    public string OwnerId { get; set; }
    public virtual UBUser Owner { get; set; }
    public long TelegramChatId { get; set; }
        
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(400)]
    public string WelcomeText { get; set; }

    [MaxLength(400)]
    public string RulesText { get; set; }

    [MaxLength(5)]
    public string SettingsLanguage { get; set; } = "en";

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

    [MaxLength(5)]
    public string CommandPrefix { get; set; } = "/";

    public long ReportChatId { get; set; }
        
    [Column(TypeName = "tinyint")]
    public Enums.EnabledCommandsTypes EnabledCommandsType { get; set; }

    public string[] DisabledCommands { get; set; } // EF conversion, ; separated
    
    [MaxLength(10)]
    public string LastVersion { get; set; }
    
    public ConfigurationParameter GetConfigParam(string name, string defaultValue)
    {
        var config = Configuration.FirstOrDefault(x => x.ConfigurationParameterId == name);
        if(config == null) return new ConfigurationParameter(name, defaultValue);

        if (config.Override == Enums.Overrides.Group)
        {
            return Chat.GetConfigParam(name, defaultValue);
        }
        if (config.Override == Enums.Overrides.Team)
        {
            // TODO
        }

        return config;
    }
}