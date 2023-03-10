using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance;
    public GameObject projectilePrefab;


    [Header("Changing Variable")]
    public float playerDamage = 10f;
    public float playerShootingTimes = 2f;
    public float playerShootingSize = 0.2f;



    [Header("Fixed Variables")]
    public float shootingCooldown = 0.2f;
    public float playerMoveSpeed = 5f;
    public float projectileSpeed = 10f;
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

            for (int i = 0; i < playerShootingTimes; i++)
            {
                if (playerShootingTimes == 1)
                {
                    // Spawn a new projectile prefab
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

                    // Apply a forward force to the projectile in the direction of the player
                    projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.up * projectileSpeed, ForceMode2D.Impulse);

                    // Set the scale of the projectile
                    projectile.transform.localScale = new Vector3(playerShootingSize, playerShootingSize, 1f);
                }

                else if (playerShootingTimes % 2 == 0)
                {
                    for (int j = 0; j < (playerShootingTimes / 2); j++)
                    {
                        float plusAdjust = (float)j + (playerShootingSize / 2);
                        Vector3 newPosition = new Vector3(transform.position.x + plusAdjust, transform.position.y, transform.position.z);
                        // Spawn a new projectile prefab at the position with x value increased
                        GameObject projectile = Instantiate(projectilePrefab, newPosition, transform.rotation);

                        // Apply a forward force to the projectile in the direction of the player
                        projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.up * projectileSpeed, ForceMode2D.Impulse);

                        // Set the scale of the projectile
                        projectile.transform.localScale = new Vector3(playerShootingSize, playerShootingSize, 1f);
                    }

                    for (int k = 0; k < (playerShootingTimes / 2); k++)
                    {
                        float minusAdjust = (float)k + (playerShootingSize / 2);
                        Vector3 newPosition = new Vector3(transform.position.x - minusAdjust, transform.position.y, transform.position.z);
                        // Spawn a new projectile prefab at the position with x value increased
                        GameObject projectile = Instantiate(projectilePrefab, newPosition, transform.rotation);

                        // Apply a forward force to the projectile in the direction of the player
                        projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.up * projectileSpeed, ForceMode2D.Impulse);

                        // Set the scale of the projectile
                        projectile.transform.localScale = new Vector3(playerShootingSize, playerShootingSize, 1f);
                    }
                }

                else if (playerShootingTimes % 2 >= 1)
                {
                    // Spawn a new projectile prefab
                    GameObject projectile1 = Instantiate(projectilePrefab, transform.position, transform.rotation);

                    // Apply a forward force to the projectile in the direction of the player
                    projectile1.GetComponent<Rigidbody2D>().AddForce(Vector3.up * projectileSpeed, ForceMode2D.Impulse);

                    // Set the scale of the projectile
                    projectile1.transform.localScale = new Vector3(playerShootingSize, playerShootingSize, 1f);

                    for (int j = 0; j < ((playerShootingTimes - 1) / 2); j++)
                    {
                        float plusAdjust = (float)j * playerShootingSize + playerShootingSize;
                        Vector3 newPosition = new Vector3(transform.position.x + plusAdjust, transform.position.y, transform.position.z);
                        // Spawn a new projectile prefab at the position with x value increased
                        GameObject projectile = Instantiate(projectilePrefab, newPosition, transform.rotation);

                        // Apply a forward force to the projectile in the direction of the player
                        projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.up * projectileSpeed, ForceMode2D.Impulse);

                        // Set the scale of the projectile
                        projectile.transform.localScale = new Vector3(playerShootingSize, playerShootingSize, 1f);
                    }

                    for (int k = 0; k < ((playerShootingTimes - 1) / 2); k++)
                    {
                        float minusAdjust = (float)k * playerShootingSize + playerShootingSize;
                        Vector3 newPosition = new Vector3(transform.position.x - minusAdjust, transform.position.y, transform.position.z);
                        // Spawn a new projectile prefab at the position with x value increased
                        GameObject projectile = Instantiate(projectilePrefab, newPosition, transform.rotation);

                        // Apply a forward force to the projectile in the direction of the player
                        projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.up * projectileSpeed, ForceMode2D.Impulse);

                        // Set the scale of the projectile
                        projectile.transform.localScale = new Vector3(playerShootingSize, playerShootingSize, 1f);
                    }

                }

            }
        }
    }



}
