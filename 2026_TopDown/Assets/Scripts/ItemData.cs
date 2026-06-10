using UnityEngine;

public enum  StatType { MaxHp, MoveSpeed, AttackSpeed, Damage }

[CreateAssetMenu(menuName = "Game/ItemData")]

public class ItemData : ScriptableObject
{
    public string itemName;         //체력 증가
    public string description;      //최대 체력이 1 증가
    public Sprite icon;             //아이템 아이콘
    public StatType statType;       //어떤 스탯을 올릴지
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
