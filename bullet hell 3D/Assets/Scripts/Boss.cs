using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public bool isHit; //when hit
    public bool playerInBossArea; //check if player is in boss area

    public GameObject door;

    public GameObject bossHealthCanvas;
    public Slider healthSlider;

    //dont edit (bullet changes this value)
    public int bulletDamage;

    void Update()
    {
        //when hit
        if(isHit && playerInBossArea)
        {
            healthSlider.value -= bulletDamage;
            isHit = false;
        }

        //dead
        if(healthSlider.value == 0)
        {
            door.GetComponent<AudioSource>().Play();
            door.GetComponent<Door>().opening = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bossHealthCanvas.SetActive(true);
            playerInBossArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bossHealthCanvas.SetActive(false);
            playerInBossArea = false;
        }
    }
}

