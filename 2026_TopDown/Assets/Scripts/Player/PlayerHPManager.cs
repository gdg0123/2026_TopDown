using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHPManager : MonoBehaviour
{
    public static PlayerHPManager Instance;

    public GameObject heartPrefab;
    public Transform heartsParent;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private List<Image> hearts = new List<Image>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    public void UpdateHP(float currentHp, int maxHp)
    {
        if (hearts.Count != maxHp)
        {
            RebuildHearts(maxHp);
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].sprite = i < currentHp ? fullHeart : emptyHeart;

            //if (i < currentHp)
            // {
            //     hearts[i].sprite = fullHeart;
            // }
            // else
            // {
            //     hearts[i].sprite = emptyHeart;
            // }
        }
    }

    void RebuildHearts(int maxHp)
    {
        
        foreach (Image heart in hearts)
            Destroy(heart.gameObject);

        hearts.Clear();

        for (int i = 0; i < maxHp; i++)
        {
            GameObject heartObj = Instantiate(heartPrefab, heartsParent);
            hearts.Add(heartObj.GetComponent<Image>());
        }
    }

}
