using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public PlayerController playerController;
    public Attacker attacker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuPanel.activeSelf)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    void OpenMenu()
    {
        
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
        playerController.enabled = false;
        attacker.enabled = false;

    }
    

    void CloseMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
        playerController.enabled = true;
        attacker.enabled = true;
    }
    
}
