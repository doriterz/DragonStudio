using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    private Health health;

    [Header("Changing Variable")]
    public float enemyDamage = 10f;
    public float projectileCooldown = 2f;
    public float enemyHP = 10f;

    [Header("Fixed Variables")]
    public float projectileSpeed = 10f;
    public float speed = 5f;
    public GameObject projectilePrefab;

    private float lastProjectileTime;
    private bool withinShootRange;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        health = this.GetComponent<Health>();
        health.maxHP = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy downwards until it reaches the stop line
        if (transform.position.y > EnemySpawner.Instance.stopLine.transform.position.y)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // Check if the enemy is within the shoot range
        if (transform.position.y < EnemySpawner.Instance.shootStartLine.transform.position.y &&
            transform.position.y >= EnemySpawner.Instance.stopLine.transform.position.y - 1)
        {
            withinShootRange = true;
        }
        else
        {
            withinShootRange = false;
        }

        // Shoot a projectile at the player if the enemy is within the shoot range
        if (withinShootRange && Time.time - lastProjectileTime > projectileCooldown)
        {
            lastProjectileTime = Time.time;

            // Find the nearest game object with the "Player" tag
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                // Spawn a new projectile prefab at the enemy's position and rotation
                GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                projectile.transform.parent = EnemySpawner.Instance.enemySpawnPositions[0].transform;
                // Calculate the direction to the player
                Vector3 direction = (player.transform.position - transform.position).normalized;

                // Apply a forward force to the projectile in the direction of the player
                projectile.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
