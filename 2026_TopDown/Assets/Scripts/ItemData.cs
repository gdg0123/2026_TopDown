using UnityEngine;

public enum  StatType { MaxHp, MoveSpeed, AttackSpeed, Damage }

[CreateAssetMenu(menuName = "Game/ItemData")]

public class ItemData : ScriptableObject
{
    public string itemName;         
    public string description;      
    public Sprite icon;             
    public StatType statType;       
    public float value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
