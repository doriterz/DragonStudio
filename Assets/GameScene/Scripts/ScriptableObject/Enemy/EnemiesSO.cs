using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "EnemiesSO", menuName = "DragonStudio/EnemiesSO", order = 0)]
public class EnemiesSO : ScriptableObject
{
    public string enemyName;
    public Sprite enemySprite;
    public float enemyHP;
    public float enemyDamage;
    public float enemyAtkSpeed;

    public Sprite projectileSprite;
}