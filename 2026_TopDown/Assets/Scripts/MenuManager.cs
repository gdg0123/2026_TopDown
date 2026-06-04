using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
        }
    }
    

    void CloseMenu()
    {
        
    }
    
}
