using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyArmy;
    public GameObject waveExit;
    private int amountOfEnemysAlive;

    void Update()
    {
        //check how many enemys are still alive
        for(int i = 0; i < enemyArmy.Length; i++)
        {
            if (enemyArmy[i] != null)
            {
                amountOfEnemysAlive++;
            }
        }

        //all dead
        if(amountOfEnemysAlive == 0)
        {
            waveExit.SetActive(false);
        }

        //reset
        amountOfEnemysAlive = 0;
    }
}
