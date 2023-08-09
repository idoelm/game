using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 20f;
    private int maxEnemies = 10; 
    private int enemyCount = 0;
    private int enemyKilled = 0;
    private float timer = 0f;
    Vector3 VictoryScreenPosition = new Vector3(0.0897f, 0.0652f, 0f);

    public GameObject afterEnemiesKilledPrefab;

    private void Start()
    {
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && enemyCount < maxEnemies)
        {
            timer = 0f;

            SpawnEnemy();
        }
  
        if (enemyKilled >= maxEnemies)
        {
            Instantiate(afterEnemiesKilledPrefab, VictoryScreenPosition, Quaternion.identity);
            Time.timeScale = 0f;
            enabled = false;
        }
    }

    private void SpawnEnemy()
    {

        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-2f, 5f);
        Vector3 randomPosition = transform.position + new Vector3(randomX, randomY, 0f);

        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        enemyCount++;
        Debug.Log("Enemy Count: " + enemyCount);
    }

    public void KillCounter()
    {
        enemyKilled++;
        Debug.Log("kiiled: " + enemyKilled);

    }

}
