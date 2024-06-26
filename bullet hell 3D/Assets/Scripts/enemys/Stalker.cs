using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    private GameObject player;

    public float normalHoverSpeed;
    public float escapeHoverSpeed;

    public float distanceFromPlayerUntilEscape;

    public bool escaping;

    public GameObject bullet;
    public float shootResetTime;
    private float shootResetCounter;

    private void Start()
    {
        player = GameObject.Find("player");
    }

    void Update()
    {
        if(player != null)
        {
            if(Vector3.Distance(player.transform.position, transform.position) < distanceFromPlayerUntilEscape)
            {
                escaping = true;
            }

            else
            {
                escaping = false;
            }
        }

        else
        {
            escaping = false;
        }

        //going to player
        if(escaping == false)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * normalHoverSpeed * Time.deltaTime);
        }

        //running from player
        else
        {
            //calculate direction from the enemy to player
            Vector3 directionToPlayer = player.transform.position - transform.position;

            //calculate the opposite direction
            Vector3 oppositeDirection = -directionToPlayer.normalized;

            GetComponent<Rigidbody>().AddForce(oppositeDirection * escapeHoverSpeed * Time.deltaTime);
        }

        //shooting
        shootResetCounter += Time.deltaTime;
        if(shootResetCounter > shootResetTime)
        {
            //able to fire
            GameObject bulletPrefab = Instantiate(bullet, transform.position, transform.rotation);
            shootResetCounter = 0;
        }

        //look at player
        transform.LookAt(player.transform.position);
    }
}
