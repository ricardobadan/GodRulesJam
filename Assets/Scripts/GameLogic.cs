using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameLogic : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public GameObject[] switches = new GameObject[7];
    public bool[] activeSwitches = new bool[7];
    public GameObject[] braillePoints = new GameObject[6];
    public bool[] activeBraillePoints = new bool[6];
    public static int killCount;
    public GameObject[] levelChunks;
    public EnemyTrigger enemyTrigger;
    public GameObject killDialogOne;
    public GameObject killDialogTwo;
    public GameObject killDialogThree;
    public GameObject enemyDoor;
    bool secondWave, thirdWave;

    private void Awake()
    {
        AudioManager.instance.Play("Audio1");
        AudioManager.instance.Play("Audio2");
        AudioManager.instance.Play("Audio3");
        AudioManager.instance.Play("Audio4");
        AudioManager.instance.Play("Audio5");
        AudioManager.instance.Play("Audio6");
        AudioManager.instance.Play("Audio7");
    }
    void Start()
    {
        AudioManager.instance.DecreaseVolume("Audio2");
        AudioManager.instance.DecreaseVolume("Audio3");
        AudioManager.instance.DecreaseVolume("Audio4");
        AudioManager.instance.DecreaseVolume("Audio5");
        AudioManager.instance.DecreaseVolume("Audio6");
        AudioManager.instance.DecreaseVolume("Audio7");

        foreach (GameObject g in levelChunks)
        {
            g.SetActive(false);
        }

    }
    void Update()
    {
        for (int i = 0; i < switches.Length; i++)
        {
            activeSwitches[i] = switches[i].GetComponent<SwitchLogic>().isActive;
        }
        
        if(activeSwitches[0] && activeSwitches[1] && activeSwitches[2])
        {
            print("1, 2 e 3 Switches");
        }

        for (int i = 0; i < braillePoints.Length; i++)
        {
            activeBraillePoints[i] = braillePoints[i].GetComponent<BraillePointLogic>().isActive;
        }

        if (activeBraillePoints[0] && activeBraillePoints[1] && activeBraillePoints[2])
        {
            print("1, 2 e 3 Braille");
        }

        if(killCount > 4 && !secondWave)
        {
            secondWave = true;
            enemyTrigger.SecondWave();
            killDialogOne.SetActive(true);
        }

        if(killCount > 9 && !thirdWave)
        {
            thirdWave = true;
            enemyTrigger.ThirdWave();
            killDialogTwo.SetActive(true);
        }

       
    }


    public void ActivateChunk(GameObject chunk)
    {
        chunk.SetActive(true);
    }


}
