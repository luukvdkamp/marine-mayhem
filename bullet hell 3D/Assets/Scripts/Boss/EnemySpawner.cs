using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnEnemy;
    private bool hasSpawnedEnemy;

    //position to spawn
    public Transform[] spawnPositions;

    //enemy that are alive
    private GameObject[] currentEnemy;
    private int enemyAliveCounter;

    //enemy types
    public GameObject dashEnemy;
    public GameObject bounceEnemy;

    //amount of waves
    public int amountOfWaves;
    private int waveCounter;

    void Update()
    {
        if(spawnEnemy && hasSpawnedEnemy == false && waveCounter <= amountOfWaves)
        {
            for(int i = 0; i < spawnPositions.Length; i++)
            {
                int randomEnemy = Random.Range(1, 3);

                if(randomEnemy == 1)
                {
                    GameObject spawnedEnemy = Instantiate(dashEnemy, spawnPositions[i].position, Quaternion.identity);
                    currentEnemy[i] = spawnedEnemy;
                }

                else
                {
                    GameObject spawnedEnemy = Instantiate(bounceEnemy, spawnPositions[i].position, Quaternion.identity);
                    currentEnemy[i] = spawnedEnemy;
                }
            }

            hasSpawnedEnemy = true;
            waveCounter++;
        }

        for (int i = 0; i < currentEnemy.Length; i++)
        {
            if (currentEnemy[i] != null)
            {
                enemyAliveCounter++;
            }
        }

        //all dead
        if (enemyAliveCounter == 0)
        {
            hasSpawnedEnemy = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (spawnEnemy == false)
            {
                spawnEnemy = true;
            }
        }
    }
}
