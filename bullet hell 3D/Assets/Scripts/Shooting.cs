using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    private float cooldownCounter;
    public float cooldown;
    void Update()
    {
        cooldownCounter += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && cooldownCounter > cooldown)
        {
            GameObject prefabBullet = Instantiate(bullet, transform.position, transform.rotation);
            cooldownCounter = 0;

        }
    }
}
