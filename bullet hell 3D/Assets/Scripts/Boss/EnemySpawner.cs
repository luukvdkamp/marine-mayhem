using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnEnemy;
    public bool hasSpawnedEnemy;

    //position to spawn
    public Transform[] spawnPositions;

    //enemy that are alive
    public List<GameObject> currentEnemy;

    //enemy type
    public GameObject bounceEnemy;

    //amount of waves
    public int amountOfWaves;
    public int waveCounter;

    //door to open (optional)
    public GameObject doorToOpen;

    private void Start()
    {
        currentEnemy = new List<GameObject>();
    }

    void Update()
    {
        if(spawnEnemy)
        {
            if (hasSpawnedEnemy == false && waveCounter <= amountOfWaves)
            {
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    GameObject spawnedEnemy = Instantiate(bounceEnemy, spawnPositions[i].position, Quaternion.identity);
                    currentEnemy.Add(spawnedEnemy);
                    print("spawning");
                }

                hasSpawnedEnemy = true;
                waveCounter++;
            }

            if (currentEnemy.Count == 0) //wave defeated
            {
                hasSpawnedEnemy = false;
                print("defeated");

                if (waveCounter >= amountOfWaves)
                {
                    //open door
                    if (doorToOpen != null)
                    {
                        Destroy(doorToOpen);
                    }
                }
            }

            else
            {
                //go backwards through list to remove destroyed GameObjects
                for (int i = currentEnemy.Count - 1; i >= 0; i--)
                {
                    if (currentEnemy[i] == null) //check if GameObject has been destroyed
                    {
                        currentEnemy.RemoveAt(i); //remove destroyed GameObject from the list
                    }
                }
            }
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
