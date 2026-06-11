using UnityEngine;


[System.Serializable]
public class EnemySpawnInfo
{
    public GameObject enemyPrefab;  
    public EnemyData enemyData;     
    public int spawnWeight;         
}


[CreateAssetMenu(menuName = "Wave/WaveData")]
public class WaveData : ScriptableObject
{
    public string waveName;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    public int spawnChance;
    public EnemySpawnInfo[] enemies;
}
