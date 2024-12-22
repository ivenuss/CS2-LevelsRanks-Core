using System.Collections.Concurrent;
using CounterStrikeSharp.API.Core;

namespace LevelsRanksApi
{
    public interface ILevelsRanksApi
    {
        Task ConnectAsync();
        string? TableName { get; set; }
        string? DbConnectionString { get; }
        void ApplyExperienceUpdateSync(User user, CCSPlayerController player, int expChange, string eventDescription, string color);
        void ApplyExperienceUpdateSyncWithoutLimits(User user, CCSPlayerController player, int expChange, string eventDescription, char color);
        Task<Dictionary<string, int>> GetCurrentRanksAsync();
        Task<int> GetPlayerPositionAsync(string steamId);
        ulong ConvertToSteamId64(string steamId);
        string ConvertToSteamId(ulong steamId64);
        void RegisterMenuOption(string menuOptionName, Action<CCSPlayerController> action);
        void UnregisterMenuOption(string menuOptionName);
        void SetExperienceMultiplier(string steamId, double multiplier);
        double GetExperienceMultiplier(string steamId);
        bool GetExperienceFromBots();
        ConcurrentDictionary<string, User> OnlineUsers { get; }
    }
}