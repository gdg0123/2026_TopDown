using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance;

    [Header("����ġ ����")]
    public int currentLevel = 1;
    public int currentExp = 0;
    public int baseExp = 10;
    public float expMultiplier = 1.5f;

    [Header("������")]
    public List<ItemData> itemPool;

    public int ExpToNextLevel => Mathf.RoundToInt(baseExp * Mathf.Pow(expMultiplier, currentLevel - 1));

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExp(int amount)
    {
        currentExp += amount;

        if(currentExp >= ExpToNextLevel)
        {
            currentExp -= ExpToNextLevel;
            LevelUp();
        }

        ExpUI.Instance?.UpdateExpBar(currentExp, ExpToNextLevel, currentLevel);

        //if (ExpUI.Instance != null)
       // {
        //    ExpUI.Instance.UpdateExpBar(currentExp, ExpRequired, currentLevel);
       // }
    }

    void LevelUp()
    {
        currentLevel++;
        Debug.Log("Current Level: " + currentLevel);

        List<ItemData> choices = GetRandomItems(2);
        LevelUpUI.Instance?.ShowLevelUp(choices);
    }

    List<ItemData> GetRandomItems(int count)
    {
     
        List<ItemData> result = new List<ItemData>();

        for (int i = 0; i < count; i++)
        {
            if (itemPool.Count == 0) break;
            int rand = Random.Range(0, itemPool.Count);
            result.Add(itemPool[rand]);
        }

        return result;
    }

    public void ApplyItem(ItemData item)
    {
        PlayerController player = FindAnyObjectByType<PlayerController>();
        PlayerHealth health = FindAnyObjectByType<PlayerHealth>();

        switch(item.statType)
        {
            case StatType.MaxHp:
                health?.IncreaseMaxHp((int)item.value);
                break;
            case StatType.MoveSpeed:
                player?.IncreaseMoveSpeed(item.value);
                break;
            case StatType.AttackSpeed:
                FindAnyObjectByType<Attacker>()?.IncreaseFirerate(item.value);
                break;
            case StatType.Damage:
                FindAnyObjectByType<Attacker>()?.IncreaseDamage(item.value);
                break;
        }
    }

}
