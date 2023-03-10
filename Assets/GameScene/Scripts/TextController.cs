using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextController : MonoBehaviour
{
    [Header("Texts")]
    public TMP_Text levelText;
    public TMP_Text levelEnemyCountText;
    public TMP_Text enemySpawnCountText;
    public TMP_Text enemyDamageText;
    public TMP_Text enemySpeedText;
    public TMP_Text EnemyHPText;
    public TMP_Text playerAtkSizeText;
    public TMP_Text playerAtkTimesText;
    public TMP_Text playerAtkDamageText;

    private void Update()
    {
        levelText.text = "Level : " + (EnemySpawner.Instance.currentLevel + 1);
        levelEnemyCountText.text = "LevelEnemyCount : " + EnemySpawner.Instance.levelListSO.levelSO[(int)EnemySpawner.Instance.currentLevel].monsterCount;
        enemySpawnCountText.text = "enemySpawnCount : " + EnemySpawner.Instance.enemySpawnCount;
        enemyDamageText.text = "EnemyDamage : " + EnemySpawner.Instance.enemyDamageTest;
        enemySpeedText.text = "EnemyAtkSpeed : " + EnemySpawner.Instance.atkSpeedTest;
        EnemyHPText.text = "EnemyHP : " + EnemySpawner.Instance.enemyHPTest;

        playerAtkSizeText.text = "Player Atk Size : " + Player.Instance.playerShootingSize;
        playerAtkTimesText.text = "Player Atk Times : " + Player.Instance.playerShootingTimes;
        playerAtkDamageText.text = "Player Atk Damage : " + Player.Instance.playerDamage;
    }
}
