using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [Header("Wave 설정")]
    public float waveTime = 20f;
    private float timer;
    private bool isCleared = false;

    [Header("적 설정")]
    public CanvasGroup stageUpCanvasGroup;
    public TMP_Text stageText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
