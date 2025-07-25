using UnityEngine;
using System.IO;

public static class PlayerStatsManager
{
    /// <summary>
    /// Saves a <c>PlayerStats</c> object to the games persistent path. This is often at
    /// <c>..\AppData\LocalLow\DefaultCompany\FootballSim</c>. A new directory called
    /// PlayerStats is created if not already present, then the stats are saved in
    /// json format with the name <c>PlayerName.json</c>.
    /// </summary>
    /// <param name="playerStats">The PlayerStats object to save.</param>
    /// <returns>True if save was successful, false otherwise.</returns>
    public static bool SaveStats(PlayerStats playerStats)
    {
        var json = JsonUtility.ToJson(playerStats, true);
        var dirPath = Path.Combine(Application.persistentDataPath, "PlayerStats");
        var fullPath = Path.Combine(dirPath, playerStats.playerName + ".json");

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        
        try
        {
            File.WriteAllText(fullPath, json);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save stats: " + e.Message);
            return false;
        }
        
        return true;
    }
    
    
    /// <summary>
    /// Loads a <c>PlayerStats</c> object from storage. Name of the file
    /// is <c>PlayerName.json</c>. If the file does not exist a default
    /// object is returned.
    /// </summary>
    /// <param name="playerName">
    /// The name of the player/file to load the stats for.
    /// </param>
    /// <returns>
    /// The players <c>PlayerStats</c> object if the file exists, a default
    /// object otherwise.
    /// </returns>
    public static PlayerStats LoadStats(string playerName)
    {
        var path = Path.Combine(Application.persistentDataPath, "PlayerStats", playerName + ".json");

        if (!File.Exists(path)) return new PlayerStats();
        
        try
        {
            var json = File.ReadAllText(path);
            var stats = JsonUtility.FromJson<PlayerStats>(json);
            return stats;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load stats for {playerName}: {e.Message}");
            return new PlayerStats();
        }
    }
}
