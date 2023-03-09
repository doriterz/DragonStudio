using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance;
    public int maxHP = 100;
    public int currentHP;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the current HP to the max HP at the start of the game
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the entity's current HP is zero or less
        if (currentHP <= 0)
        {
            // Destroy the entity if its current HP is zero or less
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        // Subtract the damage from the entity's current HP
        currentHP -= damage;
    }
}
