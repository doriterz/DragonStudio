using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float lifespan = 5f;

    void Start()
    {
        // Destroy the projectile after the lifespan
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Get the Health component of the player
            Health enemyHealth = other.gameObject.GetComponent<Health>();

            // Check if the player has a Health component
            if (enemyHealth != null)
            {
                // Reduce the player's HP by the damage amount of the projectile
                enemyHealth.TakeDamage((int)Player.Instance.playerDamage);
            }

            // Destroy the projectile if it collides with an object tagged "Enemy"
            Destroy(gameObject);
        }
    }

}
