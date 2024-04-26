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
    void Update()
    {
        if(boss.playerInBossArea)
        {
            transform.LookAt(player);

            cooldownCounter += Time.deltaTime;
            if (cooldownCounter > shootCooldown)
            {
                GameObject bulletPrefab = Instantiate(bullet, spawn.position, transform.localRotation);
                cooldownCounter = 0;
            }
        }

        else
        {
            cooldownCounter = 0;
        }
    }
}
