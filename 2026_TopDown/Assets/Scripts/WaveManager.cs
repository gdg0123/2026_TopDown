using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [Header("Wave ¼³Á¤")]
    public float waveTime = 20f;
    private float timer;
    private bool isCleared = false;
    private int currentLevel = 2;

    [Header("UI")]
    public CanvasGroup stageUpCanvasGroup;
    public TMP_Text stageText;
    public float fadeDuration = 1f;
    public float displayDuration = 2f;

    [Header("EnemySpawner")]
    public EnemySpawner enemySpawner;

    [Header("Scene")]
    public string gameOverScene = "GameOver";
    public string gameClearScene = "GameClear";
    public int totalLevels = 5;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = waveTime;

        if(stageUpCanvasGroup != null)
        {
            stageUpCanvasGroup.alpha = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCleared) return;

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(ClearWaveRoutine());
        }
    }

    IEnumerator ClearWaveRoutine()
    {
        isCleared = true;

        if(enemySpawner != null)
        {
            enemySpawner.StopSpawning();
        }

        DestroyAllEnemies();

        UpdateStageText();

        yield return StartCoroutine(FadeCanvasGroup(0f, 1f, fadeDuration));

        
        yield return new WaitForSeconds(displayDuration);

        
        yield return StartCoroutine(FadeCanvasGroup(1f, 0f, fadeDuration));

        
        GoToNextLevel();
    }

    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    IEnumerator FadeCanvasGroup(float start, float end, float duration)
    {
        float elapsed = 0f;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            stageUpCanvasGroup.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }
        stageUpCanvasGroup.alpha = end;
    }

    void GoToNextLevel()
    {
        if(currentLevel >= totalLevels)
        {
            SceneManager.LoadScene(gameClearScene);
            return;
        }

        currentLevel++;
        timer = waveTime;
        isCleared = false;

        if(enemySpawner != null)
        {
            enemySpawner.isSpawning = true;
        }
    }

    void UpdateStageText()
    {
        if(stageText != null)
        {
            stageText.text = $"Stage {currentLevel}";
        }
    }


}
