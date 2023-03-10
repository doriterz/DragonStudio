using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPillController : MonoBehaviour
{

    public static LevelPillController Instance;

    public GameObject levelPillPrefab;
    public List<Transform> SpawnPositions;

    private void Awake()
    {
        Instance = this;
    }


    public void LevelPillSpawn()
    {

        for (int i = 0; i < SpawnPositions.Count; i++)
        {
            GameObject levelPill = Instantiate(levelPillPrefab, SpawnPositions[i].transform.position, transform.rotation);
            levelPill.transform.parent = SpawnPositions[i];
            if (i == 0)
            {
                levelPill.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (i == 1)
            {
                levelPill.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            if (i == 2)
            {
                levelPill.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            Pill levelPillscript = levelPill.GetComponent<Pill>();
            levelPillscript.pillvalue = i;
        }

    }



    public void LevelPillTake(int index)
    {

        //red pill = 0 , yellow pill = 1, blue pill 2
        if (index == 0)
        {
            Player.Instance.playerShootingSize += 0.1f;
        }
        if (index == 1)
        {
            Player.Instance.playerShootingTimes++;
        }
        if (index == 2)
        {
            Player.Instance.playerDamage += 3f;
        }

        GameObject[] pills = GameObject.FindGameObjectsWithTag("PowerUp");

        foreach (GameObject pill in pills)
        {
            Destroy(pill);
        }


    }
}
