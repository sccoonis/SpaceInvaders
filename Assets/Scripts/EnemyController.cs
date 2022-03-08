using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int numAcross = 6;
    public float widthPerEnemy = 2f;
    public float heightPerEnemy = 2f;

    public float secPerStep = 0.5f;
    [Range(0.1f, 2)] public float minShootInterval = 1f;
    [Range(2f, 10f)] public float maxShootInterval = 7f;

    public Transform enemy1Prefab;
    public Transform enemy2Prefab;
    public Transform enemy3Prefab;

    public Transform enemyRoot;
    public ScoreManager scoreManager;
    
    private Vector3 marchDir = Vector3.right;
    private float shotInterval;
    private float timeSinceStep;
    private float timeSinceShot;
    
    void Start()
    {
        float windowHeight = Camera.main.orthographicSize;
        float enemyStartHeight = windowHeight - heightPerEnemy * 2.5f;
        SpawnEnemyRow(enemy1Prefab, enemyStartHeight);
        SpawnEnemyRow(enemy2Prefab, enemyStartHeight - heightPerEnemy);
        SpawnEnemyRow(enemy3Prefab, enemyStartHeight - heightPerEnemy * 2f);
        shotInterval = Random.Range(minShootInterval, maxShootInterval);
    }
    
    void Update()
    {
        timeSinceStep += Time.deltaTime;
        timeSinceShot += Time.deltaTime;

        if (timeSinceStep > secPerStep)
        {
            timeSinceStep -= secPerStep;
            enemyRoot.position += marchDir * widthPerEnemy * 05f;

            float hExtent = Camera.main.orthographicSize * Camera.main.aspect - widthPerEnemy;
            foreach (Transform enemyTransform in enemyRoot)
            {
                if (Mathf.Abs(enemyTransform.position.x) > hExtent)
                {
                    enemyRoot.position += Vector3.down* heightPerEnemy;
                    marchDir *= -1f;
                    break;
                }
            }
        }

        if (timeSinceShot > shotInterval)
        {
            timeSinceShot -= shotInterval;
            Debug.Log("Return fire");
            shotInterval = Random.Range(minShootInterval, maxShootInterval);
        }
    }

    void SpawnEnemyRow(Transform enemyPrefab, float height)
    {
        for (int i = 0; i < numAcross; i++)
        {
            float xPos = -(numAcross * widthPerEnemy) / 2 + i * widthPerEnemy + widthPerEnemy / 2;
            Transform enemy = Instantiate(enemyPrefab, new Vector3(xPos, height, 0f), Quaternion.identity);
            enemy.SetParent(enemyRoot);
            enemy.GetComponent<Enemy>().OnEnemyDestroyed += OnEnemyDied;
        }
    }

    void OnEnemyDied(Enemy enemy)
    {
        enemy.OnEnemyDestroyed -= OnEnemyDied;
        scoreManager.AddPoints(enemy);
    }
}
