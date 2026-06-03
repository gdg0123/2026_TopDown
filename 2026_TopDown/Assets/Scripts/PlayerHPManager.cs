using UnityEngine;
using UnityEngine.UI;

public class PlayerHPManager : MonoBehaviour
{
    public static PlayerHPManager Instance;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    public void UpdateHP(int currentHp, int maxHp)
    {
        for(int i = 0; i < hearts.Length; i++)
        {
           if (i < currentHp)
               hearts[i].sprite = fullHeart;
           else
               hearts[i].sprite = emptyHeart;
        }
    }
   
}
