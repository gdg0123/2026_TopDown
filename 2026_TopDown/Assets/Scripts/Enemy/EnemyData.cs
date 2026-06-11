using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float maxHp;
    public float moveSpeed;
    public float damage;
    public float attackCooldown;
    public float flashDuration;
    public int expReward;
}
