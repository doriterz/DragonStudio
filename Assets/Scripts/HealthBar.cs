using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        // Set the max value of the slider to the entity's max HP
        slider.maxValue = health.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the value of the slider to the entity's current HP
        slider.value = health.currentHP;
    }
}
