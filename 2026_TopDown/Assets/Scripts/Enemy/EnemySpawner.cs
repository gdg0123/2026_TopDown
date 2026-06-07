using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy 스폰 설정")]
    public GameObject enemyPrefabs;
    public Transform[] spawnPoints;
    public bool isSpawning = true;

    [Header("스폰 타이밍 설정")]
    public float minSpawnInterval = 0.5f;       //최소 생성 간격
    public float maxSpawnInterval = 1.5f;       //최대 생성 간격
    public float timer = 0.0f;
    public float nextSpawnTime;                 //다음 생성시간

    [Header("Enemy 스폰 확률 설정")]
    [Range(0, 100)]
    public int enemySpawnChance = 60;             //생성될 확률(0~100) => 60



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            timer = 0.0f;                       //시간을 초기화 시켜준다
            SetNextSpawnTime();                 //다시 함수 실행
        }
    }

    void SpawnEnemy()
    {
        int randomValue = Random.Range(0, 100);

        if (randomValue < enemySpawnChance)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform selectedPoint = spawnPoints[randomIndex];
            Instantiate(enemyPrefabs, selectedPoint.position, selectedPoint.rotation);       //코인 프리팹을 해당 위치에 생성한다
        }

    }


    void SetNextSpawnTime()          //최소~최대 사이의 랜덤한 시간 설정
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
