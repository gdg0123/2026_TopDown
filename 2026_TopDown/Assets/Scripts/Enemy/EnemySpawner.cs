using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("Wave Data")]
    public WaveData[] waveDatas;
    private WaveData currentWave;

    public bool isSpawning = true;
    private float timer = 0f;
    private float nextSpawnTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetWave(0);
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;               //시간이 0에서 점점 증가

        //생성 시간이 되면 오브젝트 생성
        if (timer > nextSpawnTime)
        {
            SpawnEnemy();                       //프리팹 생성 함수를 호출한다
            timer = 0f;                         //시간을 초기화 시켜준다
            SetNextSpawnTime();                 //다시 함수 실행
        }
    }

    public void SetWave(int stageIndex)
    {
        if (stageIndex >= waveDatas.Length)
            stageIndex = waveDatas.Length - 1;

        currentWave = waveDatas[stageIndex];
        isSpawning = true;
        timer = 0f;
        SetNextSpawnTime();
    }

    void SpawnEnemy()
    {
        int randomValue = Random.Range(0, 100);
        if (randomValue >= currentWave.spawnChance) return;

        // 랜덤 스폰 위치
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        EnemySpawnInfo selected = GetRandomEnemy();
        if (selected == null) return;

        // 프리팹 생성 후 EnemyData 연결
        GameObject obj = Instantiate(selected.enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        obj.GetComponent<Enemy1>().data = selected.enemyData;

    }

    EnemySpawnInfo GetRandomEnemy()
    {
        if (currentWave.enemies.Length == 0) return null;

        int totalWeight = 0;
        foreach (EnemySpawnInfo info in currentWave.enemies)
            totalWeight += info.spawnWeight;

        int rand = Random.Range(0, totalWeight);
        int cumulative = 0;

        foreach (EnemySpawnInfo info in currentWave.enemies)
        {
            cumulative += info.spawnWeight;
            if (rand < cumulative)
                return info;
        }

        return currentWave.enemies[0];
    }


    void SetNextSpawnTime()       
    {
        if (currentWave == null) return;
        nextSpawnTime = Random.Range(currentWave.minSpawnInterval, currentWave.maxSpawnInterval);
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
