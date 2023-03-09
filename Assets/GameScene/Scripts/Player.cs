using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance;
    public GameObject projectilePrefab;

    public float playerDamage = 10f;
    public float playerMoveSpeed = 5f;
    public float projectileSpeed = 10f;
    public float shootingCooldown = 0.2f;

    private float lastShootTime;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShooting();
    }

    public void PlayerMovement()
    {
        // Get the horizontal and vertical input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player in the direction of the movement
        transform.Translate(movementDirection * playerMoveSpeed * Time.deltaTime);
    }


    public void PlayerShooting()
    {
        // Check if enough time has passed since the last shot
        if (Time.time - lastShootTime > shootingCooldown)
        {
            lastShootTime = Time.time;

            // Spawn a new projectile prefab
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Apply a forward force to the projectile in the direction of the player
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.up * projectileSpeed, ForceMode2D.Impulse);
        }
    }

}
