using UnityEngine.Serialization;

[System.Serializable]
public class PlayerStats
{
    public string playerName;

    public int vision;

    public PlayerStats() { }
    
    public PlayerStats(string playerName, int vision)
    {
        this.playerName = playerName;
        this.vision = vision;
    }
}
