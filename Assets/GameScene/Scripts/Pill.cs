using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pill : MonoBehaviour
{

    public float lifespan = 15f;
    public float pillvalue;

    void Start()
    {
        // Destroy the projectile after the lifespan
        Destroy(gameObject, lifespan);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelPillController.Instance.LevelPillTake((int)pillvalue);
        }
    }

}
