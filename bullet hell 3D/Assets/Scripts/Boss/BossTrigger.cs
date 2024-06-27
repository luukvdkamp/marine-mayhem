using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public Boss boss;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (boss.firstTimeEncounter == 0)
            {
                boss.healthSlider.maxValue = boss.health;
                boss.healthSlider.value = boss.healthSlider.maxValue;
                boss.bossNameText.text = boss.bossName;
            }

            boss.firstTimeEncounter++;
            boss.bossHealthCanvas.SetActive(true);
            boss.playerInBossArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss.bossHealthCanvas.SetActive(false);
            boss.playerInBossArea = false;
        }
    }
}
