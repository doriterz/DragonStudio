using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelListSO", menuName = "DragonStudio/LevelListSO", order = 0)]
public class LevelListSO : ScriptableObject
{
    public LevelSO[] levelSO;
}