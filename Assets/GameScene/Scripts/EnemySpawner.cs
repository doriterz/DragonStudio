using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static EnemySpawner Instance;

    public LevelListSO levelListSO;
    public EnemiesListSO enemiesListSO;
    public GameObject enemyPrefab;
    public List<Transform> enemySpawnPositions;
    public float spawnDelay = 5f;
    public GameObject stopLine;
    public GameObject shootStartLine;
    private float lastSpawnTime;
    public float enemyKillCount;
    public float enemySpawnCount;
    public float currentLevel;

    [Header("Testing Variables")]
    public float enemyDamageTest;
    public float atkSpeedTest;
    public float enemyHPTest;


    private void Awake()
    {
        Instance = this;
    }



    public void SpawnEnemy()
    {

        // Spawn enemies for the required amount per level
        if (enemySpawnCount < levelListSO.levelSO[(int)currentLevel].monsterCount)
        {
            // Check if enough time has passed since the last spawn
            if (Time.time - lastSpawnTime > spawnDelay)
            {
                lastSpawnTime = Time.time;

                // Randomly select an enemy spawn position
                int randomPositionIndex = Random.Range(0, enemySpawnPositions.Count);
                Transform spawnPosition = enemySpawnPositions[randomPositionIndex];

                // Randomly select an enemy to spawn
                int randomEnemyIndex = Random.Range(0, enemiesListSO.enemiesSO.Length);

                // Spawn a new enemy prefab at the selected spawn position
                GameObject enemySpawn = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
                // Set the spawned enemy's parent to the spawn position object
                enemySpawn.transform.parent = spawnPosition;

                Enemy enemy = enemySpawn.GetComponent<Enemy>();
                enemy.enemyDamage = enemiesListSO.enemiesSO[randomEnemyIndex].enemyDamage * (currentLevel + 1);
                enemy.projectileCooldown = enemiesListSO.enemiesSO[randomEnemyIndex].enemyAtkSpeed / (currentLevel + 1);
                enemy.enemyHP = enemiesListSO.enemiesSO[randomEnemyIndex].enemyHP * (currentLevel + 1);
                enemy.enemyProjectileSprite = enemiesListSO.enemiesSO[randomEnemyIndex].projectileSprite;

                enemySpawnCount++;
                enemyDamageTest = enemy.enemyDamage;
                atkSpeedTest = enemy.projectileCooldown;
                enemyHPTest = enemy.enemyHP;
            }
        }
        // if all the monsters are spawned for the level 
        else if (enemySpawnCount == levelListSO.levelSO[(int)currentLevel].monsterCount)
        {
            // check there are more levels to play, if so increase level 
            if (currentLevel < levelListSO.levelSO.Length)
            {
                currentLevel++;
                enemySpawnCount = 0;
                LevelPillController.Instance.LevelPillSpawn();
            }
            else
            {
                currentLevel = levelListSO.levelSO.Length;
                enemySpawnCount = 0;
            }
        }
    }









}
