using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemiesListSO", menuName = "DragonStudio/EnemiesListSO", order = 0)]
public class EnemiesListSO : ScriptableObject
{
    public EnemiesSO[] enemiesSO;
}