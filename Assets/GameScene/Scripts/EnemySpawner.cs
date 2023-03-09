using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner Instance;

    public GameObject enemyPrefab;
    public List<Transform> enemySpawnPositions;
    public float spawnDelay = 2f;
    public GameObject stopLine;
    public GameObject shootStartLine;
    private float lastSpawnTime;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if enough time has passed since the last spawn
        if (Time.time - lastSpawnTime > spawnDelay)
        {
            lastSpawnTime = Time.time;

            // Randomly select an enemy spawn position
            int randomIndex = Random.Range(0, enemySpawnPositions.Count);
            Transform spawnPosition = enemySpawnPositions[randomIndex];

            // Spawn a new enemy prefab at the selected spawn position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
            // Set the spawned enemy's parent to the spawn position object
            enemy.transform.parent = spawnPosition;
        }
    }
}
