using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float lifespan = 5f;

    void Start()
    {
        // Destroy the projectile after the lifespan
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the Health component of the player
            Health playerHealth = other.gameObject.GetComponent<Health>();

            // Check if the player has a Health component
            if (playerHealth != null)
            {
                // Reduce the player's HP by the damage amount of the projectile
                playerHealth.TakeDamage((int)Enemy.Instance.enemyDamage);
            }
            // Destroy the projectile if it collides with an object tagged "Player"
            Destroy(gameObject);
        }
    }

}
