using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenGiver : MonoBehaviour
{
    public float spawnTime;
    private float spawnCounter;
    public float minSpawnOffset;
    public float maxSpawnOffset;
    public int amountOfOxygen;
    public GameObject bubblePrefab;
    public Oxygen oxygenCode;
    void Update()
    {
        spawnCounter += Time.deltaTime;
        if ((spawnCounter > spawnTime))
        {
            spawnCounter = 0;

            Vector3 randomOffset = new Vector3(Random.Range(minSpawnOffset, maxSpawnOffset), 0, Random.Range(minSpawnOffset, maxSpawnOffset));
            GameObject bubble = Instantiate(bubblePrefab, transform.position + randomOffset, Quaternion.identity);
            bubble.GetComponent<OxygenBubble>().oxygen = oxygenCode;
            bubble.GetComponent<OxygenBubble>().amountOfOxygen = amountOfOxygen;
        }
    }
}
