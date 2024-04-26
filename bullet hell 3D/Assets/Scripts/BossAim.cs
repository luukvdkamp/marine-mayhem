using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAim : MonoBehaviour
{
    public Transform player;
    public Boss boss;

    public float shootCooldown;
    private float cooldownCounter;

    public GameObject bullet;
    public Transform spawn;

    [Header("Spray (optional)")]
    public bool spray;
    public float sprayCooldown;
    private float sprayTime;
    public int amountOfBullets;
    private int bulletCounter;
    private bool hasFired;

    private void Start()
    {

    }

    void Update()
    {
        if (boss.playerInBossArea)
        {
            transform.LookAt(player);

            //single
            if (spray == false)
            {
                cooldownCounter += Time.deltaTime;
                if (cooldownCounter > shootCooldown)
                {
                    GameObject bulletPrefab = Instantiate(bullet, spawn.position, transform.localRotation);
                    cooldownCounter = 0;

                }
            }

            //spray
            else
            {
                cooldownCounter += Time.deltaTime;
                if (cooldownCounter > shootCooldown)
                {
                    hasFired = true;
                }

                if(hasFired)
                {
                    sprayTime += Time.deltaTime;
                    if(sprayTime > sprayCooldown)
                    {
                        GameObject bulletPrefab = Instantiate(bullet, spawn.position, transform.localRotation);
                        sprayTime = 0;
                        bulletCounter++;
                    }

                    if(bulletCounter >= amountOfBullets)
                    {
                        sprayTime = 0;
                        hasFired = false;
                        cooldownCounter = 0;
                        bulletCounter = 0;
                    }
                }
            }
        }

        else
        {
            cooldownCounter = 0;
        }
    }
}
