using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpUI : MonoBehaviour
{
    public static ExpUI Instance;

    public Slider expSlider;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateExpBar(int currentExp, int required, int level)
    {
        if (expSlider != null)
            expSlider.value = (float)currentExp / required;

    }

}
