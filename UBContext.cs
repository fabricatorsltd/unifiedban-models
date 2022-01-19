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
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Unifiedban.Next.Models;

public class UBContext : DbContext
{
    private static string _connectionString =
        @"Server=.;Database=Unifiedban;Trusted_Connection=False;User Id=sa;Password=";

    private static readonly ValueConverter<string[], string> _stringArrayConverter = new (
        v => string.Join(";", v),
        v => v.Split(";",
            StringSplitOptions.RemoveEmptyEntries).ToArray());

    private static readonly ValueComparer<string[]> _stringArrayComparer = new((s1, s2) =>
        s1.Length == s2.Length, d => d.GetHashCode());
        
    private static readonly ValueConverter<long[], string> _longArrayConverter = new (
        v => string.Join(";", v),
        v => v.Split(";",
                StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .ConvertAll(long.Parse)
            .ToArray());

    public UBContext()
    {
    }

    public UBContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public UBContext(DbContextOptions<UBContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString,
            options => options.EnableRetryOnFailure(3));
    }

    #region " dbo "

    public DbSet<ConfigurationParameter> ConfigurationParameters { get; set; }
    public DbSet<UBChat> UBChats { get; set; }
    public DbSet<UBChatConfiguration> UBChatConfigurations { get; set; }
    public DbSet<UBUser> UBUsers { get; set; }
    public DbSet<UBStaff> UBStaffs { get; set; }
    public DbSet<Module> Modules { get; set; }

    #endregion

    #region " log "

    public DbSet<Log.SystemLog> log_SystemLogs { get; set; }
    public DbSet<Log.TrustFactor> log_TrustFactors { get; set; }
    public DbSet<Log.ActionType> log_ActionTypes { get; set; }
    public DbSet<Log.Action> log_Actions { get; set; }
    public DbSet<Log.SupportSession> log_SupportSessions { get; set; }
    public DbSet<Log.SupportSessionLog> log_SupportSessionLogs { get; set; }
    public DbSet<Log.Operation> log_Operations { get; set; }
    public DbSet<Log.Instance> log_Instances { get; set; }
    public DbSet<Log.Stats> log_Stats { get; set; }

    #endregion

    #region " lang "

    public DbSet<Translation.Language> lang_Languages { get; set; }
    public DbSet<Translation.Key> lang_Key { get; set; }
    public DbSet<Translation.Entry> lang_Entries { get; set; }
    public DbSet<Translation.EntryCustom> lang_CustomEntries { get; set; }

    #endregion

    #region " security "

    public DbSet<Security.Privilege> Privileges { get; set; }
    public DbSet<Security.Session> Sessions { get; set; }
    public DbSet<Security.UBUserPrivilege> UBUserPrivileges { get; set; }
    public DbSet<Security.Warn> Warns { get; set; }

    #endregion

    #region " filters "

    public DbSet<Filters.BadWord> BadWords { get; set; }
    public DbSet<Filters.SafeTName> SafeTNames { get; set; }

    #endregion

    #region " telegram "

    public DbSet<Telegram.TGUser> TGUsers { get; set; }
    public DbSet<Telegram.TGChat> TGChats { get; set; }
    public DbSet<Telegram.TGChatMember> TGChatStaffs { get; set; }
    public DbSet<Telegram.TGStats> TGStats { get; set; }

    #endregion

    #region " twitch "

    public DbSet<Twitch.TUser> TUsers { get; set; }
    public DbSet<Twitch.TBroadcaster> TBroadcasters { get; set; }
    public DbSet<Twitch.TBroadcasterStaff> TBroadcasterStaffs { get; set; }

    #endregion

    #region " discord "

    public DbSet<Discord.DUser> DUsers { get; set; }
    public DbSet<Discord.DGuild> DGuilds { get; set; }
    public DbSet<Discord.DGuildMember> DGuildStaffs { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        OnDboCreating(modelBuilder);
        OnLogCreating(modelBuilder);
        OnLangCreating(modelBuilder);
        OnSecurityCreating(modelBuilder);
        OnFilterCreating(modelBuilder);
        OnTelegramCreating(modelBuilder);
        OnDiscordCreating(modelBuilder);
        OnTwitchCreating(modelBuilder);
    }

    private void OnDboCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConfigurationParameter>()
            .Property(e => e.AcceptedValues)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(30);
        modelBuilder.Entity<ConfigurationParameter>()
            .Property(e => e.Platforms)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(60);

        modelBuilder.Entity<Module>()
            .Property(e => e.Platforms)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(60);

        modelBuilder.Entity<UBChatConfiguration>()
            .Property(e => e.AcceptedValues)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(60);
        modelBuilder.Entity<UBChatConfiguration>()
            .Property(e => e.Platforms)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(60);
        modelBuilder.Entity<UBChatConfiguration>()
            .HasKey(x => new { x.ChatId, x.ConfigurationParameterId, x.Platforms });

        modelBuilder.Entity<UBStaff>()
            .HasKey(x => new { x.UBUserId, x.Platform });

        modelBuilder.Entity<UBCommand>()
            .Property(e => e.TwitchUserLevel)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(60);
        modelBuilder.Entity<UBCommand>()
            .HasKey(x => new { x.Command, x.Platform });

        modelBuilder.Entity<UBCustomCommand>()
            .Property(e => e.Platforms)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(60);
        modelBuilder.Entity<UBCustomCommand>()
            .Property(e => e.TwitchUserLevel)
            .HasConversion(_stringArrayConverter, _stringArrayComparer)
            .HasMaxLength(60);
        modelBuilder.Entity<UBCustomCommand>()
            .Property(e => e.DiscordRoles)
            .HasConversion(_longArrayConverter);
    }

    private void OnLogCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log.TrustFactor>()
            .HasOne(x => x.Instance)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Log.Stats>()
            .HasKey(x => new { x.Date, x.Category });
    }
    
    private void OnLangCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation.Entry>()
            .HasKey(x => new { x.LanguageId, x.KeyId });
        modelBuilder.Entity<Translation.EntryCustom>()
            .HasKey(x => new { x.LanguageId, x.KeyId, x.ChatId });
    }

    private void OnSecurityCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Security.UBUserPrivilege>()
            .HasKey(x => new { x.UBUserId, x.ChatId, x.PrivilegeId });

        modelBuilder.Entity<Security.Warn>()
            .HasKey(x => new { x.UBUserId, x.Platform, x.PlatformChatId });
    }

    private void OnFilterCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filters.SafeTName>()
            .HasKey(x => new { x.Username, x.TelegramChatId });
    }

    private void OnTelegramCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Telegram.TGChatMember>()
            .HasKey(x => new { x.ChatId, x.UBUserId });
            
        modelBuilder.Entity<Telegram.TGChat>()
            .Property(e => e.DisabledCommands)
            .HasConversion(_stringArrayConverter, _stringArrayComparer);
        
        modelBuilder.Entity<Telegram.TGStats>()
            .HasKey(x => new { x.ChatId, x.Date, x.Category });
    }

    private void OnDiscordCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discord.DGuildMember>()
            .HasKey(x => new { x.ChatId, x.UBUserId });
        
        modelBuilder.Entity<Discord.DGuild>()
            .Property(e => e.DisabledCommands)
            .HasConversion(_stringArrayConverter, _stringArrayComparer);
    }

    private void OnTwitchCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Twitch.TBroadcasterStaff>()
            .HasKey(x => new { x.ChatId, x.UBUserId });
        
        modelBuilder.Entity<Twitch.TBroadcaster>()
            .Property(e => e.DisabledCommands)
            .HasConversion(_stringArrayConverter, _stringArrayComparer);
    }
}