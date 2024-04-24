using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    private float cooldownCounter;
    public float cooldown;
    public Transform shootPosition;
    void Update()
    {
        cooldownCounter += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && cooldownCounter > cooldown)
        {
            GameObject prefabBullet = Instantiate(bullet, shootPosition.position, transform.localRotation);
            cooldownCounter = 0;

        }
    }
}
