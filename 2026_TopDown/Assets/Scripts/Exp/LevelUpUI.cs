using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LevelUpUI : MonoBehaviour
{
    public static LevelUpUI Instance;

    public GameObject panel;
    public GameObject[] cardObjects;
    public Image[] cardIcons;
    public TMP_Text[] cardDescs;

    private List<ItemData> currentChoices;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLevelUp(List<ItemData> choices)
    {
        currentChoices = choices;
        panel.SetActive(true);
        Time.timeScale = 0f;

        for(int i = 0; i < cardObjects.Length; i++)
        {
            if(i < choices.Count)
            {
                cardObjects[i].SetActive(true);
                cardIcons[i].sprite = choices[i].icon;
                cardDescs[i].text = choices[i].description;
            }
            else
            {
                cardObjects[i].SetActive(false);
            }
        }
    }

    public void SelectItem(int index)
    {
        if (index >= currentChoices.Count) return;

        ExpManager.Instance?.ApplyItem(currentChoices[index]);

        panel.SetActive(false);
        Time.timeScale = 1f;
    }


}
