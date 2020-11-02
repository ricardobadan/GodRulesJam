using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject[] enemyPrefabsEasy;
    public GameObject[] enemyPrefabsMedium;
    public GameObject[] enemyPrefabsHard;

    public Transform[] spawnPoints;

    public GameObject dialogToActivate;
    public GameObject doorToActivate;
    public GameObject chunkToActivate;

    bool hasSpawned;

    
    void Start()
    {
        chunkToActivate.SetActive(false);
        dialogToActivate.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasSpawned){
            Invoke("ActivateDoor", 5f);
            if (collision.tag == "Player")
            {
                FirstWave();
            }
            hasSpawned = true;
        }
        
    }

    void ActivateDoor()
    {
        if(GameLogic.killCount == 0)
        {
            chunkToActivate.SetActive(true);
            dialogToActivate.SetActive(true);
            doorToActivate.GetComponent<DoorLogic>().canOpen = true;
        }
    }

    public void FirstWave()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemyPrefabsEasy[Random.Range(0, enemyPrefabsEasy.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    public void SecondWave()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemyPrefabsMedium[Random.Range(0, enemyPrefabsMedium.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
        }
        for (int i = 0; i < spawnPoints.Length - 3; i++)
        {
            Instantiate(enemyPrefabsMedium[Random.Range(0, enemyPrefabsMedium.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    public void ThirdWave()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemyPrefabsHard[Random.Range(0, enemyPrefabsHard.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
        }
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemyPrefabsHard[Random.Range(0, enemyPrefabsHard.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
        }

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemyPrefabsMedium[Random.Range(0, enemyPrefabsMedium.Length)], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }
}
