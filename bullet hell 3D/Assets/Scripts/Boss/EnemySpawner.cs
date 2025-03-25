using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public bool spawnEnemy;
    public bool hasSpawnedEnemy;

    //position to spawn
    public Transform[] spawnPositions;

    //enemy that are alive
    public List<GameObject> currentEnemy;

    //enemy type
    public GameObject enemyType;

    //amount of waves
    public int amountOfWaves;
    private int waveCounter = 1;

    //door to open (optional)
    public GameObject doorToOpen;

    public GameObject waveText;

    private void Start()
    {
        currentEnemy = new List<GameObject>();

        waveCounter = amountOfWaves;
    }

    void Update()
    {
        if(spawnEnemy)
        {
            if (hasSpawnedEnemy == false && waveCounter >= amountOfWaves)
            {
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    GameObject spawnedEnemy = Instantiate(enemyType, spawnPositions[i].position, Quaternion.identity);
                    currentEnemy.Add(spawnedEnemy);
                    print("spawning");
                }

                hasSpawnedEnemy = true;

            }

            if (currentEnemy.Count == 0) //wave defeated
            {
                waveCounter--;
                hasSpawnedEnemy = false;
                print("defeated");
                waveText.GetComponent<TextMeshProUGUI>().text = waveCounter.ToString();

                if (waveCounter <= amountOfWaves)
                {
                    //open door
                    if (doorToOpen != null)
                    {
                        Destroy(doorToOpen);
                        Destroy(gameObject);
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

            waveText.SetActive(true);
            waveText.GetComponent<TextMeshProUGUI>().text = waveCounter.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            waveText.SetActive(false);
        }
    }

}
