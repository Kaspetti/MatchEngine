using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string playerName;
    
    private PlayerStats _playerStats;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _playerStats = PlayerStatsManager.LoadStats(playerName);
        Debug.Log(_playerStats.playerName + _playerStats.vision);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
